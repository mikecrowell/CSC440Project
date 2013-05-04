using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigitalAssetManagementSep28
{
    public class DataFileComparer : IEqualityComparer<DataFile>
    {
        public bool Equals(DataFile a, DataFile b)
        {
            return a.dfid.Equals(b.dfid);
        }
        public int GetHashCode(DataFile obj)
        {
            return obj.dfid.GetHashCode();
        }
    }
}