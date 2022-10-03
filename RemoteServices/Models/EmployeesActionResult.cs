using System;
using System.Data;

namespace RemoteServices.Models
{
    [Serializable]
    public class EmployeesActionResult : ActionResult
    {
        public DataTable EmployeesTable { get; set; }
    }
}