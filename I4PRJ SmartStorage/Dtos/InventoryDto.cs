using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace I4PRJ_SmartStorage.Dtos
{
    public class InventoryDto
    {
        [Key]
        public int InventoryId { get; set; }

        [Required]
        public string Name { get; set; }
    }
}