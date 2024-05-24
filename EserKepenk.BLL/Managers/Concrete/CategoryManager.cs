using DTOs;
using Entities;
using EserKepenk.BLL.Managers.Abstract;
using EserKepenk.DAL.Services.Abstract;
using EserKepenk.DAL.Services.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EserKepenk.BLL.Managers.Concrete
{
    public class CategoryManager : Manager<CategoryDto,Category>
    {
        public CategoryManager(CategoryService service) : base(service)
        {

        }
        

    }
}
