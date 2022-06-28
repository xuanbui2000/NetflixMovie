using System.ComponentModel.DataAnnotations;

namespace Project_PlantShop.Models
{
    public enum PaymentMethod
    {
        Cash, OnlineBanking
    }
    public class Order
    {
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public int OrderId { get; set; }

        [Required]
        [Display(Name = "Product Quantities")]
        public int quantity { get; set; }

        public Plant Product { get; set; }
        public Profile Profile { get; set; }
    }
}
