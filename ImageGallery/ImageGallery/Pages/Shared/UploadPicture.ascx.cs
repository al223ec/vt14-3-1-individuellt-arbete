using ImageGallery.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ImageGallery.Pages.Shared
{
    public partial class UploadPicture : PageBASE
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (AlbumID != null)
            {
                //TODO: sätt ett valt värde om värden har skickats med
            }
        }

        public IEnumerable<Category> CategoryDropDownList_GetData()
        {
            return Service.GetAllCategorys();
        }

        public IEnumerable<Album> AlbumCheckBoxList_GetData()
        {
            return Service.GetAllAlbums();
        }

        protected void UploadButton_Click(object sender, EventArgs e)
        {
            var items = AlbumCheckBoxList.Items;
            var cat = CategoryDropDownList.SelectedItem.Value;


            var selectedValues = AlbumCheckBoxList.Items.Cast<ListItem>().Where(li => li.Selected)
               .Select(li => li.Value).ToList();

        }
    }
}