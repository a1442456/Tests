using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ABC.User
{
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnGrayStyle_Click(object sender, EventArgs e)
        {
            HttpCookie cook = new HttpCookie("ChoosedStyle", "Gray");          
            cook.Expires.AddDays(1);
            Response.Cookies.Add(cook);           
            Response.Redirect("..\\Users\\Profile.aspx");
            
        }

        protected void btnBlueStyle_Click(object sender, EventArgs e)
        {
            HttpCookie cook = new HttpCookie("ChoosedStyle", "Blue");
            cook.Expires.AddDays(1);
            Response.Cookies.Add(cook);           
            Response.Redirect("..\\Users\\Profile.aspx");
        }

        protected void btnStatistic_Click(object sender, EventArgs e)
        {
            Response.Redirect("..\\Users\\Statistics.aspx");
        }
    }
}