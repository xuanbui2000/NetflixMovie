using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlantsShop.Models
{
    public class Order
    {
        public int Id { get; set; }
       [ForeignKey("Product")]
        public int ProductId { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BuyDate { get; set; }
        public decimal Payment { get; set; }
        public int Quantity { get; set; }
        public User Users { get; set; }
        public Product Products { get; set; }

    }
}
