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
        public IEnumerable<Category> GetAllCategorys(bool update = false)
        {
            using (var conn = CreateConnection())
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
        }
    }
}