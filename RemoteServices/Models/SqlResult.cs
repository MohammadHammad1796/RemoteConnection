using System;
using System.Collections.Generic;

namespace RemoteServices.Models
{
    [Serializable]
    public class SqlResult
    {
        public bool IsSucceeded { get; set; }

        public ICollection<string> Columns { get; set; }

        public ICollection<ICollection<object>> Rows { get; set; }

        public string Message { get; set; }

        public SqlResult()
        {
            IsSucceeded = false;
            Message = string.Empty;
            Columns = new List<string>();
            Rows = new List<ICollection<object>>();
        }
    }
}