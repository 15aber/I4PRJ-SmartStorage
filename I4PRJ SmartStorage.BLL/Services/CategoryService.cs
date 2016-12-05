using AutoMapper;
using I4PRJ_SmartStorage.BLL.Interfaces.Services;
using I4PRJ_SmartStorage.BLL.ViewModels;
using I4PRJ_SmartStorage.DAL.Interfaces;
using I4PRJ_SmartStorage.DAL.Interfaces.Models;
using I4PRJ_SmartStorage.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace I4PRJ_SmartStorage.BLL.Services
{
  public class CategoryService : Service<ICategoryModel>, ICategoryService
  {
    private readonly IUnitOfWork _unitOfWork;

    public CategoryService(IUnitOfWork unitOfWork)
    {
      _unitOfWork = unitOfWork;
    }


    public List<CategoryViewModel> GetAllActive()
    {
      try
      {
        var allActiveCategories = _unitOfWork.Categories.GetAll(c => c.IsDeleted == false);
        var result = Mapper.Map<List<CategoryModel>, List<CategoryViewModel>>(allActiveCategories);
        return result;
      }
      catch (Exception)
      {

        throw;
      }
    }

    public List<CategoryViewModel> GetAllActive(Expression<Func<CategoryViewModel, bool>> whereCondition)
    {
      throw new NotImplementedException();
    }


    public void Add(CategoryViewModel entity)
    {
      throw new NotImplementedException();
    }

    public long Count(Expression<Func<CategoryViewModel, bool>> whereCondition)
    {
      throw new NotImplementedException();
    }

    public void Delete(CategoryViewModel entity)
    {
      throw new NotImplementedException();
    }

    public IList<CategoryViewModel> GetAll()
    {
      throw new NotImplementedException();
    }

    public IList<CategoryViewModel> GetAll(Expression<Func<CategoryViewModel, bool>> whereCondition)
    {
      throw new NotImplementedException();
    }

    public CategoryViewModel GetSingle(Expression<Func<CategoryViewModel, bool>> whereCondition)
    {
      throw new NotImplementedException();
    }

    public void Update(CategoryViewModel entity)
    {
      throw new NotImplementedException();
    }
  }
}
