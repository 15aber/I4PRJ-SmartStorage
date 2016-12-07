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
        var entity = Mapper.Map<StockDto, Stock>(entityDto);

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
        var entity = Mapper.Map<StockDto, Stock>(entityDto);
        _unitOfWork.Stocks.Update(entity);
        _unitOfWork.Complete();
      }
      catch (Exception)
      {
        // TODO lav exception

        throw;
      }
    }

    public IList<StockDto> GetAllOfInventory(int id)
    {
      try
      {
        var entities = _unitOfWork.Stocks.GetAllOfInventory(id);
        var entitiesDtos = Mapper.Map<List<Stock>, List<StockDto>>(entities);
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
        var entitiesDtos = Mapper.Map<List<Stock>, List<StockDto>>(entities);
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
        var entityDto = Mapper.Map<Stock, StockDto>(entity);
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