using System.ComponentModel.DataAnnotations;

namespace cashcrusaderspos.Models
{
    public class CaptureOrdersModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Date is required")]
        public string? Date { get; set; } 

        [Required(ErrorMessage = "Total is required")]
        public string? Total { get; set; } 

        [Required(ErrorMessage = "Lines is required")]
        public string? Lines { get; set; } 
    }
}
