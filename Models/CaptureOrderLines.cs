using System.ComponentModel.DataAnnotations;

namespace cashcrusaderspos.Models
{
    public class CaptureOrderLinesModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Product is required")]
        public string? Product { get; set; }

        [Required(ErrorMessage = "Quantity is required")]
        public string? Quantity { get; set; }
    }
}
