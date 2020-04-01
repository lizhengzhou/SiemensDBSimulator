using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace SiemensSimulator
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
                Application.ThreadException += Application_ThreadException;
                AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

                Application.Run(new Form1());
            }
            catch (Exception ex)
            {
                Log.Logger.ExceptionLog(ex);
                Thread.Sleep(5 * 1000);
                Application.Restart();
            }

        }

        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            var ex = e.Exception;
            if (ex != null)
            {
                Log.Logger.ExceptionLog(ex);
            }
            Thread.Sleep(5 * 1000);
            Application.Restart();
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            var ex = e.ExceptionObject as Exception;
            if (ex != null)
            {
                Log.Logger.ExceptionLog(ex);
            }
            Thread.Sleep(5 * 1000);
            Application.Restart();
        }
    }
}
