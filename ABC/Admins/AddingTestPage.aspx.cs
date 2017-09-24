using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ABC.Admin
{
    public partial class AddingTestPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {   
            if (!IsPostBack)
            {                
                GetViewOfTheme();
                GetViewOfSubTheme();               
                GetViewOfQuestion();
                GetViewOfAnswers();               
            }
        }

        protected void btnAddTheme_Click(object sender, EventArgs e)
        {
            if (txtbxTheme.Text != String.Empty) //use String.Empty instead of ""
            {
                ThemeDAL themeDAL = new ThemeDAL();

                themeDAL.InsertThemeViaStoredProc(txtbxTheme.Text);
                txtbxTheme.Text = "";
            }

            GetViewOfTheme();
            GetViewOfSubTheme();
            GetViewOfQuestion();
            GetViewOfAnswers();

        }

        protected void btnAddSubTheme_Click(object sender, EventArgs e)
        {
            if (txtbxSubTheme.Text!="")
            {
                ThemeDAL tDAL = new ThemeDAL();
                SubThemeABC subTheme = new SubThemeABC(0, txtbxSubTheme.Text, tDAL.GetThemeIdByThemeNameViaStoredProc(ddlTheme.SelectedValue)); //remove "viaStoredProc"

                SubThemeDAL stDAL = new SubThemeDAL();

                stDAL.InsertSubThemeViaStoredProc(subTheme);               

                txtbxSubTheme.Text = "";  
            }
            
            GetViewOfSubTheme();
            GetViewOfQuestion();
            GetViewOfAnswers();

           
        }

        protected void btnAddQuestion_Click(object sender, EventArgs e)
        {
            if (txtbxQuestion.Text != "")
            {
                QuestionDAL qDAL = new QuestionDAL();
                SubThemeDAL stDAL = new SubThemeDAL();

                QuestionABC quest = new QuestionABC(0, txtbxQuestion.Text, stDAL.GetSubThemeIdBySubThemeNameViaStoredProc(ddlSubTheme.SelectedValue));

                qDAL.InsertQuestionViaStoredProc(quest);

                txtbxQuestion.Text = "";
            }
            
            GetViewOfQuestion();
            GetViewOfAnswers();

            
        }

        protected void btnAddAnnwer_Click(object sender, EventArgs e)
        {
            AnswerDAL aDAL = new AnswerDAL();

            aDAL.AddAnswer(txtbxAnswer.Text, ddlQuestion.SelectedValue, chbxIsRightAnswer.Checked);

            GetViewOfAnswers();


        }

        protected void btnDeleteTheme_Click(object sender, EventArgs e)
        {
            ThemeDAL tDAL = new ThemeDAL();
            tDAL.DeleteFromThemes(ddlTheme.SelectedValue);

            GetViewOfTheme();
            GetViewOfSubTheme();
            GetViewOfQuestion();
            GetViewOfAnswers();
        }

        protected void btnDeleteSubTheme_Click(object sender, EventArgs e)
        {
            SubThemeDAL stDAL = new SubThemeDAL();
            stDAL.DeleteFromSubThemes(ddlSubTheme.SelectedValue);

            GetViewOfSubTheme();
            GetViewOfQuestion();
            GetViewOfAnswers();
        }

        protected void btnDeleteQuestion_Click(object sender, EventArgs e)
        {
            QuestionDAL qDAL = new QuestionDAL();
            qDAL.DeleteFromQuestions(ddlQuestion.SelectedValue);

            GetViewOfQuestion();
            GetViewOfAnswers();
        }

        protected void btnSaveChanges_Click(object sender, EventArgs e)
        {
            ////GetViewOfAnswers();
            //if (IsPostBack)
            //{
            //    List<AnswerABC> answList = new List<AnswerABC>();

            //    Table tbl = new Table();

            //    tbl = tblAnswers;

            //    answList = GetAnswersFromTable(tbl);

            //    AnswerDAL aDAL = new AnswerDAL();
            //    string question = ddlQuestion.SelectedValue;
            //    aDAL.UpToDateAnswerRightState(answList, question);
            //}

            //GetViewOfAnswers();

            Table tbl = new Table();

            foreach (Control ctrl in tblAnswers.Controls)
            {
                lblTester.Text += ctrl.GetType().ToString() + " " + ctrl.ID + "<br/>";
            }
            
        }

        protected void ddlTheme_SelectedIndexChanged(object sender, EventArgs e)
        {
            
                GetViewOfSubTheme();

                GetViewOfQuestion();

                GetViewOfAnswers();
        }

        protected void ddlSubTheme_SelectedIndexChanged(object sender, EventArgs e)
        {

            GetViewOfQuestion();

            GetViewOfAnswers();
        }

        protected void ddlQuestion_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetViewOfAnswers();
        }

        protected void txtbxTheme_TextChanged(object sender, EventArgs e)
        {
        }

        protected void txtbxSubTheme_TextChanged(object sender, EventArgs e)
        {
           
        }

        protected void txtbxQuestion_TextChanged(object sender, EventArgs e)
        {
            
        }

        protected void GetViewOfAnswers()
        {
            AnswerDAL aDAL = new AnswerDAL();
            int k = 0, i = 0; //счетчик для айдишников эелемента
            Label lblAnswer = new Label();
            Label lblAnswerNumber = new Label();
            CheckBox chbxIsRight = new CheckBox();
            Label lblBr = new Label();
            TableRow tRow = new TableRow();
            TableCell tCell = new TableCell();

            // use for wherever you need indexes
            foreach (AnswerABC answ in aDAL.GetAllAnswersByQuestion(ddlQuestion.SelectedValue))
            {
                lblAnswer = new Label();
                lblAnswerNumber = new Label();
                lblAnswer.ID = string.Format("lblAnswer{0}", k);
                lblAnswerNumber.Text = string.Format("{0}) ", k + 1);
                lblAnswer.Text = string.Format("{0}", answ.AnswerCurrent);

                chbxIsRight = new CheckBox();
                chbxIsRight.ID = string.Format("chbxIsRight{0}", k);
                chbxIsRight.AutoPostBack = true;


                lblBr = new Label();
                lblBr.Text = "<br/>";

                if (!answ.IsRight)
                {
                    chbxIsRight.Checked = false;
                }
                else
                {
                    chbxIsRight.Checked = true;
                }

                // don't copy -paste - use nested "for" cycle
                tCell.Controls.Add(lblAnswerNumber);
                tCell.ID = string.Format("answCell{0}{1}", k, i);
                i++;
                tRow.Cells.Add(tCell);
                tCell = new TableCell();

                tCell.Controls.Add(lblAnswer);
                tCell.ID = string.Format("answCell{0}{1}", k, i);
                i++;
                tRow.Cells.Add(tCell);
                tCell = new TableCell();

                tCell.Controls.Add(chbxIsRight);
                tCell.ID = string.Format("answCell{0}{1}", k, i);
                i++;
                tRow.Cells.Add(tCell);
                tCell = new TableCell();

                tRow.ID = string.Format("answRow{0}", k);

                tblAnswers.Rows.Add(tRow);
                tRow = new TableRow();

                k++;
                i = 0;
            }
            
        }

        protected void GetViewOfTheme()
        {
            ThemeDAL tDAL = new ThemeDAL();

            ddlTheme.Items.Clear();

            foreach (string theme in tDAL.GetAllThemes())
            {
                ddlTheme.Items.Add(theme);
            }
        }

        protected void GetViewOfTheme(int startPos)
        {
            GetViewOfTheme();

            ddlTheme.SelectedIndex = startPos;
        }

        protected void GetViewOfSubTheme()
        {
            ddlSubTheme.Items.Clear();

            SubThemeDAL stDAL = new SubThemeDAL();

            foreach (string subTheme in stDAL.GetAllSubThemesByThemeName(ddlTheme.SelectedValue))
            {
                ddlSubTheme.Items.Add(subTheme);
            }
        }

        protected void GetViewOfSubTheme(int startPos)
        {
            GetViewOfSubTheme();

            ddlSubTheme.SelectedIndex = startPos;
        }

        protected void GetViewOfQuestion()
        {
            ddlQuestion.Items.Clear();

            QuestionDAL qDAL = new QuestionDAL();

            foreach (QuestionABC question in qDAL.GetAllQuestionsBySubThemeName((string)ddlSubTheme.SelectedValue))
            {
                ddlQuestion.Items.Add(question.QuestionCurrent);
            }
        }

        protected void GetViewOfQuestion(int startPos)
        {
            GetViewOfQuestion();

            ddlQuestion.SelectedIndex = startPos;
        }

        protected List<CheckBox> GetAllCheckboxFromPanel(Panel pnl)
        {
            List<CheckBox> chbxList = new List<CheckBox>();
            CheckBox chBx = new CheckBox();
            

            foreach (Control ctrl in pnl.Controls)
            {
                if (ctrl.GetType() == chBx.GetType())
                {
                    chbxList.Add((CheckBox)ctrl);
                }
            }

            return chbxList;
        }

        protected string GetNumbersFromString(string word)
        {
            string number = string.Empty;


            for (int i = 0; i < word.Length; i++)
            {
                if (Char.IsDigit(word[i]))
                {
                    number += word[i];
                }

            }

            return number;
        }

        protected void SaveAnswersState(List<AnswerABC> answerList, string question)
        {
            AnswerDAL aDAL = new AnswerDAL();

            aDAL.UpToDateAnswerRightState(answerList, question);
           
        }

        protected List<AnswerABC> GetAnswersFromTable(Table tbl)
        {
            List<AnswerABC> listAnswer = new List<AnswerABC>();
            AnswerABC answer = new AnswerABC();
            Label lblAnswer = new Label();
            CheckBox chbxIsRight = new CheckBox();

            foreach (TableRow tRow in tbl.Rows)
            {
                foreach (TableCell tCell in tRow.Cells)
                {
                    foreach (Control ctrl in tCell.Controls)
                    {
                        if (ctrl.GetType().ToString() == lblAnswer.GetType().ToString())
                        {
                            lblAnswer = (Label)ctrl;

                            if (lblAnswer.ID != null)
                            {
                                if (ctrl.ID.StartsWith("lblAnswer"))
                                {
                                    answer.AnswerCurrent = lblAnswer.Text;
                                    lblAnswer = new Label();
                                }
                            }

                           
                        }

                        else if (ctrl.GetType().ToString() == chbxIsRight.GetType().ToString())
                        {
                            chbxIsRight = (CheckBox)ctrl;
                            answer.IsRight = chbxIsRight.Checked;
                            chbxIsRight = new CheckBox();
                        }
                    }
                }

                listAnswer.Add(answer);
                answer = new AnswerABC();
            }

            return listAnswer;
        }

    }
}