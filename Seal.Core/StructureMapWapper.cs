using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Seal.Core
{
    public class StructureMapWapper
    {
        public static void Init()
        {
            try
            {
                ObjectFactory.Initialize(c =>
                {
                    c.AddConfigurationFromXmlFile("Config\\StructureMap\\Business.config");
                    c.AddConfigurationFromXmlFile("Config\\StructureMap\\DataAccess.config");
                });

            }
            catch (Exception)
            {
                //加系统日志
                throw;
            }

        }

        public static T GetInstance<T>()
        {
            return ObjectFactory.TryGetInstance<T>();
        }
    }
}
