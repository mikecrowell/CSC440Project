using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DigitalAssetManagementSep28
{
    public partial class DatabaseTestPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!(IsPostBack))
            {
                DataAccess da = new DataAccess();
                List<DataFile> dfList = new List<DataFile>();
                dfList = da.getListOfDataFiles();

                Label1.Text = "";
                Label2.Text = "";
                Label3.Text = "";
                Label4.Text = "";

                DropDownList1.DataSource = dfList;
                DropDownList1.DataTextField = "shortDesc";
                DropDownList1.DataValueField = "dfid";
                DropDownList1.DataBind();

                GridView2.DataSource = dfList;
                GridView2.DataBind();

                List<Tag> tagList = new List<Tag>();
                tagList = da.getFileTagsAll();
                DropDownList2.DataSource = tagList;
                DropDownList2.DataTextField = "tagName";
                DropDownList2.DataValueField = "tagid";
                DropDownList2.DataBind();

            }

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

            DataAccess da = new DataAccess();
            DataFile df = new DataFile();
            df = da.getFileByID(Int32.Parse(DropDownList1.SelectedValue));

            string filename = "~/DataFiles/" + df.fileName + "." + df.extension;
            Label1.Text = filename;
            Image1.Visible = true;
            Image1.ImageUrl = filename.ToString();

            Label1.Text = filename;
            Label2.Text = df.shortDesc;
            Label3.Text = df.longDesc;
            Label4.Text = df.category;

            GridView1.DataSource = df.tags;
            GridView1.DataBind();

            

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            DataFile df = new DataFile();
            df.fileName = TextBox1.Text;
            df.ext_id = Int32.Parse(TextBox2.Text);
            df.shortDesc = TextBox3.Text;
            df.longDesc = TextBox4.Text;

            List<Tag> tags = new List<Tag>();

            Tag t = new Tag();
            t.tagid = Int32.Parse(TextBox5.Text.ToString());
            tags.Add(t);

            Tag t2 = new Tag();
            t2.tagid = Int32.Parse(TextBox6.Text.ToString());
            tags.Add(t2);

            df.tags = tags;

            DataAccess da = new DataAccess();
            da.addDataFile(df);
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataAccess da = new DataAccess();
            List<DataFile> datList = new List<DataFile>();
            datList = da.getListOfDataFilesByTagID(Int32.Parse(DropDownList2.SelectedValue));
            GridView2.DataSource = datList;
            GridView2.DataBind();
        }

    }
}