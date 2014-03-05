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
        public int? PictureID { get; set; } //Om denna är set kommer denna class användas som edit också

        protected void Page_Load(object sender, EventArgs e)
        {
            if (AlbumID != null)
            {
                //TODO: sätt ett förvalt värde om värden har skickats med
            }
            if (PictureID != null)
            {
                //TODO: Hämta aktuell bild och sätt värden
                Service.GetPicture((int)PictureID);
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
            Page.Validate();
            if (Page.IsValid)
            {
                //Validering,
                if (ImageFileUpload.PostedFile.ContentLength != 0)
                {
                    PictureExtensions.SaveImage(ImageFileUpload.PostedFile.InputStream, ImageFileUpload.PostedFile.FileName);
                }
                else
                {
                    throw new ApplicationException("Ingen fil är vald"); 
                   
                }
                var picture = new Picture
                {
                    Name = NameTextBox.Text,
                    CategoryID = int.Parse(CategoryDropDownList.SelectedItem.Value)
                };

                var selectedValues = AlbumCheckBoxList.Items.Cast<ListItem>().Where(li => li.Selected)
                   .Select(li => li.Value).ToList();
                Service.AddPicture(picture, selectedValues); 
            }
        }
    }
}