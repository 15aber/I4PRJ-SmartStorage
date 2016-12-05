using AutoMapper;
using I4PRJ_SmartStorage.BLL.Dtos;
using I4PRJ_SmartStorage.DAL.Models;

namespace I4PRJ_SmartStorage.BLL.Mapping
{
  public class MappingProfile : Profile
  {
    public MappingProfile()
    {
      // Model to Dto
      CreateMap<CategoryModel, CategoryDto>();
      CreateMap<InventoryModel, InventoryDto>();
      CreateMap<ProductModel, ProductDto>();
      CreateMap<StatusModel, StatusDto>();
      CreateMap<SupplierModel, SupplierDto>();
      CreateMap<TransactionModel, TransactionDto>();
      CreateMap<WholesalerModel, WholesalerDto>();

      // Dto to Model
      CreateMap<CategoryDto, CategoryModel>();
      CreateMap<InventoryDto, InventoryModel>();
      CreateMap<ProductDto, ProductModel>();
      CreateMap<StatusDto, StatusModel>();
      CreateMap<SupplierDto, SupplierModel>();
      CreateMap<TransactionDto, TransactionModel>();
      CreateMap<WholesalerDto, WholesalerModel>();
    }
  }
}
