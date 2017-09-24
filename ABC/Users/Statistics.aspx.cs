using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace ABC.Users
{
    public partial class Statistics : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TestABC tABC = new TestABC();
            MembershipABC user = new MembershipABC();

            Guid userId = new Guid();
            userId = user.GetUserIdByUserName(Membership.GetUser().UserName);


            tABC.CreateViewOfStatistic(userId, tblStatistic);

        }
    }
}