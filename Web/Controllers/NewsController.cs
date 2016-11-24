using System.Web.Mvc;
using Umbraco.Web.Mvc;
using Web.Helpers;

namespace Web.Controllers
{
    public class NewsController : SurfaceController
    {
        #region Actions

        //[ChildActionOnly]
        [HttpPost]
        public ActionResult Index(int year, int page, int itemsPerPage)
        {
            //System.Threading.Thread.Sleep(1000);

            var model = ContentManager.GetNewsItems(year, page, itemsPerPage);
            return PartialView("~/Views/Partials/News/NewsList.cshtml", model);
        }

        #endregion
    }
}
