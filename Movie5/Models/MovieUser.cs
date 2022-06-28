using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Movie5.Models
{
    public class MovieUser:IdentityUser<int>
    {
        public Profile profile { get; set; }
    }
}
