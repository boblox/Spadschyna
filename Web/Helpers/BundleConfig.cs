using System.Web.Optimization;

namespace Web.Helpers
{
    public static class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            var orderer = new NonOrderingBundleOrderer();

            //Basic Js&Css============================================================
            var styleBundle = new StyleBundle("~/css/basic-css")
                .Include("~/css/jquery-ui.min.css")
                .Include("~/css/magnific-popup.css")
                .Include("~/css/styles.min.css");
            styleBundle.Orderer = orderer;
            bundles.Add(styleBundle);

            var scriptBundle = new ScriptBundle("~/js/basic-js")
                .Include("~/js/jquery.min.js")
                .Include("~/js/bootstrap.min.js")
                .Include("~/js/jquery-ui.min.js")
                .Include("~/js/jquery.validate.min.js")
                .Include("~/js/jquery.validate.unobtrusive.min.js")
                .Include("~/js/jquery.unobtrusive-ajax.min.js")
                .Include("~/js/imagesloaded.pkgd.min.js")
                .Include("~/js/masonry.pkgd.min.js")
                .Include("~/js/jquery.unveil.js")
                .Include("~/js/magnific.popup.min.js")
                .Include("~/js/director.min.js")
                .Include("~/scripts/utils.js")
                .Include("~/scripts/config.js");
            scriptBundle.Orderer = orderer;
            bundles.Add(scriptBundle);

            //Magnific Pop-Up=========================================================
            //styleBundle = new StyleBundle("~/css/magnific-popup-css")
            //    .Include("~/css/magnific-popup.css");
            //styleBundle.Orderer = orderer;
            //bundles.Add(styleBundle);

            //scriptBundle = new ScriptBundle("~/js/magnific-popup-js")
            //    .Include("~/js/magnific.popup.min.js");
            //scriptBundle.Orderer = orderer;
            //bundles.Add(scriptBundle);

            //Owl Carousel ===========================================================
            styleBundle = new StyleBundle("~/css/OwlCarousel/carousel-css")
                .Include("~/css/OwlCarousel/owl.carousel.css")
                .Include("~/css/OwlCarousel/owl.theme.green.css");
            styleBundle.Orderer = orderer;
            bundles.Add(styleBundle);

            scriptBundle = new ScriptBundle("~/js/carousel-js")
                .Include("~/js/owl.carousel.min.js");
            scriptBundle.Orderer = orderer;
            bundles.Add(scriptBundle);

            //BundleTable.EnableOptimizations = false;
        }
    }
}