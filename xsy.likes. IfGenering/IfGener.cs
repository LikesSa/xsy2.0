using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using xsy.likes.WebServices;

namespace xsy.likes.IfGenering
{
    public class IfGener
    {
        #region 定义需要的参数
        private readonly string userId;
        private readonly string pwd;
        private readonly string code;
        private readonly string tokenClientId;
        private readonly string tokenClientSecret;
        private readonly string tokenRedirectUrl;
        private string apiurl = "https://api.xiaoshouyi.com";
        internal protected GetTokenReturn TokenReturn;
        #endregion

        #region 基础
        /// <summary>
        /// 重写构造方法
        /// </summary>
        public IfGener(string userId, string pwd, string code, string tokenClientId, string tokenClientSecret, string tokenRedirectUrl)
        {
            this.userId = userId;
            this.pwd = pwd;
            this.code = code;
            this.tokenClientId = tokenClientId;
            this.tokenClientSecret = tokenClientSecret;
            this.tokenRedirectUrl = tokenRedirectUrl;
        }

        /// <summary>
        /// 先读取配置文件，读取不到访问接口生成token
        /// </summary>
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
            var url = $"{apiurl}/oauth2/token";
            // $"{apiurl}/oauth2/token?grant_type=password&client_id={tokenClientId}&client_secret={tokenClientSecret}&redirect_uri={tokenRedirectUrl}&username={userId}&password={pwd}{code}";
            string input = $"grant_type=password&client_id={tokenClientId}&client_secret={tokenClientSecret}&redirect_uri={tokenRedirectUrl}&username={userId}&password={pwd}{code}";
            WebHelper.Instrance.RequestPostDataShaderJson(url,input, out TokenReturn,null,"application/x-www-form-urlencoded", "utf-8");
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

        #region  客户
        
        /// <summary>
        /// 获取客户接口描述
        /// </summary>
        /// <returns></returns>
        public virtual string CustomerDescribe()
        {
            string url = $"{apiurl}/data/v1/objects/account/describe";

            string result;
            string code = $"Bearer {AccessToken}";
            WebHelper.Instrance.RequestGetData(url, out result, code);
            return result;

        }

        /// <summary>
        /// 创建客户
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public virtual bool CustomerCreate(string input,out string id)
        {
            //input格式
            //    string input = "{\"public\":false,\"record\":{"
            //+ "\"accountName\":\"客户测试\""
            //+ $",\"dbcSelect1\":{1}"
            //+ $",\"level\":{1}"
            //+ $",\"dbcSelect2\":{1}"
            //+ $",\"dbcVarchar3\":{12131321}"
            //+ $",\"phone\":{12211121}"
            //+ $",\"dbcVarchar1\":\"{"bm11231212"}\""
            //+ $",\"dbcVarchar2\":\"{"KHCS"}\""
            //+ "}}";
            string url = $"{apiurl}/data/v1/objects/account/create";
            //string result;
            //string code = $"Bearer {AccessToken}";
            //WebHelper.Instrance.RequestPostData(url,input,out result,code);
            //return result;
            return GenerCreate(url,input,out id);
        }

        /// <summary>
        /// 更新客户
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public virtual bool CustomerUpdate(string input)
        {
            //input格式        /
            // string input = "{"
            //+ $"\"id\": 24602"
            //+ $",\"accountName\": \"LiN\""
            //+ "}";
            string url = $"{apiurl}/data/v1/objects/account/update";
            //string result;
            //string code = $"Bearer {AccessToken}";
            //WebHelper.Instrance.RequestPostData(url, input, out result, code);
            //return result;
            return GenerUpdate(url,input);

        }

        /// <summary>
        /// 删除客户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual string CustomerDeleteById(string input)
        {   //input格式为string input = "id=30246779";
            string url = $"{apiurl}/data/v1/objects/account/delete";
            string result;
            string code = $"Bearer {AccessToken}";
            WebHelper.Instrance.RequestPostData(url,input,out result,code,"application/x-www-form-urlencoded");
            return result;

        }

        /// <summary>
        /// 根据id获取客户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual string CustomerInfoById(string id)
        {
            string url = $"{apiurl}/data/v1/objects/account/info?id={id}";
            string result;
            string code = $"Bearer {AccessToken}";
            WebHelper.Instrance.RequestGetData(url,out result,code);
            return result;

        }

