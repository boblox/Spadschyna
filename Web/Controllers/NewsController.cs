using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Logic.Models;
using Umbraco.Core;
using Umbraco.Core.Models;
using Umbraco.Web;
using Umbraco.Web.Mvc;
using Web.Helpers;

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
            var newsOverview = home.Children
                .FirstOrDefault(i => i.DocumentTypeAlias == Consts.NewsOverviewDocType.Alias);
            var news = new List<IPublishedContent>();
            int totalPagesCount = 0;
            if (newsOverview != null)
            {
                //Filter by year
                if (year == Consts.NewsConfig.YearAllInt)
                {
                    news = newsOverview.Children.SelectMany(i => i.Children).ToList();
                }
                else
                {
                    var newsByYear = newsOverview.Children.FirstOrDefault(i => i.Name == year.ToString());
                    if (newsByYear != null)
                    {
                        news = newsByYear.Children.ToList();
                    }
                }

                //Order by create date
                news = news.OrderBy("createDate desc").ToList();

                //Filter by category
                if (category != Consts.NewsConfig.NewsCategoryAllInt)
                {
                    var newsCategories = Utils.GetDataTypePreValues(Consts.DataTypes.NewsCategory).ToList();
                    var categoryStr = newsCategories.First(i => i.Id == category).Value;
                    news = news.Where(i => 
                        i.GetPropertyValue<string>(Consts.NewsItemDocType.CategoryProperty).Equals(categoryStr, StringComparison.InvariantCultureIgnoreCase))
                        .ToList();
                }

                //Filter by page 
                totalPagesCount = (int)Math.Ceiling(((double)news.Count / Consts.NewsConfig.NewsPerPage));
                if (page != 0)
                {
                    news = news.Skip((page - 1) * Consts.NewsConfig.NewsPerPage).Take(Consts.NewsConfig.NewsPerPage).ToList();
                }
            }

            var model = new NewsResult
            {
                News = news,
                Page = page,
                TotalPages = totalPagesCount
            };
            return PartialView("NewsList", model);
        }

        #endregion
    }
}
