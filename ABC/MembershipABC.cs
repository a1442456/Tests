using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace ABC
{
    public class MembershipABC : BaseDAL
    {
        public Guid GetUserIdByUserName(string userName)
        {
            Guid id = new Guid();

            base.OpenConnection();

            SqlCommand cmd = new SqlCommand("aspnet_Membership_GetUserIdByUser", base._sqlConnection);

            using (cmd)
            {
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter();
                param.ParameterName = "@Username";
                param.SqlDbType = SqlDbType.VarChar;
                param.Size = 256;
                param.Direction = ParameterDirection.Input;
                param.Value = userName;
                cmd.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@UserId";
                param.SqlDbType = SqlDbType.UniqueIdentifier;
                param.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(param);
                cmd.ExecuteNonQuery();

                id = (Guid)cmd.Parameters["@UserId"].Value;
            }

            base.CloseConnection();

            

            return id;
        }
    }
}