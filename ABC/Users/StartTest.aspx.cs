using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ABC.User
{
    public partial class StartTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            bool isShuffle;
            if (IsPostBack)
            {
                isShuffle = false;
                CreateTableOfQuests(tblTest, (TestABC)Session["choosetTest"], isShuffle);

                lblTester.Text = "Postback";

                foreach (Control ctrl in tblTest.Controls)
                {
                    lblTester.Text += ctrl.GetType().ToString() + " " + ctrl.ID + "<br/>";
                }
            }
            if (!IsPostBack)
            {
                isShuffle = true;
                TestABC tABC = new TestABC(Session["choosedSubTheme"].ToString());
                Session.Add("choosetTest",tABC);
                CreateTableOfQuests(tblTest, tABC, isShuffle);

                lblTester.Text = "!Postback";

                foreach (Control ctrl in tblTest.Controls)
                {
                    lblTester.Text += ctrl.GetType().ToString() + " " + ctrl.ID + "<br/>";
                }
            }


        }        

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("..\\Users\\ChooseTest.aspx");
        }

        protected void btnComplete_Click(object sender, EventArgs e)
        {
            

            //Достаем все радиобаттоны из таблицы
            List<RadioButton> rbtnList = new List<RadioButton>();
            rbtnList = GetAllRbtnFromTable(tblTest);

            

           
            //Получаем из списка всех радиобаттонов только нажатые
            List<string> idOfSelectedRBTN = new List<string>();
            idOfSelectedRBTN = GetAllSelectedRBTNID(rbtnList);

           
            //Получаем цифры из полного ИД
            
            List<string> tmpSelectedRbtn = new List<string>();

            foreach (string rbtnID in idOfSelectedRBTN)
            {
                string rbtn = rbtnID;
                rbtn = GetNumbersFromString(rbtnID);
                tmpSelectedRbtn.Add(rbtn);
                
            }

            idOfSelectedRBTN = tmpSelectedRbtn;

            //Конвертируем айдишник лэйбла
            List<string> listOfLblID = new List<string>();

            foreach (string id in idOfSelectedRBTN)
            {
                listOfLblID.Add(ConvertIDToMask(id, "lblAnswer", false));
            }

            //Получаем список из лэйблов(те, что напротив нажатого баттона)
            List<Label> listLbl = new List<Label>();

            foreach (string lblId in listOfLblID)
            {
                listLbl.Add((Label)GetControlInTable(tblTest, lblId));
            }

            AnswerDAL aDAL = new AnswerDAL();

            //проверяем правильные ли ответы и возвращаем результат
            int rightAnswers = 0;
            Color clrRight = new Color();
            Color clrWrong = new Color();
            clrRight = Color.Green;
            clrWrong = Color.Red;
            foreach (Label lbl in listLbl)
            {

                if (aDAL.IsRightAnswer(lbl.Text))
                {
                    ChangeRowColorTo(tblTest, string.Format("tRow{0}", GetNumbersFromString(lbl.ID)), clrRight);
                    rightAnswers++;
                }

                else
                {
                    ChangeRowColorTo(tblTest, string.Format("tRow{0}", GetNumbersFromString(lbl.ID)), clrWrong);
                }
            }

            TestABC tABC = new TestABC(Session["choosedSubTheme"].ToString());

            lblResult.Text = GetResultInString(tABC.QuestionCount, rightAnswers, "Your result is: ") + "%";

            double underScoredRes = tABC.QuestionCount / 100.00;
            double res = rightAnswers / underScoredRes;
            
            SubThemeDAL stDAL = new SubThemeDAL();
            int idSubTheme = stDAL.GetSubThemeIdBySubThemeNameViaStoredProc(Session["choosedSubTheme"].ToString());

            BaseDAL dalABC = new BaseDAL();
            MembershipABC memABC = new MembershipABC();
            Guid idUser = memABC.GetUserIdByUserName(Membership.GetUser().UserName);

            tABC.InsertResult(res, idSubTheme, idUser, DateTime.Now);

            //btnComplete.Visible = false;

            
            
            
        }        

        protected List<string> GetAllSelectedRBTNID(List<RadioButton> rbtnList)
        {
            List<string> idList = new List<string>();
            foreach (RadioButton rbtn in rbtnList)
            {
                if (!rbtn.Checked)
                {
                   continue;
                }
                else
                {
                    idList.Add(rbtn.ID);
                }
            }

            return idList;
        }

        protected List<RadioButton> GetAllRbtnFromTable(Table tbl)
        {
            List<RadioButton> rbtnList = new List<RadioButton>();
            RadioButton rbtn = new RadioButton();

            foreach (TableRow tRow in tbl.Controls)
            {
                foreach (TableCell tCell in tRow.Controls)
                {
                    foreach (Control ctrl in tCell.Controls)
                    {
                        if (ctrl.GetType() != rbtn.GetType())
                        {
                            continue;
                        }
                        else
                        {
                            rbtnList.Add((RadioButton)ctrl);
                        }
                    }                   
                }
            }

            return rbtnList;
        }

        protected string ConvertIDToMask(string id, string mask, bool isIDinFront)
        {
            string lblID = "";          
            

            if (isIDinFront)
            {
                lblID = id + mask;
            }

            else
            {
                lblID = mask + id;
            }
            

            return lblID;
        }

        protected Control GetControlInTable(Table tbl, string idControl)
        {

            Control wantedCtrl = new Control();
            
            wantedCtrl.ID = idControl;            

            foreach (TableRow tRow in tbl.Rows)
            {
                foreach (TableCell tCell in tRow.Cells)
                {
                    foreach (Control ctrl in tCell.Controls)
                    {
                        if (wantedCtrl.ID != ctrl.ID)
                        {
                            continue;
                        }

                        else
                        {
                            return ctrl;
                        }                        
                    }
                }
            }

            return wantedCtrl;
        }

        protected void ChangeRowColorTo(Table tbl, string rowID, Color clr)
        {
            foreach (TableRow tRow in tbl.Rows)
            {
                if (tRow.ID == rowID)
                {
                    foreach (TableCell tCell in tRow.Cells)
                    {
                        tCell.BackColor = clr;
                    }
                }
            }
        }

        protected string GetResultInString(double questionCount, double rightAnswerCount, string mask)
        {
            string result = "";
            double res =  rightAnswerCount / (questionCount / 100);
            result = mask + res.ToString();
            return result;
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

        protected List<string> GetListOfSelectedRbtnID(Panel panel)
        {
            List<string> ListOfRbtnId = new List<string>();
            RadioButton rb = new RadioButton();

            foreach (Control c in panel.Controls)
            {
                if (c.GetType() == rb.GetType())
                {
                    rb = (RadioButton)c;

                    if (rb.Checked)
                    {
                        ListOfRbtnId.Add(rb.ID.ToString());
                    }
                }
            }



            return ListOfRbtnId;
        }

        public void CreateTableOfQuests(Table tbl, TestABC tABC, bool isShuffle)
        {

            QuestionDAL qDAL = new QuestionDAL();
            AnswerDAL aDAL = new AnswerDAL();
            Label lblQestion = new Label();
            Label lblAnswer = new Label();
            Label lblNumerator = new Label();
            RadioButton rbtnAnswer = new RadioButton();

            TableCell tCell = new TableCell();
            TableRow tRow = new TableRow();

            int i = 0;
            int j = 0;
            int q = 0;

            tbl.CssClass = "AbcTest";

            foreach (QuestionABC qt in tABC.QuestionList)
            {
                lblNumerator.Text = string.Format("{0}.", q + 1);
                tCell.Controls.Add(lblNumerator);
                tCell.HorizontalAlign = HorizontalAlign.Center;
                tCell.VerticalAlign = VerticalAlign.Middle;
                tCell.ID = string.Format("tCell{0}{1}", i, j);
                j++;
                tRow.Cells.Add(tCell);
                lblNumerator = new Label();
                tCell = new TableCell();

                lblQestion.Text = qt.QuestionCurrent;
                tCell.Controls.Add(lblQestion);
                tCell.HorizontalAlign = HorizontalAlign.Center;
                tCell.VerticalAlign = VerticalAlign.Middle;
                tCell.ID = string.Format("tCell{0}{1}", i, j);
                tRow.Cells.Add(tCell);
                j = 0;
                tRow.ID = string.Format("tRow{0}", i);
                i++;

                tbl.Rows.Add(tRow);

                tCell = new TableCell();
                tRow = new TableRow();
                lblQestion = new Label();

                if (isShuffle)
                {
                    Shuffle(qt.ListAnswers);
                }

                foreach (AnswerABC answer in qt.ListAnswers)
                {
                    rbtnAnswer.ID = string.Format("rbtn{0}", i);
                    rbtnAnswer.GroupName = string.Format("rbtnGrP{0}", q);
                    tCell.Controls.Add(rbtnAnswer);
                    tCell.HorizontalAlign = HorizontalAlign.Center;
                    tCell.VerticalAlign = VerticalAlign.Middle;
                    tCell.ID = string.Format("tCell{0}{1}", i, j);
                    j++;
                    tRow.Cells.Add(tCell);

                    tCell = new TableCell();

                    lblAnswer.ID = string.Format("lblAnswer{0}", i);
                    lblAnswer.Text = answer.AnswerCurrent;
                    tCell.Controls.Add(lblAnswer);
                    tCell.HorizontalAlign = HorizontalAlign.Center;
                    tCell.ID = string.Format("tCell{0}{1}", i, j);
                    tCell.HorizontalAlign = HorizontalAlign.Left;
                    j++;
                    tRow.Cells.Add(tCell);

                    tCell = new TableCell();

                    j = 0;
                    tRow.ID = string.Format("tRow{0}", i);
                    i++;

                    tbl.Rows.Add(tRow);

                    tRow = new TableRow();

                    rbtnAnswer = new RadioButton();
                    lblAnswer = new Label();

                }

                q++;
            }
        }

        public void Shuffle(List<AnswerABC> list)
        {
            Random rng = new Random();
            AnswerABC a = new AnswerABC();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                a = list[k];
                list[k] = list[n];
                list[n] = a;
            }
        }

       
    }
}