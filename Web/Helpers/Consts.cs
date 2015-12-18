namespace Web.Helpers
{
    public static class Consts
    {
        public static class MasterDocType
        {
            public const string Alias = "Master";
            public const string TitleProperty = "Title";
        }

        public static class HomeDocType
        {
            public const string Alias = "Home";
        }

        public static class SiteDocType
        {
            public const string Alias = "Site";
            public const string SiteNameProperty = "SiteName";
            public const string SpadshchynaDescriptionProperty = "SpadshchynaDescription";
            public const string SiteDescriptionProperty = "SiteDescription";
            public const string EmailProperty = "Email";
            public const string JoinOrganizationLinkProperty = "JoinOrganizationLink";
        }

        public static class NewsOverviewDocType
        {
            public const string Alias = "NewsOverview";
            public const string TitleProperty = "Title";
        }

        public static class NewsByYearDocType
        {
            public const string Alias = "NewsByYear";
        }

        public static class NewsItemDocType
        {
            public const string Alias = "NewsItem";
            public const string SubHeaderProperty = "SubHeader";
            public const string ContentProperty = "BodyText";
            public const string TitleProperty = "Title";
            public const string ImageProperty = "Image";
            public const string CategoryProperty = "Category";
            public const string TagsProperty = "Tags";
            public const string PublishDateProperty = "ReleaseDate";
        }

        public static class GalleryCategoryDocType
        {
            public const string Alias = "GalleryCategory";
        }

        public static class GalleryDocType
        {
            public const string Alias = "Gallery";
            public const string CategoryProperty = "Category";
            public const string ImagesProperty = "Images";
        }

        public static class FeaturedArticlesOverviewDocType
        {
            public const string Alias = "FeaturedArticlesOverview";
        }

        public static class FeaturedArticleDocType
        {
            public const string Alias = "FeaturedArticle";
            public const string ImageProperty = "Image";
            public const string TitleProperty = "Title";
            public const string SubtitleProperty = "Subtitle";
            public const string PageToOpenProperty = "PageToOpen";
        }

        public static class DataTypes
        {
            public const string NewsCategory = "News Category";
        }

        public static class MediaTypes
        {
            public const string Image = "Image";
            public const string Folder = "Folder";
            public const string File = "File";
        }

        public static class NewsConfig
        {
            /// <summary>
            /// How many pages to show on the pager on the left and right side from the current page
            /// </summary>
            public const int PagerInterval = 3; 
            public const int NewsPerPage = 3;

            public const string NewsCategoryAll = "Всі";
            public const int NewsCategoryAllInt = 0;
            public const string YearAll = "Всі";
            public const int YearAllInt = 0;
            public const int PageAllInt = 0;
        }

    }
}