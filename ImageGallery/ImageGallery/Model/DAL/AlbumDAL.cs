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
        }
    }
}