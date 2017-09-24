using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Drawing;

namespace ABC.Else
{
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            MembershipCreateStatus status = new MembershipCreateStatus();

            if (Page.IsValid)
            {
                try
                {
                    MembershipUser newUser = Membership.CreateUser(txtbxLogin.Text, txtbxPassword.Text, txtbxMail.Text, txtbxQuestion.Text, txtbxAnswer.Text, true, out status);
                    Roles.AddUserToRole(txtbxLogin.Text, "User");
                    Response.Redirect("LoginPage.aspx");  
                }
                catch
                {
                    lblStatus.Visible = true;
                    lblStatus.Text = GetErrorMessage(status);
                }
            }
        }

        protected void btnGoBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("../others/StartPage.aspx");
        }

        protected void txtbxLogin_OnClick(object sender, EventArgs e)
        {
            txtbxLogin.Text = "";
        }

        public string GetErrorMessage(MembershipCreateStatus status)
        {

            switch (status)
            {
                case MembershipCreateStatus.DuplicateUserName:
                    return "Please, insert another UserName";

                case MembershipCreateStatus.DuplicateEmail:
                    return "Please, insert another e-Mail";

                case MembershipCreateStatus.InvalidPassword:
                    return "The password provided is invalid. Please enter a valid password value.";

                case MembershipCreateStatus.InvalidEmail:
                    return "The e-mail address provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidAnswer:
                    return "The password retrieval answer provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidQuestion:
                    return "The password retrieval question provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidUserName:
                    return "The user name provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.ProviderError:
                    return "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                case MembershipCreateStatus.UserRejected:
                    return "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                default:
                    return "Неизвестная ошибка. Пожалуйста проверьте ваши данные и попытайтесь зарегистрироваться заново, если проблема не устранится, то обратитесь за помощью к администрации сайта";
            }

        }


    }
}