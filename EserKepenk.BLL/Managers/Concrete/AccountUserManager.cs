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
    public class AccountUserManager : Manager<AccountUserDto, AccountUser>, IAccountUserManager
    {
        public AccountUserManager(AccountUserService service) : base(service)
        {
        }

        public AccountUserDto? FindLoginUser(string username, string password)
        {
            return (base._service as IAccountUserService).FindLoginUser(username, password);
        }
    }
}
