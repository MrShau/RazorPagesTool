using System.ComponentModel.DataAnnotations;

namespace RazorPagesTool.Models
{
    public class Tool
    {
        public int Id { get; set; }
        
        [Display(Name = "Название инструмента")]
        public string? Title { get; set; }
        
        [Display(Name = "Цена")]
        public decimal Price { get; set; }
        
        public string? img { get; set; }

        [Display(Name = "В наличии")]
        public int Count { get; set; }
    }
}
