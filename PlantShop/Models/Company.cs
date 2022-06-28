using System.ComponentModel.DataAnnotations;

namespace PlantShop.Models
{
  
    public class Company
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public ICollection<Plant>  Plants { get; set; }
    }
}
