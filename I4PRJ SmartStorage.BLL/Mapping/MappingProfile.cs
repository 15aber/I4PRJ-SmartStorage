using AutoMapper;
using I4PRJ_SmartStorage.BLL.Dtos;
using I4PRJ_SmartStorage.BLL.Interfaces.Dtos;
using I4PRJ_SmartStorage.DAL.Interfaces.Models;
using I4PRJ_SmartStorage.DAL.Models;

namespace I4PRJ_SmartStorage.BLL.Mapping
{
  public class MappingProfile : Profile
  {
    public MappingProfile()
    {
      // Model to Dto
      CreateMap<ICategoryModel, ICategoryDto>();
      CreateMap<InventoryModel, InventoryDto>();
      CreateMap<SupplierModel, SupplierDto>();
      CreateMap<WholesalerModel, WholesalerDto>();

      // Dto to Model
      CreateMap<ICategoryDto, ICategoryModel>();
      CreateMap<InventoryDto, InventoryModel>();
      CreateMap<SupplierDto, SupplierModel>();
      CreateMap<WholesalerDto, WholesalerModel>();
    }
  }
}
