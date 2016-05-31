using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;

namespace Web
{
    public class AutoFacBootStrapper
    {
        public static void AutoFacInit()
        {
            var builder = new ContainerBuilder();

            //注册DomainServices
            var services = Assembly.Load("DomainServices");
            builder.RegisterAssemblyTypes(services, services)
              .Where(t => t.Name.EndsWith("Service"))
              .AsImplementedInterfaces().PropertiesAutowired();

            //实现插件Controllers注入
            var assemblies = new DirectoryInfo(
                     HttpContext.Current.Server.MapPath("~/App_Data/Plugins/"))
               .GetFiles("*.dll")
               .Select(r => Assembly.LoadFrom(r.FullName)).ToArray();
            foreach (var assembly in assemblies)
            {
                builder.RegisterControllers(assembly).PropertiesAutowired();
            }

            //注册主项目的Controllers
            builder.RegisterControllers(Assembly.GetExecutingAssembly()).PropertiesAutowired();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}