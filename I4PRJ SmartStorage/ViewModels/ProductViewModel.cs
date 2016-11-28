using System.Collections.Generic;
using I4PRJ_SmartStorage.Models.Domain;

namespace I4PRJ_SmartStorage.ViewModels
{
    public class ProductViewModel
    {
        public List<Category> Categories { get; set; }
        public List<Supplier> Suppliers { get; set; }
        public List<Wholesaler> Wholesalers { get; set; }
        public List<Product> Products { get; set; }
        public Product Product { get; set; }
        public int CategoryId { get; set; }
    }
}