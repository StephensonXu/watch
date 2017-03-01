using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;

namespace Watch
{
    class log
    {
        private string LogPath; //= "D://log";  
        private string LogName; // = "/Watch.log";  

        public log(string path, string name)
        {
            LogPath = path;
            LogName = "/" + name;
        }

        public void WriteLog(string log1, string log2)
        {
            try
            {
                DirectoryInfo d = Directory.CreateDirectory(LogPath);
                FileStream fs = new FileStream(LogPath + LogName, System.IO.FileMode.Append);
                StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.Default);
                sw.WriteLine(DateTime.Now.ToString() + "\t" + log1 + "\t" + log2);
                sw.Close();
                fs.Close();
            }
            catch
            {
                //    // Nothing to do  
            }
        }
    }
}
