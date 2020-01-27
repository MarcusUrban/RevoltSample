using System.ComponentModel.DataAnnotations;


namespace RevoltSampleWebApp.Models
{
    public class Activity
    {
        public string ActivityId { get; set; }
        public DataType Timestamp { get; set; }
        public string ApplicationUserID { get; set; }
    }
}
