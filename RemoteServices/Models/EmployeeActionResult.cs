using System;

namespace RemoteServices.Models
{
    [Serializable]
    public class EmployeeActionResult : ActionResult
    {
        public Employee Employee { get; set; }
    }
}