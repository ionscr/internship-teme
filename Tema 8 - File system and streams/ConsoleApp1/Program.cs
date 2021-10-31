using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleApp1
{
    public class FileObj
    {
        public DateTime Date { get; set; }
        public string Name { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string DocumentsPath = @"C:\Users\User\Documents\Downloads";
            string DownloadsPath = @"E:\Users\User\Downloads";
            List<FileObj> filelist = new List<FileObj>();
            try
            {
                DirectoryInfo newDownloads = Directory.CreateDirectory(DocumentsPath);
                string [] files = Directory.GetFiles(DownloadsPath);
                foreach(var file in files)
                {
                    filelist.Add(new FileObj { Name = file, Date = File.GetCreationTime(file).Date });
                }
                var groupedFiles = from f in filelist
                                   group f by f.Date into sgroup
                                   select sgroup;
  
                foreach (var group in groupedFiles)
                {
                    var dateString = group.Key.ToString("d");
                    Directory.CreateDirectory(DocumentsPath+"\\"+dateString);
                    foreach (var fg in group)
                    {
                        File.Move(fg, DocumentsPath + "\\" + dateString);
                    }
                }



            }
            catch (Exception e)
            {

                throw new Exception("Exception" + e.ToString());
            }


        }
    }
}
