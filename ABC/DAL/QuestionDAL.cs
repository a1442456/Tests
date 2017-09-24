using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ABC
{
    public class QuestionDAL : BaseDAL
    {
        public List<string> GetAllQuestions()
        {
            List<string> questions = new List<string>();

            string question = "";
            

            base.OpenConnection();

            SqlCommand command = new SqlCommand("Select * from Questions", base._sqlConnection);

            SqlDataReader reader = command.ExecuteReader();

            
            using (reader)
            {
                while (reader.Read())
                {

                    question = (string)reader["Question"];
                    questions.Add(question);
                    question = "";
                    //question.Id = (int)reader["ID"];
                    //question.QuestionCurrent = (string)reader["Question"];

                    //SqlCommand commandForAnswers = new SqlCommand(string.Format("Select * from answers inner join questions on answers.ID_Question = Questions.ID where Questions.ID = {0}", (int)reader["ID"]), base._sqlCn);
                    //SqlDataReader readerForAnswers = commandForAnswers.ExecuteReader();
                    //using (readerForAnswers)
                    //{
                    //    while (readerForAnswers.Read())
                    //    {
                    //        answer.Id = (int)readerForAnswers["ID"];
                    //        answer.AnswerCurrent = (string)readerForAnswers["Answer"];
                    //        answer.QuestionId = (int)readerForAnswers["ID_Qestion"];
                    //        answer.IsRight = (bool)readerForAnswers["IsRight"];

                    //        question.ListAnswers.Add(answer);
                    //        answer = new Answer();
                    //    }                        
                    //}
                    //questions.Add(question);
                }
            }

            base.CloseConnection();


            return questions;
        }

        public List<QuestionABC> GetAllQuestionsBySubThemeName(string subThemeName)
        {
            List<QuestionABC> questions = new List<QuestionABC>();
            QuestionABC quest = new QuestionABC();
            AnswerDAL aDAL = new AnswerDAL();
            
            base.OpenConnection();

            SqlCommand command = new SqlCommand(string.Format("Select * from Questions inner join Sub_Themes on Questions.ID_SubTheme = Sub_Themes.ID where Sub_Themes.Sub_Theme like '" + "{0}" + "'", subThemeName), base._sqlConnection);

            SqlDataReader reader = command.ExecuteReader();

            using (reader)
            {
                while (reader.Read())
                {
                    quest.Id = (int)reader["ID"];
                    quest.QuestionCurrent = (string)reader["Question"];
                    quest.SubThemeId = (int)reader["ID_SubTheme"];
                    quest.ListAnswers = aDAL.GetAllAnswersByQuestion(quest.QuestionCurrent);
                    
                    questions.Add(quest);

                    quest = new QuestionABC();
                }
            }

            base.CloseConnection();

            return questions;
        }

        public DataSet GetAllQuestionsViaDataSet()
        {
            DataSet ds = new DataSet();

            string connectionString = ConfigurationManager.ConnectionStrings["csABC_Tests"].ConnectionString;

            SqlConnection connection = new SqlConnection(connectionString);

            SqlCommand command = new SqlCommand("Select * from Questions", connection);

            SqlDataAdapter adapter = new SqlDataAdapter(command);

            adapter.Fill(ds);

            return ds;
        }

        public void InsertQuestionViaStoredProc(QuestionABC quest)
        {
            base.OpenConnection();

            SqlCommand cmd = new SqlCommand("InsertIntoQuestions", base._sqlConnection);
            
            using(cmd)
            {
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter();
                param.ParameterName = "@Question";
                param.SqlDbType = SqlDbType.VarChar;
                param.Size = 200;
                param.Value = quest.QuestionCurrent;

                cmd.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@Id_Sub_Theme";
                param.SqlDbType = SqlDbType.Int;
                param.Value = quest.SubThemeId;

                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();
            }

            base.CloseConnection();
	
        }

        public string GetSubThemeByQuestion(QuestionABC quest)
        {
            string subTheme = "";

            base.OpenConnection();

            SqlCommand command = new SqlCommand(string.Format("Select Sub_Themes.Sub_Theme from Sub_Themes inner join Questions on Sub_Themes.ID = Questions.ID_SubTheme where Questions.Question like '" + "{0}" + "'", quest.QuestionCurrent), base._sqlConnection);

            SqlDataReader reader = command.ExecuteReader();

            using (reader)
            {
                while (reader.Read())
                {                    
                    subTheme = (string)reader["Sub_Theme"]; 
                }
            }

            base.CloseConnection();

            return subTheme;
        }

        public int GetQuestionIdByQuestionName(string quest)
        {
            int id = new int();

            base.OpenConnection();

            SqlCommand command = new SqlCommand(string.Format("Select Questions.ID from Questions where Questions.Question = '{0}'", quest), base._sqlConnection);

            SqlDataReader reader = command.ExecuteReader();

            using (reader)
            {
                while (reader.Read())
                {
                    id = (int)reader["ID"];
                }
            }

            base.OpenConnection();

            return id;
        }

        public void DeleteFromQuestions(string questionName)
        {
            base.OpenConnection();

            SqlCommand cmd = new SqlCommand("DeleteFromQuestionsByName", base._sqlConnection);

            using (cmd)
            {
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter();
                param.ParameterName = "@questionName";
                param.SqlDbType = SqlDbType.VarChar;
                param.Size = 200;
                param.Value = questionName;

                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();
            }

            base.CloseConnection();
        }


    }
}