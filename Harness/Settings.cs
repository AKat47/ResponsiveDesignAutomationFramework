using System;
using System.Collections.Generic;

namespace Harness
{

    public class EnironmentConfig
    {
        public string Environment { get; set; }
        public Uri Url { get; set; }
        public string DBInstance { get; set; }  
    }

    public class RootObject
    {
        public string env { get; set; }
        public string browserName { get; set; }
        public List<EnironmentConfig> EnironmentConfig { get; set; }
        public string userName { get; set; }
        public string passWord { get; set; }
        public string deviceName { get; set; }
        public string ScreenshotLocation { get; set; }
    }
}