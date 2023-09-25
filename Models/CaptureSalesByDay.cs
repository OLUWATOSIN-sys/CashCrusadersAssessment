using System.ComponentModel.DataAnnotations;

namespace cashcrusaderspos.Models
{
    public class CaptureSalesByDayModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Orders is required")]
        public string? Orders { get; set; } 

        [Required(ErrorMessage = "Date is required")]
        public string? Date { get; set; } 

    }
}
