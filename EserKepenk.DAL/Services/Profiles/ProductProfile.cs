using AutoMapper;
using DTOs;
using Entities;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EserKepenk.DAL.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductDto, Product>().ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category));
            CreateMap<Product, ProductDto>().ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category));

            CreateMap<CategoryDto, Category>().ReverseMap();

            ///CreateMap<ProductDto, Product>().ForMember(x=> x.Picture, y=> y.MapFrom(z=> z.Picture)).ReverseMap();
        }
    }
}
