using Seal.Common;
using Seal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Seal.Business.Interface
{
    /// <summary>
    /// 日志：基于一次会话创建
    /// </summary>
    public interface ILoginLogService : ILogHelper<AccountLog>
    {
        /// <summary>
        /// 查询最近  order: asc or desc
        /// </summary>
        /// <param name="loginName"></param>
        /// <param name="top"></param>
        /// <returns></returns>
        IList<AccountLog> QueryLogByLoginName(string loginName, int top, string order="DESC");
    }
}
