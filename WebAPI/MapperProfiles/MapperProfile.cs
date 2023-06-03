using AutoMapper;
using Entities.Concrete;
using Entities.DTOs;

namespace WebAPI.MapperProfiles
{
	public class MapperProfile : Profile
	{
		public MapperProfile()
		{

			CreateMap<Product, ProductDto>()
				.ForMember(d => d.ProductId, o => o.MapFrom(s => s.Id))
				.ForMember(d => d.ProductDescription, o => o.MapFrom(s => s.ProductDescription))
				.ForMember(d => d.Category, o => o.MapFrom(s => s.Category))
				.ForMember(d => d.Unit, o => o.MapFrom(s => s.Unit))
				.ForMember(d => d.UnitPrice, o => o.MapFrom(s => s.UnitPrice));

			CreateMap<Order, CreateOrderRequest>()
				.ForMember(d => d.CustomerName, o => o.MapFrom(s => s.CustomerName))
				.ForMember(d => d.CustomerGSM, o => o.MapFrom(s => s.CustomerGSM))
				.ForMember(d => d.CustomerEmail, o => o.MapFrom(s => s.CustomerEmail))
				.ForMember(d => d.Amount, o => o.MapFrom(s => s.TotalAmount));

			CreateMap<Order, CreateOrderRequest>().ReverseMap();

			CreateMap<OrderDetail, CreateOrderRequest>()
				.ForMember(d => d.ProductId, o => o.MapFrom(s => s.ProductId))
				.ForMember(d => d.UnitPrice, o => o.MapFrom(s => s.UnitPrice));

			CreateMap<OrderDetail, CreateOrderRequest>().ReverseMap();
		}
	}
}
