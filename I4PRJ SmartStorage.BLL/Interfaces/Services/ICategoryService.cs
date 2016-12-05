using I4PRJ_SmartStorage.BLL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace I4PRJ_SmartStorage.BLL.Interfaces.Services
{
  public interface ICategoryService : IService<CategoryViewModel>
  {
    List<CategoryViewModel> GetAllActive();
    List<CategoryViewModel> GetAllActive(Expression<Func<CategoryViewModel, bool>> whereCondition);
  }
}