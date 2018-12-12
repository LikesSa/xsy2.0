using System.Xml;
using xsy.likes.WebServices;

namespace BingWallpaperGet
{
    public class WallPageGet
    {
        //获取url和图片名称
        public bool wallPageGetByurl(out string ImageName,out string ImageUrl,int n = 1)
        {

            string url = $"https://cn.bing.com/HPImageArchive.aspx?idx={n}&n={1}";
            string xmlDoc = null;
            WebHelper.Instrance.RequestGetData(url,out xmlDoc);        
            XmlDocument xx = new XmlDocument();
            xx.LoadXml(xmlDoc);//加载xml
            //XmlNodeList nodeList = xx.SelectNodes("images/image/url");
            ImageUrl = xx.SelectSingleNode("images/image/url").InnerText;
            ImageUrl = "http://www.bing.com" + ImageUrl;
            ImageUrl = ImageUrl.Replace("1366x768", "1920x1080");
            ImageName = xx.SelectSingleNode("images/image/copyright").InnerText;

            return true;


        }


        //下载到本地
        public void picSavebyUrl()
        {
                string ImageName = null;
                string ImageUrl = null;
                wallPageGetByurl(out ImageName, out ImageUrl);
                ImageName = ImageName.Replace('/', ' ');
                string localPatch = @"C:\Users\Likes\Pictures\bingImg";
                WebHelper.Instrance.DownloadOneFileByPicAddress(ImageName + ".jpg", ImageUrl, localPatch);

        }



    }
}
