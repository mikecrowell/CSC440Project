using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigitalAssetManagementSep28
{
    public class DataAccess
    {
        LinqToAllDataDataContext linqDat = new LinqToAllDataDataContext();

        public List<DataFile> getListOfDataFiles()
        {
            List<DataFile> dfList = new List<DataFile>();

            var files = from dat in linqDat.DATAFILEs
                        join ext in linqDat.EXTENSIONs on dat.EXTENSION_ID equals ext.EXTENSION_ID
                        join cat in linqDat.CATEGORies on ext.CATEGORY_ID equals cat.CATEGORY_ID
                    //    where dat.FILE_NAME.Contains("TEST") //TESTING where condition
                        select new
                        {
                            dat,
                            ext,
                            cat
                        };

            foreach (var v in files)
            {
                DataFile df = new DataFile();
                df.dfid = v.dat.DF_ID;
                df.fileName = v.dat.FILE_NAME;
                df.extension = v.ext.FILE_EXTENSION;
                df.shortDesc = v.dat.SHORT_DESC;
                df.longDesc = v.dat.LONG_DESC;
                df.category = v.cat.CATEGORY_NAME;
                df.tags = getFileTagsByFileID(df.dfid);
                dfList.Add(df);
            }

            return dfList;
        }

        public List<DataFile> getListOfDataFilesByTagID(int t)
        {
            List<DataFile> dfList = new List<DataFile>();

            var files = from dat in linqDat.DATAFILEs
                        join ext in linqDat.EXTENSIONs on dat.EXTENSION_ID equals ext.EXTENSION_ID
                        join cat in linqDat.CATEGORies on ext.CATEGORY_ID equals cat.CATEGORY_ID
                        join ftag in linqDat.FILE_TAGs on dat.DF_ID equals ftag.DF_ID
                        join tag in linqDat.TAGs on ftag.TAG_ID equals tag.TAG_ID
                        where tag.TAG_ID == t
                        select new
                        {
                            dat,
                            ext,
                            cat
                        };

            foreach (var v in files)
            {
                DataFile df = new DataFile();
                df.dfid = v.dat.DF_ID;
                df.fileName = v.dat.FILE_NAME;
                df.extension = v.ext.FILE_EXTENSION;
                df.shortDesc = v.dat.SHORT_DESC;
                df.longDesc = v.dat.LONG_DESC;
                df.category = v.cat.CATEGORY_NAME;
                df.tags = getFileTagsByFileID(df.dfid);
                dfList.Add(df);
            }

            return dfList;
        }


        public DataFile getFileByID(int id)
        {
            DataFile df = new DataFile();

            var files = from dat in linqDat.DATAFILEs
                        join ext in linqDat.EXTENSIONs on dat.EXTENSION_ID equals ext.EXTENSION_ID
                        join cat in linqDat.CATEGORies on ext.CATEGORY_ID equals cat.CATEGORY_ID
                        where dat.DF_ID == id
                        select new
                        {
                            dat,
                            ext,
                            cat
                        };

            df.dfid = files.First().dat.DF_ID;
            df.fileName = files.First().dat.FILE_NAME;
            df.extension = files.First().ext.FILE_EXTENSION;
            df.shortDesc = files.First().dat.SHORT_DESC;
            df.longDesc = files.First().dat.LONG_DESC;
            df.category = files.First().cat.CATEGORY_NAME;
            df.tags = getFileTagsByFileID(df.dfid);

            return df;
        }


        public List<Tag> getFileTagsAll()
        {
            List<Tag> tagList = new List<Tag>();

            var tags = (from dat in linqDat.DATAFILEs
                        join filetag in linqDat.FILE_TAGs on dat.DF_ID equals filetag.DF_ID
                        join tag in linqDat.TAGs on filetag.TAG_ID equals tag.TAG_ID
                        select new { tag }).Distinct();
                       

            foreach (var v in tags)
            {
                Tag t = new Tag();
                t.tagid = v.tag.TAG_ID;
                t.tagName = v.tag.TAG_NAME;
                tagList.Add(t);
            }

            return tagList;
        }


        public List<Tag> getFileTagsByFileID(int id)
        {
            List<Tag> tagList = new List<Tag>();

            var tags = from dat in linqDat.DATAFILEs
                       join filetag in linqDat.FILE_TAGs on dat.DF_ID equals filetag.DF_ID
                       join tag in linqDat.TAGs on filetag.TAG_ID equals tag.TAG_ID
                       where dat.DF_ID == id
                       select new
                       {
                           tag
                       };

            foreach (var v in tags)
            {
                Tag t = new Tag();
                t.tagid = v.tag.TAG_ID;
                t.tagName = v.tag.TAG_NAME;
                tagList.Add(t);
            }

            return tagList;
        }


        public List<Category> getCategoriesAll()
        {
            List<Category> categoryList = new List<Category>();

            //TODO: Insert code to return a list of Categories

            return categoryList;
        }


        public List<Extension> getExtensionsAll()
        {
            List<Extension> extensionList = new List<Extension>();

            //TODO: Insert code to return a list of Extensions

            return extensionList;
        }


        public List<AppUser> getAppUsersAll()
        {
            List<AppUser> userList = new List<AppUser>();

            //TODO: Insert code to return a list of App Users 

            return userList;
        }


        public AppUser getAppUserByID(int id)
        {
            AppUser user = new AppUser();

            //TODO: Insert code to return a single App User

            return user;
        }


        public void addDataFile(DataFile df)
        {
            
            DATAFILE newDF = new DATAFILE();

            newDF.FILE_NAME = df.fileName;
            newDF.SHORT_DESC = df.shortDesc;
            newDF.LONG_DESC = df.longDesc;
            newDF.EXTENSION_ID = df.ext_id;
            linqDat.DATAFILEs.InsertOnSubmit(newDF);

            linqDat.SubmitChanges();

            foreach (var t in df.tags)
            {
                FILE_TAG newFT = new FILE_TAG();
                newFT.TAG_ID = t.tagid;
                newFT.DF_ID = newDF.DF_ID;
                linqDat.FILE_TAGs.InsertOnSubmit(newFT);
            }

            linqDat.SubmitChanges();

        }

    }
}