using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EserKepenk.BLL.Managers.Abstract
{
    public interface IAccountUserManager
    {
        AccountUserDto? FindLoginUser(string username, string password);
    }
}
