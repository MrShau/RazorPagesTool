namespace RazorPagesTool.Models
{
    public class Basket
    {
        public int Id { get; set; }
        public List<Tool> Tools { get; set; } = new List<Tool>();
    }
}
