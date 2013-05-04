using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DigitalAssetManagementSep28;
using System.Collections;

namespace Test_Duc.Models
{

    public class Test_Duc
    {
        public int file_ID { get; set; }
        public string file_fullName { get; set; }
        public string file_Name { get; set; }
        public string file_Ext { get; set; }
    }
   
       /* // return the whole table
        public IList getFiles(string fid)
        {
            LinqToAllDataDataContext filesContext = new LinqToAllDataDataContext();
            int number;
            IList files = new List<TEST_DUC>();
            bool result = Int32.TryParse(fid, out number);
            if (result)
            {
                var thefiles = from f in filesContext.TEST_DUCs
                               where f.File_ID == int.Parse(fid)
                               select f;
                files = thefiles.ToList();
            }

            return files;

        }

        // return a specific row in the table
        public Test_Duc getFilebyID(int fileID)
        {
            LinqToAllDataDataContext filesContext = new LinqToAllDataDataContext();
            var thefiles = from f in filesContext.TEST_DUCs
                           where f.File_ID == File_ID
                           select f;
            return this;
        } 
    }*/
}