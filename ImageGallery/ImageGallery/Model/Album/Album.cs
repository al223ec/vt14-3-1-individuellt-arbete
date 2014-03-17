using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ImageGallery.Model
{
    public class Album
    {
        public int AlbumID { get; set; }

        [Required(ErrorMessage = "Ett album måste ha ett namn")]
        [StringLength(35, ErrorMessage = "Albumnamnet kan som mest bestå av 35 tecken.")]
        public string Name { get; set; }

        [Required]
        public DateTime Date { get; set;  } //Date kommer databasen lösa, när man skapade albumet
    }
}