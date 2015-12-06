using System.Web.Mvc;
using Umbraco.Web.Mvc;

namespace Web.Controllers
{
    public class NewsController : SurfaceController
    {
        #region Actions

        //[ChildActionOnly]
        //public JsonResult Index(string year, string category, int page)
        [HttpPost]
        public JsonResult Index(int year, int category, int page)
        {
            var success = true;
            return Json(new { year, category, page });
        }

        #endregion
    }
}
