using System;
using System.Data;

namespace RemoteServices.Models
{
    [Serializable]
    public class SqlResult
    {
        public bool IsSucceeded { get; set; }

        public string Message { get; set; }

        public DataTable Table { get; set; }

        public SqlResult()
        {
            IsSucceeded = false;
            Message = string.Empty;
        }
    }
}