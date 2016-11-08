using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Seal.Common
{
    /// <summary>
    /// 日志工具
    /// 日志包括：登录，操作日志（用于分析用户行为）,系统运行情况
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ILogHelper<T> where T : class
    {
        /// <summary>
        /// 创建日志
        /// </summary>
        /// <typeparam name="T"></typeparam>
        void Create(T obj);
        /// <summary>
        /// 查询日志
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        IList<T> QueryLog();
        
    }
}
