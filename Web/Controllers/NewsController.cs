using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Umbraco.Web;
using Umbraco.Web.Mvc;
using Umbraco.Web.PublishedContentModels;
using Web.Helpers;
using NewsResult = Web.Models.NewsResult;

namespace Web.Controllers
{
    public class NewsController : SurfaceController
    {
        #region Helpers

        private static List<NewsItem> SortNews(IEnumerable<NewsItem> items)
        {
            //Order by NewsByYear node, then by publish or create date
            return items.OrderByDescending(i => i.Parent<NewsByYear>().Name)
                    .ThenByDescending(i => i.PublishDate != default(DateTime) ? i.PublishDate : i.CreateDate)
                    .ToList();
        }

        #endregion

        #region Actions

        //[ChildActionOnly]
        [HttpPost]
        public ActionResult Index(int year, int category, int page, int itemsPerPage)
        {
            //System.Threading.Thread.Sleep(1000);

            var model = ContentManager.GetNewsItems(year, category, page, Consts.NewsConfig.ItemsPerPageOnOverviewPage);
            return PartialView("NewsList", model);
        }

        [ChildActionOnly]
        public ActionResult GetRelatedNews(int id)
        {
            var home = Umbraco.TypedContentAtRoot().First();
            var overview = home.FirstChild<NewsOverview>();
            var items = SortNews(overview.Children.SelectMany(i => i.Children<NewsItem>()));
            var index = items.FindIndex(i => i.Id == id);
            NewsItem prev = null, next = null;
            if (index >= 1)
            {
                next = items[index - 1];
            }
            if (index <= items.Count - 2)
            {
                prev = items[index + 1];
            }
            var model = new[] { prev, next };
            return PartialView("RelatedNews", model);
        }

        #endregion
    }
}
