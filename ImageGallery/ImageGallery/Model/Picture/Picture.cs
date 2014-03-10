using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ImageGallery.Model
{
    public class Picture : PictureBase, ICloneable
    {
        public int PictureID { get; set; }

        [Required(ErrorMessage = "Bilden måste ha ett namn")]
        [StringLength(35, ErrorMessage = "Bildnamnet kan som mest bestå av 35 tecken.")]
        public override string Name { get; set; }

        [Required]
        public int CategoryID { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Bilden måste ha en filändelse")]
        [StringLength(6, ErrorMessage = "Filändelsen kan som mest bestå av 6 tecken.")]
        public override string Extension { get; set; }

        public Picture()
        {
            Date = DateTime.Today; //default värden 
            Extension = ".jpg";
        }

        public object Clone()
        {
            return new Picture
            {
                PictureID = 0, //Får inte finnas 2 bilder med samma id!!
                Name = this.Name,
                CategoryID = this.CategoryID,
                Date = this.Date,
                Extension = this.Extension
            };
        }
    }
}