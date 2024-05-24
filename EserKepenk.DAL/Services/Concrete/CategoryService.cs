using DTOs;
using Entities;
using EserKepenk.DAL.Repositories.Concrete;
using EserKepenk.DAL.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using EserKepenk.DAL.Profiles;
using Microsoft.EntityFrameworkCore;
using EserKepenk.DAL.Repositories.Abstract;

namespace EserKepenk.DAL.Services.Concrete
{
    public class CategoryService : Service<Category, CategoryDto>
    {
        public CategoryService(CategoryRepo categoryRepo) : base(categoryRepo)
        {
            MapperConfiguration config = new MapperConfiguration(config =>
            {
                Profile profile = new CategoryProfile();
                config.AddProfile(profile);
            });

            base.Mapper = config.CreateMapper();
        }
        
    }
}
