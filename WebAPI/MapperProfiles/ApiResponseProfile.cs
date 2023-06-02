using AutoMapper;
using Entities.Concrete;
using Entities.DTOs;

namespace WebAPI.MapperProfiles
{
	public class ApiResponseProfile : Profile
	{
		public ApiResponseProfile()
		{

			CreateMap<Product, ProductDto>()
				.ForMember(d => d.ProductId, o => o.MapFrom(s => s.Id))
				.ForMember(d => d.ProductDescription, o => o.MapFrom(s => s.ProductDescription))
				.ForMember(d => d.Category, o => o.MapFrom(s => s.Category))
				.ForMember(d => d.Unit, o => o.MapFrom(s => s.Unit))
				.ForMember(d => d.UnitPrice, o => o.MapFrom(s => s.UnitPrice));



		}
	}
}

