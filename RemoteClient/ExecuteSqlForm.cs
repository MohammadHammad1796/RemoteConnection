using RemoteServices.Models;
using RemoteServices.Services;
using System;
using System.Net.Sockets;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Threading.Tasks;
using System.Windows.Forms;
using static RemoteClient.Messages;

namespace RemoteClient
{
    public partial class ExecuteSqlForm : Form
    {
        private TcpChannel _channel;
        private ISqlService _service;
        private static string ServiceUrl => Properties.Settings.Default.SqlServiceUrl;

        public ExecuteSqlForm()
        {
            InitializeComponent();
        }

        private async void ExecuteSqlForm_Load(object sender, EventArgs e)
        {
            UrlTxt.Text = ServiceUrl;
            _channel = new TcpChannel();
            ChannelServices.RegisterChannel(_channel, false);

            await ConfigureRemoteServiceAsync();
        }

        private void ExecuteSqlForm_Resize(object sender, EventArgs e)
        {
            groupBox1.Width = Width - 40;
            CommandTxt.Width = groupBox1.Width - 94;
            groupBox2.Width = Width - 40;
            UrlTxt.Width = groupBox2.Width - 94;
            SelectGrid.Width = Width - 40;
            SelectGrid.Height = Height - 238;
        }

        private void CommandTxt_TextChanged(object sender, EventArgs e)
        {
            ExecuteBtn.Enabled = !string.IsNullOrWhiteSpace(CommandTxt.Text);
        }

        private async void ExecuteBtn_Click(object sender, EventArgs e)
        {
            ExecuteBtn.Enabled = false;
            Text += "         Please wait............";
            var connectMessage = await ConfigureRemoteServiceAsync();
            if (!string.IsNullOrEmpty(connectMessage))
            {
                MessageBox.Show(connectMessage, "Connection failed");
                ExecuteBtn.Enabled = true;
                Text = "SQL";
                return;
            }

            var sqlText = CommandTxt.Text.Trim();
            if (sqlText.ToLower().StartsWith("select"))
            {
                var sqlResult = await ExecuteQueryAsync(sqlText);
                if (!sqlResult.IsSucceeded)
                {
                    MessageBox.Show(sqlResult.Message, "Fail");
                    SelectGrid.Columns.Clear();
                    SelectGrid.Visible = false;

                    ExecuteBtn.Enabled = true;
                    Text = "SQL";
                    return;
                }

                if (sqlResult.Table.Rows.Count > 1)
                {
                    SelectGrid.Columns.Clear();

                    SelectGrid.DataSource = sqlResult.Table;

                    SelectGrid.Visible = true;
                }
                else
                {
                    SelectGrid.Visible = false;
                    MessageBox.Show("No rows found", "Executed successfully");
                }

                ExecuteBtn.Enabled = true;
                Text = "SQL";
                return;
            }

            MessageBox.Show(await ExecuteCommandAsync(sqlText));

            SelectGrid.Visible = false;
            ExecuteBtn.Enabled = true;
            Text = "SQL";
        }

        private async Task<SqlResult> ExecuteQueryAsync(string sql)
        {
            var result = new SqlResult();
            try
            {
                await Task.Run(() =>
                {
                    result = _service.ExecuteQuery(sql);
                });
            }
            catch (SocketException)
            {
                result.Message = ServerOfflineOrUrlIncorrect;
            }
            catch (RemotingException)
            {
                result.Message = ServerOrServiceOffline;
            }
            catch (Exception exception)
            {
                result.Message = exception.Message;
            }
            return result;
        }

        private async Task<string> ExecuteCommandAsync(string sql)
        {
            var message = string.Empty;
            try
            {
                await Task.Run(() =>
                {
                    message = _service.ExecuteCommand(sql).Message;
                });
            }
            catch (SocketException)
            {
                message = ServerOfflineOrUrlIncorrect;
            }
            catch (RemotingException)
            {
                message = ServerOrServiceOffline;
            }
            catch (Exception exception)
            {
                message = exception.Message;
            }
            return message;
        }

        private void UrlTxt_TextChanged(object sender, EventArgs e)
        {
            var url = UrlTxt.Text.Trim();
            SaveUrlBtn.Enabled = !string.IsNullOrWhiteSpace(url) && !url.Equals(ServiceUrl);
        }

        private async void SaveUrlBtn_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.SqlServiceUrl = UrlTxt.Text.Trim();
            Properties.Settings.Default.Save();
            await ConfigureRemoteServiceAsync();
            SaveUrlBtn.Enabled = false;
            MessageBox.Show(UrlUpdated, "Success");
        }

        private async Task<string> ConfigureRemoteServiceAsync()
        {
            var message = string.Empty;
            await Task.Run(() =>
            {
                try
                {
                    _service = (ISqlService)Activator.GetObject(typeof(ISqlService), ServiceUrl);
                }
                catch (Exception exception)
                {
                    message = exception.Message;
                }
            });
            return message;
        }
    }
}
