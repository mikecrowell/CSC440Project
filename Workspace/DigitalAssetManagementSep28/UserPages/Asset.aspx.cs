using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using Ionic.Zip;
using System.IO;
using System.Security;
using System.Security.Permissions;


namespace DigitalAssetManagementSep28
{
    public partial class Asset : System.Web.UI.Page
    {

        private List<DataFile> currDataFiles = new List<DataFile>();
        private List<DataFile> currFilteredDataFiles = new List<DataFile>();

        protected void Page_Load(object sender, EventArgs e)
        {

            //setup JavaScript handlers for server controls
            //var chkListImagesClientID = chkListImages.ClientID;
            //chkImages.Attributes.Add("onclick", "ParentChkBox_Checked(this," + chkListImagesClientID + ")");

            //var chkListVideosClientId = chkListVideos.ClientID;
            //chkVideos.Attributes.Add("onclick", "ParentChkBox_Checked(this," + chkListVideosClientId + ")");

            //var chkListAudioClientId = chkListAudio.ClientID;
            //chkAudio.Attributes.Add("onclick", "ParentChkBox_Checked(this," + chkListAudioClientId + ")");

            //var chkListDocumentsId = chkListDocs.ClientID;
            //chkDocs.Attributes.Add("onclick", "ParentChkBox_Checked(this," + chkListDocumentsId + ")");

            if (Page.IsPostBack)
            {
                Control c = GetPostBackControl(Page);
                if (c.ID == "btnSearch")
                {
                    List<int> tagsToSearch = GetTagIDsToSearch();
                    ViewState["tagsToSearch"] = tagsToSearch;
                    Search(tagsToSearch);
                }
                else
                {
                    List<int> tagsToSearch = (List<int>)ViewState["tagsToSearch"];
                    if (tagsToSearch != null)
                    {
                        if (tagsToSearch.Count != 0)
                        {
                            Search(tagsToSearch);
                        }
                    }
                }
            }

        }
        public static Control GetPostBackControl(Page page)
        {
            Control control = null;

            string ctrlname = page.Request.Params.Get("__EVENTTARGET");
            if (ctrlname != null && ctrlname != string.Empty)
            {
                control = page.FindControl(ctrlname);
            }
            else
            {
                foreach (string ctl in page.Request.Form)
                {
                    Control c = page.FindControl(ctl);
                    if (c is System.Web.UI.WebControls.Button)
                    {
                        control = c;
                        break;
                    }
                }
            }
            return control;
        }

        protected void Search(List<int> tagsToSearch)
        {
            if (tagsToSearch.Count > 0)
            {
                if (rbAND.Checked == true)
                {
                    currDataFiles = GetListDataFilesAND(tagsToSearch);
                }
                else
                {
                    currDataFiles = GetListDataFilesOR(tagsToSearch);
                }
                currFilteredDataFiles = FilterByExtension(currDataFiles);
                //sort/prioritize results???


                //      txtResultsTest.Text = "Number of Files: " + currFilteredDataFiles.Count + "\n";
                //     foreach (DataFile df in currFilteredDataFiles)
                //      {
                //            txtResultsTest.Text += df.ToString() + "\n";
                //     }

                foreach (DataFile df in currFilteredDataFiles)
                {
                    String filePath = ("~/DataFiles/" + df.fileName + "." + df.extension.Trim());
                    String extension = df.extension.Replace(" ", "").ToUpper();
                    if (System.IO.File.Exists(Server.MapPath("~/DataFiles/" + df.fileName + "." + df.extension.Trim())))
                    {
                        AddImage(df, filePath);
                    }

                }
            }
            else
            {
                //    txtResultsTest.Text = "No Results";
            }
        }

