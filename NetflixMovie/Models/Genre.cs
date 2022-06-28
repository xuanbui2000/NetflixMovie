using System.ComponentModel.DataAnnotations;

namespace NetflixMovie.Models
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(100)]
        public string? GenreName { get; set; }
        public int Amount { get; set; }

    }
    
}
