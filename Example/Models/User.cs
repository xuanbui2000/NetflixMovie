using System.ComponentModel.DataAnnotations;

namespace PlantsShop.Models
{
    public class User
    {
        public Profile profile { get; set; }

    }
    public class Profile
    {
        [Key]
        public int Userid { get; set; }
        [Required]
        [MaxLength(50)]
        public User user { get; set; }
        [Required]
        public string IRN { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public String FullName
        {
            get => FirstName + " " + LastName;
        }
       
    }
}
