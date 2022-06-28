using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movie5.Models
{
    public class MovieGenre
    {
        
        [ForeignKey("Genre")]
        public int GenreID { get; set; }
        [ForeignKey("Movie")]
        public int MovieID { get; set; }
        public Movie Movies { get; set; }
        public Genre Genres { get; set; }
    }
}
