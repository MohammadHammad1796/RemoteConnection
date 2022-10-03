using RemoteServices.Models;
using RemoteServices.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace RemoteServer.Services
{
    internal class EmployeesManagementService : MarshalByRefObject, IEmployeesManagementService
    {
        private static string ConnectionString => Properties.Settings.Default.ConnectionString;
        private readonly ControlForm _activeControlForm;

        public EmployeesManagementService()
        {
            _activeControlForm = ControlForm.GetInstance();
        }

        public EmployeesActionResult GetAll()
        {
            var sqlConnection = new SqlConnection(ConnectionString);
            const string sql = "select * from employees";
            var result = new EmployeesActionResult();
            return ExecuteCommandAndHandleExceptions(() =>
            {
                sqlConnection.Open();
                _activeControlForm.AppendToLog($"Query: {sql}");
                var command = new SqlCommand(sql, sqlConnection);
                var sqlDataAdapter = new SqlDataAdapter(command);
                var dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet);
                result.EmployeesTable = dataSet.Tables[0];
                sqlConnection.Close();
                result.IsSucceeded = true;
            }, result, sqlConnection);
        }

        public EmployeeActionResult GetById(int id)
        {
            var sqlConnection = new SqlConnection(ConnectionString);
            const string sql = "select * from employees where id = @id";
            var result = new EmployeeActionResult();
            return ExecuteCommandAndHandleExceptions(() =>
            {
                sqlConnection.Open();
                _activeControlForm.AppendToLog(
                    $"Query: {sql.Replace("@id", id.ToString())}");
                var command = new SqlCommand(sql, sqlConnection);
                var sqlParameter = new SqlParameter("@id", SqlDbType.Int)
                {
                    Value = id
                };
                command.Parameters.Add(sqlParameter);

                var reader = command.ExecuteReader();
                if (!reader.Read())
                {
                    sqlConnection.Close();
                    result.Message = "There is no employee with this id.";
                    return;
                }

                result.Employee = new Employee
                {
                    Id = id,
                    FirstName = reader.GetString(reader.GetOrdinal("First Name")),
                    LastName = reader.GetString(reader.GetOrdinal("Last Name")),
                    Age = reader.GetInt32(reader.GetOrdinal("Age"))
                };

                sqlConnection.Close();
                result.IsSucceeded = true;
            }, result, sqlConnection);
        }

        public ActionResult Delete(int id)
        {
            var sqlConnection = new SqlConnection(ConnectionString);
            const string sql = "delete from employees where id = @id";
            var result = new ActionResult();
            return ExecuteCommandAndHandleExceptions(() =>
            {
                sqlConnection.Open();
                _activeControlForm.AppendToLog(
                    $"Command: {sql.Replace("@id", id.ToString())}");
                var command = new SqlCommand(sql, sqlConnection);
                var sqlParameter = new SqlParameter("@id", SqlDbType.Int)
                {
                    Value = id
                };
                command.Parameters.Add(sqlParameter);
                var affectedRowsCount = command.ExecuteNonQuery();
                sqlConnection.Close();
                if (affectedRowsCount == 1)
                    result.IsSucceeded = true;
                else
                    result.Message = "There is no employee with this id.";
            }, result, sqlConnection);
        }

        public InsertResult Add(InsertEmployee employee)
        {
            var sqlConnection = new SqlConnection(ConnectionString);
            const string sql = "insert into employees ([First name], [Last name], Age) OUTPUT INSERTED.ID " +
                               "values (@firstName, @lastName, @age)";
            var result = new InsertResult();
            return ExecuteCommandAndHandleExceptions(() =>
            {
                sqlConnection.Open();
                _activeControlForm.AppendToLog(
                    string.Format("Command: {0}",
                        sql.Replace("@firstName", employee.FirstName)
                            .Replace("@lastName", employee.LastName)
                            .Replace("@age", employee.Age.ToString()))
                );
                var command = new SqlCommand(sql, sqlConnection);
                var sqlParameters = new List<SqlParameter>
                {
                    new SqlParameter("@firstName", SqlDbType.NVarChar)
                    {
                        Value = employee.FirstName
                    },
                    new SqlParameter("@lastName", SqlDbType.NVarChar)
                    {
                        Value = employee.LastName
                    },
                    new SqlParameter("@age", SqlDbType.Int)
                    {
                        Value = employee.Age
                    }
                };
                command.Parameters.AddRange(sqlParameters.ToArray());
                var affectedRowsCount = command.ExecuteScalar();
                int.TryParse(affectedRowsCount.ToString(), out var id);
                if (id > 0)
                {
                    result.IsSucceeded = true;
                    result.Id = id;
                }
                sqlConnection.Close();
            }, result, sqlConnection);
        }

        public ActionResult Update(Employee employee)
        {
            var sqlConnection = new SqlConnection(ConnectionString);
            const string sql = "update employees set [First name] = @firstName, [Last name] = @lastName, " +
                               "Age = @age where Id = @id";
            var result = new ActionResult();
            return ExecuteCommandAndHandleExceptions(() =>
            {
                sqlConnection.Open();
                _activeControlForm.AppendToLog(
                    string.Format("Command: {0}",
                        sql.Replace("@id", employee.Id.ToString())
                            .Replace("@firstName", employee.FirstName)
                            .Replace("@lastName", employee.LastName)
                            .Replace("@age", employee.Age.ToString()))
                );
                var command = new SqlCommand(sql, sqlConnection);
                var sqlParameters = new List<SqlParameter>
                {
                    new SqlParameter("@id", SqlDbType.Int)
                    {
                        Value = employee.Id
                    },
                    new SqlParameter("@firstName", SqlDbType.NVarChar)
                    {
                        Value = employee.FirstName
                    },
                    new SqlParameter("@lastName", SqlDbType.NVarChar)
                    {
                        Value = employee.LastName
                    },
                    new SqlParameter("@age", SqlDbType.Int)
                    {
                        Value = employee.Age
                    }
                };
                command.Parameters.AddRange(sqlParameters.ToArray());
                var affectedRowsCount = command.ExecuteNonQuery();
                sqlConnection.Close();
                if (affectedRowsCount == 1)
                    result.IsSucceeded = true;
                else
                    result.Message = "There is no employee with this id.";
            }, result, sqlConnection);
        }

        private TActionResult ExecuteCommandAndHandleExceptions<TActionResult>(Action action,
            TActionResult result, SqlConnection connection) where TActionResult : ActionResult
        {
            try
            {
                action();
            }
            catch (SqlException exception)
            {
                result.Message = exception.Message;
                if (connection.State == ConnectionState.Open)
                    connection.Close();
                _activeControlForm.AppendToLog($"Sql Exception: {exception.Message}");
            }
            catch (Exception exception)
            {
                result.Message = "This action failed due to server Error.";
                if (connection.State == ConnectionState.Open)
                    connection.Close();
                _activeControlForm.AppendToLog($"Exception: {exception.Message}");
            }

            _activeControlForm.AppendToLog("--------------");
            return result;
        }

        public override object InitializeLifetimeService() => null;
    }
}