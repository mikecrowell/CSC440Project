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
    public partial class Tags : System.Web.UI.Page
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
                addTag();
                DropDownList1.DataBind();
                DropDownList2.DataBind();
            }
            else if (RadioButton2.Checked == true)
            {
                modifyTag();
                DropDownList1.DataBind();
                DropDownList2.DataBind();
            }
            else if (RadioButton3.Checked == true)
            {
                if (RadioButton4.Checked == true)
                {
                    activateTag();
                }
                else if (RadioButton5.Checked == true)
                {
                    inactivateTag();
                }
                DropDownList1.DataBind();
                DropDownList2.DataBind();
            }
        }

        protected void addTag()
        {
            if (txtTagName.Text.Equals(""))
            {
                lblMessage.Text = "Tag name can not be blank!";
            }
            else
            {
                DataAccess da = new DataAccess();         
                TAG temp = da.getTagByName(txtTagName.Text);
                if (temp == null)
                {
                    Tag tag = new Tag();
                    tag.tagName = txtTagName.Text;
                    da.addNewTag(tag);

                    txtTagName.Text = "";

                    lblMessage.Text = "New tag has been added.";

                    updateControls();
                }
                else
                {
                    lblMessage.Text = "That tag already exists.";
                }

            }
        }

        protected void activateTag()
        {
            DataAccess da = new DataAccess();
            TAG tag = new TAG();
            tag = da.getTAGByID(Int32.Parse(DropDownList2.SelectedValue));

            tag.IS_ACTIVE = true;
            da.modifyTag(tag);

            lblMessage.Text = "Tag is active.";

            updateControls();
        }

        protected void inactivateTag()
        {
            DataAccess da = new DataAccess();
            TAG tag = new TAG();
            tag = da.getTAGByID(Int32.Parse(DropDownList2.SelectedValue));

            tag.IS_ACTIVE = false;
            da.modifyTag(tag);

            lblMessage.Text = "Tag is inactive.";

            updateControls();
        }

        protected void modifyTag()
        {
            DataAccess da = new DataAccess();
            TAG tag = new TAG();
            tag = da.getTagByName(txtModTagName.Text);
            if (tag == null)
            {
                tag = da.getTAGByID(Int32.Parse(DropDownList1.SelectedValue));

                tag.TAG_NAME = txtModTagName.Text;
                da.modifyTag(tag);

                lblMessage.Text = "Tag has been modified.";

                updateControls();
            }
            else
            {
                lblMessage.Text = "That tag name already exists.";
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

            List<Tag> activeList = new List<Tag>();
            activeList = da.getTagListActive();
            activeList.Sort();

            DropDownList1.DataSource = activeList;
            DropDownList1.DataTextField = "tagName";
            DropDownList1.DataValueField = "tagid";
            DropDownList1.DataBind();

            List<Tag> allList = new List<Tag>();
            allList = da.getTagList();
            allList.Sort();

            DropDownList2.DataSource = allList;
            DropDownList2.DataTextField = "tagName";
            DropDownList2.DataValueField = "tagid";
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
            TAG tag;
            tag = da.getTAGByID(Int32.Parse(DropDownList1.SelectedValue));
            txtModTagName.Text = tag.TAG_NAME.ToString();
        }

        protected void setActiveUserControls()
        {
            DataAccess da = new DataAccess();
            TAG tag;
            tag = da.getTAGByID(Int32.Parse(DropDownList2.SelectedValue));
            txtActiveTagName.Text = tag.TAG_NAME.ToString();
            if (tag.IS_ACTIVE == true)
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