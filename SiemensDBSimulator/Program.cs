using Snap7;
using System;
using System.Text.RegularExpressions;

namespace SiemensDBSimulator
{
    class Program
    {
        static S7Server Server;

        static void Main(string[] args)
        {
            Server = new S7Server();

            Server.SetEventsCallBack(new S7Server.TSrvCallback(EventCallback), IntPtr.Zero);

            int Error = Server.Start();

            System.Console.WriteLine("Started:" + Error);

            while (true)
            {
                var cmd = System.Console.ReadLine();

                if (!Regex.IsMatch(cmd, "^[0-9]*,[0-9]*$"))
                {
                    System.Console.WriteLine("输入格式不正确,示例[1,1024]");
                    continue;
                }

                var numStr = cmd.Split(',')[0];
                var sizeStr = cmd.Split(',')[1];

                var buf = new byte[Convert.ToInt32(sizeStr)];

                Server.RegisterArea(S7Server.srvAreaDB, Convert.ToInt32(numStr), buf, buf.Length);

            }

        }

        static void EventCallback(IntPtr usrPtr, ref S7Server.USrvEvent Event, int Size)
        {
            var msg = Server.EventText(ref Event);
            System.Console.WriteLine(msg);
        }
    }
}
