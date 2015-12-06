using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiAngularTest.Models
{
    public class DirectoryView
    {
        public string CurrentPath { get; set; }
        public List<ItemView> Files { get; set; }
        public List<ItemView> Directories { get; set; }
        public FilesCountView FilesCount { get; set; }
        public DirectoryView()
        {
            FilesCount = new FilesCountView();
            Files = new List<ItemView>();
            Directories = new List<ItemView>();
        }
    }
}