using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Zadanko.Infrastructure;

namespace Zadanko
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            ModelBinders.Binders.Remove(typeof(byte[]));
            ModelBinders.Binders.Add(typeof(byte[]), new CustomByteArrayModelBinder());
        }
    }
}
