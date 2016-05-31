using System.Web.Mvc;
using System.Web.Routing;


namespace Plugin.Demo
{
    public class DemoPlugin :IPlugin
    {
        public string Name
        {

            get
            {
                return "Demo";
            }
        }

        public void Initialize()
        {
            var route = RouteTable.Routes.MapRoute(
                name: this.Name,
                url: this.Name + "/{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional, pluginName = this.Name }
            );

            route.DataTokens["area"] = this.Name;//设置area的值为Plugin.Name
        }

        public virtual void Unload()
        {
            RouteTable.Routes.Remove(RouteTable.Routes[this.Name]);
        }
    }
}