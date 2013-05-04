using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.Web.UI.WebControls;

namespace DigitalAssetManagementSep28
{

    public class DisplayImage : Image 
    {
        public CheckBox chk;
        public DataFile df;
        public DisplayImage(DataFile df, Image img)
        {
            this.Width = 100;
            this.Height = 100;
            this.df = df;
            switch (this.df.extension.Trim().ToUpper())
            {
                case "FLA" : this.ImageUrl = "~/Images/FLA_Example.png"; break;
                case "MOV" : this.ImageUrl = "~/Images/MOV_Example.png"; break;
                case "PDF" : this.ImageUrl = "~/Images/PDF_Example.jpg"; break;
                case "SWF" : this.ImageUrl = "~/Images/SWF_Example.png"; break;
                case "WAV" : this.ImageUrl = "~/Images/WAV_Example.png"; break;
                case "WMV" : this.ImageUrl = "~/Images/WMV_Example.png"; break;
                case "MP4": this.ImageUrl = "~/Images/MP4_Example.jpg"; break;
                case "MP3": this.ImageUrl = "~/Images/MP3_Example.jpg"; break;
                default: this.ImageUrl = img.ImageUrl; break;
            }
            
            this.Attributes["style"] = "padding: 5px; margin 5px;";
            this.chk = new CheckBox();
            this.ToolTip = GetToolTip();
            chk.Attributes["style"] = "padding-right:10px;";
        }
        public String GetToolTip()
        {
            String strToReturn = "";
            strToReturn += "File Name: " + df.fileName + "." + df.extension.Trim() +  "\n" +
               GetFormattedTags();
            if (df.shortDesc.Replace(" ", "") != ""){
                strToReturn += "Short Description: " + df.shortDesc + "\n"; 
            }
            if (df.longDesc.Replace(" ", "") != "")
            {
                strToReturn += "Long Description: " + df.longDesc;
            }
            return strToReturn;
        } 
        public String GetFormattedTags()
        {
            String strToReturn = "" ;
            for (int i = 1; i <= df.tags.Count; i++)
            {
                strToReturn += "Tag " + i + ": " +  df.tags[i-1].tagName + "\n";
            }
            return strToReturn;
        }


    }

}