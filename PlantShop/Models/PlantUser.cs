using Microsoft.AspNetCore.Identity;

namespace PlantShop.Models
{
    public class PlantUser:IdentityUser<int>
    {
        public Profile Profile { get; set; }
    }
}