        public bool ThumbnailCallback()
        {
            return false;
        }
        protected List<int> GetTagIDsToSearch() //converts string tags to integer tag IDs
        {
            List<String> strTags = txtSearch.Text.Trim().Split(null).ToList<String>();
            List<int> intTagsToSearch = new List<int>();
            List<DataFile> dfListToDisplay = new List<DataFile>();

            foreach (String strTag in strTags)
            {
                DataAccess da = new DataAccess();
                int id = da.getTagIDByTagName(strTag.ToUpper());
                if (intTagsToSearch.IndexOf(id) == -1 && id != -1) //don't add duplicate tags, don't add "-1" as it represents a tag not found
                {
                    intTagsToSearch.Add(id);
                }
            }
            return intTagsToSearch;
        }
        protected List<DataFile> GetListDataFilesOR(List<int> tagsToSearch) // "Or" search
        {
            DataAccess da = new DataAccess();
            List<DataFile> toReturn = new List<DataFile>();

            toReturn.AddRange(da.getListOfDataFilesByTagID(tagsToSearch[0]));
            for (int i = 1; i < tagsToSearch.Count; i++)
            {
                List<DataFile> list = da.getListOfDataFilesByTagID(tagsToSearch[i]);
                toReturn = toReturn.Union(list, new DataFileComparer()).ToList();
            }
            //prioritize results by number of tag matches
            foreach (DataFile df in toReturn)
            {
                foreach (int tagToSearch in tagsToSearch)
                {
                    foreach (Tag tag in df.tags)
                    {
                        if (tagToSearch == tag.tagid)
                        {
                            df.numTagMatches += 1;
                            break;
                        }
                    }
                }
            }
            toReturn = toReturn.OrderBy(df => df.numTagMatches).Reverse().ToList();
            return toReturn;
        }
        protected List<DataFile> GetListDataFilesAND(List<int> tagsToSearch) // "And" search
        {
            DataAccess da = new DataAccess();
            List<DataFile> toReturn = new List<DataFile>();

            toReturn.AddRange(da.getListOfDataFilesByTagID(tagsToSearch[0]));
            for (int i = 1; i < tagsToSearch.Count; i++)
            {
                List<DataFile> list = da.getListOfDataFilesByTagID(tagsToSearch[i]);
                toReturn = toReturn.Intersect(list, new DataFileComparer()).ToList();
            }

            return toReturn;
        }
        protected List<DataFile> FilterByExtension(List<DataFile> dataFiles)
        {
            List<String> allChecked = new List<String>();
            IEnumerable<String> checkedImages = (from item in chkListImages.Items.Cast<ListItem>()
                                                 where item.Selected
                                                 select item.Value);
            IEnumerable<String> checkedAudio = (from item in chkListAudio.Items.Cast<ListItem>()
                                                where item.Selected
                                                select item.Value);
            IEnumerable<String> checkedVideo = (from item in chkListVideos.Items.Cast<ListItem>()
                                                where item.Selected
                                                select item.Value);
            IEnumerable<String> checkedDocs = (from item in chkListDocs.Items.Cast<ListItem>()
                                               where item.Selected
                                               select item.Value);

            allChecked.AddRange(checkedImages);
            allChecked.AddRange(checkedAudio);
            allChecked.AddRange(checkedVideo);
            allChecked.AddRange(checkedDocs);
            for (int i = 0; i < dataFiles.Count; i++)
            {
                if (!(allChecked.Contains("." + dataFiles[i].extension.Replace(" ", ""))))
                {
                    dataFiles.Remove(dataFiles[i]);
                    i--;
                }
            }

            return dataFiles;
        }
        public void AddImage(DataFile df, String filePath)
        {
            System.Web.UI.WebControls.Image img = new Image();
            img.ImageUrl = filePath;
            img.Width = 150;
            img.Height = 150;
            DisplayImage di = new DisplayImage(df, img);
            pnlImages.Controls.Add(di);
            pnlImages.Controls.Add(di.chk);
        }
        protected void downloadButton_Click(object sender, EventArgs e)
        {
            List<DisplayImage> displayItems = new List<DisplayImage>();
            foreach (Control c in pnlImages.Controls)
            {
                if (c is DisplayImage)
                {
                    DisplayImage di = (DisplayImage)c;
                    if (di.chk.Checked == true)
                    {
                        displayItems.Add(di);
                    }
                }
            }
            if (displayItems.Count == 1)
            {
                downloadFile(displayItems[0]);
            }
            else if (displayItems.Count >= 1)
            {
                zipAndDownload(displayItems);
            }
            else if (displayItems.Count == 0) Response.Write("<script>alert('No items are marked for download.');</script>");

        }

        private void downloadFile(DisplayImage di)
        {
            string strURL = di.ImageUrl;
            if (System.IO.File.Exists(Server.MapPath("~/DataFiles/" + di.df.fileName + "." + di.df.extension.Trim())))
            {
                //Log user download
                DataAccess da = new DataAccess();
                da.logDownload(di.df.dfid, Page.User.Identity.Name);
                WebClient req = new WebClient();
                HttpResponse response = HttpContext.Current.Response;
                response.Clear();
                response.ClearContent();
                response.ClearHeaders();
                response.Buffer = false;
                response.AddHeader("Content-Disposition", "attachment;filename=\"" + di.df.fileName + "." + di.df.extension.Trim());
                byte[] data = req.DownloadData(Server.MapPath("~/DataFiles/" + di.df.fileName + "." + di.df.extension.Trim()));
                response.BinaryWrite(data);
                response.End();
            }
        }
        private void zipAndDownload(List<DisplayImage> displayItems)
        {
            //   Tell the browser we're sending a ZIP file!
            var downloadFileName = string.Format("YourDownload-{0}.zip", DateTime.Now.ToString("yyyy-MM-dd-HH_mm_ss"));
            Response.ContentType = "application/zip";
            Response.AddHeader("Content-Disposition", "filename=" + downloadFileName);
            using (var zip = new ZipFile())
            {
                // Construct the contents of the README.txt file that will be included in this ZIP
                var readMeMessage = string.Format("Your ZIP file {0} contains the following files:{1}{1}", downloadFileName, Environment.NewLine);
                foreach (DisplayImage di in displayItems)
                {
                    string rootpath = Server.MapPath("~/DataFiles/");
                    string namepath = di.df.fileName + "." + di.df.extension.Trim();
                    zip.AddFile(rootpath + namepath, "Downloaded Files");
                    //Log user download
                    DataAccess da = new DataAccess();
                    da.logDownload(di.df.dfid, Page.User.Identity.Name);
                }
                zip.Save(Response.OutputStream);
            }
        }
    }
}