        /// <summary>
        /// 转移客户
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public virtual string CustomerTransfer(string input)
        {
            //input格式        /
            // string input = "{"
            //+ $"\"id\": 24602"
            //+ $",\"targetOwnerId\": \"LiN\""
            //+ "}";
            string url = $"{apiurl}/data/v1/objects/account/transfer";
            string result;
            string code = $"Bearer {AccessToken}";
            WebHelper.Instrance.RequestPostData(url, input, out result, code);
            return result;

        }

        /// <summary>
        /// 客户退回公海池
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public virtual string CustomerRelease(string input)
        {
            //input格式        /
            // string input = "{"
            //+ $"\"accountId\": 24602"
            //+ $",\"reasonType\": \"LiN\""
            //+ $",\"releaseReason\": \"客户电话打不通\""
            //+ "}";
            string url = $"{apiurl}/data/v1/objects/account/release";
            string result;
            string code = $"Bearer {AccessToken}";
            WebHelper.Instrance.RequestPostData(url, input, out result, code);
            return result;

        }
        #endregion



        /// <summary>
        /// 创建自定义实体
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public virtual bool customizeCreate(string input, out string id)
        {
            //input格式
            //    string input = "{\"public\":false,\"record\":{"
            //+ "\"accountName\":\"客户测试\""
            //+ $",\"dbcSelect1\":{1}"
            //+ $",\"level\":{1}"
            //+ $",\"dbcSelect2\":{1}"
            //+ $",\"dbcVarchar3\":{12131321}"
            //+ $",\"phone\":{12211121}"
            //+ $",\"dbcVarchar1\":\"{"bm11231212"}\""
            //+ $",\"dbcVarchar2\":\"{"KHCS"}\""
            //+ "}}";
            string url = $"{apiurl}/data/v1/objects/customize/create";
            return GenerCreate(url, input, out id);
        }

        /// <summary>
        /// 更新自定义实体
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public virtual bool customizeUpdate(string input)
        {
            //input格式
            //    string input = "{\"public\":false,\"record\":{"
            //+ "\"accountName\":\"客户测试\""
            //+ $",\"dbcSelect1\":{1}"
            //+ $",\"level\":{1}"
            //+ $",\"dbcSelect2\":{1}"
            //+ $",\"dbcVarchar3\":{12131321}"
            //+ $",\"phone\":{12211121}"
            //+ $",\"dbcVarchar1\":\"{"bm11231212"}\""
            //+ $",\"dbcVarchar2\":\"{"KHCS"}\""
            //+ "}}";
            string url = $"{apiurl}/data/v1/objects/customize/update";
            return GenerUpdate(url, input);
        }


        #region 发送通知
        /// <summary>
        /// 发送通知信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        protected virtual string MessageSend(string input)
        {
            string url = $"{apiurl}/data/v1/notice/notify/send";

            string result;
            string code = $"Bearer {AccessToken}";
            bool fa = WebHelper.Instrance.RequestPostData(url,input,out result,code);

            return result;

        }
        #endregion

        /// <summary>
        /// v2 获取实体业务对象列表
        /// </summary>
        /// <returns></returns>
        public virtual string allObjectsGet()
        {
            string url = $"{apiurl}/rest/data/v2/objects";

            string result;
            string code = $"Bearer {AccessToken}";
            WebHelper.Instrance.RequestGetData(url, out result, code);

            return result;



        }

        /// <summary>
        /// v2 获取自定义明细
        /// </summary>
        /// <param name="ApiKey"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual string customizeGetById(string ApiKey, string id)
        {
            string url = $"{apiurl}/rest/data/v2/objects/{ApiKey}/{id}";

            string result;
            string code = $"Bearer {AccessToken}";
            WebHelper.Instrance.RequestGetData(url,out result,code);

            return result;

        }

        /// <summary>
        /// v2 获取自定义明细描述
        /// </summary>
        /// <param name="ApiKey"></param>
        /// <returns></returns>
        public virtual string customizeGet(string ApiKey)
        {
            string url = $"{apiurl}/rest/data/v2/objects/{ApiKey}/description";

            string result;
            string code = $"Bearer {AccessToken}";
            WebHelper.Instrance.RequestGetData(url,out result,code);

            return result;



        }

        /// <summary>
        /// v2 根据id获取派工单信息
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
        /// v2 下载图片
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

        /// <summary>
        ///v2  XOQL查询 最大3000条
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="charset"></param>
        /// <returns></returns>
        public virtual string xoqlGet(string sql)
        {

            string url = $"{apiurl}/rest/data/v2.0/query/xoql?";
            string input = $"xoql={sql}";

            string result;
            string code = $"Bearer {AccessToken}";
            bool fa = WebHelper.Instrance.RequestPostData(url, input,out result, code,"application/x-www-form-urlencoded");

            return result;


        }


