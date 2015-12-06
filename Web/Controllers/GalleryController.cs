using System;
using System.Linq;
using System.Web.Mvc;
using Logic.Models;
using umbraco;
using Umbraco.Web;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;
using Web.Helpers;

namespace Web.Controllers
{
    public class GalleryController : RenderMvcController
    {
        public override ActionResult Index(RenderModel model)
        {
            var subGalleries = CurrentPage.Children.Where(i => i.DocumentTypeAlias == Consts.GalleryCategoryDocType.Alias);
            var gallery = new Gallery();
            foreach (var subGallery in subGalleries)
            {
                var category = subGallery.GetPropertyValue<string>(Consts.GalleryDocType.CategoryProperty);
                var mediaStr = subGallery.GetPropertyValue<string>(Consts.GalleryDocType.ImagesProperty);
                var mediaIds = mediaStr.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                var media = Umbraco.TypedMedia(mediaIds).ToList();
                //check for folders
                var folders = media.Where(i => i.DocumentTypeAlias == Consts.MediaTypes.Folder).ToList();
                folders.ForEach(i => media.Remove(i));
                media.AddRange(folders.SelectMany(i => i.Children.Where(j => j.DocumentTypeAlias == Consts.MediaTypes.Image)));

                gallery.Media.AddRange(media.Select(i => new CategorizedMedia
                {
                    Media = i,
                    Category = category.ToLower()
                }));
            }
            gallery.Media = gallery.Media.RandomOrder().ToList(); //chaoticly order images

            return CurrentTemplate(gallery);
        }
    }
}
