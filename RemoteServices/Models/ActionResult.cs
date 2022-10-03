using System;

namespace RemoteServices.Models
{
    [Serializable]
    public class ActionResult
    {
        public string Message { get; set; }

        public bool IsSucceeded { get; set; }

        public ActionResult()
        {
            IsSucceeded = false;
            Message = string.Empty;
        }
    }
}