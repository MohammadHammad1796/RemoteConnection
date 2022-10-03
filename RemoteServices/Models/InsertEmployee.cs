using System;

namespace RemoteServices.Models
{
    [Serializable]
    public class InsertEmployee
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }
    }
}