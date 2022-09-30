using RemoteServer.Extensions;
using RemoteServer.Services;
using System;
using System.Data.SqlClient;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Threading.Tasks;
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

        private async void SaveConnectionStringBtn_Click(object sender, EventArgs e)
        {
            var connectionString = ConnectionStringTxt.Text.Trim();
            try
            {
                await Task.Run(() =>
                {
                    var connection = new SqlConnection(connectionString);
                    connection.Open();
                    connection.Close();
                });
            }
            catch (Exception exception)
            {
                AppendToLog("Connection string is not updated dut the following error: " +
                            exception.Message);
                return;
            }

            Properties.Settings.Default.UpdateConnectionString(connectionString);
            SaveConnectionStringBtn.Disable();
            AppendToLog("Connection string updated successfully.");
        }

        private async void RunStopServerBtn_Click(object sender, EventArgs e)
        {
            if (_isServerRunning)
                await StopServerAndUpdateUIAsync();
            else
                await RunServerAndUpdateUIAsync();
        }

        // ReSharper disable once InconsistentNaming
        private async Task RunServerAndUpdateUIAsync()
        {
            await RunServerAsync();
            UrlTxt.Text = $"Sql service url is tcp://localhost:{PortNumber}/SqlService for local host." +
                          NewLine +
                          "If you have public IP replace 'localhost' with it." +
                          NewLine +
                          $"If you have domain replace 'localhost:{PortNumber}' with it.";
            UrlTxt.Show();
            AppendToLog($"Server started at {DateTime.Now:dd-MM-yyyy hh:mm tt}");
            RunStopServerBtn.Text = "Stop server";
        }

        private async Task RunServerAsync()
        {
            await Task.Run(() =>
            {
                _sqlService = new SqlService();
                RemotingServices.Marshal(_sqlService, "SqlService");
                _tcpServerChannel = new TcpServerChannel(PortNumber);
                ChannelServices.RegisterChannel(_tcpServerChannel, false);
            });

            _isServerRunning = true;
        }

        // ReSharper disable once InconsistentNaming
        private async Task StopServerAndUpdateUIAsync()
        {
            await StopServerAsync();
            RunStopServerBtn.Text = "Run server";
            AppendToLog($"Server stopped at {DateTime.Now:dd-MM-yyyy hh:mm tt}");
            AppendToLog("-----------------------");
            UrlTxt.Hide();
        }

        private async Task StopServerAsync()
        {
            await Task.Run(() =>
            {
                _tcpServerChannel.StopListening(null);
                ChannelServices.UnregisterChannel(_tcpServerChannel);
                RemotingServices.Disconnect(_sqlService);
            });
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

        private async void SavePortBtn_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.UpdatePortNumber(int.Parse(PortTxt.Text));
            SavePortBtn.Disable();
            AppendToLog("Port number updated successfully.");
            if (!_isServerRunning)
                return;

            await StopServerAndUpdateUIAsync();
            await RunServerAndUpdateUIAsync();
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
