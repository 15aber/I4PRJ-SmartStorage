using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using SmartStorage.BLL.Dtos;
using SmartStorage.BLL.Interfaces.Services;
using SmartStorage.DAL.Interfaces;
using SmartStorage.DAL.Models;

namespace SmartStorage.BLL.Services
{
  public class CategoryService : ICategoryService
  {
    private readonly IUnitOfWork _unitOfWork;

    public CategoryService(IUnitOfWork unitOfWork)
    {
      try
      {
        _unitOfWork = unitOfWork;
      }
      catch (Exception)
      {
        // TODO lav exception
        throw;
      }
    }

    public void Add(CategoryDto entityDto)
    {
      try
      {
        var entity = Mapper.Map<CategoryDto, Category>(entityDto);
        _unitOfWork.Categories.Add(entity);
        _unitOfWork.Complete();
      }
      catch (Exception)
      {
        // TODO lav exception

        throw;
      }
    }

    public void Update(CategoryDto entityDto)
    {
      try
      {
        var entity = Mapper.Map<CategoryDto, Category>(entityDto);
        _unitOfWork.Categories.Update(entity);
        _unitOfWork.Complete();
      }
      catch (Exception)
      {
        // TODO lav exception

        throw;
      }
    }

    public void Delete(int id)
    {
      try
      {
        var entity = _unitOfWork.Categories.Get(id);
        entity.IsDeleted = true;
        _unitOfWork.Categories.Update(entity);
        _unitOfWork.Complete();
      }
      catch (Exception)
      {
        // TODO lav exception

        throw;
      }
    }

    public IList<CategoryDto> GetAll()
    {
      try
      {
        var entities = _unitOfWork.Categories.GetAll().ToList();
        var entitiesDtos = Mapper.Map<List<Category>, List<CategoryDto>>(entities);
        return entitiesDtos;
      }
      catch (Exception)
      {
        // TODO lav exception

        throw;
      }
    }

    public List<CategoryDto> GetAllActive()
    {
      try
      {
        var entities = _unitOfWork.Categories.GetAll(e => e.IsDeleted == false).ToList();
        var entitiesDtos = Mapper.Map<List<Category>, List<CategoryDto>>(entities);
        return entitiesDtos;
      }
      catch (Exception)
      {
        // TODO lav exception

        throw;
      }
    }

    public CategoryDto GetSingle(int id)
    {
      try
      {
        var entity = _unitOfWork.Categories.Get(id);
        var entityDto = Mapper.Map<Category, CategoryDto>(entity);
        return entityDto;
      }
      catch (Exception)
      {
        // TODO lav exception

        throw;
      }
    }
  }
}