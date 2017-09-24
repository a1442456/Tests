using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace ABC.User
{
   
    public partial class ChooseTest : System.Web.UI.Page
    {
       

        protected void Page_Load(object sender, EventArgs e)
        {            
            if (!IsPostBack)
            {
                ThemeDAL tDAL = new ThemeDAL();

                foreach (string theme in tDAL.GetAllThemes())
                {
                    ddlTheme.Items.Add(theme);
                }

                ddlSubTheme.Items.Clear();

                SubThemeDAL stDAL = new SubThemeDAL();

                foreach (string subTheme in stDAL.GetAllSubThemesByThemeName(ddlTheme.SelectedValue))
                {
                    ddlSubTheme.Items.Add(subTheme);
                }

                ddlSubTheme.Visible = true;
            }

        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
          Session.Add("choosedSubTheme", ddlSubTheme.SelectedValue.ToString());
            //false to fix ThreadAbortException
          Response.Redirect("..\\Users\\StartTest.aspx",false);
        }

        protected void ddlTheme_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlSubTheme.Items.Clear();

            SubThemeDAL stDAL = new SubThemeDAL();

            foreach (string subTheme in stDAL.GetAllSubThemesByThemeName(ddlTheme.SelectedValue))
            {
                ddlSubTheme.Items.Add(subTheme);
            }

            ddlSubTheme.Visible = true;
        }

    }
}