using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace ImageGallery.Model
{
    public class PictureHandler
    {
        private bool IsValidImage(Image image)
        {
            return image.RawFormat.Guid == System.Drawing.Imaging.ImageFormat.Gif.Guid ||
                    image.RawFormat.Guid == System.Drawing.Imaging.ImageFormat.Jpeg.Guid ||
                    image.RawFormat.Guid == System.Drawing.Imaging.ImageFormat.Png.Guid;
        }

        private void CreateThumbnail(Picture pic)
        {
            using (var thumbnail = System.Drawing.Image.FromFile(pic.GetFullImagePath()).GetThumbnailImage(160, 120, null, System.IntPtr.Zero))
            {
                thumbnail.Save(pic.GetFullThumbnailPath());
            }
        }

        public void SavePictureToFile(Picture pic, Stream stream)
        {
            if (stream == null)
            {
                throw new ArgumentNullException("Strömmen är null, det får den inte vara");
            }
            using (var newImage = Image.FromStream(stream)) //Kastas ett undatag om filen som laddas upp inte är en bild
            {
                if (IsValidImage(newImage))
                {
                    newImage.Save(pic.GetFullImagePath());
                    CreateThumbnail(pic);
                }
                else
                {
                    throw new ArgumentNullException("Filen är inte av rätt typ!! Gif, Jpeg eller png");
                }
            }

        }

        public void DeletePictureFile(Picture pic)
        {
            //TODO:Fixa try catch samt testa, funkar inte om bilden tillhör flera album, får processen är upptagen!
            //Föredrar egent att ha alla try catcher i service classen
            File.Delete(pic.GetFullImagePath());
            File.Delete(pic.GetFullThumbnailPath());
        }
        public bool StreamIsValid(Stream stream)
        {
            using (var newImage = Image.FromStream(stream)) //Kastas ett undatag om filen som laddas upp inte är en bild
            {
                return IsValidImage(newImage);
            }
        }
    }
}