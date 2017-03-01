using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;
using System.Threading;

namespace Watch
{
    class Program
    {
        
        static void Main(string[] args)
        {
            deleteLog();
            new Program().watching();
        }
        private void watching()
        {
            log myLog = new log("D://log", "/Watch.log");
            int startCounts = 0;
            Process watch = new Process();
            try
            {
                watch = Process.Start("AVR_3.exe");
                startCounts++;
                myLog.WriteLog("start counts", startCounts.ToString());              
            }
            catch(Exception e){
                myLog.WriteLog("start failed", e.ToString());
            }
            while (true)
            {
                if (watch.HasExited)
                {
                    myLog.WriteLog("process stoped!", "null");
                    Thread.Sleep(2000);
                    watching();
                }                           
            }
        }

        static void deleteLog()
        {
            String[] filename =
            {
                @"D:\\log\\event.log", @"D:\\log\\main.log", @"D:\\log\\tcp.log", @"D:\\log\\video.log",
                @"D:\\log\\Watch.log", @"D:\\log\\gpio.log"
            };
            for (int i = 0; i < filename.Length; i++)
            {
                if (File.Exists(filename[i]))
                {
                    //如果存在则删除
                    File.Delete(filename[i]);
                } 
            }
        }
    }
}
