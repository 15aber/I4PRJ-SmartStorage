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
    public IList<StatusDto> GetAllOfStatus(int id)
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

    public List<int> GetStartedStatusInventories()
    {
      try
      {
        var statusStartedInventories = new List<int>();

        foreach (var inventory in _unitOfWork.Inventories.GetAll())
        {
          var status = _unitOfWork.Statuses.GetAll(i => i.InventoryId == inventory.InventoryId)
              .ToList().OrderByDescending(o => o.Updated).FirstOrDefault();

          if (status != null && status.IsStarted)
            statusStartedInventories.Add(status.InventoryId);
        }

        return statusStartedInventories;
      }
      catch (Exception)
      {
        // TODO lav exception

        throw;
      }
    }

    public IList<StatusDto> GetUpdated(int id)
    {
      try
      {
        var stocksDtos = _unitOfWork.Stocks.GetAllOfInventory(id);

        var statusDtos = new List<StatusDto>();
        foreach (var stocksDto in stocksDtos)
        {
          var statusDto = new StatusDto
          {
            InventoryId = stocksDto.InventoryId,
            ProductId = stocksDto.ProductId,
            Product = stocksDto.Product,
            ExpQuantity = stocksDto.Quantity
          };
          statusDtos.Add(statusDto);

        }

        return statusDtos;

      }
      catch (Exception)
      {
        // TODO lav exception

        throw;
      }
    }

    public void Create(IList<StatusDto> entities)
    {
      try
      {
        foreach (var statusDto in entities)
        {
          var status = Mapper.Map<StatusDto, Status>(statusDto);
          _unitOfWork.Statuses.Add(status);

          if (Math.Abs(status.Difference) > 0)
          {
            var transaction = new Transaction
            {
              ToInventoryId = statusDto.InventoryId,
              ProductId = statusDto.ProductId,
              Quantity = statusDto.Difference,
              Updated = statusDto.Updated,
              ByUser = statusDto.ByUser + " [status]"
            };
            _unitOfWork.Transactions.Add(transaction);

            var stock = _unitOfWork.Stocks.GetSingle(s => s.InventoryId == status.InventoryId,
              s => s.ProductId == status.ProductId);
            stock.Quantity += status.Difference;
            _unitOfWork.Stocks.Update(stock);
          }
        }

        _unitOfWork.Complete();

      }
      catch (Exception)
      {
        // TODO lav exception

        throw;
      }
    }
  }
}