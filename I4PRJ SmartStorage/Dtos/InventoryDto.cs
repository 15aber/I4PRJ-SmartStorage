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
        public int InventoryId { get; set; }

        public string Name { get; set; }

        public DateTime Updated { get; set; }

        public string ByUser { get; set; }

        public bool IsDeleted { get; set; }
    }
}