using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ABC
{
    public class SubThemeDAL : BaseDAL
    {
        
        public List<string> GetAllSubThemes()
        {
            List<string> SubThemes = new List<string>();

            base.OpenConnection();

            SqlCommand command = new SqlCommand("Select * from Sub_Themes", base._sqlConnection);

            SqlDataReader reader = command.ExecuteReader();

            using (reader)
            {
                while (reader.Read())
                {
                    SubThemes.Add((string)reader["Sub_Theme"]);
                }
            }

            base.CloseConnection();


            return SubThemes;
        }

        public List<string> GetAllSubThemesByThemeName(string themeName)
        {
            List<string> subThemes = new List<string>();

            base.OpenConnection();

            SqlCommand command = new SqlCommand(string.Format("Select Sub_Theme from Sub_Themes inner join Themes on Sub_Themes.ID_Theme = Themes.ID where Themes.Theme like '" + "{0}" + "'", themeName), base._sqlConnection);

            SqlDataReader reader = command.ExecuteReader();

            using (reader)
            {
                while (reader.Read())
                {
                    subThemes.Add((string)reader["Sub_Theme"]);
                }
            }

            base.OpenConnection();

            return subThemes;
        }

        public DataSet GetAllSubTHemesViaDataSet()
        {
            DataSet ds = new DataSet();

            string connectionString = ConfigurationManager.ConnectionStrings["csABC_Tests"].ConnectionString;

            SqlConnection connection = new SqlConnection(connectionString);

            SqlCommand command = new SqlCommand("Select Sub_Theme.Sub_Themes from Sub_Themes", connection);

            SqlDataAdapter adapter = new SqlDataAdapter(command);

            adapter.Fill(ds);

            return ds;
        }

        public void InsertSubThemeViaStoredProc(SubThemeABC subtheme)
        {

            base.OpenConnection();

            SqlCommand cmd = new SqlCommand("InsertIntoSubThemes", base._sqlConnection);            

            using (cmd)
            {

                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter();
                param.ParameterName = "@Sub_Theme";
                param.SqlDbType = SqlDbType.VarChar;
                param.Size = 200;
                param.Direction = ParameterDirection.Input;
                param.Value = subtheme.subTheme;
                cmd.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@ID_Theme";
                param.SqlDbType = SqlDbType.Int;
                param.Direction = ParameterDirection.Input;
                param.Value = subtheme.ThemeId;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();

            }

            base.CloseConnection();
        }

        public int GetSubThemeIdBySubThemeNameViaStoredProc(string subthemeName)
        {
            int subThemeId = new int();

            base.OpenConnection();

            SqlCommand cmd = new SqlCommand("GetSubThemeIdBySubTheme", base._sqlConnection);

            using(cmd)
	        {
                cmd.CommandType = CommandType.StoredProcedure;
		        SqlParameter param = new SqlParameter();
                param.ParameterName = "@SubTheme";
                param.SqlDbType = SqlDbType.VarChar;
                param.Size = 200;
                param.Direction = ParameterDirection.Input;
                param.Value = subthemeName;
                cmd.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@ID";
                param.SqlDbType = SqlDbType.Int;
                param.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(param);
                cmd.ExecuteNonQuery();

                subThemeId = (int)cmd.Parameters["@ID"].Value;   
	        }

            base.CloseConnection();

            return subThemeId;
        }

        public List<string> GetSubThemesByTHemeIdViaStoredProc(int themeId)
        {
            List<string> subThemeL = new List<string>();

            base.OpenConnection();

            SqlCommand cmd = new SqlCommand("GetSubThemesByThemeId_test", base._sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;

            using (cmd)
            {

                SqlParameter param = new SqlParameter();
                param.ParameterName = "@ThemeId";
                param.SqlDbType = SqlDbType.Int;                
                param.Direction = ParameterDirection.Input;
                param.Value = themeId;
                cmd.Parameters.Add(param);                

                SqlDataReader reader = cmd.ExecuteReader();

                using (reader)
                {
                    while (reader.Read())
                    {
                        subThemeL.Add((string)reader["Sub_Theme"]);
                    }
                }
            }

            base.CloseConnection();

            return subThemeL;
        }

        public void DeleteFromSubThemes(string subThemeName)
        {
            base.OpenConnection();

            SqlCommand cmd = new SqlCommand("DeleteFromSubThemesByName", base._sqlConnection);

            using (cmd)
            {
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter();
                param.ParameterName = "@subThemeName";
                param.SqlDbType = SqlDbType.VarChar;
                param.Size = 200;
                param.Value = subThemeName;

                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();
            }

            base.CloseConnection();
        }

        public string GetSubThemeBySubThemeId(int subThemeId)
        {
            string subThemeName = "";

            base.OpenConnection();

            SqlCommand command = new SqlCommand(string.Format("Select Sub_Themes.Sub_Theme from Sub_Themes  where Sub_Themes.ID = " + "{0}", subThemeId), base._sqlConnection);

            SqlDataReader reader = command.ExecuteReader();

            using (reader)
            {
                while (reader.Read())
                {
                    subThemeName = (string)reader["Sub_Theme"] ?? "null";
                }
            }


            base.CloseConnection();

            return subThemeName;
        }

        public string GetSubThemeNameBySubThemeIdViaStoredProc(int subthemeID)
        {
            string subThemeName = "";

            base.OpenConnection();

            SqlCommand cmd = new SqlCommand("GetSubThemeNameBySubThemeID", base._sqlConnection);

            using (cmd)
            {
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter(); 
                param = new SqlParameter();
                param.ParameterName = "@ID";
                param.SqlDbType = SqlDbType.Int;
                param.Direction = ParameterDirection.Input;
                param.Value = subthemeID;
                cmd.Parameters.Add(param);
                param = new SqlParameter();

                param.ParameterName = "@SubTheme";
                param.SqlDbType = SqlDbType.VarChar;
                param.Size = 200;
                param.Direction = ParameterDirection.Output;                
                

                cmd.Parameters.Add(param);
                cmd.ExecuteNonQuery();

                subThemeName = (string)cmd.Parameters["@SubTheme"].Value;
            }

            base.CloseConnection();

            return subThemeName;
        }
    }
}