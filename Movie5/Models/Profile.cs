using System.ComponentModel.DataAnnotations;

namespace Movie5.Models
{
    public class Profile
    {

        [Key]
        public int UserId { get; set; }
        public MovieUser User { get; set; }
        [Required]
        public string IRN { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public String FullName
        {
            get => FirstName + " " + LastName;
        }
        public Gender Gender { get; set; }


    }
    public enum Gender
    {
        Male, Female, Order
    }
}
