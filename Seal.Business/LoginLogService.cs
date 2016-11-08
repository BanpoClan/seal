using Seal.Business.Interface;
using Seal.Core;
using Seal.DataAccess.Interface;
using Seal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Seal.Business
{
    /// <summary>
    /// 创建和查询登录日志
    /// </summary>
    public class LoginLogService : ILoginLogService
    {
        public readonly ILoginLogDao loginLogDao;

        public LoginLogService()
        {
            loginLogDao = StructureMapWapper.GetInstance<ILoginLogDao>();
        }



        public void Create(AccountLog obj)
        {
            throw new NotImplementedException();
        }

        public IList<AccountLog> QueryLog()
        {
            throw new NotImplementedException();
        }



        public IList<AccountLog> QueryLogByLoginName(string loginName, int top, string order = "DESC")
        {
            return loginLogDao.QueryLogByLoginName(loginName,top,order);
        }
    }
}
