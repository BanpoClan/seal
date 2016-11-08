using Seal.Common;
using Seal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Seal.Business.Interface
{
    /// <summary>
    /// 后台账户管理
    /// </summary>
    public interface IAccountService
    {
        /// <summary>
        /// 通过登录名获取用户信息
        /// </summary>
        /// <param name="loginName"></param>
        /// <returns></returns>
        Account GetAccountByLoginName(string loginName);

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="loginName"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        SessionWapper Login(Account account);
        /// <summary>
        /// 会话是否过期
        /// </summary>
        /// <param name="loginName"></param>
        /// <returns></returns>
        bool CheckSessionIsExpired(string loginName, out string sessionKey);

        /// <summary>
        /// 修改账户
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        int Update(Account account);

        /// <summary>
        /// 创建账户
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        ActResult<string> Create(Account account);

        
        
    }
}