        /// <summary>
        ///v2  sQL查询 最大300条
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="charset"></param>
        /// <returns></returns>
        public virtual string sqlvtwoGet(string sql)
        {

            string url = $"{apiurl}/rest/data/v2/query?";
            string input = $"q={sql}";

            string result;
            string code = $"Bearer {AccessToken}";
            bool fa = WebHelper.Instrance.RequestPostData(url, input, out result, code, "application/x-www-form-urlencoded");

            return result;


        }


        /// <summary>
        ///v1  sQL查询 最大300条
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="charset"></param>
        /// <returns></returns>
        public virtual string sqlGet(string sql)
        {

            string url = $"{apiurl}/data/v1/query?";
            string input = $"q={sql}";

            string result;
            string code = $"Bearer {AccessToken}";
            bool fa = WebHelper.Instrance.RequestPostData(url, input, out result, code, "application/x-www-form-urlencoded");

            return result;


        }

        /// <summary>
        ///  sQL查询 获取id
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="charset"></param>
        /// <returns></returns>
        public virtual string[] IdGetSql(string vl,string sql)
        {
            string url = $"{apiurl}/rest/data/v2.0/query/xoql?";
            string input = $"xoql={sql}";
            var result = string.Empty;
            string code = $"Bearer {AccessToken}";
            bool fa = WebHelper.Instrance.RequestPostData(url, input, out result, code, "application/x-www-form-urlencoded");
            if (fa && result.Contains("\"code\":\"200\""))
            {
                JObject jo = (JObject)JsonConvert.DeserializeObject(result);
                int count = Convert.ToInt32(jo["data"]["count"].ToString());
                string[] str = new string[count];
                if (count > 0)
                {
                    for (int a=0;a<count;a++)
                    {
                        if (!jo["data"]["records"][a][vl].ToString().Contains("c"))
                        {
                            str[a] = jo["data"]["records"][a][vl].ToString();
                        }
                        
                    }

                    return str; 
                }

            }
            return null;


        }

        /// <summary>
        /// 接口测试
        /// </summary>
        /// <returns></returns>
        public string ifTextBygetoke()
        {
            return AccessToken;

        }

        /// <summary>
        /// 新增通用
        /// </summary>
        private bool GenerCreate(string url, string input, out string id)
        {
            string result;
            string code = $"Bearer {AccessToken}";
            var webResult = WebHelper.Instrance.RequestPostData(url, input, out result, code);

            if (!webResult || string.IsNullOrWhiteSpace(result) || result.ToUpper().Contains("ERROR"))
            {
                if (result.Contains("数据重复"))
                {
                    id = "数据重复";
                }
                else if (result.Contains("1002002"))
                {
                    id = "数据重复";
                }

                else
                {
                    id = result;
                }
                return false;
            }

            id = string.IsNullOrWhiteSpace(result)
                ? ""
                : result.Substring(result.IndexOf(":", StringComparison.Ordinal) + 1,
                    result.IndexOf("}", StringComparison.Ordinal) - result.IndexOf(":", StringComparison.Ordinal) -
                    1);


            return true;


        }

        /// <summary>
        /// 修改通用
        /// </summary>
        private bool GenerUpdate(string url, string input)
        {
            string result;
            string code = $"Bearer {AccessToken}";
            WebHelper.Instrance.RequestPostData(url, input, out result, code);
            var status = string.IsNullOrWhiteSpace(result) ? "" : result.Substring(result.IndexOf(":", StringComparison.Ordinal) + 1, result.IndexOf("}", StringComparison.Ordinal) - result.IndexOf(":", StringComparison.Ordinal) - 1);

            if (status.Contains("\"1002002\",") || result.Contains("error_code\":\"300001"))
            {
                status = "0";
            }
            return status.Trim().Equals("0");


        }

        #region 审批

        /// <summary>
        /// 获取所有待审批
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="pageno"></param>
        /// <param name="pagesize"></param>
        /// <returns></returns>
        public bool allApprovalsingGet(string userid, out string[] str, string pageno = "1",string pagesize= "100")
        {
            string url = $"{apiurl}/data/v1/objects/approval/approvals?pageNo={pageno}&pageSize={pagesize}&userId={userid}";

            string result;
            string code = $"Bearer {AccessToken}";
            bool fa = WebHelper.Instrance.RequestGetData(url,out result,code);
            if (fa && result.Contains("totalSize"))
            {
                JObject jo = (JObject)JsonConvert.DeserializeObject(result);
                int count = Convert.ToInt32(jo["count"].ToString());
                str = new string[count];
                if (count > 0)
                {
                    for (int a = 0; a < count; a++)
                    {

                        str[a] = jo["records"][a]["id"].ToString();


                    }

                    return true;
                }

            }
            str = null;
            return false;

        }


