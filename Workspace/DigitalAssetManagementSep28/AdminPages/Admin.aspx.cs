using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security;
using System.Security.Permissions;


namespace DigitalAssetManagementSep28
{
    public partial class Admin : System.Web.UI.Page
    {
        string filename;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(IsPostBack))
            {
                DataAccess da = new DataAccess();
                List<Tag> tagList = new List<Tag>();
                tagList = da.getTagListActive();
                tagList.Sort();
                ddListTags.DataSource = tagList;
                ddListTags.DataTextField = "tagName";
                ddListTags.DataValueField = "tagid";
                ddListTags.DataBind();
            }
            if (Session["FileUpload1"] == null && FileUpload1.HasFile)
            {
                Session["FileUpload1"] = FileUpload1;
                Label3.Text = FileUpload1.FileName;
            }
            else if (Session["FileUpload1"] != null && (!FileUpload1.HasFile))
            {
                FileUpload1 = (FileUpload)Session["FileUpload1"];
                Label3.Text = FileUpload1.FileName;
            }
            else if (FileUpload1.HasFile)
            {
                Session["FileUpload1"] = FileUpload1;
                Label3.Text = FileUpload1.FileName;
            }
        }

         protected void addTagButton_Click(object sender, EventArgs e)
         {

             if (!(tagExists(tagTextBox.Text.ToUpper()))) 
             {
                 //we need to add code here to ask the user whether or not to add the tag
                 TagListBox.Items.Add(tagTextBox.Text.ToUpper());
             }
             else TagListBox.Items.Add(tagTextBox.Text.ToUpper());

         }

         protected void deleteTagButton_Click(object sender, EventArgs e)
         {
             TagListBox.Items.Remove(TagListBox.SelectedItem);
         }

         protected void tagExistButton_Click(object sender, EventArgs e)
         {
             Tag newTag = new Tag();
             newTag.tagName = checkExistTextBox.Text;
             DataAccess da = new DataAccess();
             if (da.isTagExisted(newTag))
                 checkExistLabel.Text = "Yes";
             else
                 checkExistLabel.Text = "No";
         }

         protected bool tagExists(String tagName)
         {
             Tag tagToCheck = new Tag();
             tagToCheck.tagName = tagName;
             DataAccess da = new DataAccess();
             if (da.isTagExisted(tagToCheck)) return true;
             else return false;

         }
         protected void numOfTagButton_Click(object sender, EventArgs e)
         {
            LinqToAllDataDataContext context = new LinqToAllDataDataContext();
            numOfTag.Text = context.TAGs.Count().ToString();       

            
         }

         protected void ddListTags_SelectedIndexChanged(object sender, EventArgs e)
         {
             tagTextBox.Text = ddListTags.SelectedItem.ToString();
         }

         protected void Upload_Click1(object sender, EventArgs e)
         {
             if (FileUpload1.HasFile)
             {
                 try
                 {
                     // retrieve destination path, file extension, and file name without extension
                     string path = Server.MapPath("~/DataFiles/"); // get directory of the destination file at runtime
                     string extension = System.IO.Path.GetExtension(FileUpload1.FileName);
                     extension = extension.Remove(0, 1);
                     string fileNameOnly = System.IO.Path.GetFileNameWithoutExtension(FileUpload1.FileName);
                     DataFile df = new DataFile();
                     DataAccess da = new DataAccess();

                     filename = FileUpload1.FileName;
                     if (da.getExtIDByExtension(extension) >= 0)
                     {
                         FileUpload1.SaveAs(path + FileUpload1.FileName); // real work here!
                         //show text 
                         Label1.Text = "File name: " +
                             FileUpload1.PostedFile.FileName + "<br>" +
                             FileUpload1.PostedFile.ContentLength + " kb<br>" +
                             "Content type: " +
                             FileUpload1.PostedFile.ContentType;

                         df.fileName = fileNameOnly;
                         df.extension = extension;
                         df.shortDesc = txtDescription.Text;
                         df.longDesc = "";

                         List<Tag> tagList = new List<Tag>();

                         foreach (ListItem tag in TagListBox.Items)
                         {
                             Tag t = new Tag();
                             t.tagName = tag.ToString();
                             tagList.Add(t);
                         }

                         df.tags = tagList;
                         da.addDataFile(df, Page.User.Identity.Name);

                         // update textbox
                         FullNameTextBox.Text = FileUpload1.FileName;
                         NameTextBox.Text = fileNameOnly;
                         ExtTextBox.Text = extension;

                         //refresh boxes
                         UploadLabel.Text = "Upload Successful";
                         TagListBox.Items.Clear();
                         txtDescription.Text = " ";
                         tagTextBox.Text = " ";
                         Label3.Text = " ";
                     }
                     else
                     {
                         UploadLabel.Text = "You have selected an unsupported file type.";
                     }

                 }
                 catch (Exception ex)
                 {
                     UploadLabel.Text = "ERROR: " + ex.Message.ToString();
                 }
             }
             else
             {
                 UploadLabel.Text = "You have not specified a file.";
             }
         }

      

    }
    
}