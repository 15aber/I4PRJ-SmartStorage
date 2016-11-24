using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace I4PRJ_SmartStorage.Models.Domain
{
    public class Supplier
    {
        [Key]
        [DisplayName("#")]
        public int SupplierId { get; set; }

        [Required]
        [DisplayName("Supplier")]
        public string Name { get; set; }
    }
}