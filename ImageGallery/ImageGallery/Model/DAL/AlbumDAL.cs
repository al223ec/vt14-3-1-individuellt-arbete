using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ImageGallery.Model.DAL
{
    public class AlbumDAL : DALBase
    {
        /// <summary>
        /// Hämtar alla poster i tabellen album
        /// </summary>
        /// <returns>IEnumberable med samtliga poster album object</returns>
        public IEnumerable<Album> GetAllAlbums()
        {
            // Skapar och initierar ett anslutningsobjekt.
            using (var conn = CreateConnection())
            {
                try
                {
                    var albums = new List<Album>(100);
                    var cmd = new SqlCommand("AppSchema.usp_GetAllAlbums", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        var albumIDIndex = reader.GetOrdinal("AlbumID");
                        var nameIndex = reader.GetOrdinal("Name");
                        var dateIndex = reader.GetOrdinal("Date");

                        while (reader.Read())
                        {
                            albums.Add(new Album
                            {
                                AlbumID = reader.GetInt32(albumIDIndex),
                                Name = reader.GetString(nameIndex),
                                Date = reader.GetDateTime(dateIndex),
                            });
                        }
                    }
                    albums.TrimExcess();
                    return albums;
                }
                catch (Exception)
                {
                    throw new ApplicationException(StandardMSsqlErrorMessage); 
                }
            }
        }
        /// <summary>
        /// Hämtar namnet på ett album, returnerar null om albummet inte finns
        /// </summary>
        /// <param name="albumID">Albummets NPK</param>
        /// <returns>En string med albummets namn</returns>
        public string GetAlbumName(int albumID)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("appSchema.usp_GetAlbumName", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AlbumID", SqlDbType.Int, 4).Value = albumID;
                    cmd.Parameters.Add("@AlbumName", SqlDbType.VarChar, 35).Direction = ParameterDirection.Output;

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    return (string)cmd.Parameters["@AlbumName"].Value; //Det aktuella albumnamnet
                }
                catch (Exception)
                {
                    throw new ApplicationException(StandardMSsqlErrorMessage); 
                }
            }
        }
        /// <summary>
        /// Lägger till ett album med hjälp av ett Album objekt
        /// </summary>
        /// <param name="album">Ett album objekt</param>
        public void AddAlbum(Album album)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("appSchema.usp_AddAlbum", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AlbumID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@Name", SqlDbType.VarChar, 35).Value = album.Name;

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    album.AlbumID = (int)cmd.Parameters["@AlbumID"].Value; //Den nya pictureID:et
                }
                catch (Exception)
                {
                    throw new ApplicationException(StandardMSsqlErrorMessage); 
                }
            }
        }
        /// <summary>
        /// Tar bort ett album med hjälp av ett albumID, kommer kasta ett undantag om albummet har tillhörande album
        /// </summary>
        /// <param name="albumID">Albumets NPK</param>
        public void DeleteAlbum(int albumID)
        {
            //KASTAR UNDANTAG OM DET FINNS BILDER SOM TILLHÖR ALBUMM OMG!!!!!!!"
            //Kanske fixa en stored procedure eller?? 
            //TODO: Fixa ta bort album med tillhörande bilder.
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("appSchema.usp_DeleteAlbum", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

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
        /// Uppdaterar albume med hjälp av ett albumobjekt
        /// </summary>
        /// <param name="album">Ett existerande album objekt</param>
        public void UpdateAlbum(Album album)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("appSchema.usp_UpdateAlbum", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AlbumID", SqlDbType.Int, 4).Value = album.AlbumID;
                    cmd.Parameters.Add("@Name", SqlDbType.VarChar, 35).Value = album.Name;
                    cmd.Parameters.Add("@Date", SqlDbType.DateTime).Value = album.Date;

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
        /// Hämtar ett album från databasen utifrån dess ID, kastar undantag om albummet inte finns
        /// </summary>
        /// <param name="albumID">AlbumIdet</param>
        /// <returns></returns>
        public Album GetAlbum(int albumID)
        {
            // Skapar och initierar ett anslutningsobjekt.
            using (var conn = CreateConnection())
            {
                try
                {
                    var cmd = new SqlCommand("AppSchema.usp_GetAlbum", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AlbumID", SqlDbType.Int, 4).Value = albumID;

                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        var nameIndex = reader.GetOrdinal("Name");
                        var dateIndex = reader.GetOrdinal("Date");

                        if (reader.Read())
                        {
                            return new Album
                           {
                               AlbumID = albumID,
                               Name = reader.GetString(nameIndex),
                               Date = reader.GetDateTime(dateIndex),
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
    }
}