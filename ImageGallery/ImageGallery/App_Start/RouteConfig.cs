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
            routeCollection.MapPageRoute("Default", "", "~/Pages/ImageGalleryPages/Default.aspx");
        }
    }
}