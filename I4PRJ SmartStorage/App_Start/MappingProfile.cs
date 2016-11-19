using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using I4PRJ_SmartStorage.Dtos;
using I4PRJ_SmartStorage.Models.Domain;

namespace I4PRJ_SmartStorage.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Product, ProductDto>();
            Mapper.CreateMap<ProductDto, Product>();
        }
    }
}