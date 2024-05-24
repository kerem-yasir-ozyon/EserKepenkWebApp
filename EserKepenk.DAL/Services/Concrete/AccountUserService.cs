using DTOs;
using Entities;
using EserKepenk.DAL.Repositories.Abstract;
using EserKepenk.DAL.Repositories.Concrete;
using EserKepenk.DAL.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EserKepenk.DAL.Services.Concrete
{
    public class AccountUserService : Service<AccountUser, AccountUserDto>, IAccountUserService
    {
        public AccountUserService(AccountUserRepo repo) : base(repo)
        {
        }

        public AccountUserDto? FindLoginUser(string username, string password)
        {
            AccountUser? accountUser = (base._repo as IAccountUserRepo).FindLoginUser(username, password);

            return _mapper.Map<AccountUserDto>(accountUser);
        }
    }
}
