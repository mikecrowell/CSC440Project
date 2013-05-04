using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigitalAssetManagementSep28
{
    public class FileReport : IComparable<FileReport>
    {
        public string fileName { get; set; }
        public string shortDescription { get; set; }
        public string fileType { get; set; }
        public int downloadCount { get; set; }



        #region IComparable<FileReport> Members

        public int CompareTo(FileReport other)
        {
            return String.Compare(this.fileName, other.fileName);

        }

        #endregion

    }
}