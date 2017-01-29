using System.Web.Mvc;
using System.Web.Routing;
using Sitecore.Pipelines;

namespace VRRE.Pipelines
{
    public class RegisterWebApiRoutes
    {
        public void Process(PipelineArgs args)
        {
            RouteTable.Routes.MapMvcAttributeRoutes();
            RouteTable.Routes.MapRoute(name: "Api", url: "api/{controller}/{action}");
        }
    }
}