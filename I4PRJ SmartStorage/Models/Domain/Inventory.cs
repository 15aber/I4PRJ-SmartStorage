using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace I4PRJ_SmartStorage.Models.Domain
{
    public class Inventory
    {
        [Key]
        [DisplayName("#")]
        public int InventoryId { get; set; }

        [Required]
        [DisplayName("Inventory")]
        public string Name { get; set; }
    }
}