using System;
using System.Globalization;
using System.IO;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Umbraco.Forms.Web.Helpers;
using Umbraco.Web.Mvc;
using Umbraco.Web.PublishedContentModels;
using Umbraco.Web.Routing;
using Umbraco.Web.WebApi;
using Web.Helpers;

namespace Web.Controllers
{
    public class TabbedPageController : SurfaceController
    {
        #region Actions

        //[ChildActionOnly]
        //[HttpPost]
        //public ActionResult GetTabContent(int pageId)
        //{
        //    //Umbraco
        //    System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo("uk-UA", false);
        //    var page = (TextPage)ContentManager.GetPage(pageId);
        //    UmbracoContext.PublishedContentRequest =
        //        new PublishedContentRequest(Request.Url, UmbracoContext.RoutingContext);
        //    return PartialView("~/Views/Partials/TabbedPage/TabContent.cshtml", page);
        //}

        #endregion
    }
}
