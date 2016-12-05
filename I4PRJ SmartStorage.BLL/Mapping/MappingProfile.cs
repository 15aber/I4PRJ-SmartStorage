using AutoMapper;
using I4PRJ_SmartStorage.BLL.ViewModels;
using I4PRJ_SmartStorage.DAL.Models;

namespace I4PRJ_SmartStorage.BLL.Mapping
{
  public class MappingProfile : Profile
  {
    public MappingProfile()
    {
      // Model to ViewModel
      CreateMap<CategoryModel, CategoryViewModel>();

      // ViewModel to Model
      CreateMap<CategoryViewModel, CategoryModel>();
    }
  }
}
