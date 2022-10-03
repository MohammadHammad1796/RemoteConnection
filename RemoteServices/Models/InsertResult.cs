using System;

namespace RemoteServices.Models
{
    [Serializable]
    public class InsertResult : ActionResult
    {
        public int Id { get; set; }
    }
}