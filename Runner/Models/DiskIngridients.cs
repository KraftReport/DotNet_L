namespace Runner.Models
{
    public class DiskIngridients
    {
        public int DiskId { get; set; }
        public Dish Dish { get; set; }
        public int IngridientId { get; set; }
        public Ingridients Ingridient { get; set; }
    }
}
