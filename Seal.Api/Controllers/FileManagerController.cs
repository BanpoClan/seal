using Seal.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Seal.Api.Controllers
{
    /// <summary>
    /// 文件上传和文件管理
    /// </summary>
    public class FileManagerController : ApiController
    {
        /// <summary>
        /// 客户采用异步调用
        /// </summary>
        /// <returns></returns>
        public ActResult<string> Upload()
        {
            var result = new ActResult<string>();
            try
            {


                HttpPostedFile file = HttpContext.Current.Request.Files[0];
                string root = HttpContext.Current.Server.MapPath("~/App_Data");
                var relative = string.Format("{0}\\{1}", ConfigurationManager.AppSettings["AccountDoc"], Guid.NewGuid().ToString("N"));
                string path = string.Format("{0}\\{1}", root, relative);
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                path += "\\" + file.FileName;
                file.SaveAs(path);
                result.Message = "上传成功";
                result.Tag = string.Format("{0}\\{1}", relative, file.FileName);
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }
            return result;
        }



    }
}
