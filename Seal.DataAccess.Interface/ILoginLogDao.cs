using Seal.Common;
using Seal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Seal.DataAccess.Interface
{
    public interface ILoginLogDao : ILogHelper<AccountLog>
    {
        /// <summary>
        /// 查询最近  order: asc or desc
        /// </summary>
        /// <param name="loginName"></param>
        /// <param name="top"></param>
        /// <returns></returns>
        IList<AccountLog> QueryLogByLoginName(string loginName, int top, string order = "DESC");
    }
}
