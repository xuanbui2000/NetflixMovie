using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlantShop.Models
{
    public enum Rate
    {
        Zero = 0, One = 1, Two = 2, Three = 3, Four = 4, Five = 5
    }
    public class Plant
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Name")]
        [StringLength(100)]
        public string Name { get; set; }
        [ForeignKey("Specie")]
        public int SpecieId { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        [ForeignKey("Company")]
        public int CompanyId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public Rate? Rating { get; set; }
        public string ImgTitle { get; set; }
        public string Description { get; set; }
        public Specie Species { get; set; }
        public Company Company { get; set; }
        public ICollection<Staff> Staffs { get; set; }
        
    }
}
