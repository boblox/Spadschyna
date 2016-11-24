using System.Web.Mvc;
using Umbraco.Web.Mvc;
using Web.Helpers;

namespace Web.Controllers
{
    public class AnnounceController : SurfaceController
    {
        #region Actions

        //[ChildActionOnly]
        [HttpPost]
        public ActionResult Index(int page, int itemsPerPage)
        {
            //System.Threading.Thread.Sleep(1000);

            var model = ContentManager.GetAnnounceItems(page, itemsPerPage);
            return PartialView("~/Views/Partials/Announce/AnnouncesList.cshtml", model);
        }

        #endregion
    }
}
