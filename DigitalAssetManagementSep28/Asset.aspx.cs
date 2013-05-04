using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;



namespace DigitalAssetManagementSep28
{
    public partial class Asset : System.Web.UI.Page
    {
        
        private List<DataFile> currDataFiles = new List<DataFile>();
        private List<DataFile> currFilteredDataFiles = new List<DataFile>();

        protected void Page_Load(object sender, EventArgs e)
        {
            //setup JavaScript handlers for server controls
            var chkListImagesClientID = chkListImages.ClientID;
            chkImages.Attributes.Add("onclick", "ParentChkBox_Checked(this," + chkListImagesClientID + ")");

            var chkListVideosClientId = chkListVideos.ClientID;
            chkVideos.Attributes.Add("onclick", "ParentChkBox_Checked(this," + chkListVideosClientId + ")");

            var chkListAudioClientId = chkListAudio.ClientID;
            chkAudio.Attributes.Add("onclick", "ParentChkBox_Checked(this," + chkListAudioClientId + ")");

            var chkListDocumentsId = chkListDocs.ClientID;
            chkDocs.Attributes.Add("onclick", "ParentChkBox_Checked(this," + chkListDocumentsId + ")");

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            List<int> tagsToSearch = GetTagIDsToSearch();
            if (tagsToSearch.Count > 0)
            {
                currDataFiles = GetListDataFiles(tagsToSearch); // returns final result of "Or" search
                currFilteredDataFiles = FilterByExtension(currDataFiles);
                //sort/prioritize results???
   

                TextBox2.Text = "Number of Files: " + currFilteredDataFiles.Count + "\n";
                foreach (DataFile df in currFilteredDataFiles)
                {
                    TextBox2.Text += df.ToString() + "\n";
                }

                foreach(DataFile df in currFilteredDataFiles)
                {
                    String filePath = ("~/DataFiles/" + df.fileName + "." + df.extension.Replace(" ", ""));

                        System.Web.UI.WebControls.Image img = new Image();
                        img.ImageUrl = filePath;
                        img.Width = 100;
                        img.Height = 100;
                        DisplayImage di = new DisplayImage(df, img);
                        pnlImages.Controls.Add(di.img);
                    }

                
            }
            else
            {
                TextBox2.Text = "No Results";
            }
        }

        public bool ThumbnailCallback()
        {
            return false;
        }
        protected List<int> GetTagIDsToSearch() //converts string tags to integer tag IDs
        {
            List<String> strTags = txtSearch.Text.Split(null).ToList<String>();
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
        protected List<DataFile> GetListDataFiles(List<int> tagsToSearch) // "Or" search
        {
            DataAccess da = new DataAccess();
            List<DataFile> toReturn = new List<DataFile>();

            toReturn.AddRange(da.getListOfDataFilesByTagID(tagsToSearch[0]));
            for (int i = 1; i < tagsToSearch.Count; i++)
            {
                List<DataFile> list = da.getListOfDataFilesByTagID(tagsToSearch[i]);
                toReturn = toReturn.Union(list).ToList();
            }

            return toReturn;
        }
        protected List<DataFile> FilterByExtension(List<DataFile> dataFiles)
        {
           List<String> allChecked = new List<String>();
           IEnumerable<String> checkedImages =  (from item in chkListImages.Items.Cast<ListItem>() 
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
           for (int i=0; i<dataFiles.Count; i++)
           {
               if (!(allChecked.Contains("." + dataFiles[i].extension.Replace(" ", ""))))
               {
                   dataFiles.Remove(dataFiles[i]);
                   i--;
               }
           }

           return dataFiles;
        }
    }
}