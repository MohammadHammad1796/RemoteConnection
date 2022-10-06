using RemoteServices.Models;
using RemoteServices.Services;
using System;
using System.Data;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Threading.Tasks;
using System.Windows.Forms;
using static RemoteClient.Messages;

namespace RemoteClient
{
    public partial class EmployeesManagementForm : Form
    {
        private TcpChannel _channel;
        private IEmployeesManagementService _service;
        private Employee _employeeToUpdate;
        private static string ServiceUrl => Properties.Settings.Default.EmployeesServiceUrl;
        private DataTable _employeesDataTable;

        public EmployeesManagementForm()
        {
            InitializeComponent();
        }

        private async void EmployeesManagementForm_Load(object sender, EventArgs e)
        {
            _employeesDataTable = new DataTable();
            _employeesDataTable.Columns.AddRange(new[]{
                new DataColumn("Id"),
                new DataColumn("First name"),
                new DataColumn("Last name"),
                new DataColumn("Age")
            });
            EmployeesGridView.DataSource = _employeesDataTable;

            UrlTxt.Text = ServiceUrl;
            _channel = new TcpChannel();
            ChannelServices.RegisterChannel(_channel, false);
            if (!string.IsNullOrWhiteSpace(ServiceUrl))
            {
                await ConfigureRemoteServiceAsync();
                return;
            }

            GetAllButton.Enabled = false;
            AddButton.Enabled = false;
        }

        private void EmployeesManagementForm_Resize(object sender, EventArgs e)
        {
            ActionsGroupBox.Width = Width - 260;
            FirstNameTextBox.Width = ActionsGroupBox.Width - 94;
            LastNameTextBox.Width = ActionsGroupBox.Width - 94;
            AgeTextBox.Width = ActionsGroupBox.Width - 94;
            groupBox2.Width = Width - 40;
            UrlTxt.Width = groupBox2.Width - 94;
            EmployeesGridView.Width = Width - 40;
            EmployeesGridView.Height = Height - 300;
        }

        private void UrlTxt_TextChanged(object sender, EventArgs e)
        {
            var url = UrlTxt.Text.Trim();
            SaveUrlBtn.Enabled = !string.IsNullOrWhiteSpace(url) && !url.Equals(ServiceUrl);
        }

        private async void SaveUrlBtn_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.EmployeesServiceUrl = UrlTxt.Text.Trim();
            Properties.Settings.Default.Save();
            await ConfigureRemoteServiceAsync();
            SaveUrlBtn.Enabled = false;
            GetAllButton.Enabled = true;
            AddButton.Enabled = true;
            MessageBox.Show(UrlUpdated, "Success");
        }

