using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DigitalAssetManagementSep28;

namespace DigitalAssetManagementSep28.Models
{
    public class TestDucAccess
    {
        LinqToAllDataDataContext dataContext = new LinqToAllDataDataContext();

        public IList<TEST_DUC> queryTestDucFiles()
        {
            LinqToAllDataDataContext filesContext = new LinqToAllDataDataContext();
            IList<TEST_DUC> files = new List<TEST_DUC>();
           
                var thefiles = from f in filesContext.TEST_DUCs
                                select f;
                files = thefiles.ToList();
            return files;
        }

        public void updateFiles(string fullname, string name, string ext)
        {
            LinqToAllDataDataContext dataContext = new LinqToAllDataDataContext();
            TEST_DUC testDuc = new TEST_DUC();
            testDuc.File_FullName = fullname;
            testDuc.File_Name = name;
            testDuc.File_Ext = ext;
            dataContext.TEST_DUCs.InsertOnSubmit(testDuc);
            dataContext.SubmitChanges();
           
        }
    }
}