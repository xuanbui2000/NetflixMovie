using System.ComponentModel.DataAnnotations;

namespace Project_PlantShop.Models
{
    public enum RoleCompanies
    {
        Plot,Plant
    }
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public RoleCompanies Role { get; set; }
        public ICollection<Plant> Plants { get; set; }
    }
}
