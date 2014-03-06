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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="albumID"></param>
        /// <returns></returns>
        public IEnumerable<Picture> GetAllPicturesFromAlbum(int albumID)
        {
            using (SqlConnection conn = CreateConnection())
            {

                var pictures = new List<Picture>(100);
                SqlCommand cmd = new SqlCommand("AppSchema.usp_GetAllPicturesFromAlbum", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@AlbumID", SqlDbType.Int, 4).Value = albumID;

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

        /// <summary>
        /// Hämtar en bild med hjälp av ett ID
        /// </summary>
        /// <param name="pictureID"></param>
        /// <returns></returns>
        public Picture GetPicture(int pictureID)
        {
            using (SqlConnection conn = CreateConnection())
            {
                SqlCommand cmd = new SqlCommand("AppSchema.usp_GetPicture", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@PictureID", SqlDbType.Int, 4).Value = pictureID;

                conn.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    var pictureIDIndex = reader.GetOrdinal("PictureID");
                    var nameIndex = reader.GetOrdinal("Name");
                    var dateIndex = reader.GetOrdinal("Date");
                    var categoryIDIndex = reader.GetOrdinal("CategoryID");

                    if (reader.Read())
                    {
                        return new Picture
                        {
                            PictureID = reader.GetInt32(pictureIDIndex),
                            Name = reader.GetString(nameIndex),
                            Date = reader.GetDateTime(dateIndex),
                            CategoryID = reader.GetInt32(categoryIDIndex)
                        };
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Lägga till en bild utan tillhörande album
        /// </summary>
        /// <param name="picture">Picture objekt</param>
        public void AddPicture(Picture picture)
        {
            throw new NotImplementedException();
        }
        
        /// <summary>
        /// Lägger till en ny bild till ett album,
        /// </summary>
        /// <param name="picture"></param>
        /// <param name="albumID"></param>
        public void AddPictureToAlbum(Picture picture, int albumID)
        {
            using (SqlConnection conn = CreateConnection())
            {
                SqlCommand cmd = new SqlCommand("appSchema.usp_AddPictureToAlbum", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@PictureID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;

                cmd.Parameters.Add("@Name", SqlDbType.VarChar, 50).Value = picture.Name;
                cmd.Parameters.Add("@CategoryID", SqlDbType.Int, 4).Value = picture.CategoryID;
                cmd.Parameters.Add("@Date", SqlDbType.DateTime).Value = picture.Date;
                cmd.Parameters.Add("@Extension", SqlDbType.VarChar, 6).Value = picture.Extension;

                cmd.Parameters.Add("@AlbumID", SqlDbType.Int, 4).Value = albumID;
                conn.Open();

                cmd.ExecuteNonQuery();

                picture.PictureID = (int)cmd.Parameters["@PictureID"].Value; //Den nya pictureID:et
            }
        }

        /// <summary>
        /// Lägger till en existerande bild till ett album
        /// </summary>
        /// <param name="pictureID"></param>
        /// <param name="albumID"></param>
        public void AddExistingPictureToAlbum(int pictureID, int albumID)
        {
            using (SqlConnection conn = CreateConnection())
            {
                SqlCommand cmd = new SqlCommand("appSchema.usp_AddExistingPictureToAlbum", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@PictureID", SqlDbType.Int, 4).Value = pictureID;
                cmd.Parameters.Add("@AlbumID", SqlDbType.Int, 4).Value = albumID;

                conn.Open();

                cmd.ExecuteNonQuery();
            }
        }
        /// <summary>
        /// Uppdaterar en existerande bild med hjälp av ett picture objekt
        /// </summary>
        /// <param name="picture">Ett existerande picture objekt</param>
        public void UpdatePicture(Picture picture)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Tar bort en bild med hjälp av ett bildID
        /// </summary>
        /// <param name="pictureID"></param>
        public void DeletePicture(int pictureID)
        {
            using (SqlConnection conn = CreateConnection())
            {
                SqlCommand cmd = new SqlCommand("appSchema.usp_DeletePicture", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@PictureID", SqlDbType.Int, 4).Value = pictureID;

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

    }
}