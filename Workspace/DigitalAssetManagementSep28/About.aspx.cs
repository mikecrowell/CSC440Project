using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DigitalAssetManagementSep28
{
    public partial class About : System.Web.UI.Page
    {
        List<CheckBox> checkBoxList = new List<CheckBox>();

        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void DownloadButton_Click(object sender, EventArgs e)
        {
            checkBoxList.Add(CheckBox1);
            checkBoxList.Add(CheckBox2);
            checkBoxList.Add(CheckBox3);


            foreach (CheckBox checkbox in checkBoxList)
            {
                if (checkbox.Checked)
                {
                    checkbox.Checked = false;
                }

            }
        }

        
      
    }
}
