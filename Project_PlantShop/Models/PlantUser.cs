using Microsoft.AspNetCore.Identity;

namespace Project_PlantShop.Models
{
    public class PlantUser :IdentityUser<int>
    {
        public Profile Profile { get; set; }
    }
}
