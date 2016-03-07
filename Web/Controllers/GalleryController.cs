using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Umbraco.Web;
using Umbraco.Web.Mvc;
using Umbraco.Web.PublishedContentModels;
using Web.Helpers;
using GalleryResult = Web.Models.GalleryResult;

namespace Web.Controllers
{
    public class GalleryController : SurfaceController
    {
        [HttpPost]
        public ActionResult Index(int year, int page)
        {
            var home = Umbraco.TypedContentAtRoot().First();
            var overview = home.FirstChild<GalleryOverview>();
            var items = new List<GalleryItem>();
            var totalPagesCount = 0;
            if (overview != null)
            {
                //Filter by year
                if (year == Consts.GalleryConfig.YearAllInt)
                {
                    items = overview.Children.SelectMany(i => i.Children<GalleryItem>()).ToList();
                }
                else
                {
                    var galleryByYear = overview.Children.FirstOrDefault(i => i.Name == year.ToString());
                    if (galleryByYear != null)
                    {
                        items = galleryByYear.Children<GalleryItem>().ToList();
                    }
                }

                //Order by GalleryByYear node, then by create date
                items = items.OrderByDescending(i => i.Parent<GalleryByYear>().Name)
                    .ThenByDescending(i => i.CreateDate)
                    .ToList();

                //Filter by page 
                totalPagesCount = (int)Math.Ceiling(((double)items.Count / Consts.GalleryConfig.ItemsPerPage));
                if (page != Consts.GalleryConfig.PageAllInt)
                {
                    items = items.Skip((page - 1) * Consts.GalleryConfig.ItemsPerPage).Take(Consts.GalleryConfig.ItemsPerPage).ToList();
                }
            }

            var model = new GalleryResult
            {
                Items = items,
                Page = page,
                TotalPages = totalPagesCount
            };
            return PartialView("GalleryList", model);
        }
    }
}
