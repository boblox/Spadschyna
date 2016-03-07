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
        #region Actions

        //[ChildActionOnly]
        //public JsonResult Index(string year, string category, int page)
        [HttpPost]
        public ActionResult Index(int year, int category, int page)
        {
            var home = Umbraco.TypedContentAtRoot().First();
            var overview = home.FirstChild<NewsOverview>();
            var items = new List<NewsItem>();
            int totalPagesCount = 0;
            if (overview != null)
            {
                //Filter by year
                if (year == Consts.NewsConfig.YearAllInt)
                {
                    items = overview.Children.SelectMany(i => i.Children<NewsItem>()).ToList();
                }
                else
                {
                    var newsByYear = overview.Children.FirstOrDefault(i => i.Name == year.ToString());
                    if (newsByYear != null)
                    {
                        items = newsByYear.Children<NewsItem>().ToList();
                    }
                }

                //Order by NewsByYear node, then by create date
                items = items.OrderByDescending(i => i.Parent<NewsByYear>().Name)
                    .ThenByDescending(i => i.PublishDate != default(DateTime) ? i.PublishDate : i.CreateDate)
                    .ToList();

                //Filter by category
                if (category == Consts.NewsConfig.NewsCategoryAnnounceInt)
                {
                    items = items.Where(i => i.IsAnnounce).ToList();
                }
                else if (category != Consts.NewsConfig.NewsCategoryAllInt)
                {
                    var newsCategories = Utils.GetDataTypePreValues(NewsItem.GetModelPropertyType(i => i.Category).DataTypeId).ToList();
                    var categoryStr = newsCategories.First(i => i.Id == category).Value;
                    items = items.Where(i =>
                        ((string)i.Category).Equals(categoryStr, StringComparison.InvariantCultureIgnoreCase))
                        .ToList();
                }

                //Filter by page 
                totalPagesCount = (int)Math.Ceiling(((double)items.Count / Consts.NewsConfig.NewsPerPage));
                if (page != Consts.NewsConfig.PageAllInt)
                {
                    items = items.Skip((page - 1) * Consts.NewsConfig.NewsPerPage).Take(Consts.NewsConfig.NewsPerPage).ToList();
                }
            }

            var model = new NewsResult
            {
                Items = items,
                Page = page,
                TotalPages = totalPagesCount
            };
            return PartialView("NewsList", model);
        }

        #endregion
    }
}
