using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;

namespace ABC
{
    public class ThemeDAL : BaseDAL
    {
        
        public List<string> GetAllThemes()
        {
            List<string> themes= new List<string>();

            string connectionString = ConfigurationManager.ConnectionStrings["csABC_Tests"].ConnectionString;           

            base.OpenConnection();

             SqlCommand command = new SqlCommand("Select Themes.Theme from Themes", _sqlConnection);

            SqlDataReader reader = command.ExecuteReader();

            using (reader)
            {
                while (reader.Read())
                {
                    themes.Add((string)reader["Theme"]);
                }
            }

            base.CloseConnection();


            return themes;
        }

        public void FillDataSetExample(DataSet ds)
        {
            //Создаем объекты колонок идентичных таблице(Theme)
            DataColumn themeIdColumn = new DataColumn("ID",typeof(int));
            themeIdColumn.Caption = "Theme ID (this is a caption property)";
            themeIdColumn.ReadOnly = true;
            themeIdColumn.AllowDBNull = false;
            themeIdColumn.Unique = true;
            themeIdColumn.AutoIncrement = true;
            themeIdColumn.AutoIncrementSeed = 1;
            themeIdColumn.AutoIncrementStep = 2;
            
            DataColumn themeColumn = new DataColumn("theme",typeof(string));

            // Создаем таблицу и пихаем в её колекцию колонок массив объектов колонок
            DataTable themesTable = new DataTable("Themes");
            themesTable.Columns.AddRange(new DataColumn[] { themeIdColumn, themeColumn });

            // Засунем в таблицу Theme объекты строк(но прямого доступа к конструктору у DataRow нет нужно создовать 

            DataRow themeRow = themesTable.NewRow();
            themeRow["theme"] = "This is a new theme1";
            themesTable.Rows.Add(themeRow);

            themeRow = themesTable.NewRow();
            themeRow["theme"] = "This is a new theme2";
            themesTable.Rows.Add(themeRow);

            //Определяем первичный ключ в таблице Themes

            themesTable.PrimaryKey = new DataColumn[] { themesTable.Columns[0] };



        }

        public DataSet GetAllThemesViaDataSet()
        {
            DataSet ds = new DataSet();

            string connectionString = ConfigurationManager.ConnectionStrings["csABC_Tests"].ConnectionString;

            SqlConnection connection = new SqlConnection(connectionString);

            SqlCommand command = new SqlCommand("Select * from Themes", connection);

            SqlDataAdapter adapter = new SqlDataAdapter(command);

            adapter.Fill(ds);

            return ds;
        }

        public void InsertThemeViaStoredProc(string theme_name)
        {

            base.OpenConnection();    
 
            SqlCommand cmd = new SqlCommand("InsertIntoThemes", base._sqlConnection);

                   
            
            using(cmd)
            {

                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter();
                param.ParameterName = "@Theme";
                param.SqlDbType = SqlDbType.VarChar;
                param.Size = 200;
                param.Direction = ParameterDirection.Input;
                param.Value = theme_name;
                cmd.Parameters.Add(param);
                
                cmd.ExecuteNonQuery();
                
            }

            base.CloseConnection();
            
        }

        public int GetThemeIdByThemeNameViaStoredProc(string theme_name)
        {
            int theme_id = new int();

            base.OpenConnection();

            SqlCommand cmd = new SqlCommand("GetThemeIdByTheme", base._sqlConnection);
            
            using (cmd)
            {
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter();
                param.ParameterName = "@Theme";
                param.SqlDbType = SqlDbType.VarChar;
                param.Size = 200;
                param.Direction = ParameterDirection.Input;
                param.Value = theme_name;
                cmd.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@ID";
                param.SqlDbType = SqlDbType.Int;
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

               
                cmd.ExecuteNonQuery();

                theme_id = (int)cmd.Parameters["@ID"].Value;
            }

            base.CloseConnection();

            return theme_id;
        }

        public void DeleteFromThemes(string themeName)
        {
            base.OpenConnection();

            SqlCommand cmd = new SqlCommand("DeleteFromThemesByName", base._sqlConnection);

            using (cmd)
            {
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter();
                param.ParameterName = "@themeName";
                param.SqlDbType = SqlDbType.VarChar;
                param.Size = 200;
                param.Value = themeName;

                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();
            }

            base.CloseConnection();
        }
    }
}