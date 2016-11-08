using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Seal.Api.Controllers
{
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult IndexStep1()
        {
            return View();
        }
        public ActionResult IndexStep2()
        {
            return View();
        }
        public ActionResult IndexStep3()
        {
            return View();
        }

        /// <summary>
        /// 学校介绍
        /// </summary>
        /// <returns></returns>
        public ActionResult Introduce()
        {
            return View();
        }
        /// <summary>
        /// 教学环境
        /// </summary>
        /// <returns></returns>
        public ActionResult Teaching()
        {
            return View();
        }
        /// <summary>
        /// 师资团队
        /// </summary>
        /// <returns></returns>
        public ActionResult Team()
        {
            return View();
        }
        /// <summary>
        /// 课程
        /// </summary>
        /// <returns></returns>
        public ActionResult Course()
        {
            return View();
        }
        /// <summary>
        /// 课程详细信息
        /// </summary>
        /// <returns></returns>
        public ActionResult CourseInfo()
        {
            return View();
        }
    }
}
