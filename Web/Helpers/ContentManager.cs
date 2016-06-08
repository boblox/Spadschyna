﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Web;
using Umbraco.Web.PublishedContentModels;
using Web.Models;

namespace Web.Helpers
{
    /// <summary>
    /// Content helper
    /// </summary>
    public static class ContentManager
    {
        private static readonly UmbracoHelper UmbracoHelper = new UmbracoHelper(UmbracoContext.Current);

        #region Helpers

        #endregion

        public static AnnounceResult GetAnnounceItems(int page, int itemsPerPage)
        {
            var home = UmbracoHelper.TypedContentAtRoot().First();
            var overview = home.FirstChild<AnnouncesOverview>();
            var items = new List<AnnounceItem>();
            var totalPagesCount = 0;
            if (overview != null)
            {
                items = overview.Children<AnnounceItem>()
                  .Where(i => i.DateOfHappening.Date >= DateTime.Now.Date)
                  .OrderBy(i => i.DateOfHappening)
                  .ToList();

                //Filter by page
                totalPagesCount = (int)Math.Ceiling(((double)items.Count / itemsPerPage));
                if (page != Consts.AnnouncesConfig.PageAllInt)
                {
                    items = items.Skip((page - 1) * itemsPerPage).Take(itemsPerPage).ToList();
                }
            }

            return new AnnounceResult
            {
                Items = items,
                Page = page,
                TotalPages = totalPagesCount
            };
        }

        public static NewsResult GetNewsItems(int year, int category, int page, int itemsPerPage)
        {
            var home = UmbracoHelper.TypedContentAtRoot().First();
            var overview = home.FirstChild<NewsOverview>();
            var items = new List<NewsItem>();
            var totalPagesCount = 1;
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

                //Sort items
                items = items
                    //.OrderByDescending(i => i.Parent<NewsByYear>().Name)
                    .OrderByDescending(i => i.PublishDate != default(DateTime) ? i.PublishDate : i.CreateDate)
                    .ToList();

                //Filter by page 
                totalPagesCount = (int)Math.Ceiling(((double)items.Count / itemsPerPage));
                if (page != Consts.NewsConfig.PageAllInt)
                {
                    items = items.Skip((page - 1) * itemsPerPage).Take(itemsPerPage).ToList();
                }
            }

            return new NewsResult
            {
                Items = items,
                Page = page,
                TotalPages = totalPagesCount
            };
        }

        public static GalleryResult GetGalleryItems(int year, int page, int itemsPerPage)
        {
            var home = UmbracoHelper.TypedContentAtRoot().First();
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
                items = items
                    //.OrderByDescending(i => i.Parent<GalleryByYear>().Name)
                    .OrderByDescending(i => i.CreateDate)
                    .ToList();

                //Filter by page 
                totalPagesCount = (int)Math.Ceiling(((double)items.Count / itemsPerPage));
                if (page != Consts.GalleryConfig.PageAllInt)
                {
                    items = items.Skip((page - 1) * itemsPerPage).Take(itemsPerPage).ToList();
                }
            }

            return new GalleryResult
            {
                Items = items,
                Page = page,
                TotalPages = totalPagesCount
            };
        }
    }
}