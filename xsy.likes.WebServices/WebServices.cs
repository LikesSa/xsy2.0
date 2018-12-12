using System;
using System.IO;
using System.Net;
using System.Text;
using System.Web.Script.Serialization;

namespace xsy.likes.WebServices
{
    public class WebServices : IWeb
    {
        /// <summary>
        /// 通用GET方法  System.Net
        /// </summary>
        /// <param name="url"></param>
        /// <param name="result"></param>
        /// <param name="chartSet"></param>
        /// <returns></returns>
        public bool RequestGetData(string url, out string result, string code = null, string chartSet = "utf-8")
        {
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            result = string.Empty;
            //ServicePointManager.SecurityProtocol = (SecurityProtocolType)192 | (SecurityProtocolType)768 | (SecurityProtocolType)3072;
            try
            {
                request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";
                request.ContentType = "application/x-www-form-urlencoded";           //"application/x-www-form-urlencoded";
                if (!string.IsNullOrEmpty(code))
                {
                    request.Headers.Add("Authorization", code);
                }
                
                response = (HttpWebResponse)request.GetResponse();
                using (var stream = response.GetResponseStream())
                {
                    if (stream != null)
                    {
                        using (var streamReader = new StreamReader(stream, Encoding.GetEncoding(chartSet)))
                        {
                            result = streamReader.ReadToEnd();
                        }
                    }
                    else
                    {
                        result = string.Empty;
                    }
                }
            }
            catch /*(Exception exception)*/
            {
                return false;
                //throw new Exception(exception.Message);
            }
            finally
            {
                response?.Close();
            }
            return true;

        }

        /// <summary>
        /// 通用post方法
        /// </summary>
        /// <param name="url"></param>
        /// <param name="input"></param>
        /// <param name="code"></param>
        /// <param name="result"></param>
        /// <param name="chartSet"></param>
        /// <returns></returns>
        public bool RequestPostData(string url, string input,out string result,string code = null,string contenttype= "json(application/json)" ,string chartSet = "utf-8")
        {
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            result = string.Empty;
            //ServicePointManager.SecurityProtocol = (SecurityProtocolType)192 | (SecurityProtocolType)768 | (SecurityProtocolType)3072;
            try
            {
                request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "POST";
                request.ContentType = contenttype;   // "application/x-www-form-urlencoded"          json(application/json) 

                //接口用，传入asstoken
                if (!string.IsNullOrEmpty(code))
                {
                    request.Headers.Add("Authorization", code);
                }
                var buffer = Encoding.GetEncoding(chartSet).GetBytes(input);

                using (var stream = request.GetRequestStream())
                {
                    stream.Write(buffer, 0, buffer.Length);
                }
                response = (HttpWebResponse)request.GetResponse();

                using (var stream = response.GetResponseStream())
                {
                    if (stream != null)
                    {
                        using (var streamReader = new StreamReader(stream, Encoding.GetEncoding(chartSet)))
                        {
                            var ec = streamReader.CurrentEncoding;
                            result = streamReader.ReadToEnd();
                        }
                    }
                    else
                    {
                        result = string.Empty;
                    }
                }
            }
            catch (Exception exception)
            {
                return false;
                throw new Exception(exception.Message);
            }
            finally
            {
                response?.Close();
            }
            return true;
        }

        /// <summary>
        /// webclient 下载图片，通过图片地址
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="url"></param>
        /// <param name="localPath"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public bool DownloadOneFileByPicAddress(string fileName, string url, string localPath, int timeout = 30)
        {
            WebClient wc = new System.Net.WebClient();
            try
            {
                if (File.Exists(localPath + fileName)) { File.Delete(localPath + fileName); }
                if (Directory.Exists(localPath) == false) { Directory.CreateDirectory(localPath); }
                wc.DownloadFile(url, localPath + "\\" + fileName);

            }
            catch (Exception ex)
            {

                string str = ex.ToString();
                return false;
            }

            return true;




        }

        /// <summary>
        /// post请求之后json实例化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="input"></param>
        /// <param name="t"></param>
        /// <param name="chartSet"></param>
        /// <returns></returns>
        public bool RequestPostDataShaderJson<T>(string url, string input, out T t,string code = null, string contenttype= "application/x-www-form-urlencoded",string chartSet = "utf-8") where T : class, new()
        {
            string result;
            bool operateResult = RequestPostData(url, input,out result,code,contenttype);

            if (operateResult)
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(result))
                    {
                        t = null;
                    }
                    else
                    {
                        var jss = new JavaScriptSerializer();
                        t = jss.Deserialize<T>(result);
                    }
                }
                catch
                {
                    t = null;
                }
            }
            else
            {
                t = null;
            }

            return operateResult;
        }

        public bool RequestGetDataShaderJson<T>(string url, out T t, string chartSet = "utf-8") where T : class, new()
        {
            string result;
            //ServicePointManager.SecurityProtocol = (SecurityProtocolType)192 | (SecurityProtocolType)768 | (SecurityProtocolType)3072;
            bool operateResult = RequestGetData(url, out result);

            if (operateResult)
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(result))
                    {
                        t = null;
                    }
                    else
                    {
                        var jss = new JavaScriptSerializer();
                        t = jss.Deserialize<T>(result);
                    }
                }
                catch
                {
                    t = null;
                }
            }
            else
            {
                t = null;
            }

            return operateResult;
        }

        /// <summary>
        /// 无参数post方法
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public string HttpPost(string url)
        {
            //ServicePointManager.SecurityProtocol = (SecurityProtocolType)192 | (SecurityProtocolType)768 | (SecurityProtocolType)3072;
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = "application/x-www-form-urlencoded"; // 因为POST无参，不写字符集也没问题
            httpWebRequest.Method = "POST";
            httpWebRequest.Timeout = 20000;

            HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream());
            string responseContent = streamReader.ReadToEnd();

            streamReader.Close();
            httpWebResponse.Close();
            httpWebRequest.Abort();

            return responseContent;
        }



    }
}
