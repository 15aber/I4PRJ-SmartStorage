using AutoMapper;
using I4PRJ_SmartStorage.BLL.Dtos;
using I4PRJ_SmartStorage.BLL.Interfaces.Services;
using I4PRJ_SmartStorage.DAL.Interfaces;
using I4PRJ_SmartStorage.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace I4PRJ_SmartStorage.BLL.Services
{
  public class StockService : IStockService
  {
    private readonly IUnitOfWork _unitOfWork;

    public StockService(IUnitOfWork unitOfWork)
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

    public void Add(StockDto entityDto)
    {
      try
      {
        var entity = Mapper.Map<StockDto, StockModel>(entityDto);

        _unitOfWork.Stocks.Add(entity);
        _unitOfWork.Complete();
      }
      catch (Exception)
      {
        // TODO lav exception

        throw;
      }
    }

    public void Update(StockDto entityDto)
    {
      try
      {
        var entity = Mapper.Map<StockDto, StockModel>(entityDto);
        _unitOfWork.Stocks.Update(entity);
        _unitOfWork.Complete();
      }
      catch (Exception)
      {
        // TODO lav exception

        throw;
      }
    }

    public IList<StockDto> GetAllActiveOfInventory(int id)
    {
      try
      {
        var entities = _unitOfWork.Stocks.GetAll(e => e.InventoryId == id).ToList();
        var entitiesDtos = Mapper.Map<List<StockModel>, List<StockDto>>(entities);
        return entitiesDtos;
      }
      catch (Exception)
      {
        // TODO lav exception

        throw;
      }
    }

    public IList<StockDto> GetAll()
    {
      try
      {
        var entities = _unitOfWork.Stocks.GetAll().ToList();
        var entitiesDtos = Mapper.Map<List<StockModel>, List<StockDto>>(entities);
        return entitiesDtos;
      }
      catch (Exception)
      {
        // TODO lav exception

        throw;
      }
    }

    public StockDto GetSingle(int id)
    {
      try
      {
        var entity = _unitOfWork.Stocks.Get(id);
        var entityDto = Mapper.Map<StockModel, StockDto>(entity);
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