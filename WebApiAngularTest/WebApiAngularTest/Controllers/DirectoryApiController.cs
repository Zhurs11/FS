using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiAngularTest.Models;

namespace WebApiAngularTest.Controllers
{
    public class DirectoryApiController : ApiController
    {
        public DirectoryView Get(string path)
        {
            var dirView = new DirectoryView();
            if (path == null)
            {
                DriveInfo[] drives = DriveInfo.GetDrives();
                foreach (var item in drives)
                {
                    if (item.DriveType == DriveType.Fixed)
                    {
                        dirView.Directories.Add(new ItemView { FullName = item.RootDirectory.FullName, Name = item.Name });
                    }
                }
                dirView.CurrentPath = "All Hard discs";
            }
            else
            {

                DirectoryInfo dir = new DirectoryInfo(path);
                try
                {
                    dirView.Directories = dir.GetDirectories().Select(a => new ItemView { Name = a.Name, FullName = a.FullName }).ToList();
                    dirView.Files = dir.GetFiles().Select(a => new ItemView { Name = a.Name }).ToList();
                }
                catch (UnauthorizedAccessException)
                {
                }
                catch (DirectoryNotFoundException) 
                {
                }

                dirView.FilesCount = FilesCount(path);
                dirView.CurrentPath = path;
            }

            return dirView;
        }

        private FilesCountView FilesCount(string path)
        {
            var countModel = new FilesCountView();
            DirectoryInfo dir = new DirectoryInfo(path);
            DirectoryInfo[] dirArr;

            try
            {
                var files = dir.GetFiles();
                countModel.LessCount += files.Where(b => b.Length <= 10485760).Count();
                countModel.BetweenCount += files.Where(b => b.Length > 10485760 && b.Length <= 52428800).Count();
                countModel.MoreCount += files.Where(b => b.Length > 104857600).Count();

                dirArr = dir.GetDirectories();
                if (dirArr.Length > 0)
                {
                    foreach (var p in dirArr)
                    {
                        countModel += FilesCount(p.FullName);
                    }
                }
            }
            catch (UnauthorizedAccessException)
            {
            }
            catch (DirectoryNotFoundException)
            {
            }

            return countModel;
        }

    }
}
