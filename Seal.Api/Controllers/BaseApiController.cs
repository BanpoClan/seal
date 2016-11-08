using Seal.Api.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace Seal.Api.Controllers
{


    [ApiAuth]
    public class BaseApiController : ApiController
    {
        public BaseApiController() : base() { }
    }
}