using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class MusicRequest
    {
        [Key]
        public string FirstName { get; set; }
        public string FavGenre { get; set; }
        public int Num_Concerts_Attended { get; set; }
        public string Last_Concert { get; set; }
        public string Music_Platform { get; set; }
    }
}
