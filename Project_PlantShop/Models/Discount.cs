namespace Project_PlantShop.Models
{
    public class Discount
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
        public ICollection<Plant>Plants { get; set; }
    }
}
