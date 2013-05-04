using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigitalAssetManagementSep28
{
    public class FileLog
    {
        public int logid { get; set; }
        public int dfid { get; set; }
        public int userid { get; set; }
        public string logDate { get; set; }
        public string logTime { get; set; }
        public int ttypeid { get; set; }

    }
}