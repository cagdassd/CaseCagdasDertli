﻿using AutoMapper;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.MapperProfiles
{
	public class ProductProfile : Profile
	{
		public ProductProfile()
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
