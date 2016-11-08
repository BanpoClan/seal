using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Seal.Models
{
    /// <summary>
    /// 记录用户行为
    /// </summary>
    [TableMap(TableName = "t_Education_Backstage_AccountLog")]
    public class AccountLog
    {
        public int ID { get; set; }
        /// <summary>
        /// 终端类型
        /// </summary>
        public string TerminalType { get; set; }
        /// <summary>
        /// 登录名
        /// </summary>
        public string LoginName { get; set; }
        /// <summary>
        /// 本次操作的会话key
        /// </summary>
        public string SessionKey { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        public string Address { get; set; }
        /// <summary>
        /// 操作类型:调用的接口名称
        /// </summary>
        public string ActionName { get; set; }
    }
}
