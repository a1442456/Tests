using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace ABC.MasterPages
{
    public partial class MainPage : System.Web.UI.MasterPage
    {
        MembershipUser currentUser;

        protected void Page_Load(object sender, EventArgs e)
        {
            string greetingsTxt = "You authorized as:";

            currentUser = Membership.GetUser();

            if (currentUser != null)
            {
                lblGreeting.Text = greetingsTxt;
                lblUserName.Text = " " + currentUser.UserName;
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (Membership.ValidateUser(txtbxLogin.Text, txtbxPassword.Text))
            {
                FormsAuthentication.RedirectFromLoginPage(txtbxLogin.Text, false);
            }            
        }

        protected void btnProfile_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Users/Profile.aspx");
        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
        }

        protected void btnRegistration_Click(object sender, EventArgs e)
        {
            Response.Redirect("../others/Registration.aspx");
        }
    }
}