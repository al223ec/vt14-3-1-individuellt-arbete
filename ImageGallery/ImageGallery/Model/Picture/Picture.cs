using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Web;

namespace ImageGallery.Model
{
    public class Picture : PictureBase, ICloneable
    {
        public int PictureID { get; set; }

        [Required(ErrorMessage = "Bilden måste ha ett namn")]
        [StringLength(35, ErrorMessage = "Bildnamnet kan som mest bestå av 35 tecken.")]
        public string Name { get; set; }

        [Required]
        public int CategoryID { get; set; }

        [Required]
        public DateTime Date { get; set; }
        
        [Required(ErrorMessage = "Filen måste ha ett namn")]
        [StringLength(20, ErrorMessage = "Filens namn får inte vara mer än 20 tecken")]
        [RegularExpression("[^\\s]+(\\.(?i)(jpg|png|gif))$",
            ErrorMessage = "Filen verkar inte vara av rätt typ, Picture")]
        public override string PictureFileName { get; set; }

        public Picture()
        {
            Date = DateTime.Today; //default värden 
            PictureFileName = Path.GetFileNameWithoutExtension(Path.GetRandomFileName());
        }

        public object Clone()
        {
            return new Picture
            {
                PictureID = 0, //Får inte finnas 2 bilder med samma id!!
                Name = this.Name,
                CategoryID = this.CategoryID,
                Date = this.Date,
                PictureFileName = this.PictureFileName
            };
        }
    }
}