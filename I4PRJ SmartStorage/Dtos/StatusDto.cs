using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using I4PRJ_SmartStorage.Models.Domain;

namespace I4PRJ_SmartStorage.Dtos
{
    public class StatusDto
    {
        public int StatusId { get; set; }

        public int InventoryId { get; set; }

        public List<Product> Products { get; set; }

        public int ProductId { get; set; }

        public string Name { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public List<Stock> Stock { get; set; }

        public bool IsDeleted { get; set; }
    }
}