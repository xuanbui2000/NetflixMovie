using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Movie6.Models
{
    public class MovieUser : IdentityUser<int>
    {
        public Profile profile { get; set; }
    }
   
}
