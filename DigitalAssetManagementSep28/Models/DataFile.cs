using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigitalAssetManagementSep28
{
    public class DataFile : IComparable<DataFile>
    {
        public int dfid { get; set; }
        public string fileName { get; set; }
        public int ext_id { get; set; }
        public string extension { get; set; }
        public string shortDesc { get; set; }
        public string longDesc { get; set; }
        public List<Tag> tags { get; set; }
        public string category { get; set; }
        public int numTagMatches { get; set; }
        public bool isActive { get; set; }


        #region IComparable<DataFile> Members

        public int CompareTo(DataFile other)
        {
            return String.Compare(this.fileName, other.fileName);

        }

        #endregion

        public override string ToString()
        {
            String tagsOutput = "";
            foreach (Tag t in tags)
            {
                tagsOutput += t.tagName + "\n";
            }

            return "ID: " + dfid + "\n" +
                "File Name: " + fileName + "." + extension + "\n" +
                "Short Description: " + shortDesc + "\n" +
                "Long Description: " + longDesc + "\n"
                + "Tags" + "\n" + tagsOutput + "\n";


        }
        public override int GetHashCode()
        {
            return this.dfid.GetHashCode();
        }

        /// <summary>
        /// Checks if the provided Person is equal to the current Person
        /// </summary>
        /// <param name="personToCompareTo">Person to compare to the current person</param>
        /// <returns>True if equal, false if not</returns>
        /// 
    }
}