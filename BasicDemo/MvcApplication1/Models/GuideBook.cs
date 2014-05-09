using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication1.Models
{
    public class GuideBook
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public string PicUrl { get; set; }
        public int DownLoadCount { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}