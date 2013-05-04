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

            var cats = from cat in linqDat.CATEGORies
                       select new { cat };

            foreach (var v in cats)
            {
                Category c = new Category();
                c.categoryid = v.cat.CATEGORY_ID;
                c.categoryName = v.cat.CATEGORY_NAME;
                categoryList.Add(c);
            }

            return categoryList;
        }


        public List<Extension> getExtensionsAll()
        {
            List<Extension> extensionList = new List<Extension>();

            var exts = from ext in linqDat.EXTENSIONs
                       select new { ext };

            foreach (var v in exts)
            {
                Extension e = new Extension();
                e.extensionid = v.ext.EXTENSION_ID;
                e.fileExtension = v.ext.FILE_EXTENSION;
                extensionList.Add(e);
            }

            return extensionList;
        }

        public List<TRANSACTIONTYPE> getTransactionTypeAll()
        {
            List<TRANSACTIONTYPE> ttypeList = new List<TRANSACTIONTYPE>();

            var ttypes = from ttype in linqDat.TRANSACTIONTYPEs
                       select new { ttype };

            foreach (var v in ttypes)
            {
                TRANSACTIONTYPE t = new TRANSACTIONTYPE();
                t.TTYPE_ID = v.ttype.TTYPE_ID;
                t.TTYPE_NAME = v.ttype.TTYPE_NAME;
                ttypeList.Add(t);
            }

            return ttypeList;
        }

        public List<AppUser> getAppUsersAll()
        {
            List<AppUser> userList = new List<AppUser>();

            var users = (from dat in linqDat.APPUSERs
                         select new { dat });

            foreach (var v in users)
            {
                AppUser u = new AppUser();
                u.appuserid = v.dat.APPUSER_ID;
                u.lastName = v.dat.LAST_NAME;
                u.firstName = v.dat.FIRST_NAME;
                u.fullName = u.firstName + " " + u.lastName;
                u.userLogin = v.dat.USER_LOGIN;
                u.userPassword = v.dat.USER_PASSWORD;
                u.isAdmin = v.dat.IS_ADMINISTRATOR;
                userList.Add(u);
            }

            return userList;
        }


        public void addDataFile(DataFile df, String name)
        {            
            DATAFILE newDF = new DATAFILE();
            newDF.FILE_NAME = df.fileName;
            newDF.SHORT_DESC = df.shortDesc;
            newDF.LONG_DESC = df.longDesc;
            newDF.EXTENSION_ID = getExtIDByExtension(df.extension);
            linqDat.DATAFILEs.InsertOnSubmit(newDF);
            linqDat.SubmitChanges();
            foreach (var t in df.tags)
            {
                FILE_TAG newFT = new FILE_TAG();  
                if (isTagExisted(t))
                {                                      
                    newFT.TAG_ID = t.tagid; //need modification here                                   
                }
                else 
                {                   
                    addTag(t, newFT);                                              
                }
                newFT.DF_ID = newDF.DF_ID;       
                linqDat.FILE_TAGs.InsertOnSubmit(newFT);
                linqDat.SubmitChanges();

                int userID = getUserIDByName(name);
                logUserActivity(newDF.DF_ID, userID, 1);
            }            
        }

        public void addTag(Tag newtag, FILE_TAG ft)
        {            
                TAG tagToBeAdded = new TAG();            
                tagToBeAdded.TAG_NAME = newtag.tagName;               
                linqDat.TAGs.InsertOnSubmit(tagToBeAdded);
                linqDat.SubmitChanges();
                //assign TAG_ID of new TAG tagtobeadded --> TAG_ID of new FILE_TAG ft
                ft.TAG_ID = tagToBeAdded.TAG_ID;                
        }

        public void addNewTag(Tag tag)
        {
            TAG newTag = new TAG();
            newTag.TAG_NAME = tag.tagName;
            newTag.IS_ACTIVE = true;
            linqDat.TAGs.InsertOnSubmit(newTag);
            linqDat.SubmitChanges();
        }

        public void modifyTag(TAG tag)
        {
            TAG modTag = getTAGByID(tag.TAG_ID);
            modTag.TAG_NAME = tag.TAG_NAME;
            modTag.IS_ACTIVE = tag.IS_ACTIVE;
            linqDat.SubmitChanges();
        }

        public Boolean isTagExisted(Tag newTag)
        {
            List<Tag> tagList = getTagList();
            foreach (var tag in tagList)
            {
                if (newTag.tagName.Equals(tag.tagName))
                {
                    newTag.tagid = tag.tagid;
                    return true;
                }
            }
            return false;
        }

        public int getExtIDByExtension(String ext)
        {
            var extensions = (from dat in linqDat.EXTENSIONs
                        where dat.FILE_EXTENSION.Equals(ext)
                        select new { dat }).ToList();

            if (extensions.Count > 0)
            {
                return extensions.First().dat.EXTENSION_ID;
            }
            else
            {
                return -1;
            }
        }

        public int getTagIDByTagName(String tagName)
        {

            List<Tag> tagList = new List<Tag>();

            var matchingTags = (from tag in linqDat.TAGs
                      where tag.TAG_NAME.Equals(tagName)
                      select new { tag }).ToList();

            if (matchingTags.Count > 0)
            {
                return matchingTags.First().tag.TAG_ID;
            }
            else
            {
                return -1;
            }
        }

        public TAG getTAGByID(int id)
        {

            var tags = (from tag in linqDat.TAGs
                                where tag.TAG_ID == id
                                select new { tag }).ToList();

            if (tags.Count > 0)
            {
                return tags.First().tag;
            }
            else
            {
                return null;
            }
        }

        public List<Tag> getTagList()
        {
            List<Tag> tagList = new List<Tag>();

            var tags = from tag in linqDat.TAGs
                       select new { tag };

            foreach (var v in tags)
            {
                Tag t = new Tag();
                t.tagid = v.tag.TAG_ID;
                t.tagName = v.tag.TAG_NAME;
                tagList.Add(t);
            }

            return tagList;
        }

        public List<Tag> getTagListActive()
        {
            List<Tag> tagList = new List<Tag>();

            var tags = from tag in linqDat.TAGs
                       where tag.IS_ACTIVE == true
                       select new { tag };

            foreach (var v in tags)
            {
                Tag t = new Tag();
                t.tagid = v.tag.TAG_ID;
                t.tagName = v.tag.TAG_NAME;
                tagList.Add(t);
            }

            return tagList;
        }

        public bool isValidUser(String name)
        {
            var users = (from dat in linqDat.APPUSERs
                              where dat.USER_LOGIN.Equals(name)
                              select new { dat }).ToList();

            if (users.Count > 0)
            {
                if (users.First().dat.IS_ACTIVE)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public String getUserPassword(String name)
        {
            var users = (from dat in linqDat.APPUSERs
                         where dat.USER_LOGIN.Equals(name)
                         select new { dat }).ToList();

            if (users.Count > 0)
            {
                return users.First().dat.USER_PASSWORD;
            }
            else
            {
                return null;
            }

        }

        public bool isUserAdmin(String name)
        {
            var users = (from dat in linqDat.APPUSERs
                         where dat.USER_LOGIN.Equals(name)
                         select new { dat }).ToList();

            if (users.Count > 0)
            {
                return users.First().dat.IS_ADMINISTRATOR;
            }
            else
            {
                return false;
            }
        }

        public int getUserIDByName(String name)
        {
            var users = (from dat in linqDat.APPUSERs
                         where dat.USER_LOGIN.Equals(name)
                         select new { dat }).ToList();

            if (users.Count > 0)
            {
                return users.First().dat.APPUSER_ID;
            }
            else
            {
                return -1;
            }
        }

        public void logUserActivity(int fileID, int userID, int type)
        {
            FILELOG logEntry = new FILELOG();
            logEntry.APPUSER_ID = userID;
            logEntry.DF_ID = fileID;
            logEntry.LOG_DATE = DateTime.Now;
            logEntry.LOG_TIME = DateTime.Now;
            logEntry.TTYPE_ID = type;  // need to modify this later.  mc
            linqDat.FILELOGs.InsertOnSubmit(logEntry);
            linqDat.SubmitChanges();
        }

        public void logDownload(int fileID, String userName)
        {
            int userID = getUserIDByName(userName);
            logUserActivity(fileID, userID, 2);
        }

        public void addUser(AppUser user)
        {
            APPUSER newUser = new APPUSER();
            newUser.FIRST_NAME = user.firstName;
            newUser.LAST_NAME = user.lastName;
            newUser.USER_LOGIN = user.userLogin;
            newUser.USER_PASSWORD = user.userPassword;
            newUser.IS_ADMINISTRATOR = user.isAdmin;
            newUser.IS_ACTIVE = true;
            linqDat.APPUSERs.InsertOnSubmit(newUser);
            linqDat.SubmitChanges();
        }

        public void modifyUser(AppUser user)
        {
            APPUSER modUser = getAPPUSERByID(user.appuserid);
            modUser.FIRST_NAME = user.firstName;
            modUser.LAST_NAME = user.lastName;
            modUser.USER_LOGIN = user.userLogin;
            modUser.USER_PASSWORD = user.userPassword;
            modUser.IS_ADMINISTRATOR = user.isAdmin;
            modUser.IS_ACTIVE = user.isActive;
            linqDat.SubmitChanges();
        }

        public void deleteUser(int id)
        {
            APPUSER delUser = getAPPUSERByID(id);
            linqDat.APPUSERs.DeleteOnSubmit(delUser);
            linqDat.SubmitChanges();
        }

        public APPUSER getAPPUSERByID(int id)
        {
            var users = (from dat in linqDat.APPUSERs
                         where dat.APPUSER_ID == id
                         select new { dat }).ToList();

            if (users.Count > 0)
            {
                return users.First().dat;
            }
            else
            {
                return null;
            }
        }

        public AppUser getUserByID(int id)
        {
            var users = (from dat in linqDat.APPUSERs
                         where dat.APPUSER_ID == id
                         select new { dat }).ToList();

            if (users.Count > 0)
            {
                AppUser user = new AppUser();
                user.appuserid = users.First().dat.APPUSER_ID;
                user.firstName = users.First().dat.FIRST_NAME;
                user.lastName = users.First().dat.LAST_NAME;
                user.userLogin = users.First().dat.USER_LOGIN;
                user.userPassword = users.First().dat.USER_PASSWORD;
                user.isAdmin = users.First().dat.IS_ADMINISTRATOR;
                user.isActive = users.First().dat.IS_ACTIVE;
                return user;
            }
            else
            {
                return null;
            }
        }

        public List<AppUser> getAppUsersActive()
        {
            List<AppUser> userList = new List<AppUser>();

            var users = (from dat in linqDat.APPUSERs
                         where dat.IS_ACTIVE == true
                         select new { dat });

            foreach (var v in users)
            {
                AppUser u = new AppUser();
                u.appuserid = v.dat.APPUSER_ID;
                u.lastName = v.dat.LAST_NAME;
                u.firstName = v.dat.FIRST_NAME;
                u.fullName = u.firstName + " " + u.lastName;
                u.userLogin = v.dat.USER_LOGIN;
                u.userPassword = v.dat.USER_PASSWORD;
                u.isAdmin = v.dat.IS_ADMINISTRATOR;
                userList.Add(u);
            }

            return userList;
        }

        public List<AppUser> getAppUsersInactive()
        {
            List<AppUser> userList = new List<AppUser>();

            var users = (from dat in linqDat.APPUSERs
                         where dat.IS_ACTIVE == false
                         select new { dat });

            foreach (var v in users)
            {
                AppUser u = new AppUser();
                u.appuserid = v.dat.APPUSER_ID;
                u.lastName = v.dat.LAST_NAME;
                u.firstName = v.dat.FIRST_NAME;
                u.fullName = u.firstName + " " + u.lastName;
                u.userLogin = v.dat.USER_LOGIN;
                u.userPassword = v.dat.USER_PASSWORD;
                u.isAdmin = v.dat.IS_ADMINISTRATOR;
                userList.Add(u);
            }

            return userList;
        }

        public AppUser getUserByLoginName(String name)
        {
            var users = (from dat in linqDat.APPUSERs
                         where dat.USER_LOGIN.Equals(name)
                         select new { dat }).ToList();

            if (users.Count > 0)
            {
                AppUser user = new AppUser();
                user.appuserid = users.First().dat.APPUSER_ID;
                user.firstName = users.First().dat.FIRST_NAME;
                user.lastName = users.First().dat.LAST_NAME;
                user.userLogin = users.First().dat.USER_LOGIN;
                user.userPassword = users.First().dat.USER_PASSWORD;
                user.isAdmin = users.First().dat.IS_ADMINISTRATOR;
                user.isActive = users.First().dat.IS_ACTIVE;
                return user;
            }
            else
            {
                return null;
            }
        }

        public TAG getTagByName(String name)
        {
            var tags = (from tag in linqDat.TAGs
                         where tag.TAG_NAME.Equals(name)
                         select new { tag }).ToList();

            if (tags.Count > 0)
            {
                TAG tag = new TAG();
                tag.TAG_ID = tags.First().tag.TAG_ID;
                tag.IS_ACTIVE = tags.First().tag.IS_ACTIVE;
                return tag;
            }
            else
            {
                return null;
            }
        }

        public List<UserReport> getUserActivityList()
        {

            var files = from log in linqDat.FILELOGs
                        join type in linqDat.TRANSACTIONTYPEs on log.TTYPE_ID equals type.TTYPE_ID
                        join usr in linqDat.APPUSERs on log.APPUSER_ID equals usr.APPUSER_ID
                        join dat in linqDat.DATAFILEs on log.DF_ID equals dat.DF_ID
                        join ext in linqDat.EXTENSIONs on dat.EXTENSION_ID equals ext.EXTENSION_ID
                        join cat in linqDat.CATEGORies on ext.CATEGORY_ID equals cat.CATEGORY_ID
                        select new
                        {
                            log,
                            type,
                            usr,
                            dat,
                            ext,
                            cat
                        };


            if (files.Count() > 0)
            {
                List<UserReport> urList = new List<UserReport>();
                foreach (var v in files)
                {
                    UserReport ur = new UserReport();
                    ur.firstName = v.usr.FIRST_NAME;
                    ur.lastName = v.usr.LAST_NAME;
                    ur.fileName = v.dat.FILE_NAME;
                    ur.fileExtension = v.ext.FILE_EXTENSION;
                    ur.fileType = v.cat.CATEGORY_NAME;
                    ur.action = v.type.TTYPE_NAME;
                    ur.date = v.log.LOG_DATE.ToShortDateString();
                    ur.time = v.log.LOG_TIME.ToShortTimeString();
                    urList.Add(ur);
                }
                return urList;
            }
            else
            {
                return null;
            }

        }

        public List<UserReport> getActivityForUser(int id)
        {

            var files = from log in linqDat.FILELOGs
                        join type in linqDat.TRANSACTIONTYPEs on log.TTYPE_ID equals type.TTYPE_ID
                        join usr in linqDat.APPUSERs on log.APPUSER_ID equals usr.APPUSER_ID
                        join dat in linqDat.DATAFILEs on log.DF_ID equals dat.DF_ID
                        join ext in linqDat.EXTENSIONs on dat.EXTENSION_ID equals ext.EXTENSION_ID
                        join cat in linqDat.CATEGORies on ext.CATEGORY_ID equals cat.CATEGORY_ID
                        where log.APPUSER_ID == id
                        select new
                        {
                            log,
                            type,
                            usr,
                            dat,
                            ext,
                            cat
                        };


            if (files.Count() > 0)
            {
                List<UserReport> urList = new List<UserReport>();
                foreach (var v in files)
                {
                    UserReport ur = new UserReport();
                    ur.firstName = v.usr.FIRST_NAME;
                    ur.lastName = v.usr.LAST_NAME;
                    ur.fileName = v.dat.FILE_NAME;
                    ur.fileExtension = v.ext.FILE_EXTENSION;
                    ur.fileType = v.cat.CATEGORY_NAME;
                    ur.action = v.type.TTYPE_NAME;
                    ur.date = v.log.LOG_DATE.ToShortDateString();
                    ur.time = v.log.LOG_TIME.ToShortTimeString();
                    urList.Add(ur);
                }
                return urList;
            }
            else
            {
                return null;
            }

        }

        public List<UserReport> getActivityByFileCategory(int id)
        {

            var files = from log in linqDat.FILELOGs
                        join type in linqDat.TRANSACTIONTYPEs on log.TTYPE_ID equals type.TTYPE_ID
                        join usr in linqDat.APPUSERs on log.APPUSER_ID equals usr.APPUSER_ID
                        join dat in linqDat.DATAFILEs on log.DF_ID equals dat.DF_ID
                        join ext in linqDat.EXTENSIONs on dat.EXTENSION_ID equals ext.EXTENSION_ID
                        join cat in linqDat.CATEGORies on ext.CATEGORY_ID equals cat.CATEGORY_ID
                        where cat.CATEGORY_ID == id
                        select new
                        {
                            log,
                            type,
                            usr,
                            dat,
                            ext,
                            cat
                        };


            if (files.Count() > 0)
            {
                List<UserReport> urList = new List<UserReport>();
                foreach (var v in files)
                {
                    UserReport ur = new UserReport();
                    ur.firstName = v.usr.FIRST_NAME;
                    ur.lastName = v.usr.LAST_NAME;
                    ur.fileName = v.dat.FILE_NAME;
                    ur.fileExtension = v.ext.FILE_EXTENSION;
                    ur.fileType = v.cat.CATEGORY_NAME;
                    ur.action = v.type.TTYPE_NAME;
                    ur.date = v.log.LOG_DATE.ToShortDateString();
                    ur.time = v.log.LOG_TIME.ToShortTimeString();
                    urList.Add(ur);
                }
                return urList;
            }
            else
            {
                return null;
            }

        }

        public List<UserReport> getActivityByFileType(int id)
        {

            var files = from log in linqDat.FILELOGs
                        join type in linqDat.TRANSACTIONTYPEs on log.TTYPE_ID equals type.TTYPE_ID
                        join usr in linqDat.APPUSERs on log.APPUSER_ID equals usr.APPUSER_ID
                        join dat in linqDat.DATAFILEs on log.DF_ID equals dat.DF_ID
                        join ext in linqDat.EXTENSIONs on dat.EXTENSION_ID equals ext.EXTENSION_ID
                        join cat in linqDat.CATEGORies on ext.CATEGORY_ID equals cat.CATEGORY_ID
                        where ext.EXTENSION_ID == id
                        select new
                        {
                            log,
                            type,
                            usr,
                            dat,
                            ext,
                            cat
                        };


            if (files.Count() > 0)
            {
                List<UserReport> urList = new List<UserReport>();
                foreach (var v in files)
                {
                    UserReport ur = new UserReport();
                    ur.firstName = v.usr.FIRST_NAME;
                    ur.lastName = v.usr.LAST_NAME;
                    ur.fileName = v.dat.FILE_NAME;
                    ur.fileExtension = v.ext.FILE_EXTENSION;
                    ur.fileType = v.cat.CATEGORY_NAME;
                    ur.action = v.type.TTYPE_NAME;
                    ur.date = v.log.LOG_DATE.ToShortDateString();
                    ur.time = v.log.LOG_TIME.ToShortTimeString();
                    urList.Add(ur);
                }
                return urList;
            }
            else
            {
                return null;
            }

        }

        public List<UserReport> getActivityByActivityType(int id)
        {

            var files = from log in linqDat.FILELOGs
                        join type in linqDat.TRANSACTIONTYPEs on log.TTYPE_ID equals type.TTYPE_ID
                        join usr in linqDat.APPUSERs on log.APPUSER_ID equals usr.APPUSER_ID
                        join dat in linqDat.DATAFILEs on log.DF_ID equals dat.DF_ID
                        join ext in linqDat.EXTENSIONs on dat.EXTENSION_ID equals ext.EXTENSION_ID
                        join cat in linqDat.CATEGORies on ext.CATEGORY_ID equals cat.CATEGORY_ID
                        where type.TTYPE_ID == id
                        select new
                        {
                            log,
                            type,
                            usr,
                            dat,
                            ext,
                            cat
                        };


            if (files.Count() > 0)
            {
                List<UserReport> urList = new List<UserReport>();
                foreach (var v in files)
                {
                    UserReport ur = new UserReport();
                    ur.firstName = v.usr.FIRST_NAME;
                    ur.lastName = v.usr.LAST_NAME;
                    ur.fileName = v.dat.FILE_NAME;
                    ur.fileExtension = v.ext.FILE_EXTENSION;
                    ur.fileType = v.cat.CATEGORY_NAME;
                    ur.action = v.type.TTYPE_NAME;
                    ur.date = v.log.LOG_DATE.ToShortDateString();
                    ur.time = v.log.LOG_TIME.ToShortTimeString();
                    urList.Add(ur);
                }
                return urList;
            }
            else
            {
                return null;
            }

        }

        public List<FileReport> getFileDownloadList()
        {

            var files = from log in linqDat.FILELOGs
                        join dat in linqDat.DATAFILEs on log.DF_ID equals dat.DF_ID
                        join ext in linqDat.EXTENSIONs on dat.EXTENSION_ID equals ext.EXTENSION_ID
                        join cat in linqDat.CATEGORies on ext.CATEGORY_ID equals cat.CATEGORY_ID
                        where log.TTYPE_ID == 2
                        group new
                        {
                            log,
                            dat,
                            cat
                        } by new
                        {
                            dat.FILE_NAME
                        } into g
                        select new
                        {
                            fileCount = g.Count(),
                            fileName = g.Key.FILE_NAME
                        };


            if (files.Count() > 0)
            {
                List<FileReport> frList = new List<FileReport>();
                foreach (var v in files)
                {
                    FileReport fr = new FileReport();
                    fr.fileName = v.fileName;
                    fr.downloadCount = v.fileCount;
                    frList.Add(fr);
                }
                return frList;
            }
            else
            {
                return null;
            }

        }

    }
}