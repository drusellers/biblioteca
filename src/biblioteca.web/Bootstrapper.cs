namespace biblioteca.web
{
    using System.Collections;
    using System.Web.Routing;
    using FubuMVC.Container.StructureMap.Config;
    using FubuMVC.Core;
    using FubuMVC.Core.Controller.Config;
    using FubuMVC.Core.Conventions;
    using Microsoft.Practices.ServiceLocation;
    using StructureMap;

    public class Bootstrapper : IBootstrapper
    {
        private static bool _hasStarted;

        public void BootstrapStructureMap()
        {
            ObjectFactory.Initialize(x =>
            {
                x.AddRegistry(new FrameworkServicesRegistry());
                x.AddRegistry(new WebRegistry());
                x.AddRegistry(new ControllerConfig());
                x.AddRegistry(new BibliotecaRegistry());
            });

            ObjectFactory.AssertConfigurationIsValid();

            setup_service_locator();

            apply_action_conventions();

            initialize_routes();
        }

        private static void setup_service_locator()
        {
            ServiceLocator.SetLocatorProvider(() => new StructureMapServiceLocator());
        }

        private static void initialize_routes()
        {
            ObjectFactory.GetInstance<IRouteConfigurer>().LoadRoutes(RouteTable.Routes);
        }

        private static void apply_action_conventions()
        {
            var fubuConfiguration = ObjectFactory.GetInstance<FubuConfiguration>();
            var actionConventions = ObjectFactory.GetAllInstances<IFubuConvention<ControllerActionConfig>>();

            fubuConfiguration.GetControllerActionConfigs().Each(actionConfig =>
                actionConventions.Each(conv =>
                    conv.Apply(actionConfig)));
        }

        public static void Restart()
        {
            if (_hasStarted)
            {
                ObjectFactory.ResetDefaults();
            }
            else
            {
                Bootstrap();
                _hasStarted = true;
            }

        }

        public static void Bootstrap()
        {

            new Bootstrapper().BootstrapStructureMap();
        }
    }
}