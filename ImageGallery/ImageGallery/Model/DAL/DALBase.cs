using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace ImageGallery.Model.DAL
{
    public abstract class DALBase
    {
        private static string _connectionString;
        protected string StandardMSsqlErrorMessage = "Något gick fel i kontakten med Servern!";  

        public DALBase()
        {
            _connectionString = WebConfigurationManager.ConnectionStrings["ImageGalleryConnectionString"].ConnectionString;
        }

        protected static SqlConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}