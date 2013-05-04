using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigitalAssetManagementSep28
{
    public class DataFile
    {
        public int dfid { get; set; }
        public string fileName { get; set; }
        public int ext_id { get; set; }
        public string extension { get; set; }
        public string shortDesc { get; set; }
        public string longDesc { get; set; }
        public List<Tag> tags { get; set; }
        public string category { get; set; }

    }
}