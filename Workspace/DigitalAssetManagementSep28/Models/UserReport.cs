using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigitalAssetManagementSep28
{
    public class UserReport : IComparable<UserReport>
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string fullName { get; set; }
        public string fileName { get; set; }
        public string fileExtension { get; set; }
        public string fileType { get; set; }
        public string action { get; set; }
        public string date { get; set; }
        public string time { get; set; }



        #region IComparable<UserReport> Members

        public int CompareTo(UserReport other)
        {
            return String.Compare(this.lastName, other.lastName);

        }

        #endregion

    }
}