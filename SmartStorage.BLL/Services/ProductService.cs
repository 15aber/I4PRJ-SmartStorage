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
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
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

        public void Add(ProductDto entityDto)
        {
            try
            {
                var entity = Mapper.Map<ProductDto, Product>(entityDto);
                _unitOfWork.Products.Add(entity);
                _unitOfWork.Complete();
            }
            catch (Exception)
            {
                // TODO lav exception

                throw;
            }
        }

        public void Update(ProductDto entityDto)
        {
            try
            {
                var entity = Mapper.Map<ProductDto, Product>(entityDto);
                _unitOfWork.Products.Update(entity);
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
                var entity = _unitOfWork.Products.Get(id);
                entity.IsDeleted = true;
                _unitOfWork.Products.Update(entity);
                _unitOfWork.Complete();
            }
            catch (Exception)
            {
                // TODO lav exception

                throw;
            }
        }

        public IList<ProductDto> GetAll()
        {
            try
            {
                var entities = _unitOfWork.Products.GetAll().ToList();
                var entitiesDtos = Mapper.Map<List<Product>, List<ProductDto>>(entities);
                return entitiesDtos;
            }
            catch (Exception)
            {
                // TODO lav exception

                throw;
            }
        }

        public IList<ProductDto> GetAllActive()
        {
            try
            {
                var entities = _unitOfWork.Products.GetAll(e => e.IsDeleted == false).ToList();
                var entitiesDtos = Mapper.Map<List<Product>, List<ProductDto>>(entities);
                return entitiesDtos;
            }
            catch (Exception)
            {
                // TODO lav exception

                throw;
            }
        }

        public IList<ProductDto> GetAllActiveOfCategory(int id)
        {
            try
            {
                var entities = _unitOfWork.Products.GetAll(e => e.IsDeleted == false, e => e.CategoryId == id).ToList();
                var entitiesDtos = Mapper.Map<List<Product>, List<ProductDto>>(entities);
                return entitiesDtos;
            }
            catch (Exception)
            {
                // TODO lav exception

                throw;
            }
        }

        public IList<ProductDto> GetAllActiveOfInventory(int id)
        {
            try
            {
                var entities = _unitOfWork.Stocks.GetAllOfInventory(id);

                var products = new List<Product>();
                foreach (var element in entities)
                {
                    products.Add(element.Product);
                }

                var entitiesDtos = Mapper.Map<List<Product>, List<ProductDto>>(products);
                return entitiesDtos;
            }
            catch (Exception)
            {
                // TODO lav exception

                throw;
            }
        }

        public ProductDto GetSingle(int id)
        {
            try
            {
                var entity = _unitOfWork.Products.Get(id);
                var entityDto = Mapper.Map<Product, ProductDto>(entity);
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