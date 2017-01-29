using System.Web.Mvc;
using Sitecore.Mvc.Presentation;
using VRRE.Models;
using System.Web;

namespace VRRE.Controllers
{
    [RoutePrefix("forms")]
    public class SearchController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Submit(Search model)
        {
            ViewData["query"] = model;
            return (ActionResult)this.View(PageContext.Current.PageView);
        }

        [Route("searchcomponent_form")]
        public PartialViewResult Form(Search model)
        {
            return PartialView("~/Views/Sublayouts/search_Form.cshtml", model);
        }

        [Route("searchcomponent_presult")]
        public PartialViewResult Result(Search model)
        {
            return PartialView("~/Views/Sublayouts/propertyResult.cshtml", model);
        }
    }
}