using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class HistoryRequest
    {
        [Key]
        public string FirstName { get; set; }
        public string Hometown { get; set; }
        public string State { get; set; }
        public string HS { get; set; }
        public int HSGradYear { get; set; }
    }
}
