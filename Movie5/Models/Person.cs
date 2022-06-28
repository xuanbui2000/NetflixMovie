using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movie5.Models
{
    public class Person
    {
        [Key]
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
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Day of birth")]
        public DateTime Dob { get; set; }
        [Display(Name = "Full Name")]
        public string FullName
        {
            get { return LastName + " " + FirstMidName; }
        }
        public ICollection<Member>Members { get; set; }
    }
}
