using Autofac;
using iAsset.App.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iAsset.App.Web
{
    public class IoCModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<GateManagerRepository>().As<IGateManagerRepository>().InstancePerRequest();
            base.Load(builder);
        }
    }
}