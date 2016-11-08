using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;


namespace Seal.Core
{
    public class SealActivator : IHttpControllerActivator
    {
        public SealActivator(HttpConfiguration configuration)
        {
        }


        public System.Web.Http.Controllers.IHttpController Create(System.Net.Http.HttpRequestMessage request, System.Web.Http.Controllers.HttpControllerDescriptor controllerDescriptor, Type controllerType)
        {
            try
            {
                return StructureMap.ObjectFactory.GetInstance(controllerType) as IHttpController;
            }
            catch (Exception)
            {
                throw new Exception(ObjectFactory.WhatDoIHave());
            }
        }
    }
}
