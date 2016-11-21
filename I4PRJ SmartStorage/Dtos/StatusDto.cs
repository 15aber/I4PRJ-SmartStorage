using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using I4PRJ_SmartStorage.Models.Domain;

namespace I4PRJ_SmartStorage.Dtos
{
    public class StatusDto
    {
        public int InventoryId { get; set; }
        public List<Product> Products { get; set; }
    }
}