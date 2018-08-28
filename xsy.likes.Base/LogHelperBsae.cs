using System;
using System.IO;

namespace xsy.likes.Base
{
    /// <summary>
    /// 日志帮助类
    /// </summary>
    public class LogHelperBase
    {

        /// <summary>
        /// 记录错误信息
        /// </summary>
        /// <param name="ex">错误</param>
        public static void ErrorLog(Exception ex)
        {
            string dir = Path() + @"/Log/" + DateTime.Now.ToString("yyyy-MM") + "/";
            string fileName = "log_" + DateTime.Now.ToString("dd") + ".txt";
            string path = dir + fileName;
            StreamWriter sw = null;
            try
            {
                Directory.CreateDirectory(dir);
                sw = new StreamWriter(path, true);
                sw.WriteLine(string.Format("-------------{0}--------------", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ffff")));
                sw.WriteLine(ex.ToString());
                sw.WriteLine();
                sw.Flush();
            }
            catch { }
            finally
            {
                if (sw != null)
                {
                    sw.Close();
                    sw = null;
                }
            }
        }

        /// <summary>
        /// 记录错误信息
        /// </summary>
        /// <param name="str">错误信息</param>
        public static void ErrorLog(string str)
        {
            string dir = Path() + @"/Log/" + DateTime.Now.ToString("yyyy-MM") + "/";
            string fileName = "log_custome_" + DateTime.Now.ToString("dd") + ".txt";
            string path = dir + fileName;
            StreamWriter sw = null;
            try
            {
                Directory.CreateDirectory(dir);
                sw = new StreamWriter(path, true);
                sw.WriteLine(string.Format("-------------{0}--------------", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ffff")));
                sw.WriteLine(str);
                sw.WriteLine();
                sw.Flush();
            }
            catch { }
            finally
            {
                if (sw != null)
                {
                    sw.Close();
                    sw = null;
                }
            }
        }

        /// <summary>
        /// 拿到项目所在目录
        /// </summary>
        /// <returns></returns>
        private static string Path()
        {
            //string path = HttpContext.Current.Server.MapPath("~/");
            //获取路径
            string path = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            //string logpath = path + @"\Log";
            //if (! Directory.Exists(logpath))
            //{
            //    Directory.CreateDirectory(logpath);//不存在就创建目录 
            //}
            return path;
        }
    }
}
