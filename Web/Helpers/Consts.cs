namespace Web.Helpers
{
    public static class Consts
    {
        public static class HomeDocType
        {
            public static string Alias = "Home";
        }

        public static class NewsOverviewDocType
        {
            public static string Alias = "NewsOverview";
            public static string TitleProperty = "Title";
        }

        public static class NewsByYearDocType
        {
            public static string Alias = "NewsByYear";
        }

        public static class NewsItemDocType
        {
            public static string Alias = "NewsItem";
            public static string TitleProperty = "Title";
            public static string ImageProperty = "Image";
        }

        public static class GalleryCategoryDocType
        {
            public static string Alias = "GalleryCategory";
        }

        public static class GalleryDocType
        {
            public static string Alias = "Gallery";
            public static string CategoryProperty = "Category";
            public static string ImagesProperty = "Images";
        }

        public static class FeaturedArticlesOverviewDocType
        {
            public static string Alias = "FeaturedArticlesOverview";
        }

        public static class FeaturedArticleDocType
        {
            public static string Alias = "FeaturedArticle";
            public static string ImageProperty = "Image";
            public static string TitleProperty = "Title";
            public static string SubtitleProperty = "Subtitle";
            public static string PageToOpenProperty = "PageToOpen";
        }

        public static class DataTypes
        {
            public static string NewsCategory = "News Category";
        }

        public static class MediaTypes
        {
            public static string Image = "Image";
            public static string Folder = "Folder";
            public static string File = "File";
        }

        public static string NewsCategoryAll = "Всі";
        public static int NewsCategoryAllInt = 0;
        public static string YearAll = "Всі";
        public static int YearAllInt = 0;
    }
}