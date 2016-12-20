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
  public class TransactionService : ITransactionService
  {
    private readonly IUnitOfWork _unitOfWork;

    public TransactionService(IUnitOfWork unitOfWork)
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

    public void Add(TransactionDto entityDto)
    {
      try
      {
        var entity = Mapper.Map<TransactionDto, Transaction>(entityDto);

        if (entity.FromInventoryId != null)
        {
          var fromStock = _unitOfWork.Stocks.GetSingle(s => s.InventoryId == entityDto.FromInventoryId, s => s.ProductId == entityDto.ProductId);
          if (fromStock.Quantity < entity.Quantity)
          {
            // TODO lav en meningsfuld excption
            throw new Exception();
          }
          fromStock.Quantity -= entity.Quantity;
          _unitOfWork.Stocks.Update(fromStock);
        }

        var toStock = _unitOfWork.Stocks.GetSingle(s => s.InventoryId == entityDto.ToInventoryId, s => s.ProductId == entityDto.ProductId);
        if (toStock == null)
        {
          var stock = new Stock
          {
            InventoryId = entity.ToInventoryId,
            ProductId = entity.ProductId,
            Quantity = entity.Quantity
          };
          _unitOfWork.Stocks.Add(stock);
        }
        else
        {
          toStock.Quantity += entity.Quantity;
          _unitOfWork.Stocks.Update(toStock);
        }

        _unitOfWork.Transactions.Add(entity);
        _unitOfWork.Complete();
      }
      catch (Exception)
      {
        // TODO lav exception

        throw;
      }
    }

    public void Update(TransactionDto entityDto)
    {
      try
      {
        var entity = Mapper.Map<TransactionDto, Transaction>(entityDto);
        _unitOfWork.Transactions.Update(entity);
        _unitOfWork.Complete();
      }
      catch (Exception)
      {
        // TODO lav exception

        throw;
      }
    }

    public IList<TransactionDto> GetAll()
    {
      try
      {
        var entities = _unitOfWork.Transactions.GetAll().ToList();
        var entitiesDtos = Mapper.Map<List<Transaction>, List<TransactionDto>>(entities);
        return entitiesDtos;
      }
      catch (Exception)
      {
        // TODO lav exception

        throw;
      }
    }

    public IList<TransactionDto> GetAllRestock()
    {
      try
      {
        var entities = _unitOfWork.Transactions.GetAllRestock();
        var entitiesDtos = Mapper.Map<List<Transaction>, List<TransactionDto>>(entities);
        return entitiesDtos;
      }
      catch (Exception)
      {
        // TODO lav exception

        throw;
      }
    }

    public TransactionDto GetSingle(int id)
    {
      try
      {
        var entity = _unitOfWork.Transactions.Get(id);
        var entityDto = Mapper.Map<Transaction, TransactionDto>(entity);
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