using Entities;
using EserKepenk.DAL.Context;
using EserKepenk.DAL.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EserKepenk.DAL.Repositories.Concrete
{
    public class AccountUserRepo : Repo<AccountUser>, IAccountUserRepo
    {
        public AccountUserRepo(EserKepenkDbContext dbContext) : base(dbContext)
        {
            
        }

        public AccountUser? FindLoginUser(string username, string password)
        {
            return base._context.AccountUsers
                                  .Where(au => au.Email == username && au.Password == password)
                                  .SingleOrDefault();
        }
    }
}
