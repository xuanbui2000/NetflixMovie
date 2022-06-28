using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlantsShop.Models
{
    public class Acount
    {

        [ForeignKey("User")]
        public int Id { get; set; }
        [Required]
        [StringLength(10)]
        public string Name { get; set; }
        [Required]
        [DataType("DataType.Password")]
        public string Password { get; set; }
        public User Users { get; set; }
    }
}
