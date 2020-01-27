using System;
using System.ComponentModel.DataAnnotations;


namespace RevoltSampleWebApp.Models
{
    public class Activity
    {
        public string ActivityId { get; set; }
        public DateTime Timestamp { get; set; }
        public string ApplicationUserID { get; set; }
    }
}
