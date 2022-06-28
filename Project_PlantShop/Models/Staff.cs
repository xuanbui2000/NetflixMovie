using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_PlantShop.Models
{
    public enum Role
    {
        planter, caretaker, seller, manager
    }
    public class Staff
    {
        public int Id { get; set; }
        [Required]
        [Column("FirstName")]
        [Display(Name = "First Name")]
        [StringLength(50)]
        public string FirstMidName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        [StringLength(50)]
        public string LastName { get; set; }
        [Display(Name = "Full Name")]
        public string FullName
        {
            get { return LastName + " " + FirstMidName; }
        }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Day of birth")]
        public DateTime Dob { get; set; }
        public Role? Role { get; set; }
        public string imageTitle { get; set; }
        public string decription { get; set; }
        [RegularExpression(@"((^(\+84|84|0|0084){1})(3|5|7|8|9))+([0-9]{8})$",
                    ErrorMessage = "Entered phone format is not valid.")]
        public string Phone { get; set; }
    }
}
