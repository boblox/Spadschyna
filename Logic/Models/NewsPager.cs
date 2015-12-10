using Umbraco.Web;
using Umbraco.Web.Models;

namespace Logic.Models
{
    public class NewsPager //: RenderModel
    {
        //public NewsPager()
        //    : base(UmbracoContext.Current.PublishedContentRequest.PublishedContent)
        //{
        //}

        public int Page { get; set; }

        public int TotalPages { get; set; }
    }
}
