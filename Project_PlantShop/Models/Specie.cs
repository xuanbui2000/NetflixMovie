namespace Project_PlantShop.Models
{
    public class Specie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Plant> Plants { get; set; }
    }
}
