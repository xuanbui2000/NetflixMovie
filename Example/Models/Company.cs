using System.ComponentModel.DataAnnotations;

namespace PlantsShop.Models
{
    public class Company
    {

        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public ICollection<Product>  plants { get; set; }
    }
}
