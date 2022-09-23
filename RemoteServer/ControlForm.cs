using RemoteServer.Extensions;
using RemoteServer.Services;
using System;
using System.Data.SqlClient;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Windows.Forms;
using static System.Environment;

namespace RemoteServer
{
    public partial class ControlForm : Form
    {
        private static string ConnectionString => Properties.Settings.Default.ConnectionString;
        private static int PortNumber => Properties.Settings.Default.PortNumber;
        private bool _isServerRunning;
        private TcpServerChannel _tcpServerChannel;
        private static ControlForm _instance;
        private SqlService _sqlService;

        public ControlForm()
        {
            InitializeComponent();
            _instance = this;
        }

        private void ControlForm_Load(object sender, EventArgs e)
        {
            ConnectionStringTxt.Text = ConnectionString;
            PortTxt.Text = PortNumber.ToString();
            _isServerRunning = false;
            _tcpServerChannel = null;
        }

        private void ConnectionStringTxt_TextChanged(object sender, EventArgs e)
        {
            var text = ConnectionStringTxt.Text.Trim();

            if (string.IsNullOrWhiteSpace(text) || text.Equals(ConnectionString))
                SaveConnectionStringBtn.Disable();
            else
                SaveConnectionStringBtn.Enable();
        }

        private void SaveConnectionStringBtn_Click(object sender, EventArgs e)
        {
            var connectionString = ConnectionStringTxt.Text.Trim();
            try
            {
                var connection = new SqlConnection(connectionString);
                connection.Open();
                connection.Close();
                Properties.Settings.Default.ConnectionString = connectionString;
                Properties.Settings.Default.Save();
                SaveConnectionStringBtn.Disable();
                AppendToLog("Connection string updated successfully.");
            }
            catch (Exception exception)
            {
                AppendToLog($"Connection string is not updated dut the following error: {exception.Message}");
            }
        }

        private void RunStopServerBtn_Click(object sender, EventArgs e)
        {
            if (_isServerRunning)
                StopServerAndUpdateUI();
            else
                RunServerAndUpdateUI();
        }

        // ReSharper disable once InconsistentNaming
        private void RunServerAndUpdateUI()
        {
            RunServer();
            UrlTxt.Text = $"Sql service url is tcp://localhost:{PortNumber}/SqlService for local host." +
                          NewLine +
                          "If you have public IP replace 'localhost' with it." +
                          NewLine +
                          $"If you have domain replace 'localhost:{PortNumber}' with it.";
            UrlTxt.Show();
            AppendToLog($"Server started at {DateTime.Now:dd-MM-yyyy hh:mm tt}");
            RunStopServerBtn.Text = "Stop server";
        }

        private void RunServer()
        {
            _sqlService = new SqlService();
            RemotingServices.Marshal(_sqlService, "SqlService");
            _tcpServerChannel = new TcpServerChannel(PortNumber);
            ChannelServices.RegisterChannel(_tcpServerChannel, false);
            //RemotingConfiguration.RegisterWellKnownServiceType(
            //    typeof(SqlService), "SqlService", WellKnownObjectMode.SingleCall);
            _isServerRunning = true;
        }

        // ReSharper disable once InconsistentNaming
        private void StopServerAndUpdateUI()
        {
            StopServer();
            RunStopServerBtn.Text = "Run server";
            AppendToLog($"Server stopped at {DateTime.Now:dd-MM-yyyy hh:mm tt}");
            AppendToLog("-----------------------");
            UrlTxt.Hide();
        }

        private void StopServer()
        {
            _tcpServerChannel.StopListening(null);
            ChannelServices.UnregisterChannel(_tcpServerChannel);
            RemotingServices.Disconnect(_sqlService);
            _isServerRunning = false;
        }

        public void AppendToLog(string message)
        {
            LogTxt.Text += message;
            LogTxt.Text += NewLine;
            LogTxt.SelectionStart = LogTxt.TextLength;
            LogTxt.ScrollToCaret();
        }

        internal static ControlForm GetInstance()
        {
            return _instance;
        }

        private void SavePortBtn_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.PortNumber = int.Parse(PortTxt.Text);
            Properties.Settings.Default.Save();
            SavePortBtn.Disable();
            AppendToLog("Port number updated successfully.");
            if (!_isServerRunning)
                return;

            StopServerAndUpdateUI();
            RunServerAndUpdateUI();
        }

        private void PortTxt_TextChanged(object sender, EventArgs e)
        {
            var portText = PortTxt.Text;
            int.TryParse(portText, out var portNumber);
            const int minimumPortNumber = 1024;
            const int maximumPortNumber = 49151;
            if (portNumber < minimumPortNumber || portNumber > maximumPortNumber)
            {
                portNumberError.SetError(PortTxt,
                    $"Port number should be between {minimumPortNumber} and {maximumPortNumber}");
                SavePortBtn.Disable();
            }
            else
            {
                if (portNumber.Equals(PortNumber))
                    SavePortBtn.Disable();
                else
                    SavePortBtn.Enable();

                portNumberError.Clear();
            }
        }

        private void ControlForm_Resize(object sender, EventArgs e)
        {
            ConnectionStringGroup.Width = Width - 40;
            ConnectionStringTxt.Width = ConnectionStringGroup.Width - 165;
            RemoteGroup.Width = Width - 323;
            UrlTxt.Width = RemoteGroup.Width - 147;
            LogGroup.Width = Width - 40;
            LogTxt.Width = LogGroup.Width - 21;
            LogGroup.Height = Height - 264;
            LogTxt.Height = LogGroup.Height - 25;
        }
    }
}
