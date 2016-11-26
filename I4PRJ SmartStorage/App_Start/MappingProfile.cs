using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using I4PRJ_SmartStorage.Dtos;
using I4PRJ_SmartStorage.Models.Domain;

namespace I4PRJ_SmartStorage
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to Dto
            CreateMap<Product, ProductDto>();
            CreateMap<Category, CategoryDto>();
            CreateMap<Transaction, TransactionDto>();
            CreateMap<Inventory, InventoryDto>();

            // Dto to Domain
            CreateMap<ProductDto, Product>();
            CreateMap<CategoryDto, Category>();
            CreateMap<TransactionDto, Transaction>();
            CreateMap<InventoryDto, Inventory>();
        }
    }
}