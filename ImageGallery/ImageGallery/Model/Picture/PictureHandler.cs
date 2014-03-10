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
        public void CreateThumbNails(IEnumerable<Picture> picturesInGallery)
        {
            foreach (var picture in picturesInGallery)
            {
                if (!File.Exists(picture.GetFullThumbnailPath()))
                {
                    if (File.Exists(picture.GetFullImagePath())) //Kontrollerar att filen finns innan den används
                    {
                        var thumbnail = System.Drawing.Image.FromFile(picture.GetFullImagePath()).GetThumbnailImage(120, 90, null, System.IntPtr.Zero);
                        thumbnail.Save(picture.GetFullThumbnailPath());
                    }
                }
            }
        }

        private bool IsValidImage(Image image)
        {
            return image.RawFormat.Guid == System.Drawing.Imaging.ImageFormat.Gif.Guid ||
                    image.RawFormat.Guid == System.Drawing.Imaging.ImageFormat.Jpeg.Guid ||
                    image.RawFormat.Guid == System.Drawing.Imaging.ImageFormat.Png.Guid;
        }

        private void CreateThumbnail(Image image, Picture pic)
        {
            if (File.Exists(pic.GetFullImagePath())) //Kontrollerar att filen finns innan den används
            {
                var thumbnail = System.Drawing.Image.FromFile(pic.GetFullImagePath()).GetThumbnailImage(60, 45, null, System.IntPtr.Zero);
                thumbnail.Save(pic.GetFullThumbnailPath());
            }
        }

        public void SaveImage(Stream stream, Picture pic)
        {
            var newImage = Image.FromStream(stream); //Kastas ett undatag om filen som laddas upp inte är en bild

            if (IsValidImage(newImage))
            {
                var path = pic.GetFullImagePath();
                var numOfExistingImages = 1;

                while (File.Exists(path))
                {
                    path = Path.Combine(pic.GetPath(), string.Format("{0}{1}{2}", pic.Name, string.Format("({0})", numOfExistingImages), pic.Extension));
                    numOfExistingImages++;
                }

                //TODO: Vart borde jag göra detta egentligen??? 
                pic.Name = Path.GetFileNameWithoutExtension(path); //Sparar det aktuella namnet 
                pic.Extension = Path.GetExtension(path);
                newImage.Save(path);
                CreateThumbnail(newImage, pic);
            }
            else
            {
                //TODO: Filen är inte av rätt typ
            }
        }

        ////public void UpdateImage(Stream stream, Picture pic)
        ////{
        ////    var newImage = Image.FromStream(stream); //Kastas ett undatag om filen som laddas upp inte är en bild

        ////    if (IsValidImage(newImage))
        ////    {
        ////        var path = pic.GetFullImagePath();

        ////        pic.Extension = Path.GetExtension(path);
        ////        newImage.Save(path);
        ////        CreateThumbnail(newImage, pic);
        ////    }
        ////}


        public void UpdateExistingImage(Picture pic, Picture oldPicture)
        {
            throw new NotImplementedException(); 
            //Skulle kunna kontrollera namnet mot databasen att det endast får finnas unika namn
            //TODO: Fixa UpdateExistingImage
            //var s = File.Create(oldPicture.GetFullImagePath());
            //using (var stream = File.Open(oldPicture.GetFullImagePath(), FileMode.Open))
            //{
            //    SaveImage(stream, pic);
            //}

            //DeleteImage(oldPicture);
            //TODO: Fixa UpdateExistingImage File.Exists            if (File.Exists(pic.GetFullImagePath())
            //File.Move(oldPicture.GetFullImagePath(), pic.GetFullImagePath());
            //File.Move(oldPicture.GetFullThumbnailPath(), pic.GetFullThumbnailPath());
        }

        public void DeleteImage(Picture pic)
        {
            //TODO:Fixa try catch samt testa
            if (File.Exists(pic.GetFullImagePath()))
            {
                File.Delete(pic.GetFullImagePath());
            }
            if (File.Exists(pic.GetFullThumbnailPath()))
            {
                File.Delete(pic.GetFullThumbnailPath());
            }
        }
    }
}