        /// <summary>
        /// 审批流程进行定义
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="pageno"></param>
        /// <param name="pagesize"></param>
        /// <returns></returns>
        public bool approvalsMeaningGet(string belongid, string entityype)
        {
            string url = $"{apiurl}/data/v1/objects/approval/define?belongId={belongid}&entityType={entityype}";

            string result;
            string code = $"Bearer {AccessToken}";
            return WebHelper.Instrance.RequestGetData(url, out result, code);

       
        }

        /// <summary>
        /// 查询下级审批人
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="pageno"></param>
        /// <param name="pagesize"></param>
        /// <returns></returns>
        public bool approvalNextUser(string belongid, string dataid,string defineid,string approvalid = null)
        {
            //belongId TRUE    long 业务对象id
            //dataId TRUE    long 数据id
            //approvalId FALSE   long 待审批的id，首次提交该审批时不需要此参数，后续所有的审批操作均需要此参数。此参数的值可通过获取所有待审批接口获得
            //defineId    TRUE    long 审批流程定义的id，此参数的值可通过审批流程定义接口获得
            string url = $"{apiurl}/data/v1/objects/approval/nextUser?belongId={belongid}&dataId={dataid}&defineId={defineid}";
            if (!string.IsNullOrEmpty(approvalid))
            {
                url = $"{apiurl}/data/v1/objects/approval/nextUser?belongId={belongid}&dataId={dataid}&approvalId={approvalid}&defineId={defineid}";
            }

            string result;
            string code = $"Bearer {AccessToken}";
            return WebHelper.Instrance.RequestGetData(url, out result, code);


        }


        /// <summary>
        /// 提交审批
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="pageno"></param>
        /// <param name="pagesize"></param>
        /// <returns></returns>
        public bool approvalSubmit(string input)
        {
            //defineId TRUE    long 审批流程定义的id
            //dataId TRUE    long 数据的id
            //approvalUserId TRUE    long 下级审批人id，此参数的值可通过获取下级审批人接口获得
            //userId  FALSE   int 获取指定的用户Id；不指定默认为当前用户

            //入参
            //{
            //    "defineId": 342,  审批流程定义的id
            //    "dataId": 7655,   数据的id
            //    "approvalUserId": 2376   下级审批人id，此参数的值可通过获取下级审批人接口获得
            //     userId      获取指定的用户Id；不指定默认为当前用户
            //}
            string url = $"{apiurl}/data/v1/objects/approval/submit";

            string result;
            string code = $"Bearer {AccessToken}";
            return WebHelper.Instrance.RequestPostData(url,input,out result,code);


        }


        /// <summary>
        /// 通过审批
        /// </summary>
        public bool approvalAgree(string input)
        {
            string url = $"{apiurl}/data/v1/objects/approval/agree";

            string result;
            string code = $"Bearer {AccessToken}";
            return WebHelper.Instrance.RequestPostData(url, input, out result, code);


        }



        #endregion


        /// <summary>
        /// 新建作业
        /// </summary>
        public bool jobCreate(string operation,string obc,out string id)
        {
            string url = $"{apiurl}/rest/bulk/v2/job";

            string code = $"Bearer {AccessToken}";
            var input = "{\"data\": {"
                        + $"\"operation\":\"{operation}\""
                        + $",\"object\":\"{obc}\""       
                        + "}}";

            return WebHelper.Instrance.RequestPostData(url, input, out id, code,"application/json");


        }


        /// <summary>
        /// 新建任务
        /// </summary>
        private bool batchCreate(string jobId, string json,out string result)
        {
            string url = $"{apiurl}/rest/bulk/v2/batch";

            string code = $"Bearer {AccessToken}";
            var input = "{\"data\": {"
                        + $"\"jobId\":\"{jobId}\""
                        + $",\"datas\":[\"{json}\""
                        + "]}}";

            return WebHelper.Instrance.RequestPostData(url, input, out result ,code);


        }



        #region 处理
        public void Dispose()
        {
            TokenReturn?.Dispose();
        }

        ~IfGener()
        {
            Dispose();
        }
        #endregion


    }
}
