using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Seal.Models
{
    /// <summary>
    /// 和数据库映射关系
    /// </summary>
    public class TableMapAttribute : Attribute
    {
        /// <summary>
        /// 数据库表名字
        /// </summary>
        public string TableName { get; set; }

        public TableMapAttribute() { }

        public TableMapAttribute(string tableName)
        {
            this.TableName = tableName;
        }


    }
}
