﻿using System;
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
                try
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
                        var fileNameIndex = reader.GetOrdinal("PictureFileName"); 

                        while (reader.Read())
                        {
                            pictures.Add(new Picture
                            {
                                PictureID = reader.GetInt32(pictureIDIndex),
                                Name = reader.GetString(nameIndex),
                                Date = reader.GetDateTime(dateIndex),
                                CategoryID = reader.GetInt32(categoryIDIndex),
                                PictureFileName = reader.GetString(fileNameIndex)
                            });
                        }
                    }
                    pictures.TrimExcess();
                    return pictures;
                }
                catch (Exception)
                {
                    throw new ApplicationException(StandardMSsqlErrorMessage); 
                }
            }
        }

        /// <summary>
        /// Returnerar samtliga bilder från ett angivet album
        /// </summary>
        /// <param name="albumID">AlbumetsID</param>
        /// <returns>Picture objekt</returns>
        public IEnumerable<Picture> GetAllPicturesFromAlbum(int albumID)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
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
                        var fileNameIndex = reader.GetOrdinal("PictureFileName"); 

                        while (reader.Read())
                        {
                            pictures.Add(new Picture
                            {
                                PictureID = reader.GetInt32(pictureIDIndex),
                                Name = reader.GetString(nameIndex),
                                Date = reader.GetDateTime(dateIndex),
                                CategoryID = reader.GetInt32(categoryIDIndex),
                                PictureFileName = reader.GetString(fileNameIndex)
                            });
                        }
                    }
                    return pictures;
                }
                catch (Exception)
                {
                    throw new ApplicationException(StandardMSsqlErrorMessage); 
                }
            }
        }

        /// <summary>
        /// Hämtar en bild med hjälp av ett ID
        /// </summary>
        /// <param name="pictureID">Pictureidet NPK</param>
        /// <returns>Ett picture objekt</returns>
        public Picture GetPicture(int pictureID)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("AppSchema.usp_GetPicture", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PictureID", SqlDbType.Int, 4).Value = pictureID;

                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        var nameIndex = reader.GetOrdinal("Name");
                        var dateIndex = reader.GetOrdinal("Date");
                        var categoryIDIndex = reader.GetOrdinal("CategoryID");
                        var fileNameIndex = reader.GetOrdinal("PictureFileName"); 

                        if (reader.Read())
                        {
                            return new Picture
                            {
                                PictureID = pictureID,
                                Name = reader.GetString(nameIndex),
                                Date = reader.GetDateTime(dateIndex),
                                CategoryID = reader.GetInt32(categoryIDIndex),
                                PictureFileName = reader.GetString(fileNameIndex)
                            };
                        }
                    }
                    return null;
                }
                catch (Exception)
                {
                    throw new ApplicationException(StandardMSsqlErrorMessage); 
                }
            }
        }

        /// <summary>
        /// Lägger till en bild utan tillhörande album, oklart när denna blir aktuell
        /// </summary>
        /// <param name="picture">Picture Objekt</param>
        public void AddPicture(Picture picture)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Lägger till en ny bild till ett album,
        /// </summary>
        /// <param name="picture">Nytt Picture objekt</param>
        /// <param name="albumID">Albummets ID</param>
        public void AddPictureToAlbum(Picture picture, int albumID)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("appSchema.usp_AddPictureToAlbum", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PictureID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;

                    cmd.Parameters.Add("@Name", SqlDbType.VarChar, 35).Value = picture.Name;
                    cmd.Parameters.Add("@CategoryID", SqlDbType.Int, 4).Value = picture.CategoryID;
                    cmd.Parameters.Add("@Date", SqlDbType.DateTime).Value = picture.Date;
                    cmd.Parameters.Add("@PictureFileName", SqlDbType.VarChar, 20).Value = picture.PictureFileName;

                    cmd.Parameters.Add("@AlbumID", SqlDbType.Int, 4).Value = albumID;
                    conn.Open();

                    cmd.ExecuteNonQuery();

                    picture.PictureID = (int)cmd.Parameters["@PictureID"].Value; //Den nya pictureID:et
                }
                catch (Exception)
                {
                       throw new ApplicationException(StandardMSsqlErrorMessage); 
                }
            }
        }

        /// <summary>
        /// Lägger till en existerande bild till ett album, änvänds senare
        /// </summary>
        /// <param name="pictureID"></param>
        /// <param name="albumID"></param>
        public void AddExistingPictureToAlbum(int pictureID, int albumID)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("appSchema.usp_AddExistingPictureToAlbum", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PictureID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;

                    cmd.Parameters.Add("@PictureID", SqlDbType.Int, 4).Value = pictureID;
                    cmd.Parameters.Add("@AlbumID", SqlDbType.Int, 4).Value = albumID;

                    conn.Open();

                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    throw new ApplicationException(StandardMSsqlErrorMessage); 
                }
            }
        }
        /// <summary>
        /// Uppdaterar en existerande bild med hjälp av ett picture objekt
        /// </summary>
        /// <param name="picture">Ett existerande picture objekt</param>
        public void UpdatePicture(Picture picture)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("appSchema.usp_UpdatePicture", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PictureID", SqlDbType.Int, 4).Value = picture.PictureID;
                    cmd.Parameters.Add("@Name", SqlDbType.VarChar, 50).Value = picture.Name;
                    cmd.Parameters.Add("@CategoryID", SqlDbType.Int, 4).Value = picture.CategoryID;
                    cmd.Parameters.Add("@Date", SqlDbType.DateTime).Value = picture.Date;
                    cmd.Parameters.Add("@PictureFileName", SqlDbType.VarChar, 20).Value = picture.PictureFileName;

                    conn.Open();

                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    throw new ApplicationException(StandardMSsqlErrorMessage); 
                }
            }
        }

        /// <summary>
        /// Uppdaterar en existerande bild med hjälp av ett picture objekt, samt tilldelar ett album. Ska kasta ett undantag om bilden redan finns i albummet
        /// </summary>
        /// <param name="picture">Ett existerande picture objekt</param>
        public void UpdateExistingPictureToAlbum(Picture picture, int albumID)
        {
            if (!PictureExistInAlbum(picture.PictureID, albumID))
            {
                using (SqlConnection conn = CreateConnection())
                {
                    try
                    {
                        //DENNA KASTAR UNDANTAG OM BILDEN REDAN FINNS I ALBUMMET!!!!
                        SqlCommand cmd = new SqlCommand("appSchema.usp_UpdateExistingPictureToAlbum", conn); //DENNA KASTAR UNDANTAG OM BILDEN REDAN FINNS I ALBUMMET!!!!
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@PictureID", SqlDbType.Int, 4).Value = picture.PictureID;
                        cmd.Parameters.Add("@Name", SqlDbType.VarChar, 50).Value = picture.Name;
                        cmd.Parameters.Add("@CategoryID", SqlDbType.Int, 4).Value = picture.CategoryID;
                        cmd.Parameters.Add("@Date", SqlDbType.DateTime).Value = picture.Date;
                        cmd.Parameters.Add("@PictureFileName", SqlDbType.VarChar, 20).Value = picture.PictureFileName;

                        cmd.Parameters.Add("@AlbumID", SqlDbType.Int, 4).Value = albumID;
                        conn.Open();

                        cmd.ExecuteNonQuery();//DENNA KASTAR UNDANTAG OM BILDEN REDAN FINNS I ALBUMMET!!!!
                    }
                    catch (Exception)
                    {
                        throw new ApplicationException(StandardMSsqlErrorMessage); 
                    }
                }
            }
            else
            {
                //Den aktuella bilden finns redan i albumet
                throw new PictureExistsInAlbumException();
            }
        }

        private bool PictureExistInAlbum(int pictureID, int albumID)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("appSchema.usp_PictureExistsInAlbum", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Exists", SqlDbType.Bit).Direction = ParameterDirection.Output;

                    cmd.Parameters.Add("@PictureID", SqlDbType.Int, 4).Value = pictureID;
                    cmd.Parameters.Add("@AlbumID", SqlDbType.Int, 4).Value = albumID;
                    conn.Open();

                    cmd.ExecuteNonQuery();

                    return (bool)cmd.Parameters["@Exists"].Value; //True om bilden redan finns i albummet pictureID:et
                }
                catch (Exception)
                {
                    throw new ApplicationException(StandardMSsqlErrorMessage); 
                }
            }
        }


        /// <summary>
        /// Tar bort en bild med hjälp av ett bildID
        /// </summary>
        /// <param name="pictureID"></param>
        public void DeletePicture(int pictureID)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("appSchema.usp_DeletePicture", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PictureID", SqlDbType.Int, 4).Value = pictureID;

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    throw new ApplicationException(StandardMSsqlErrorMessage); 
                }
            }
        }

    }
}