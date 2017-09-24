using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Drawing;
using ABC;
using ABC.DAL;

namespace ABC
{
    public class TestABC : BaseDAL
    {
        private string _testName;
        private List<QuestionABC> _questionList;
        private int _questionCount;

        public TestABC()
        { 
        }

        public TestABC(string subThemeName)
        {
            QuestionDAL qDAL = new QuestionDAL();
            this._questionList = qDAL.GetAllQuestionsBySubThemeName(subThemeName);
            this._testName = subThemeName;
            this._questionCount = this._questionList.Count;
        }
       
        public string TestName
        {
            get { return _testName; }
            set { _testName = value; }
        }

        public List<QuestionABC> QuestionList
        {
            get { return _questionList; }            
        }

        public int QuestionCount
        {
            get { return _questionCount; }
        }

        public void InsertResult(double result, int ID_SubTheme, Guid ID_User, DateTime date)
        {
            base.OpenConnection();

            SqlCommand command = new SqlCommand(string.Format("insert into TestResults values('{0}','{1}','{2}','{3}')", result, date, ID_User, ID_SubTheme), base._sqlConnection);

            SqlDataReader reader = command.ExecuteReader();

            base.OpenConnection();
        }

        private void ConfigureCell(TableCell cell, Label lbl)
        {
            cell.Controls.Add(lbl);
            cell.BorderWidth = 1;
            cell.BorderColor = Color.Black;
        }

        private void ConfigureLable(Label lbl, string text)
        {
            lbl.Text = text;
            lbl = new Label();
        }

        private Color GetColorForResult(double result)
        {
            Color clr = new Color();

            if (result < 20)
            {
                 clr = Color.Red; // use retun instead local variable
            }
            else if (result < 50)
            {
                clr = Color.Orange;
            }
            else if (result < 70)
            {
                clr = Color.LightGreen;
            }

            else if (result <= 100)
            {
                clr = Color.Green;
            }

            return clr;
        }

        private void ConfigureCellColor(double result, TableCell tCell)
        {
            tCell.BackColor = GetColorForResult(result);
        }


        public void CreateViewOfStatistic(Guid userId, Table tbl)
        {
            StatisticDAL statDAL = new StatisticDAL();
            SubThemeDAL subThDAL = new SubThemeDAL();
            List<ResultABC> statList = new List<ResultABC>();
            statList = statDAL.GetAllResultsByUserID(userId);
            TableRow tRow = new TableRow();
            TableCell tCell = new TableCell();
            Label lblSubThemeName = new Label();
            Label lblTestDate = new Label();
            Label lblResult = new Label();

            const string headerTextDate = "Date";
            const string headerTextSuBTheme = "SubTheme Name";
            const string headerTextResult = "Result";

            ConfigureLable(lblTestDate, headerTextDate);
            ConfigureCell(tCell, lblTestDate);
            lblTestDate = new Label();

            tRow.Cells.Add(tCell);
            tCell = new TableCell();

            
            ConfigureLable(lblSubThemeName, headerTextSuBTheme);
            ConfigureCell(tCell, lblSubThemeName);

            lblSubThemeName = new Label();

            tRow.Cells.Add(tCell);
            tCell = new TableCell();
            
            ConfigureLable(lblResult, headerTextResult);
            ConfigureCell(tCell, lblResult);

            lblResult = new Label();

            tRow.Cells.Add(tCell);
            tCell = new TableCell();

            tbl.Rows.Add(tRow);
            tRow = new TableRow();

            
            foreach (ResultABC result in statList)
            {
                string testDate =  result.TestDate.ToString();
                ConfigureLable(lblTestDate, testDate);

                tCell.Controls.Add(lblTestDate);
                lblTestDate = new Label();
                tRow.Cells.Add(tCell);
                tCell = new TableCell();

                //Get subTHeme name from resultABC.SubThemeID
                string subTheme = subThDAL.GetSubThemeBySubThemeId(result.SubThemeID);                                
                ConfigureLable(lblSubThemeName, subTheme);

                tCell.Controls.Add(lblSubThemeName);
                lblSubThemeName = new Label();
                tRow.Cells.Add(tCell);
                tCell = new TableCell();

                lblResult.Text = result.Result.ToString();
                tCell.Controls.Add(lblResult);
                double testResult = result.Result;
                ConfigureCellColor(testResult, tCell);


                lblResult = new Label();

                tRow.Cells.Add(tCell);
                tCell = new TableCell();

                tbl.Rows.Add(tRow);
                tRow = new TableRow();
            }
        }

        
    }
}