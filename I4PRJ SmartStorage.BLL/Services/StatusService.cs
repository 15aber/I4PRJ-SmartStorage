using AutoMapper;
using SmartStorage.BLL.Dtos;
using SmartStorage.BLL.Interfaces.Services;
using SmartStorage.DAL.Interfaces;
using SmartStorage.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartStorage.BLL.Services
{
  public class StatusService : IStatusService
  {
    private readonly IUnitOfWork _unitOfWork;

    public StatusService(IUnitOfWork unitOfWork)
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

    public void Add(StatusDto entityDto)
    {
      try
      {
        var entity = Mapper.Map<StatusDto, Status>(entityDto);
        _unitOfWork.Statuses.Add(entity);
        _unitOfWork.Complete();
      }
      catch (Exception)
      {
        // TODO lav exception

        throw;
      }
    }

    public void Update(StatusDto entityDto)
    {
      try
      {
        var entity = Mapper.Map<StatusDto, Status>(entityDto);
        _unitOfWork.Statuses.Update(entity);
        _unitOfWork.Complete();
      }
      catch (Exception)
      {
        // TODO lav exception

        throw;
      }
    }

    public IList<StatusDto> GetAll()
    {
      try
      {
        var entities = _unitOfWork.Statuses.GetAll().ToList();
        var entitiesDtos = Mapper.Map<List<Status>, List<StatusDto>>(entities);
        return entitiesDtos;
      }
      catch (Exception)
      {
        // TODO lav exception

        throw;
      }
    }

    public StatusDto GetSingle(int id)
    {
      try
      {
        var entity = _unitOfWork.Statuses.Get(id);
        var entityDto = Mapper.Map<Status, StatusDto>(entity);
        return entityDto;
      }
      catch (Exception)
      {
        // TODO lav exception

        throw;
      }
    }

    public IList<StatusDto> GetAllOfInventory(int id)
    {
      try
      {
        var entities = _unitOfWork.Statuses.GetAll(i => i.InventoryId == id).ToList();
        var entitiesDtos = Mapper.Map<List<Status>, List<StatusDto>>(entities);
        return entitiesDtos;
      }
      catch (Exception)
      {
        // TODO lav exception

        throw;
      }
    }
  }
}