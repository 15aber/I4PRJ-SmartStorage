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
  public class WholesalerService : IWholesalerService
  {
    private readonly IUnitOfWork _unitOfWork;

    public WholesalerService(IUnitOfWork unitOfWork)
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

    public void Add(WholesalerDto entityDto)
    {
      try
      {
        var entity = Mapper.Map<WholesalerDto, Wholesaler>(entityDto);
        _unitOfWork.Wholesalers.Add(entity);
        _unitOfWork.Complete();
      }
      catch (Exception)
      {
        // TODO lav exception

        throw;
      }
    }

    public void Update(WholesalerDto entityDto)
    {
      try
      {
        var entity = Mapper.Map<WholesalerDto, Wholesaler>(entityDto);
        _unitOfWork.Wholesalers.Update(entity);
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
        var entity = _unitOfWork.Wholesalers.Get(id);
        entity.IsDeleted = true;
        _unitOfWork.Wholesalers.Update(entity);
        _unitOfWork.Complete();
      }
      catch (Exception)
      {
        // TODO lav exception

        throw;
      }
    }

    public IList<WholesalerDto> GetAll()
    {
      try
      {
        var entities = _unitOfWork.Wholesalers.GetAll().ToList();
        var entitiesDtos = Mapper.Map<List<Wholesaler>, List<WholesalerDto>>(entities);
        return entitiesDtos;
      }
      catch (Exception)
      {
        // TODO lav exception

        throw;
      }
    }

    public IList<WholesalerDto> GetAllActive()
    {
      try
      {
        var entities = _unitOfWork.Wholesalers.GetAll(e => e.IsDeleted == false).ToList();
        var entitiesDtos = Mapper.Map<List<Wholesaler>, List<WholesalerDto>>(entities);
        return entitiesDtos;
      }
      catch (Exception)
      {
        // TODO lav exception

        throw;
      }
    }

    public WholesalerDto GetSingle(int id)
    {
      try
      {
        var entity = _unitOfWork.Wholesalers.Get(id);
        var entityDto = Mapper.Map<Wholesaler, WholesalerDto>(entity);
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