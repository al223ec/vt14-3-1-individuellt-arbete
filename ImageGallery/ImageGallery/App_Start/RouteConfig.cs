using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace ImageGallery.App_Start
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routeCollection)
        {
            routeCollection.MapPageRoute("Default", "", "~/Pages/ImageGalleryPages/ListAlbums.aspx");

            routeCollection.MapPageRoute("ViewAlbumPictures", "album/{id}/", "~/Pages/ImageGalleryPages/ListPictures.aspx");
            routeCollection.MapPageRoute("ViewAlbumPicturesPictureID", "album/{id}/{pictureID}/", "~/Pages/ImageGalleryPages/ListPictures.aspx");

            routeCollection.MapPageRoute("ViewCategories", "categories/", "~/Pages/ImageGalleryPages/ListCategories.aspx");
            routeCollection.MapPageRoute("ViewCategoryPictures", "category/{id}/", "~/Pages/ImageGalleryPages/ListCategories.aspx");

            routeCollection.MapPageRoute("NewPicture", "", "~/Pages/ImageGalleryPages/EditPicture.aspx");

            routeCollection.MapPageRoute("Error", "serverfel", "~/Pages/Shared/Error.aspx");

            routeCollection.MapPageRoute("ListPictures", "Bilder", "~/Pages/ImageGalleryPages/ListPictures.aspx");
            routeCollection.MapPageRoute("EditPicture", "Redigerabild/{id}/{pictureID}", "~/Pages/ImageGalleryPages/EditPicture.aspx");

        }
    }
}