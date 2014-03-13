using ImageGallery.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ImageGallery.Pages.Shared
{
    public partial class UploadPicture : PageBASE
    {
        public int? PictureID { get; set; }
        private Picture CurrentPicture { get; set; }
        //Om denna är set kommer denna class användas som edit också

        public FormViewMode ViewMode
        {
            get { return UploadFormView.DefaultMode; }
            set { UploadFormView.DefaultMode = value; }
        }
        //i förlängningen en referens till valt ablumID
        private RadioButtonList RBL { get; set; }
        private FileUpload FUL { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (PictureID != null)
            {
                CurrentPicture = Service.GetPicture((int)PictureID);
                if (CurrentPicture != null)
                {
                    MainImage.ImageUrl = CurrentPicture.GetImagePath; //Änvänder jag bilden här kan jag inte redigera den, byta namn e
                    MainImage.Visible = true;
                }
                ViewMode = FormViewMode.Edit;
                titleLiteral.Text = "Redigera Bild";
            }
        }

        public IEnumerable<Category> CategoryDropDownList_GetData() { return Service.GetAllCategorys(); }
        public IEnumerable<Album> AlbumRadioButtonList_GetData() { return Service.GetAllAlbums(); }

        /// <summary>
        /// Binder data till album Radio button listan
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void AlbumRadioButtonList_DataBound(object sender, EventArgs e)
        {
            var rbl = sender as RadioButtonList;
            if (rbl != null && AlbumID != null)
            {
                RBL = rbl;
                for (int i = 0; i < rbl.Items.Count; i++)
                {
                    if (int.Parse(rbl.Items[i].Value) == AlbumID)
                    {
                        rbl.Items[i].Selected = true;
                    }
                }
            }
        }

        // The id parameter should match the DataKeyNames value set on the control
        // or be decorated with a value provider attribute, e.g. [QueryString]int id
        public Picture UploadFormView_GetItem([RouteData]int pictureID)
        {
            return Service.GetPicture(pictureID);
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void UploadFormView_UpdateItem(int pictureID)
        {
            try
            {
                Page.Validate();
                if (!Page.IsValid)
                {
                    return;
                }
                Picture picture = Service.GetPicture(pictureID);
                if (picture == null)
                {
                    // The item wasn't found
                    Page.ModelState.AddModelError("", String.Format("Item with id {0} was not found", pictureID));
                    return;
                }
                if (Page.TryUpdateModel(picture))
                {
                    if (AlbumID != null)
                    {
                        if (AlbumID == int.Parse(RBL.SelectedValue)) //Nytt album inte satt
                        {
                            Service.UpdatePicture(picture);
                        }
                        else
                        {
                            //Användaren har uppdaterat bildens tillhörande album. 
                            Service.AddPictureToAlbum(picture, int.Parse(RBL.SelectedValue));
                        }
                        Session["successfull"] = "Uppdateringen lyckades";
                        Response.RedirectToRoute("ViewAlbumPictures", new { id = AlbumID });
                    }
                    else
                    {
                        Page.ModelState.AddModelError("", String.Format("Inget album är angivet!!!"));
                    }
                }
            }
            catch (PictureExistsInAlbumException)
            {
                Page.ModelState.AddModelError("", String.Format("Bilden finns redan i det aktuella ablummet!!!"));
            }
        }

        public void UploadFormView_InsertItem()
        {
            Page.Validate();
            if (!Page.IsValid)
            {
                return;
            }
            if (FUL.PostedFile.ContentLength != 0)
            {
                var picture = new Picture();
                picture.PictureFileName += Path.GetExtension(FUL.FileName);

                Page.TryUpdateModel(picture);
                if (Page.ModelState.IsValid)
                {
                    //TODO: Klickar man två ggr på ladda upp väldigt snabbt blir det två poster
                    Service.AddPictureToAlbum(picture, int.Parse(RBL.SelectedValue), FUL.PostedFile.InputStream);
                    Session["successfull"] = "Uppladdningen lyckades!";
                    Response.RedirectToRoute("ViewAlbumPictures", new { id = AlbumID });
                }
            }
            else
            {
                Page.ModelState.AddModelError("", String.Format("Du måsta välja en bild att ladda upp!!!"));
            }
        }

        /// <summary>
        /// Sparar en referens till fileupload objektet
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ImageFileUpload_DataBinding(object sender, EventArgs e)
        {
            var fileUpload = sender as FileUpload;
            if (fileUpload != null)
            {
                FUL = fileUpload;
            }
        }
    }
}