using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiAngularTest.Models
{
    public class FilesCountView
    {
        public int LessCount { get; set; }
        public int BetweenCount { get; set; }
        public int MoreCount { get; set; }
        public static FilesCountView operator +(FilesCountView item1, FilesCountView item2)
        {
            FilesCountView filesCount = new FilesCountView();
            filesCount.LessCount = item1.LessCount + item2.LessCount;
            filesCount.BetweenCount = item1.BetweenCount + item2.BetweenCount;
            filesCount.MoreCount = item1.MoreCount + item2.MoreCount;
            return filesCount;
        }

    }
}