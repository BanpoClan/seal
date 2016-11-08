using Seal.Business.Interface;
using Seal.Common;
using Seal.Core;
using Seal.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Web;
using System.Web.Http;
using System.Web.Security;

namespace Seal.Api.Controllers
{
    /// <summary>
    /// 测试：Api Controller
    /// </summary>
    public class AccountController : BaseApiController
    {
        public readonly IAccountService accountService;

        public AccountController()
        {
            accountService = StructureMapWapper.GetInstance<IAccountService>();
        }

        /// <summary>
        /// 账户登录
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        [AllowAnonymous]
        public SessionWapper Login([FromBody]Account account)
        {
            return accountService.Login(account);
        }

        /// <summary>
        /// 修改账户基本信息
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public int Update([FromBody]Account account)
        {
            return accountService.Update(account);
        }

        /// <summary>
        /// 创建账户:创建完成后
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        [AllowAnonymous]
        public ActResult<string> Create([FromBody]Account account)
        {
            return accountService.Create(account);
        }

        /// <summary>
        /// 通过电话找回账户信息:接受账户信息，发验证码到手机；
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public string GetVeriCode([FromBody]Account account)
        {
            string VerificationCode = string.Empty;
            return VerificationCode;
        }

        /// <summary>
        /// 对比验证码 返回密码
        /// </summary>
        /// <param name="veriCode"></param>
        /// <returns></returns>
        public string CheckVerificationCode([FromBody]string veriCode)
        {
            return string.Empty;
        }
    }
}
