using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigitalAssetManagementSep28
{
    public class AppUser
    {
         public int appuserid { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string userLogin { get; set; }
        public string userPassword { get; set; }
        public bool isAdmin { get; set; }
        public List<Category> categories { get; set; }
        
    }
}