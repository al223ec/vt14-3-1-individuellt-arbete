using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ImageGallery.Model.DAL
{
    public class CategoryDAL : DALBase
    {
        public IEnumerable<Category> GetAllCategorys()
        {
            using (var conn = CreateConnection())
            {
                try
                {
                    var categorys = new List<Category>(100);
                    var cmd = new SqlCommand("AppSchema.usp_GetAllCategorys", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        var categoryIDIndex = reader.GetOrdinal("CategoryID");
                        var valueIndex = reader.GetOrdinal("Value");

                        while (reader.Read())
                        {
                            categorys.Add(new Category
                            {
                                CategoryID = reader.GetInt32(categoryIDIndex),
                                Value = reader.GetString(valueIndex),
                            });
                        }
                    }
                    categorys.TrimExcess();
                    return categorys;
                }
                catch (Exception)
                {
                    throw new ApplicationException(StandardMSsqlErrorMessage); 
                }
            }
        }

        public IEnumerable<Picture> GetAllPicturesInCategory(int CategoryID)
        {
            using (var conn = CreateConnection())
            {
                try
                {
                    var pictures = new List<Picture>(100);
                    SqlCommand cmd = new SqlCommand("AppSchema.usp_GetAllPicturesFromCategory", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CategoryID", SqlDbType.Int, 4).Value = CategoryID;

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
                                CategoryID = reader.GetInt32(categoryIDIndex),
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
    }
}