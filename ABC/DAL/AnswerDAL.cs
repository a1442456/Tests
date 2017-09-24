using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ABC
{
    public class AnswerDAL : BaseDAL
    {
        private const string ALL_ANSWERS_QUERY = "Select * from Answers"; // put all constants as separated field

        public List<AnswerABC> GetAllAnswers()
        {
            List<AnswerABC> answers = new List<AnswerABC>();
            AnswerABC answer = new AnswerABC();

            var connectionString = ConfigurationManager.ConnectionStrings[CONNECTION_NAME].ConnectionString;

            OpenConnection();

            SqlCommand command = new SqlCommand(ALL_ANSWERS_QUERY, base._sqlConnection);

            SqlDataReader reader = command.ExecuteReader();

            using (reader)
            {
                while (reader.Read())
                {
                    answer.Id = (int)reader["ID"];
                    answer.AnswerCurrent = (string)reader["Answer"] ?? "null";
                    answer.QuestionId = (int)reader["ID_Qestion"];
                    answer.IsRight = (bool)reader["IsRight"];

                    answers.Add(answer);
                    answer = new AnswerABC();
                    
                }
            }

            base.CloseConnection();


            return answers;
        }

        public List<AnswerABC> GetAllAnswersByQuestion(string question)
        {
            List<AnswerABC> listAnswers = new List<AnswerABC>();
            AnswerABC answ = new AnswerABC();

            string connectionString = ConfigurationManager.ConnectionStrings["csABC_Tests"].ConnectionString;

            base.OpenConnection();

            SqlCommand command = new SqlCommand(string.Format("select Answers.ID, Answers.Answer, Answers.IsRight, Answers.ID_Question from ABC_Tests.dbo.Answers inner join ABC_Tests.dbo.Questions on Answers.ID_Question = Questions.ID where Questions.Question like '{0}'",question), base._sqlConnection);

            SqlDataReader reader = command.ExecuteReader();

            using (reader)
            {
                while (reader.Read())
                {
                    
                    answ.Id = (int)reader["ID"];
                    answ.AnswerCurrent = reader["Answer"].ToString();
                    answ.IsRight = (bool)reader["IsRight"];
                    answ.QuestionId = (int)reader["ID_Question"];
                    listAnswers.Add(answ);
                    answ = new AnswerABC();
                }
            }

            base.CloseConnection();

            return listAnswers;
        }

        public bool IsRightAnswer(string answer)
        {
            bool isRight = false;

            base.OpenConnection();

            SqlCommand cmd = new SqlCommand(string.Format("Select Answers.IsRight from Answers where answers.answer like '{0}'",answer),base._sqlConnection);

            SqlDataReader reader = cmd.ExecuteReader();

            using (reader)
            {
                while (reader.Read())
                {   
                    isRight = (bool)reader["IsRight"];
                }
            }

            base.CloseConnection();

            return isRight;
        }

        public void AddAnswer(string answer, string question, bool isRight)
        {            
            int questionid = new int();

            QuestionDAL qDAL = new QuestionDAL();

            questionid = qDAL.GetQuestionIdByQuestionName(question);

            base.OpenConnection();

            SqlCommand command = new SqlCommand(string.Format("insert into Answers values('{0}','{1}','{2}')",answer, questionid, isRight), base._sqlConnection);

            SqlDataReader reader = command.ExecuteReader();

            base.OpenConnection();
        }

        public void DeleteFromAnswers(string answerName)
        {
            base.OpenConnection();

            SqlCommand cmd = new SqlCommand("DeleteFromAnswersByName", base._sqlConnection);

            using (cmd)
            {
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter();
                param.ParameterName = "@answerName";
                param.SqlDbType = SqlDbType.VarChar;
                param.Size = 200;
                param.Value = answerName;

                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();
            }

            base.CloseConnection();
        }

        public void UpToDateAnswerRightState(AnswerABC answ, string question)
        {
            base.OpenConnection();

            SqlCommand cmd = new SqlCommand("SetRightAnswerByAnswer", base._sqlConnection);

            using (cmd)
            {
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter();
                param.ParameterName = "@Answer";
                param.SqlDbType = SqlDbType.VarChar;
                param.Size = 200;
                param.Value = answ.AnswerCurrent;
                cmd.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@isRight";
                param.SqlDbType = SqlDbType.Bit;
                param.Value = answ.IsRight;
                cmd.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@Question";
                param.SqlDbType = SqlDbType.VarChar;
                param.Size = 200;
                param.Value = question;                
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();
            }

            base.CloseConnection();
        }

        public void UpToDateAnswerRightState(List<AnswerABC> answList, string question)
        {
            foreach (AnswerABC answ in answList)
            {
                base.OpenConnection();

                SqlCommand cmd = new SqlCommand("SetRightAnswerByAnswer", base._sqlConnection);

                using (cmd)
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter param = new SqlParameter();
                    param.ParameterName = "@Answer";
                    param.SqlDbType = SqlDbType.VarChar;
                    param.Size = 200;
                    param.Value = answ.AnswerCurrent;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter();
                    param.ParameterName = "@isRight";
                    param.SqlDbType = SqlDbType.Bit;
                    param.Value = answ.IsRight;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter();
                    param.ParameterName = "@Question";
                    param.SqlDbType = SqlDbType.VarChar;
                    param.Size = 200;
                    param.Value = question;
                    cmd.Parameters.Add(param);

                    cmd.ExecuteNonQuery();
                }

                base.CloseConnection();
            }
        }
    }
}