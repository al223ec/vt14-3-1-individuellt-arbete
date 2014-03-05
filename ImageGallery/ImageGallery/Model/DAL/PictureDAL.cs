using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ImageGallery.Model.DAL
{
    public class PictureDAL : DALBase
    {
        /// <summary>
        /// Hämtar alla poster i tabellen pictures
        /// </summary>
        /// <returns>IEnumberable med samtliga poster som picture object</returns>
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
                    var extensionIndex = reader.GetOrdinal("Extension");

                    while (reader.Read())
                    {
                        pictures.Add(new Picture
                        {
                            PictureID = reader.GetInt32(pictureIDIndex),
                            Name = reader.GetString(nameIndex),
                            Date = reader.GetDateTime(dateIndex),
                            CategoryID = reader.GetInt32(categoryIDIndex),
                            Extension = reader.GetString(extensionIndex),
                        });
                    }
                }
                pictures.TrimExcess();
                return pictures;
            }
        }

        public IEnumerable<Picture> GetAllPicturesFromAlbum(int albumID)
        {
            // Skapar ett anslutningsobjekt.
            using (SqlConnection conn = CreateConnection())
            {

                var pictures = new List<Picture>(100);
                SqlCommand cmd = new SqlCommand("AppSchema.usp_GetAllPicturesFromAlbum", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@AlbumID", SqlDbType.Int, 4).Value = albumID;

                // Öppnar anslutningen till databasen.
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
                return pictures;
            }
        }
    }
}