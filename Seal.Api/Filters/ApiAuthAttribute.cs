using Seal.Business.Interface;
using Seal.Core;
using Seal.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Script.Serialization;

namespace Seal.Api.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
    public class ApiAuthAttribute : System.Web.Http.Filters.ActionFilterAttribute
    {
        private string key = "LoginName";
        public override void OnActionExecuting(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            try
            {
                string loginName = GetLoginNameFromHttpContext(actionContext);
                if (string.IsNullOrEmpty(loginName))
                {
                    actionContext.Response = new HttpResponseMessage(HttpStatusCode.Forbidden);
                    actionContext.Response.ReasonPhrase = "请登录";
                    return;
                }

                if (actionContext.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Count > 0)   // 允许匿名访问
                {
                    base.OnActionExecuting(actionContext);
                    return;
                }

                // TODO: sessionkey过期或不存在就拒绝 调用BLL方法验证
                var accountService = StructureMapWapper.GetInstance<IAccountService>();
                string sessionKey=string.Empty;
                if (!accountService.CheckSessionIsExpired(loginName, out sessionKey))
                {
                    actionContext.Response = new HttpResponseMessage(HttpStatusCode.Forbidden);
                    actionContext.Response.ReasonPhrase = "会话超时，请重新登录";
                    return;
                }

                base.OnActionExecuting(actionContext);
            }
            catch (Exception ex)
            {
                actionContext.Response = new HttpResponseMessage(HttpStatusCode.Forbidden);
                actionContext.Response.ReasonPhrase = ex.Message;
            }
        }

        private string GetLoginNameFromHttpContext(HttpActionContext actionContext)
        {
            string loginName = string.Empty;
            if (actionContext.Request.Method.Method.ToLower() == "post")
            {
                Stream stream = actionContext.Request.Content.ReadAsStreamAsync().Result;
                Encoding encoding = Encoding.UTF8;
                stream.Position = 0;
                string postData = "";
                using (StreamReader reader = new StreamReader(stream, encoding))
                {
                    postData = reader.ReadToEnd().ToString();
                }
                var serialize = new JavaScriptSerializer();
                var obj = serialize.Deserialize<Account>(postData);
                if (obj != null)
                {
                    loginName = obj.Name;
                }
            }
            else
            {
                var query = HttpUtility.ParseQueryString(actionContext.Request.RequestUri.Query);
                //从请求中获取用户名
                loginName = query[key];
            }
            return loginName;
        }
    }
}