using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Seal.Models
{
    /// <summary>
    /// 返回给客户端会话对象
    /// </summary>
    public class SessionWapper
    {
        /// <summary>
        /// 登录成功后返回给客户端的信息
        /// </summary>
        public string SessionKey { get; set; }

        /// <summary>
        /// 会话创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 当前账户信息
        /// </summary>
        public Account Account { get; set; }
    }
}
