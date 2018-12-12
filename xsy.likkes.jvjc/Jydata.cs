using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NPOI.XWPF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using xsy.likes.Base;
using xsy.likes.DB;
using xsy.likes.IfGenering;

namespace xsy.likkes.jvjc
{
    public class Jydata : IfGener
    {

        #region 配置文件和参数
        private const string UserId = "13603715895";     //用户名
        private const string Pwd = "jasmine780925";
        private const string Code = "sTwwiu49";          //安全令牌
        private const string TokenClientId = "e2a23f172f9c686f7e2f4953577dee05";
        private const string TokenClientSecret = "609a1d958e2d623369b2cacc26c72ba8";
        private const string TokenRedirectUrl = "http://www.api.jy.com";

        DbOperate db = new DbOperate();
        private const int countOneTime = 30;//每次取的个数

        public string logMsg = string.Empty;//全局Log对象，用于记录错误日志


        #endregion

        /// <summary>
        /// 构造方法
        /// </summary>
        public Jydata() : base(UserId, Pwd, Code, TokenClientId, TokenClientSecret, TokenRedirectUrl)
        {

        }



        public DataTable Text()
        {
            XWPFDocument doc = new XWPFDocument();
            XWPFParagraph  xh = doc.CreateParagraph();
            string sql = "select id,customItem8__c 供应商,customItem13__c 原材料名称,customItem24__c 净重,name 磅单号,customItem21__c 运费单价,customItem18__c 出库时间 from customEntity33__c limit 3000";

            string result = xoqlGet(sql);

            JObject jo = (JObject)JsonConvert.DeserializeObject(result);

            return JsonHelper.ToDataTable(jo["data"]["records"].ToString());
        }

        public void worddc()
        {





        }




    }
}
