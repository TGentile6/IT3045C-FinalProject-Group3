using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class FavoritesRequest
    {
        [Key]
        public string FirstName { get; set; }
        public string FavFood { get; set; }
        public string FavFruit { get; set; }
        public string FavColor { get; set; }
        public string FavIceCream { get; set; }
    }
}

