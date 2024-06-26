using System.ComponentModel.DataAnnotations;

namespace OpenTelemetryWebApplication.Dtos.Inventory
{
    public class InventoryAddDto
    {
        [Required(ErrorMessage = "The field {0} is required")]
        public int BookId { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        public int Amount { get; set; }
    }
}