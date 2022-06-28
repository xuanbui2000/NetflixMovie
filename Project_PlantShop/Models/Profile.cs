using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_PlantShop.Models
{
    public class Profile
    {

        [Key]
        [ForeignKey("PlantUser")]
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
            get
            {
                return LastName + " " + FirstName;
            }
        }
        public Gender? Gender { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date Of Birth")]
        public DateTime Dob { get; set; }

        public string Address { get; set; }
        public string Nationality { get; set; }
        public string PhoneNumber { get; set; }
        public string Avatar { get; set; }
        public PlantUser PlantUser { get; set; }
    }
    public enum Gender
    {
        Male, Female, Order
    }
}
