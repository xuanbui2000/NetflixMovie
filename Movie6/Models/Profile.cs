using System.ComponentModel.DataAnnotations;

namespace Movie6.Models
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

    }
}
