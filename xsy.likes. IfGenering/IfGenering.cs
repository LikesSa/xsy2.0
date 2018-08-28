using System;
using xsy.likes.WebServices;

namespace xsy.likes.IfGenering
{
    public class IfGenering
    {
        #region 定义需要的参数
        private readonly string userId;
        private readonly string pwd;
        private readonly string code;
        private readonly string tokenClientId;
        private readonly string tokenClientSecret;
        private readonly string tokenRedirectUrl;
        private string apiurl = "https://api.xiaoshouyi.com";
        private string restapiurl = "https://api.xiaoshouyi.com";
        internal protected GetTokenReturn TokenReturn;
        #endregion

        #region 基础
        /// <summary>
        /// 重写构造方法
        /// </summary>
        public IfGenering(string userId, string pwd, string code, string tokenClientId, string tokenClientSecret, string tokenRedirectUrl)
        {
            this.userId = userId;
            this.pwd = pwd;
            this.code = code;
            this.tokenClientId = tokenClientId;
            this.tokenClientSecret = tokenClientSecret;
            this.tokenRedirectUrl = tokenRedirectUrl;
        }

        internal protected string AccessToken
        {
            get
            {
                //GetToken();
                if (TokenReturn == null)
                {
                    TokenReturn = new GetTokenReturn();
                }
                if (string.IsNullOrEmpty(TokenReturn.issued_at))
                {
                    GetToken();
                }
                var minute =
                   (DateTime.Now - DateTime.Parse("1970-1-1").AddMilliseconds(double.Parse(TokenReturn?.issued_at)))
                       .TotalMinutes;
                if (minute >= 24 * 60)
                {
                    GetToken();
                }
                return TokenReturn?.access_token;
            }
        }

        /// <summary>
        /// 获取astoken
        /// </summary>
        protected virtual void GetToken()
        {
            var url =
                $"{apiurl}/oauth2/token?grant_type=password&client_id={tokenClientId}&client_secret={tokenClientSecret}&redirect_uri={tokenRedirectUrl}&username={userId}&password={pwd}{code}";

            WebHelper.Instrance.RequestGetDataShaderJson(url, out TokenReturn, "utf-8");
        }

        /// <summary>
        /// 接口测试
        /// </summary>
        /// <returns></returns>
        public string inTextBygetoke()
        {
            return AccessToken;

        }
        #endregion

        #region v2接口
        //获取自定义明细
        public virtual string customizeGetById(string ApiKey, string id)
        {
            string url = $"{apiurl}/rest/data/v2/objects/{ApiKey}/{id}";

            string result;
            string code = $"Bearer {AccessToken}";
            WebHelper.Instrance.RequestGetData(url,out result,code);

            return result;

        }

        //获取自定义明细描述
        public virtual string customizeGet(string ApiKey)
        {
            string url = $"{apiurl}/rest/data/v2/objects/{ApiKey}/description";

            string result;
            string code = $"Bearer {AccessToken}";
            WebHelper.Instrance.RequestGetData(url,out result,code);

            return result;



        }

        /// <summary>
        /// 根据id获取派工单信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual string fieldJobGet(string id)
        {
            string url = $"{apiurl}/rest/data/v2/objects/fieldJob/{id}";

            string result;
            string code = $"Bearer {AccessToken}";
            WebHelper.Instrance.RequestGetData(url,out result,code);

            return result;





        }

        /// <summary>
        /// //下载图片
        /// </summary>
        /// <param name="fileId"></param>
        /// <param name="charset"></param>
        /// <returns></returns>
        public virtual bool picDown(string filename,string url,string downpath)
        {
            //string url = $"{apiurl}/rest/file/v2.0/image/{fileId}";

            //string result;
            //string code = $"Bearer {AccessToken}";
            //WebHelper.Instrance.RequestGettAddHeadData(url, code, out result, charset);
            //filename = "1531447380605.jpg";
            //url = "https://xsybucket.s3.cn-north-1.amazonaws.com.cn/363680/2018/07/13/bdc3e2f3-7e05-4f34-be31-33077e47c204.jpg";
            //downpath = "C:\\Downlod\\dd";
            //return result;
            return WebHelper.Instrance.DownloadOneFileByPicAddress(filename,url,downpath);



        }

        #endregion

        #region 销毁
        public void Dispose()
        {
            TokenReturn?.Dispose();
        }

        ~IfGenering()
        {
            Dispose();
        }
        #endregion


    }
}
