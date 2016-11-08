using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Seal.Common
{
    /// <summary>
    /// 操作返回结果
    /// </summary>
    public class ActResult<T>
    {
        /// <summary>
        /// 操作后返回给客户端的消息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 返回给客户端的对象
        /// </summary>
        public T Tag { get; set; }
    }
}
