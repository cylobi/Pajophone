using AutoMapper;
using Pajophone.Models;
using Pajophone.ViewModels;

namespace Pajophone.AutoMapper;

public class ProductMapperProfile : Profile
{
    public ProductMapperProfile()
    {
        CreateMap<ProductViewModel, ProductModel>();
    }
}