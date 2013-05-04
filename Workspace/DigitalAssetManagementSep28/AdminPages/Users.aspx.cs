using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;


namespace DigitalAssetManagementSep28.AdminPages
{
    public partial class Users : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(IsPostBack))
            {
                lblMessage.Text = "";
                updateControls();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (RadioButton1.Checked == true)
            {
                addUser();
                DropDownList1.DataBind();
                DropDownList2.DataBind();
            }
            else if (RadioButton2.Checked == true)
            {
                modifyUser();
                DropDownList1.DataBind();
                DropDownList2.DataBind();
            }
            else if (RadioButton3.Checked == true)
            {
                if (RadioButton4.Checked == true)
                {
                    activateUser();
                }
                else if (RadioButton5.Checked == true)
                {
                    inactivateUser();
                }
                DropDownList1.DataBind();
                DropDownList2.DataBind();
            }
        }

        protected void addUser()
        {
            if (txtFirstName.Text.Equals("") && txtLastName.Text.Equals("") && txtLogin.Text.Equals("") && txtPassword.Text.Equals(""))
            {
                lblMessage.Text = "All fields must be filled in!";
            }
            else
            {
                DataAccess da = new DataAccess();         
                AppUser temp = da.getUserByLoginName(txtLogin.Text);
                if (temp == null)
                {
                    AppUser user = new AppUser();
                    user.firstName = txtFirstName.Text;
                    user.lastName = txtLastName.Text;
                    user.userLogin = txtLogin.Text;
                    user.userPassword = txtPassword.Text;
                    user.isAdmin = chkIsAdmin.Checked;
                    da.addUser(user);

                    txtFirstName.Text = "";
                    txtLastName.Text = "";
                    txtLogin.Text = "";
                    txtPassword.Text = "";
                    chkIsAdmin.Checked = false;

                    lblMessage.Text = "New user has been added.";

                    updateControls();
                }
                else
                {
                    lblMessage.Text = "That login name already exists.  Login name must be unique.";
                }

            }
        }

        protected void activateUser()
        {
            DataAccess da = new DataAccess();
            AppUser user = new AppUser();
            user = da.getUserByID(Int32.Parse(DropDownList2.SelectedValue));

            user.isActive = true;
            da.modifyUser(user);

            lblMessage.Text = "User is active.";

            updateControls();
        }

        protected void inactivateUser()
        {
            DataAccess da = new DataAccess();
            AppUser user = new AppUser();
            user = da.getUserByID(Int32.Parse(DropDownList2.SelectedValue));

            user.isActive = false;
            da.modifyUser(user);

            lblMessage.Text = "User is inactive.";

            updateControls();
        }

        protected void modifyUser()
        {
            DataAccess da = new DataAccess();
            AppUser user = new AppUser();
            user = da.getUserByLoginName(txtLogin.Text);
            if (user == null)
            {
                user = da.getUserByID(Int32.Parse(DropDownList1.SelectedValue));

                user.firstName = txtModFirstName.Text;
                user.lastName = txtModLastName.Text;
                user.userLogin = txtModLogin.Text;
                user.userPassword = txtModPassword.Text;
                user.isAdmin = chkModIsAdmin.Checked;
                da.modifyUser(user);

                lblMessage.Text = "User has been modified.";

                updateControls();
            }
            else
            {
                lblMessage.Text = "That login name already exists.  Login name must be unique.";
            }

        }


        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            setModUserControls();
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            setActiveUserControls();
        }

        protected void updateControls()
        {
            DataAccess da = new DataAccess();

            List<AppUser> activeList = new List<AppUser>();
            activeList = da.getAppUsersActive();
            activeList.Sort();

            DropDownList1.DataSource = activeList;
            DropDownList1.DataTextField = "fullName";
            DropDownList1.DataValueField = "appuserid";
            DropDownList1.DataBind();

            List<AppUser> allList = new List<AppUser>();
            allList = da.getAppUsersAll();
            allList.Sort();

            DropDownList2.DataSource = allList;
            DropDownList2.DataTextField = "fullName";
            DropDownList2.DataValueField = "appuserid";
            DropDownList2.DataBind();

            setModUserControls();
            setActiveUserControls();

            RadioButton1.Checked = true;
            RadioButton2.Checked = false;
            RadioButton3.Checked = false;

        }

        protected void setModUserControls()
        {
            DataAccess da = new DataAccess();
            AppUser user;
            user = da.getUserByID(Int32.Parse(DropDownList1.SelectedValue));
            txtModFirstName.Text = user.firstName;
            txtModLastName.Text = user.lastName;
            txtModLogin.Text = user.userLogin;
            txtModPassword.Text = user.userPassword;
            chkModIsAdmin.Checked = user.isAdmin;
        }

        protected void setActiveUserControls()
        {
            DataAccess da = new DataAccess();
            AppUser user;
            user = da.getUserByID(Int32.Parse(DropDownList2.SelectedValue));
            txtActiveFirstName.Text = user.firstName;
            txtActiveLastName.Text = user.lastName;
            txtActiveLogin.Text = user.userLogin;
            txtActivePassword.Text = user.userPassword;
            chkActiveIsAdmin.Checked = user.isAdmin;
            if (user.isActive)
            {
                RadioButton4.Checked = true;
                RadioButton5.Checked = false;
            }
            else
            {
                RadioButton4.Checked = false;
                RadioButton5.Checked = true;
            }
        }

    }

}