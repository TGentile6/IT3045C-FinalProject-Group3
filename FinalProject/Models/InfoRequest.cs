using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class InfoRequest
    {
        [Key]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Birthdate { get; set; }
        public string College_Program { get; set; }
        public string Program_Year { get; set; }
    }
}
