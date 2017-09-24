using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

namespace ABC // rename this namespace
{
    public class BaseDAL 
    {
        protected const string CONNECTION_NAME = "csABC_Tests"; // you can set public access type to constants, but can't do this for variables
        protected SqlConnection _sqlConnection = null;

        public void OpenConnection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["csABC_Tests"].ConnectionString;
            _sqlConnection = new SqlConnection();
            _sqlConnection.ConnectionString = connectionString;
            _sqlConnection.Open();
        }

        public void CloseConnection()
        {
            _sqlConnection.Close();
        }
    }
}