        private async Task ConfigureRemoteServiceAsync()
        {
            await Task.Run(() =>
            {
                try
                {
                    _service = (IEmployeesManagementService)Activator
                        .GetObject(typeof(IEmployeesManagementService), ServiceUrl);
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            });
        }

        private void IdTextBox_TextChanged(object sender, EventArgs e)
        {
            int.TryParse(IdTextBox.Text, out var id);
            const int minimumId = 0;
            if (id > minimumId)
            {
                IdErrorProvider.Clear();
                GetByIdButton.Enabled = true;
                return;
            }

            IdErrorProvider.SetError(IdTextBox,
                $"The id should be integer and greater than {minimumId}");
            GetByIdButton.Enabled = false;
            _employeeToUpdate = null;
        }

        private async void GetByIdButton_Click(object sender, EventArgs e)
        {
            await DisplayLoaderUntilFunctionDone(async () =>
            {
                var result = await CallRemoteFunctionAndHandelExceptionsAsync(() =>
                    _service.GetById(int.Parse(IdTextBox.Text)));
                if (!result.IsSucceeded)
                {
                    MessageBox.Show(result.Message, "Fail");
                    return;
                }

                _employeeToUpdate = result.Employee;
                FirstNameTextBox.Text = _employeeToUpdate.FirstName;
                LastNameTextBox.Text = _employeeToUpdate.LastName;
                AgeTextBox.Text = _employeeToUpdate.Age.ToString();
                UpdateButton.Enabled = true;
            });
        }

        private async Task DisplayLoaderUntilFunctionDone(Func<Task> action)
        {
            LoaderPictureBox.Visible = true;
            Text += "                     Please wait............";
            await action();
            LoaderPictureBox.Visible = false;
            Text = "Employees Management";
        }

        private static async Task<TActionResult> CallRemoteFunctionAndHandelExceptionsAsync<TActionResult>
            (Func<TActionResult> action) where TActionResult : ActionResult, new()
        {
            var result = new TActionResult();
            try
            {
                result = await Task.Run(action);
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

        private bool ValidateFirstName()
        {
            var firstName = FirstNameTextBox.Text.Trim();
            const int minimumFirstNameLength = 3;
            var conditions = firstName.Length >= minimumFirstNameLength;
            if (conditions)
                FirstNameErrorProvider.Clear();
            else
                FirstNameErrorProvider.SetError(FirstNameTextBox,
                    $"The first name should be at least {minimumFirstNameLength} characters");
            return conditions;
        }

        private void FirstNameTextBox_TextChanged(object sender, EventArgs e)
        {
            ValidateFirstName();
        }

        private bool ValidateLastName()
        {
            var lastName = LastNameTextBox.Text.Trim();
            const int minimumLastNameLength = 3;
            var conditions = lastName.Length >= minimumLastNameLength;
            if (conditions)
                LastNameErrorProvider.Clear();
            else
                LastNameErrorProvider.SetError(LastNameTextBox,
                    $"The first name should be at least {minimumLastNameLength} characters");
            return conditions;
        }

        private void LastNameTextBox_TextChanged(object sender, EventArgs e)
        {
            ValidateLastName();
        }

        private bool ValidateAge()
        {
            int.TryParse(AgeTextBox.Text, out var age);
            const int minimumAge = 18;
            const int maximumAge = 65;
            var conditions = age >= minimumAge && age <= maximumAge;
            if (conditions)
                AgeErrorProvider.Clear();
            else
                AgeErrorProvider.SetError(AgeTextBox,
                    $"The age should be integer and between {minimumAge} and {maximumAge}");
            return conditions;
        }

        private void AgeTextBox_TextChanged(object sender, EventArgs e)
        {
            ValidateAge();
        }

        private async void GetAllButton_Click(object sender, EventArgs e)
        {
            await DisplayLoaderUntilFunctionDone(async () =>
            {
                var result = await CallRemoteFunctionAndHandelExceptionsAsync(() => _service.GetAll());
                if (!result.IsSucceeded)
                {
                    MessageBox.Show(result.Message, "Fail");
                    return;
                }

                if (result.EmployeesTable.Rows.Count == 0)
                    MessageBox.Show("No rows found", "Warning");
                else
                {
                    _employeesDataTable = result.EmployeesTable;
                    EmployeesGridView.DataSource = result.EmployeesTable;
                    EmployeesGridView.Visible = true;
                }
            });
        }

        private bool ValidateAddEmployeeData()
        {
            return ValidateFirstName() && ValidateLastName() && ValidateAge();
        }

        private void ClearInputsAndErrors()
        {
            IdTextBox.Clear();
            FirstNameTextBox.Clear();
            LastNameTextBox.Clear();
            AgeTextBox.Clear();
            IdErrorProvider.Clear();
            FirstNameErrorProvider.Clear();
            LastNameErrorProvider.Clear();
            AgeErrorProvider.Clear();
        }

        private async void AddButton_Click(object sender, EventArgs e)
        {
            await DisplayLoaderUntilFunctionDone(async () =>
            {
                UpdateButton.Enabled = false;
                _employeeToUpdate = null;
                if (!ValidateAddEmployeeData())
                    return;

                var insertEmployee = new InsertEmployee
                {
                    FirstName = FirstNameTextBox.Text.Trim(),
                    LastName = LastNameTextBox.Text.Trim(),
                    Age = int.Parse(AgeTextBox.Text)
                };
                var result = await CallRemoteFunctionAndHandelExceptionsAsync(() =>
                        _service.Add(insertEmployee));
                if (!result.IsSucceeded)
                {
                    MessageBox.Show(result.Message, "Fail");
                    return;
                }

                MessageBox.Show("Employee added.", "Success");

                // ReSharper disable once PossibleNullReferenceException
                _employeesDataTable.Rows.Add(result.Id, insertEmployee.FirstName,
                    insertEmployee.LastName, insertEmployee.Age);
                EmployeesGridView.Visible = true;
                ClearInputsAndErrors();
            });
        }

        private async void UpdateButton_Click(object sender, EventArgs e)
        {
            await DisplayLoaderUntilFunctionDone(async () =>
            {
                _employeeToUpdate.FirstName = FirstNameTextBox.Text;
                _employeeToUpdate.LastName = LastNameTextBox.Text;
                _employeeToUpdate.Age = int.Parse(AgeTextBox.Text);

                var result = await CallRemoteFunctionAndHandelExceptionsAsync(() =>
                    _service.Update(_employeeToUpdate));
                if (!result.IsSucceeded)
                {
                    MessageBox.Show(result.Message, "Fail");
                    return;
                }

                MessageBox.Show("Employee updated.", "Success");

                var row = EmployeesGridView.Rows.Cast<DataGridViewRow>()
                    .FirstOrDefault(r => int.Parse(r.Cells[0].Value.ToString()) == _employeeToUpdate.Id);
                if (row != null)
                {
                    EmployeesGridView.Rows[row.Index].Cells[1].Value = _employeeToUpdate.FirstName;
                    EmployeesGridView.Rows[row.Index].Cells[2].Value = _employeeToUpdate.LastName;
                    EmployeesGridView.Rows[row.Index].Cells[3].Value = _employeeToUpdate.Age;
                }
                else
                    // ReSharper disable once PossibleNullReferenceException
                    _employeesDataTable.Rows.Add(_employeeToUpdate.Id, _employeeToUpdate.FirstName,
                        _employeeToUpdate.LastName, _employeeToUpdate.Age);

                _employeeToUpdate = null;
                EmployeesGridView.Visible = true;
                ClearInputsAndErrors();
            });
        }

        private async void EmployeesGridView_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            var dialog = MessageBox.Show("Are you sure to delete this employee?",
                "Please confirm", MessageBoxButtons.YesNo);
            if (dialog != DialogResult.Yes)
            {
                e.Cancel = true;
                return;
            }

            await DisplayLoaderUntilFunctionDone(async () =>
            {
                var employeeId = int.Parse(e.Row.Cells[0].Value.ToString());

                var result = await CallRemoteFunctionAndHandelExceptionsAsync(() =>
                    _service.Delete(employeeId));
                if (!result.IsSucceeded)
                {
                    MessageBox.Show(result.Message, "Fail");
                    e.Cancel = true;
                    return;
                }

                MessageBox.Show("Employee Deleted.", "Success");
            });
        }
    }
}