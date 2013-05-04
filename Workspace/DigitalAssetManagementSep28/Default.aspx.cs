using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DigitalAssetManagementSep28
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

     
        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void Login1_LoggedIn(object sender, EventArgs e)
        {
            AccountRoleProvider Roles = new AccountRoleProvider();
            if (Roles.IsUserInRole(Login1.UserName, "Admin"))
            {
                Response.Redirect("~/AdminPages/Admin.aspx");
            }
            else if (Roles.IsUserInRole(Login1.UserName, "User"))
            {
                Response.Redirect("~/UserPages/Asset.aspx");
            }
            else
            {
                Response.Redirect("~/AdminPages/DatabaseTestPage.aspx");
            }
        }

    }
}
