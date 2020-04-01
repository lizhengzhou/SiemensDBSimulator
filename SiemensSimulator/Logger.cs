namespace Log
{
    using System;
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;
    using System.IO;
    using System.Web;

    /// <summary>
    /// 日志记录器
    /// </summary>
    public partial class Logger
    {
        static object _lock = new object();
        /// <summary>
        /// 跟踪日志
        /// </summary>
        /// <param name="exception">异常</param>
        public static void TraceLog(string msg)
        {
            // 写文件日志
            WriteFileLog(null, 99, msg, "");
        }
        /// <summary>
        /// 异常日志
        /// </summary>
        /// <param name="exception">异常</param>
        public static void ExceptionLog(Exception exception)
        {
            string errorMessage = GetFullExceptionMessage(exception);
            string errorStackTrace = GetFullExceptionStackTrace(exception);

            // 写文件日志
            WriteFileLog(null, 30, errorMessage, errorStackTrace);
        }

        /// <summary>
        /// 获取完整的异常信息
        /// </summary>
        /// <param name="exception">异常</param>
        /// <returns>完整的异常信息</returns>
        public static string GetFullExceptionMessage(Exception exception)
        {
            string errorMessage = exception.GetType() + ":" + exception.Message;
            Exception innerException = exception.InnerException;

            while (innerException != null)
            {
                errorMessage += " => " + innerException.GetType() + ":" + innerException.Message;
                innerException = innerException.InnerException;
            }

            return errorMessage;
        }

        /// <summary>
        /// 获取完整的异常堆栈
        /// </summary>
        /// <param name="exception">异常</param>
        /// <returns>完整的异常堆栈</returns>
        private static string GetFullExceptionStackTrace(Exception exception)
        {
            string errorStackTrace = exception.StackTrace;
            Exception innerException = exception.InnerException;

            while (innerException != null)
            {
                errorStackTrace = innerException.StackTrace + " => " + errorStackTrace;
                innerException = innerException.InnerException;
            }

            return errorStackTrace;
        }

        /// <summary>
        /// 写文件日志
        /// </summary>
        /// <param name="log">日志</param>
        private static void WriteFileLog(string logType, int logLevel, string description, string stack)
        {
            lock (_lock)
            {
                var root = Directory.GetCurrentDirectory();
                string path = root + @"\Logs\";

                path += DateTime.Now.ToString("yyyy-MM") + "/";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                path += "Log-" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt";

                FileStream fs;

                if (File.Exists(path))
                {
                    fs = new FileStream(path, FileMode.Append);
                }
                else
                {
                    fs = new FileStream(path, FileMode.OpenOrCreate);
                }

                StreamWriter sw = new StreamWriter(fs);

                string content = logLevel.ToString();
                content += " | " + logType;
                content += " | " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:sss");
                content += " | " + "";
                content += " | " + "";
                content += " | " + description;
                sw.WriteLine(content);

                if (!string.IsNullOrEmpty(stack))
                {
                    sw.WriteLine(stack);
                }

                sw.Flush();
                sw.Close();
                fs.Close();
            }

        }

    }
}
