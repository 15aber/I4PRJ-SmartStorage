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
  public class InventoryService : IInventoryService
  {
    private readonly IUnitOfWork _unitOfWork;

    public InventoryService(IUnitOfWork unitOfWork)
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

    public void Add(InventoryDto entityDto)
    {
      try
      {
        var entity = Mapper.Map<InventoryDto, Inventory>(entityDto);
        _unitOfWork.Inventories.Add(entity);
        _unitOfWork.Complete();
      }
      catch (Exception)
      {
        // TODO lav exception

        throw;
      }
    }

    public void Update(InventoryDto entityDto)
    {
      try
      {
        var entity = Mapper.Map<InventoryDto, Inventory>(entityDto);
        _unitOfWork.Inventories.Update(entity);
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
        var entity = _unitOfWork.Inventories.Get(id);
        entity.IsDeleted = true;
        _unitOfWork.Inventories.Update(entity);
        _unitOfWork.Complete();
      }
      catch (Exception)
      {
        // TODO lav exception

        throw;
      }
    }

    public IList<InventoryDto> GetAll()
    {
      try
      {
        var entities = _unitOfWork.Inventories.GetAll().ToList();
        var entitiesDtos = Mapper.Map<List<Inventory>, List<InventoryDto>>(entities);
        return entitiesDtos;
      }
      catch (Exception)
      {
        // TODO lav exception

        throw;
      }
    }

    public IList<InventoryDto> GetAllActive()
    {
      try
      {
        var entities = _unitOfWork.Inventories.GetAll(e => e.IsDeleted == false).ToList();
        var entitiesDtos = Mapper.Map<List<Inventory>, List<InventoryDto>>(entities);
        return entitiesDtos;
      }
      catch (Exception)
      {
        // TODO lav exception

        throw;
      }
    }

    public InventoryDto GetSingle(int id)
    {
      try
      {
        var entity = _unitOfWork.Inventories.Get(id);
        var entityDto = Mapper.Map<Inventory, InventoryDto>(entity);
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