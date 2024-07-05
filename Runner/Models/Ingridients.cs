namespace Runner.Models
{
    public class Ingridients
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<DiskIngridients>? DiskIngridients { get; set; }
    }
}
