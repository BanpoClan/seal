using Seal.Business.Interface;
using Seal.Common;
using Seal.Core;
using Seal.DataAccess.Interface;
using Seal.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Seal.Business
{
    public class AccountService : IAccountService
    {
        public readonly IAccountDao accountDao;
        public readonly ILoginLogDao loginLogDao;


        public AccountService()
        {
            accountDao = StructureMapWapper.GetInstance<IAccountDao>();
            loginLogDao = StructureMapWapper.GetInstance<ILoginLogDao>();
        }


        public Models.Account GetAccountByLoginName(string loginName)
        {
            return accountDao.GetAccountByLoginName(loginName);
        }

        Models.SessionWapper IAccountService.Login(Account para)
        {

            //检查用户登录名
            var account = GetAccountByLoginName(para.Name);
            if (account == null || (account != null && account.PassWord != para.PassWord))
            {
                throw new ExceptionBase("用户名或密码错误");
            }
            account.PassWord = string.Empty;


            string sessionKey = string.Empty;
            SessionWapper session = null;
            if (CheckSessionIsExpired(para.Name, out sessionKey))
            {
                session = new SessionWapper();
                session.SessionKey = sessionKey;
                session.Account = account;
            }
            else
            {
                session = CreateSession(account);
            }

            CreateLog(para.Name, session);

            return session;
        }

        private SessionWapper CreateSession(Account account)
        {
            SessionWapper session = new SessionWapper();
            MD5CryptoServiceProvider provider = new MD5CryptoServiceProvider();
            string str = account.Name + DateTime.Now.ToString() + Guid.NewGuid().ToString();
            session.Account = account;
            session.SessionKey = BitConverter.ToString(provider.ComputeHash(System.Text.Encoding.UTF8.GetBytes(str)));
            session.CreateTime = DateTime.Now;
            return session;
        }

        private void CreateLog(string loginName, SessionWapper sessionWapper)
        {
            AccountLog log = new AccountLog();
            log.LoginName = loginName;
            log.SessionKey = sessionWapper.SessionKey;
            log.CreateTime = sessionWapper.CreateTime;
            log.ActionName = "Login";
            loginLogDao.Create(log);

        }


        /// <summary>
        /// 检查会话是否过期:
        /// </summary>
        /// <param name="loginName"></param>
        /// <returns>false：已过期；true：未过期</returns>
        public bool CheckSessionIsExpired(string loginName, out string sessionKey)
        {
            sessionKey = string.Empty;
            //到日志表中查询数据，若是有就延长会话时间,否则新加入日志
            var log = loginLogDao.QueryLogByLoginName(loginName, 1, "DESC").FirstOrDefault();
            if (log != null)
            {
                sessionKey = log.SessionKey;
                if (DateTime.Now.Subtract(log.CreateTime).TotalMinutes > Convert.ToInt32(ConfigurationManager.AppSettings["ExpiredTime"]))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }



        public int Update(Account account)
        {
            return accountDao.Update(account);
        }


        public ActResult<string> Create(Account account)
        {
            var result = new ActResult<string>();
            try
            {
                //检查登录名和手机号码是否重复
                if (accountDao.GetAccountByLoginName(account.Name) != null)
                {
                    result.Message = "该用户名已存在!";
                }
                else if (accountDao.GetAccountByPhone(account.Phone) != null)
                {
                    result.Message = "该手机号码已存在!";
                }
                else
                {
                    accountDao.Create(account);
                    result.Message = "创建成功!";
                }

            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }
            return result;

        }
    }
}
