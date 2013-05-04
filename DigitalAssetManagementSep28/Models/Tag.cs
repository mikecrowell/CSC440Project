using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigitalAssetManagementSep28
{
    public class Tag : IComparable<Tag>
    {
        public int tagid { get; set; }
        public string tagName { get; set; }
        public bool isActive { get; set; }

        #region IComparable<Tag> Members

        public int CompareTo(Tag other)
        {
            return String.Compare(this.tagName, other.tagName);

        }

        #endregion
    }

}