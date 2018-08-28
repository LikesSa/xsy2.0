namespace xsy.likes.WebServices
{
    public interface IWeb
    {
        bool DownloadOneFileByPicAddress(string fileName, string url, string localPath, int timeout = 30);
        bool RequestGetData(string url, out string result, string code = null, string chartSet = "utf-8");
        bool RequestGetDataShaderJson<T>(string url, out T t, string chartSet = "utf-8") where T : class, new();
        bool RequestPostData(string url, string input, out string result, string code = null, string contenttype = "json(application/json)", string chartSet = "utf-8");
        bool RequestPostDataShaderJson<T>(string url, string input, out T t, string chartSet) where T : class, new();
        string HttpPost(string url);
    }
}