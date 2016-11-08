using Seal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Seal.DataAccess.Interface
{
    public interface IAccountDao
    {

        Account GetAccountByLoginName(string loginName);
        Account GetAccountByPhone(string phone);

        int Update(Account account);

        void Create(Account account);
    }
}
