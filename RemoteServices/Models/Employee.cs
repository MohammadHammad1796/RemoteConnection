using System;

namespace RemoteServices.Models
{
    [Serializable]
    public class Employee : InsertEmployee
    {
        public int Id { get; set; }
    }
}
