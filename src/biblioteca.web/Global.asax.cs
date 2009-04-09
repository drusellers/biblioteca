using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace biblioteca.web
{
    using System.Reflection;
    using FubuMVC.Container.StructureMap.Config;
    using FubuMVC.Core.Behaviors;

    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            ControllerConfig.Configure = x =>
                                         {
                                             x.ByDefault.EveryControllerAction(d => d
                                                                                        .Will<execute_the_result>());

                                             const BindingFlags publicDeclaredOnly = BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly;
                                             x.AddControllerActions(a =>
                                                 a.UsingTypesInTheSameAssemblyAs<ViewModel>(types =>
                                                     from type in types
                                                     where type.Namespace.EndsWith("web.controllers") &&
                                                           type.Name.EndsWith("Controller")
                                                     from method in type.GetMethods(publicDeclaredOnly)
                                                     select method
                                             ));
            };

            Bootstrapper.Bootstrap();
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}