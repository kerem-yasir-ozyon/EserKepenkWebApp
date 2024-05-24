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
    public class ProductRepo : Repo<Product>
    {
        public ProductRepo(EserKepenkDbContext dbContext) : base(dbContext) 
        { }

        public override IEnumerable<Product> GetAll()
        {
            return _context.Products.Include(c => c.Category).AsNoTracking().ToList();
        }

        public override Product GetById(int id)
        {
            return _context.Products.Include(c => c.Category).AsNoTracking().SingleOrDefault(z => z.Id == id);
        }
    }
}
