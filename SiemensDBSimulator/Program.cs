using Snap7;
using System;
using System.Configuration;
using System.Text.RegularExpressions;

namespace SiemensDBSimulator
{
    class Program
    {
        static S7Server Server;

        static void Main(string[] args)
        {
            try
            {
                Server = new S7Server();

                Server.SetEventsCallBack(new S7Server.TSrvCallback(EventCallback), IntPtr.Zero);

                int Error = Server.Start();

                System.Console.WriteLine("Started:" + Error);

                var dbs = ConfigurationManager.AppSettings["dbs"];
                if (!string.IsNullOrEmpty(dbs))
                {
                    foreach (var cmd in dbs.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        Reg(cmd);
                    }
                }

                while (true)
                {
                    var cmd = System.Console.ReadLine();

                    Reg(cmd);
                }
            }
            catch (Exception ex)
            {
                Log.Logger.ExceptionLog(ex);
                Console.ReadKey();
            }
        }

        static bool Reg(string cmd)
        {
            try
            {
                string numStr = "0", sizeStr = "0";

                if (Regex.IsMatch(cmd, "^[1-9]{1}[0-9]*,[0-9]*$"))
                {
                    numStr = cmd.Split(',')[0];
                    sizeStr = cmd.Split(',')[1];

                }
                else if (Regex.IsMatch(cmd, "^[1-9]{1}[0-9]*$"))
                {
                    numStr = cmd;
                    sizeStr = "1024";
                }
                else
                {
                    System.Console.WriteLine("输入格式不正确,示例[1,1024]:" + cmd);
                    return false;
                }

                var buf = new byte[Convert.ToInt32(sizeStr)];

                Server.RegisterArea(S7Server.srvAreaDB, Convert.ToInt32(numStr), buf, buf.Length);

                Console.WriteLine(string.Format("注册成功:DB{0},大小:{1}字节", numStr, sizeStr));

                return true;
            }
            catch (Exception ex)
            {
                Log.Logger.ExceptionLog(ex);

                return false;
            }
        }

        static void EventCallback(IntPtr usrPtr, ref S7Server.USrvEvent Event, int Size)
        {
            try
            {
                var msg = Server.EventText(ref Event);
                System.Console.WriteLine(msg);
            }
            catch (Exception ex)
            {
                Log.Logger.ExceptionLog(ex);
            }
        }
    }
}
