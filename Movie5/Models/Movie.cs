using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movie5.Models
{
    public enum Rating { Zero = 0, One = 1, Two = 2, Three = 3, Four = 4, Five = 5 }
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Name")]
        [StringLength(100)]
        public string Title { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ReleaseDate { get; set; }
        [ForeignKey("Company")]
        public string ProducerId { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
        public string imageTitle { get; set; }
        public Company Producer { get; set; }
        public Rating Rating { get; set; }
        [Required]
        public string MovieLink { get; set; }
        public ICollection<Member> Members { get; set; }
        public ICollection<Genre> Genres{ get; set; }

    }
}
