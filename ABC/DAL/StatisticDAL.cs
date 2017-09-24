using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace ABC.DAL
{
    public class StatisticDAL : BaseDAL
    {
        public List<ResultABC> GetAllResultsByUserID(Guid userID)
        {
            List<ResultABC> resultList = new List<ResultABC>();

            ResultABC result = new ResultABC();

            base.OpenConnection();

            SqlCommand cmd = new SqlCommand("GetAllResultsByUserId", base._sqlConnection);

            using (cmd)
            {
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter();
                param.ParameterName = "@UserId";
                param.SqlDbType = SqlDbType.UniqueIdentifier;                
                param.Value = userID;

                cmd.Parameters.Add(param);               

                SqlDataReader reader = cmd.ExecuteReader();

                using (reader)
                {
                    while (reader.Read())
                    {
                        result.SubThemeID = (int)reader["ID_SubTheme"];
                        result.Result = (int)reader["Result"];
                        result.TestDate = (DateTime)reader["TestDate"];

                        resultList.Add(result);

                        result = new ResultABC();
                    }
                }
            }

            base.CloseConnection();

            return resultList;
        }
    }
}