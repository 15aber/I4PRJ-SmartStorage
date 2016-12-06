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
  public class SupplierService : ISupplierService
  {
    private readonly IUnitOfWork _unitOfWork;

    public SupplierService(IUnitOfWork unitOfWork)
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

    public void Add(SupplierDto entityDto)
    {
      try
      {
        var entity = Mapper.Map<SupplierDto, Supplier>(entityDto);
        _unitOfWork.Suppliers.Add(entity);
        _unitOfWork.Complete();
      }
      catch (Exception)
      {
        // TODO lav exception

        throw;
      }
    }

    public void Update(SupplierDto entityDto)
    {
      try
      {
        var entity = Mapper.Map<SupplierDto, Supplier>(entityDto);
        _unitOfWork.Suppliers.Update(entity);
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
        var entity = _unitOfWork.Suppliers.Get(id);
        entity.IsDeleted = true;
        _unitOfWork.Suppliers.Update(entity);
        _unitOfWork.Complete();
      }
      catch (Exception)
      {
        // TODO lav exception

        throw;
      }
    }

    public IList<SupplierDto> GetAll()
    {
      try
      {
        var entities = _unitOfWork.Suppliers.GetAll().ToList();
        var entitiesDtos = Mapper.Map<List<Supplier>, List<SupplierDto>>(entities);
        return entitiesDtos;
      }
      catch (Exception)
      {
        // TODO lav exception

        throw;
      }
    }

    public List<SupplierDto> GetAllActive()
    {
      try
      {
        var entities = _unitOfWork.Suppliers.GetAll(e => e.IsDeleted == false).ToList();
        var entitiesDtos = Mapper.Map<List<Supplier>, List<SupplierDto>>(entities);
        return entitiesDtos;
      }
      catch (Exception)
      {
        // TODO lav exception

        throw;
      }
    }

    public SupplierDto GetSingle(int id)
    {
      try
      {
        var entity = _unitOfWork.Suppliers.Get(id);
        var entityDto = Mapper.Map<Supplier, SupplierDto>(entity);
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