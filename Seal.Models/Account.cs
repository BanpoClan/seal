using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Seal.Models
{
    /// <summary>
    /// 账户信息。使用Name登录
    /// </summary>
    [TableMap(TableName = "t_Education_Backstage_LoginNews")]
    public class Account
    {
        public string LID { get; set; }

        public string Name { get; set; }

        /// <summary>
        /// 密码：客户端加密传递
        /// </summary>
        public string PassWord { get; set; }

        public string Phone { get; set; }
        public int Level { get; set; }

        public DateTime CreateDate { get; set; }

    }
}
