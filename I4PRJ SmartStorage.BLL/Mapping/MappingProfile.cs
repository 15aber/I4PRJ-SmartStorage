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
      CreateMap<Category, CategoryDto>();
      CreateMap<Inventory, InventoryDto>();
      CreateMap<Product, ProductDto>();
      CreateMap<Status, StatusDto>();
      CreateMap<Supplier, SupplierDto>();
      CreateMap<Transaction, TransactionDto>();
      CreateMap<Wholesaler, WholesalerDto>();

      // Dto to Model
      CreateMap<CategoryDto, Category>();
      CreateMap<InventoryDto, Inventory>();
      CreateMap<ProductDto, Product>();
      CreateMap<StatusDto, Status>();
      CreateMap<SupplierDto, Supplier>();
      CreateMap<TransactionDto, Transaction>();
      CreateMap<WholesalerDto, Wholesaler>();
    }
  }
}
