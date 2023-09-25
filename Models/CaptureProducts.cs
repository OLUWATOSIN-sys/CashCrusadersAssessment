using System.ComponentModel.DataAnnotations;

namespace cashcrusaderspos.Models
{
    public class CaptureProductsModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string? Name { get; set; } 

        [Required(ErrorMessage = "Price is required")]
        public string? Price { get; set; } 

        [Required(ErrorMessage = "Description is required")]
        public string? Description { get; set; } 
    }
}
