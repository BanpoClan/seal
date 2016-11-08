using IBatisNet.DataMapper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Seal.Core
{
    public class BaseDao
    {
        //返回SqlMapper 的实例  用单件模式    
        private static readonly object syncInvoke = new object();
        private static SqlMapper _SqlMapperInstance;

        public SqlMapper SqlMapperInstance
        {
            get
            {
                if (_SqlMapperInstance == null)
                {
                    lock (syncInvoke)
                    {
                        if (_SqlMapperInstance == null)
                        {
                            _SqlMapperInstance = (SqlMapper)Mapper.Instance();

                        }
                    }
                }

                return _SqlMapperInstance;
            }
        }

        #region 查询方法

        public object Add(string statementName, Hashtable parameterObject)
        {
            return this.SqlMapperInstance.Insert(statementName, parameterObject);
        }

        public object Add(string statementName, object parameterObject)
        {
            return this.SqlMapperInstance.Insert(statementName, parameterObject);
        }

        /// <summary>
        /// 返回单个对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="statementName"></param>
        /// <returns></returns>
        public T QueryForObject<T>(string statementName)
        {
            return this.SqlMapperInstance.QueryForObject<T>(statementName, null);
        }

        /// <summary>
        /// 返回单个对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="statementName"></param>
        /// <returns></returns>
        public T QueryForObject<T>(string statementName, Hashtable parameterObject)
        {
            return this.SqlMapperInstance.QueryForObject<T>(statementName, parameterObject);
        }

        /// <summary>
        /// 获取对象列表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="statementName"></param>
        /// <returns></returns>
        public IList<T> QueryForList<T>(string statementName)
        {
            return this.SqlMapperInstance.QueryForList<T>(statementName, null);
        }

        /// <summary>
        /// 获取对象列表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="statementName"></param>
        /// <returns></returns>
        public IList<T> QueryForList<T>(string statementName, Hashtable parameterObject)
        {
            return this.SqlMapperInstance.QueryForList<T>(statementName, parameterObject);
        }

        public int Delete(string statementName, object parameterObject)
        {
            return this.SqlMapperInstance.Delete(statementName, parameterObject);
        }

        public int Update(string statementName, object parameterObject)
        {
            return this.SqlMapperInstance.Update(statementName, parameterObject);
        }

        #endregion
    }
}
