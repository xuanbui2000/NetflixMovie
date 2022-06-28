using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movie5.Models
{
    public enum Role
    {
        Actor, Director, Editor,Exra
    }
    public class Member
    {
        [ForeignKey("Member")]
        public int PersonId { get; set; }
        [ForeignKey("Movie")]

        public int MovieId { get; set; }
        [DisplayFormat(NullDisplayText = "No grade")]
        public Role? Role { get; set; }
        public Person Persions { get; set; }
        public Movie Movies { get; set; }
    }
}
