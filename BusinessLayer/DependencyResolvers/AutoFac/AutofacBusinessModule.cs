﻿using Autofac;
using Autofac.Extras.DynamicProxy;
using BusinessLayer.Abstract;
using BusinessLayer.Concretes;
using Core.Utilities.Interceptors;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DependencyResolvers.AutoFac
{
    public class AutofacBusinessModule:Module
    {

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductManager>().As<IProductService>().SingleInstance();
            builder.RegisterType<EFProductDal>().As<IProductDal>().SingleInstance();

            var assembly =System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
            .EnableInterfaceInterceptors(new Castle.DynamicProxy.ProxyGenerationOptions
            {
                Selector = new AspectInterceptorSelector()
            }).SingleInstance();


        }
    }
}
