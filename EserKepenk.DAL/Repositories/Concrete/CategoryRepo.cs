using Entities;
using EserKepenk.DAL.Context;
using EserKepenk.DAL.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EserKepenk.DAL.Repositories.Concrete
{
    public class CategoryRepo : Repo<Category>
    {
        public CategoryRepo(EserKepenkDbContext dbContext):base(dbContext) 
        { }
        public override IEnumerable<Category> GetAll()
        {
            return _context.Categories.Include(c => c.Products).ToList();
        }

        public override Category? GetById(int id)
        {
            return _context.Categories.Include(p=> p.Products).Where(c=> c.Id == id).AsNoTracking().SingleOrDefault();
        }

    }
}
