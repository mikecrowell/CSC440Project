using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace DigitalAssetManagementSep28
{
    public partial class DucTestPage : System.Web.UI.Page
    {
        public string fullName, name, ext;
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }
       
        protected void Upload_OnClick(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
                try
                {
                    // retrieve destination path, file extension, and file name without extension
                    string path = Server.MapPath("~\\DataFiles\\"); // get director of the destination file at runtime
                    string extension = System.IO.Path.GetExtension(FileUpload1.FileName);
                    string fileNameOnly = System.IO.Path.GetFileNameWithoutExtension(FileUpload1.FileName);
                    FileUpload1.SaveAs(path + FileUpload1.FileName); // real work here!
                    //show text 
                    Label1.Text = "File name: " +
                             FileUpload1.PostedFile.FileName + "<br>" +
                             FileUpload1.PostedFile.ContentLength + " kb<br>" +
                             "Content type: " +
                             FileUpload1.PostedFile.ContentType;

                    // using linq to add file to Test_Duc table in SQL database
                    new Models.TestDucAccess().updateFiles(FileUpload1.FileName, fileNameOnly, extension); //real work here

                    // update textbox
                    FullNameTextBox.Text = FileUpload1.FileName;
                    NameTextBox.Text = fileNameOnly;
                    ExtTextBox.Text = extension;
                }
                catch (Exception ex)
                {
                    Label1.Text = "ERROR: " + ex.Message.ToString();
                }
            else
            {
                Label1.Text = "You have not specified a file.";
            }
        } 
    }
}