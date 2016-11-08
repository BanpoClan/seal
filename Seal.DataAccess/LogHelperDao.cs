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
    public class LoginLogDao : BaseDao,ILoginLogDao
    {
        public void Create(Models.AccountLog obj)
        {
            var para = new Hashtable();
            para.Add("TerminalType", obj.TerminalType);
            para.Add("LoginName", obj.LoginName);
            para.Add("SessionKey", obj.SessionKey);
            para.Add("CreateTime", obj.CreateTime);
            para.Add("Address", obj.Address);
            para.Add("ActionName", obj.ActionName);
            base.Add("CreateLog", para);
        }



        public IList<AccountLog> QueryLog()
        {
            throw new NotImplementedException();
        }



        public IList<AccountLog> QueryLogByLoginName(string loginName, int top, string order = "DESC")
        {
            var para = new Hashtable();
            para.Add("loginName", string.IsNullOrEmpty(loginName) ? "" : loginName);
            para.Add("top", top.ToString());
            para.Add("order", order);
            return base.QueryForList<AccountLog>("QueryLogByLoginName", para);
        }
    }
}
