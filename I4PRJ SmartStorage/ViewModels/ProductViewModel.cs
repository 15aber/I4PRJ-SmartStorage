using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using I4PRJ_SmartStorage.Models.Domain;

namespace I4PRJ_SmartStorage.ViewModels
{
    public class ProductViewModel
    {
        public List<Category> Categories { get; set; }

        public List<Product> Products { get; set; }

        public Product Product { get; set; }

        public int CategoryId { get; set; }
    }
}