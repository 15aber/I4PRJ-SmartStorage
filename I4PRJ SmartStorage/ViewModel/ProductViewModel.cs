using System.Collections.Generic;
using I4PRJ_SmartStorage.Models.Domain;

namespace I4PRJ_SmartStorage.ViewModel
{
  public class ProductViewModel
  {
    public List<Category> Categories { get; set; }

    public Product Product { get; set; }
  }
}