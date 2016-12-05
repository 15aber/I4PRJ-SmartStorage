using System.Collections.Generic;
using I4PRJ_SmartStorage.DAL.Interfaces.Models;

namespace I4PRJ_SmartStorage.BLL.ViewModels
{
  public class CategoryViewModel : ICategoryModel
  {
    public List<ICategoryModel> Categories { get; set; }
    public ICategoryModel Category { get; set; }
  }
}