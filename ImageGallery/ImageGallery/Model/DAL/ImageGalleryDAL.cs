using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ImageGallery.Model.DAL
{
    public class ImageGalleryDAL : DALBase
    {
        /// <summary>
        /// Hämtar alla poster i databasen
        /// </summary>
        /// <returns>IEnumberable med samtilga poster som picture object</returns>
        public IEnumerable<Picture> GetAllPictures()
        {
            // Skapar och initierar ett anslutningsobjekt.
            using (var conn = CreateConnection())
            {
                var pictures = new List<Picture>(100);
                var cmd = new SqlCommand("AppSchema.usp_GetAllPictures", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    var pictureIDIndex = reader.GetOrdinal("PictureID");
                    var nameIndex = reader.GetOrdinal("Name");
                    var dateIndex = reader.GetOrdinal("Date");
                    var categoryIDIndex = reader.GetOrdinal("CategoryID");

                    while (reader.Read())
                    {
                        pictures.Add(new Picture
                        {
                            PictureID = reader.GetInt32(pictureIDIndex),
                            Name = reader.GetString(nameIndex),
                            Date = reader.GetDateTime(dateIndex),
                            CategoryID = reader.GetInt32(categoryIDIndex)
                        });
                    }
                }
                pictures.TrimExcess();
                return pictures;
            }
        }
    }
}