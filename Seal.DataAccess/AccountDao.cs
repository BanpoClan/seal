using Seal.Core;
using Seal.DataAccess.Interface;
using Seal.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Seal.DataAccess
{
    public class AccountDao : BaseDao, IAccountDao
    {
        public Account GetAccountByLoginName(string loginName)
        {
            var para = new Hashtable();
            para.Add("loginName", string.IsNullOrEmpty(loginName) ? "" : loginName);
            return base.QueryForObject<Account>("GetAccountByLoginName", para);
        }
        public Account GetAccountByPhone(string phone)
        {
            var para = new Hashtable();
            para.Add("phone", string.IsNullOrEmpty(phone) ? "" : phone);
            return base.QueryForObject<Account>("GetAccountByPhone", para);
        }


        public int Update(Account account)
        {
            return base.Update("UpdateAccount", account);
        }


        public void Create(Account account)
        {
            account.LID = Guid.NewGuid().ToString("N");
            account.CreateDate = DateTime.Now;
            base.Add("CreateAccount", account);
        }


        
    }
}
