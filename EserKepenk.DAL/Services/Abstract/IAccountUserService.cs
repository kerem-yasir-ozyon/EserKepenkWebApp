using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EserKepenk.DAL.Services.Abstract
{
    public interface IAccountUserService
    {
        AccountUserDto? FindLoginUser(string username, string password);
    }
}
