using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NPinyin;
using System;
using System.Collections;
using System.Data;
using System.Text;
using xsy.likes.Base;
using xsy.likes.DB;
using xsy.likes.IfGenering;
using xsy.likes.Log;

namespace xsy.likes.szs
{
    public class SzsData : IfGener
    {
        #region 配置文件和参数
        private const string UserId = "13633823006";     //用户名
        private const string Pwd = "990517";
        private const string Code = "Vo5J5bJd";          //安全令牌
        private const string TokenClientId = "761eb320f605e46b45669106e6be9e20";
        private const string TokenClientSecret = "c18cff89e430c0b9ad2f62156ecd20f5";
        private const string TokenRedirectUrl = "https://www.szsyy.xsy.com";

        DbOperate db = new DbOperate();
        private const int countOneTime = 30;//每次取的个数

        public string logMsg = string.Empty;//全局Log对象，用于记录错误日志

        /// <summary>
        /// 构造方法
        /// </summary>
        public SzsData() : base(UserId, Pwd, Code, TokenClientId, TokenClientSecret, TokenRedirectUrl)
        {

        }


        #endregion

        /// <summary>
        /// 回写到ERP中间库
        /// </summary>
        public void CustomerToErp()
        {
            string updateSqls = string.Empty;
            string ids = string.Empty;
            ArrayList List = new ArrayList(); //放入写入成功的id
            try
            {
                //测试git
                string cuselectSql = "select id,entityType,ownerId.name,accountName,level,parentAccountId,state,city,region,dimDepart.departName,"
                                    + "address,phone,comment,customItem150__c,customItem152__c,customItem153__c,customItem159__c,"
                                    + "customItem154__c,customItem155__c,customItem156__c,customItem157__c,customItem158__c,customItem160__c "
                                    + " from account where customItem157__c = 1 and customItem158__c = 2 and customItem152__c is not null and level is not null"
                                    + "  limit 3000";
                string resultjson = xoqlGet(cuselectSql);
                if (resultjson.Contains("\"code\":\"200\""))
                {
                    JObject jo =(JObject)JsonConvert.DeserializeObject(resultjson);
                    int count = Convert.ToInt32(jo["data"]["count"].ToString());
                    //string records = jo["data"]["records"].ToString();
                    if (count > 0)
                    {
                        for (int a = 0; a < count; a++)
                        {
                            //string level = jo["data"]["records"][0]["level"][0].ToString();
                            //取值
                            string id = jo["data"]["records"][a]["id"].ToString(); //id
                            string ownerName = jo["data"]["records"][a]["ownerId.name"].ToString(); //客户所有人
                            string accountName = jo["data"]["records"][a]["accountName"].ToString(); //客户名称
                            //判定客户等级
                            string level = null;
                            if (resultjson.Contains("\"level\":"))
                            {
                                level = jo["data"]["records"][a]["level"][0].ToString(); //客户等级
                            }
                            string parentAccountId = jo["data"]["records"][a]["parentAccountId"].ToString(); //上级客户
                            string state = jo["data"]["records"][a]["state"].ToString(); //省份
                            string city = jo["data"]["records"][a]["city"].ToString(); //市
                            string region = jo["data"]["records"][a]["region"].ToString(); //区
                            string address = jo["data"]["records"][a]["address"].ToString(); //详细地址
                            string phone = jo["data"]["records"][a]["phone"].ToString(); //手机1
                            string comment = jo["data"]["records"][a]["comment"].ToString(); //备注
                            string dimDepart = jo["data"]["records"][a]["dimDepart.departName"].ToString(); //所属部门
                            string customItem150__c = jo["data"]["records"][a]["customItem150__c"].ToString(); //客户编码
                            string customItem159__c = jo["data"]["records"][a]["customItem159__c"][0].ToString(); //客户分类
                            string customItem152__c = jo["data"]["records"][a]["customItem152__c"].ToString(); //客户简称
                            string customItem153__c = jo["data"]["records"][a]["customItem153__c"].ToString(); //手机2
                            string customItem154__c = jo["data"]["records"][a]["customItem154__c"].ToString(); //微信
                            string customItem155__c = jo["data"]["records"][a]["customItem155__c"].ToString(); //平台/介绍人
                            string customItem156__c = jo["data"]["records"][a]["customItem156__c"][0].ToString(); //客户来源
                            string customItem160__c = jo["data"]["records"][a]["customItem160__c"][0].ToString(); //客户crmid
                            string crmid = jo["data"]["records"][a]["customItem160__c"].ToString(); //crmid

                            if (!string.IsNullOrEmpty(parentAccountId))
                            {
                                parentAccountId = IdGetSql("accountName", $"select accountName from account where id  = {parentAccountId}")[0].ToString();//

                            }

                            if (!string.IsNullOrEmpty(customItem150__c))
                            {
                                updateSqls += $"if not (exists(select * from dbo.customer where cusno = '{customItem150__c}'))	"
                                        + "begin "
                                        + "insert into dbo.customer(cusname,cusno,crmid,ownername,cuslevel,parentAccountname,state,city,region,address,phone,comment,"
                                        + "dimDepart,custype,cusshortname,phone2,weichat,ptorjsr,cusfrom,id,status)"
                                        + $"values('{accountName}','{customItem150__c}','{crmid}','{ownerName}','{level}','{parentAccountId}','{state}','{city}','{region}','{address}',"
                                        + $" '{phone}','{comment}','{dimDepart}','{customItem159__c}','{customItem152__c}','{customItem153__c}',"
                                        + $"'{customItem154__c}','{customItem155__c}','{customItem156__c}','{id}','1');"
                                        + $" end; ";

                                ids += $"客户id：{id},客户名称：{accountName}；";
                                List.Add(id);

                            }
                            else
                            {
                                //input格式 /
                                string input = "{"
                                           + $"\"id\": {id}"
                                           + $",\"dbcVarchar1\": \"{customItem160__c}\""
                                           + "}";

                                bool fa = CustomerUpdate(input);
                                if (fa)
                                {
                                    LogHelper.Info($"{accountName}的编码：补写成功！");
                                }
                                else
                                {
                                    LogHelper.Info($"{accountName}的编码：补写失败！");
                                }




                            }


                        }
                        try
                        {
                            if (!string.IsNullOrEmpty(updateSqls))
                            {
                                db.ExecuteNonQuery(updateSqls, CommandType.Text);
                                //if (List.Count > 0)
                                //{
                                //    for (int a = 0; a < List.Count; a++)
                                //    {
                                //        //更新到本地数据库
                                //        string jsoncus = "{\"id\":"
                                //        + $"{List[a]},"
                                //        + "\"dbcSelect3\": \"2\""
                                //        + "}";

                                //        CustomerUpdate(jsoncus);
                                //    }
                                //}

                            }
                            else
                            {

                                logMsg = "SQL拼接为空！";
                            }

                        }
                        catch (Exception exception)
                        {
                            logMsg = $"但在更新数据库时失败，失败原因：{exception.Message}";
                            LogHelper.Error(logMsg);
                        }

                        LogHelper.Info($"当前{ids}回写到ERP成功！");


                    }
                    else
                    {
                         LogHelper.Info($"无需要回写的客户！");
                    }
                   
                }

            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.ToString());
            }


        }

        /// <summary>
        /// 更新到ERP中间库
        /// </summary>
        public void CustomerChange()
        {
            string nowtime = DateTime.Now.AddMinutes(+5).ToString();//获取当前系统时间 完整的日期和时间
            string updateSqls = string.Empty;
            string ids = string.Empty;
            try
            {
                string lasttime = db.ExecuteScalar("select nowtime from tablesjc where tablename = 'customer';").ToString();
                long lasttimesjc = DateHelper.ConvertDateTimeToInt(lasttime);
                string upjson = "select id,entityType,ownerId.name,accountName,level,parentAccountId,state,city,region,dimDepart.departName,"
                                    + "address,phone,comment,customItem150__c,customItem152__c,customItem153__c,customItem159__c,"
                                    + "customItem154__c,customItem155__c,customItem156__c,customItem157__c,customItem158__c "
                                    + $" from account where customItem157__c = 2 and customItem158__c = 2 and updatedAt > '{lasttimesjc}' limit 30";
                string resultjson = xoqlGet(upjson);

                if (resultjson.Contains("\"code\":\"200\""))
                {
                    JObject jo = (JObject)JsonConvert.DeserializeObject(resultjson);
                    int count = Convert.ToInt32(jo["data"]["count"].ToString());
                    //string records = jo["data"]["records"].ToString();
                    if (count > 0)
                    {
                        for (int a = 0; a < count; a++)
                        {
                            //string level = jo["data"]["records"][0]["level"][0].ToString();
                            //取值
                            string id = jo["data"]["records"][a]["id"].ToString(); //id
                            string ownerName = jo["data"]["records"][a]["ownerId.name"].ToString(); //客户所有人
                            string accountName = jo["data"]["records"][a]["accountName"].ToString(); //客户名称
                            string level = jo["data"]["records"][a]["level"][0].ToString(); //客户等级
                            string parentAccountId = jo["data"]["records"][a]["parentAccountId"].ToString(); //上级客户
                            string state = jo["data"]["records"][a]["state"].ToString(); //省份
                            string city = jo["data"]["records"][a]["city"].ToString(); //市
                            string region = jo["data"]["records"][a]["region"].ToString(); //区
                            string address = jo["data"]["records"][a]["address"].ToString(); //详细地址
                            string phone = jo["data"]["records"][a]["phone"].ToString(); //手机1
                            string comment = jo["data"]["records"][a]["comment"].ToString(); //备注
                            string dimDepart = jo["data"]["records"][a]["dimDepart.departName"].ToString(); //所属部门
                            string customItem150__c = jo["data"]["records"][a]["customItem150__c"].ToString(); //客户编码
                            string customItem159__c = jo["data"]["records"][a]["customItem159__c"][0].ToString(); //客户分类
                            string customItem152__c = jo["data"]["records"][a]["customItem152__c"].ToString(); //客户简称
                            string customItem153__c = jo["data"]["records"][a]["customItem153__c"].ToString(); //手机2
                            string customItem154__c = jo["data"]["records"][a]["customItem154__c"].ToString(); //微信
                            string customItem155__c = jo["data"]["records"][a]["customItem155__c"].ToString(); //平台/介绍人
                            string customItem156__c = jo["data"]["records"][a]["customItem156__c"][0].ToString(); //客户来源

                            if (!string.IsNullOrEmpty(parentAccountId))
                            {
                                parentAccountId = IdGetSql("accountName", $"select accountName from account where id  = {parentAccountId}")[0].ToString();//

                            }

                            updateSqls += $"if exists(select * from dbo.customer  where cusno ='{customItem150__c}') "
                                        + $"begin 	"
                                        + $"update dbo.customer set cusname = '{accountName}',ownername = '{ownerName}',cuslevel = '{level}',"
                                        + $"parentAccountname  = '{parentAccountId}',state = '{state}',city = '{city}',cusno = '',"
                                        + $"region = '{region}',address = '{address}',phone = '{phone}',comment = '{comment}',"
                                        + $"dimDepart ='{dimDepart}',custype ='{customItem159__c}',cusshortname ='{customItem152__c}',phone2 ='{customItem153__c}',"
                                        + $"weichat ='{customItem154__c}',ptorjsr ='{customItem155__c}',cusfrom ='{customItem156__c}' where id = '{id}';"
                                        + $" end;";

                            ids += $"客户id：{id},客户名称：{accountName}；";
                        }


                        //更新到本地数据库
                        try
                        {
                            if (string.IsNullOrEmpty(updateSqls))
                            {
                                db.ExecuteNonQuery(updateSqls, CommandType.Text);
                                db.ExecuteNonQuery($"update tablesjc set nowtime = '{nowtime}' where tablename = 'customer';");
                                LogHelper.Info($"当前{ids}更新成功！");

                            }
                            else
                            {
                                logMsg = "sql拼接为空！";
                            }
                        }
                        catch (Exception exception)
                        {
                            logMsg = $"但在更新数据库时失败，失败原因：{exception.Message}";
                            LogHelper.Error(logMsg);
                        }

                    }
                    else
                    {
                        LogHelper.Info("无需要更新的客户信息！");
                    }
                   
                }
                 LogHelper.Info("post获取客户信息发生错误！");




            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.ToString());
            }


        }

        /// <summary>
        /// 客户名称简写
        /// </summary>
        public void CustomerNameToShorthand()
        {
            try
            {
                string cc = CustomerDescribe();
                string Tsql = "select id,accountName from account where dbcVarchar2 is null or dbcVarchar2 = '' ;";
                //string resultjson = xoqlGet(Tsql);
                string resultjson = sqlGet(Tsql);
                if (resultjson.Contains("count"))
                {
                    JObject jo = (JObject)JsonConvert.DeserializeObject(resultjson);
                    int count = Convert.ToInt32(jo["count"].ToString());
                    if (count > 0)
                    {
                        for (int a = 0; a < count; a++)
                        {
                            string id = jo["records"][a]["id"].ToString();
                            string accountName = jo["records"][a]["accountName"].ToString();

                            Encoding gb2312 = Encoding.GetEncoding("GB2312");
                            string s = Pinyin.ConvertEncoding(accountName, Encoding.UTF8, gb2312);
                            string shortName = Pinyin.GetInitials(s, gb2312);

                            //input格式        /
                            string input = "{"
                                           + $"\"id\": {id}"
                                           + $",\"dbcVarchar2\": \"{shortName}\""
                                           + "}";

                            bool fa = CustomerUpdate(input);
                            if (fa)
                            {
                                LogHelper.Info($"{accountName}的简写：{shortName}生成成功！");
                            }
                            else
                            {
                                LogHelper.Info($"{accountName}的简写：{shortName}生成失败！");
                            }

                        }
                    }

                     LogHelper.Info($"无需要生成简写的客户信息！");


                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.ToString());
            }
        }

        /// <summary>
        /// 客户名称简写全部 需要分页
        /// </summary>
        public void CustomerNameToShorthandFenye()
        {
            try
            {
                string cc = CustomerDescribe();
                string Tsql = "select id,accountName from account limit 0,300;";
                //string resultjson = xoqlGet(Tsql);
                string resultjson = sqlGet(Tsql);
                if (resultjson.Contains("count"))
                {
                    JObject jo = (JObject)JsonConvert.DeserializeObject(resultjson);
                    double count = Convert.ToDouble(jo["count"].ToString());
                    if (count > 0)
                    {
                        double totalsize = Convert.ToDouble(jo["totalSize"].ToString());
                        double yeshu = Math.Ceiling(totalsize / count);

                        for (int b = 0; b < yeshu; b++)
                        {
                            Tsql = $"select id,accountName from account limit {b*300},300;";
                            resultjson = sqlGet(Tsql);


                            if (resultjson.Contains("count"))
                            {

                                jo = (JObject)JsonConvert.DeserializeObject(resultjson);
                                count = Convert.ToDouble(jo["count"].ToString());
                                if (count > 0)
                                {
                                    for (int a = 0; a < count; a++)
                                    {
                                        string id = jo["records"][a]["id"].ToString();
                                        string accountName = jo["records"][a]["accountName"].ToString();

                                        Encoding gb2312 = Encoding.GetEncoding("GB2312");
                                        string s = Pinyin.ConvertEncoding(accountName, Encoding.UTF8, gb2312);
                                        string shortName = Pinyin.GetInitials(s, gb2312);

                                        //input格式        /
                                        string input = "{"
                                                       + $"\"id\": {id}"
                                                       + $",\"dbcVarchar2\": \"{shortName}\""
                                                       + "}";

                                        bool fa = CustomerUpdate(input);
                                        if (fa)
                                        {
                                            LogHelper.Info($"{accountName}的简写：{shortName}生成成功！");
                                        }
                                        else
                                        {
                                            LogHelper.Info($"{accountName}的简写：{shortName}生成失败！");
                                        }

                                    }



                                }


                            }

                        }

                        LogHelper.Info($"无需要生成简写的客户信息！");


                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.ToString());
            }
        }

        /// <summary>
        /// 下载所有id
        /// </summary>
        public void Ycon()
        {
                try
                {
                    
                    string cc = CustomerDescribe();
                    string Tsql = "select id,accountName from account limit 0,300;";
                    //string resultjson = xoqlGet(Tsql);
                    string resultjson = sqlGet(Tsql);
                    if (resultjson.Contains("count"))
                    {
                        JObject jo = (JObject)JsonConvert.DeserializeObject(resultjson);
                        double count = Convert.ToDouble(jo["count"].ToString());
                        if (count > 0)
                        {
                            double totalsize = Convert.ToDouble(jo["totalSize"].ToString());
                            double yeshu = Math.Ceiling(totalsize / count);

                            for (int b = 0; b < yeshu; b++)
                            {
                                string upsql = string.Empty;
                                Tsql = $"select id,accountName from account order by id limit {b*300},300;";
                                resultjson = sqlGet(Tsql);


                                if (resultjson.Contains("count"))
                                {
                                    jo = (JObject)JsonConvert.DeserializeObject(resultjson);
                                    count = Convert.ToDouble(jo["count"].ToString());
                                    if (count > 0)
                                    {
                                        for (int a = 0; a < count; a++)
                                        {
                                            string id = jo["records"][a]["id"].ToString();
                                            string accountName = jo["records"][a]["accountName"].ToString();

                                            upsql += $"('{id}','{accountName}'),";

                                        }



                                    }
                                }
                                string uplastsql = $"insert into crmcunid(id,cusname) values{upsql.Remove(upsql.LastIndexOf(","), 1)}";

                            db.ExecuteNonQuery(uplastsql);


                            }
                            
                            LogHelper.Info($"无需要生成简写的客户信息！");


                        }
                    }

                }
            catch (Exception ex)
            {
                LogHelper.Error(ex.ToString());
            }


        }

        /// <summary>
        /// 修改
        /// </summary>
        public void xiugai()
        {
            try
            {
                          string sql = "select * from chuliwanhhh where id is not null and id <> ''";
                var dt = db.GetDataSet(sql, CommandType.Text);

                if (dt.Rows.Count <= 0)
                {
                    LogHelper.Info("无需要修改的发货信息！");
                    return;
                }


                foreach (DataRow dataRow in dt.Rows)
                {

                    var json = "{\"id\":"
                                + $"{dataRow["id"]},"
                                + $"\"comment\": \"{dataRow["beizhu"]}\""
                                + "}";


                    CustomerUpdate(json);


                }




            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.ToString());
            }


        }

        /// <summary>
        /// 客户编码补写
        /// </summary>
        public void CustomercodeTochar1()
        {
            try
            {
                //string cc = CustomerDescribe();
                string Tsql = "select id,accountName,dbcVarchar5 from account where dbcVarchar1 is null or dbcVarchar1 = '' limit 300;";
                //string resultjson = xoqlGet(Tsql);
                string resultjson = sqlGet(Tsql);
                if (resultjson.Contains("count"))
                {
                    JObject jo = (JObject)JsonConvert.DeserializeObject(resultjson);
                    int count = Convert.ToInt32(jo["count"].ToString());
                    if (count > 0)
                    {
                        for (int a = 0; a < count; a++)
                        {
                            string id = jo["records"][a]["id"].ToString();
                            string accountName = jo["records"][a]["accountName"].ToString();
                            string dbcVarchar5 = jo["records"][a]["dbcVarchar5"].ToString();

                            //input格式        /
                            string input = "{"
                                           + $"\"id\": {id}"
                                           + $",\"dbcVarchar1\": \"{dbcVarchar5}\""
                                           + "}";

                            bool fa = CustomerUpdate(input);
                            if (fa)
                            {
                                LogHelper.Info($"{accountName}的编码：补写成功！");
                            }
                            else
                            {
                                LogHelper.Info($"{accountName}的编码：补写失败！");
                            }

                        }
                    }

                    LogHelper.Info($"无需要补写编码的客户！");


                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.ToString());
            }
        }

        /// <summary>
        /// 接口通断测试
        /// </summary>
        /// <returns></returns>
        public string ifText()
        {
            return ifTextBygetoke();
        }

        /// <summary>
        /// 修改客户状态
        /// </summary>
        public void cusstastom()
        {
            try
            {
                string sql = "select id,accountName,customItem157__c from account where customItem157__c = '已同步' limit 1000";
                string[] str = IdGetSql("id",sql);
                for (int a = 0;a < str.Length;a++)
                {
                    var input = "{"
                            + $"\"id\": {str[a]}"
                            + $",\"dbcSelect3\": \"1\""
                            + "}";

                    bool fa = CustomerUpdate(input);

                }

            }
            catch(Exception ex)
            {
                LogHelper.Error(ex.ToString());
            }

        }

        /// <summary>
        /// 测试
        /// </summary>
        public void text()
        {
            //customizeGet("account");
            //approvalsMeaningGet("1","7233920");   //7233920
            ////string sql = "select id from user where name = '魏艳艳'";
            ////xoqlGet(sql);

            try
            {
                string[] cuids = IdGetSql("id", "select id,customItem150__c from account where approvalStatus = 0 limit 300");
                if (cuids.Length > 0)
                {
                    for (int a = 0; a < cuids.Length; a++)
                    {
                        var input = "{"
                                + $"\"defineId\": {"1331102"}"
                                + $",\"dataId\": \"{cuids[a]}\""
                                + $",\"approvalUserId\": \"{"1107600"}\""
                                + "}";

                        approvalSubmit(input);


                    }


                }
                //string[] str = null;
                //bool fa = allApprovalsingGet("1107600",out str);
                //if (fa && str.Length >0)
                //{
                //    for (int a = 0;a < str.Length; a++)
                //    {

                //        var input = "{"
                //                + $"\"approvalId\": {str[a]}"
                //                + $",\"approvalUserId\": \"{"1107600"}\""
                //                + $",\"comments\": \"{"销售易实施批量审批"}\""
                //                + "}";

                //        approvalAgree(input);
                //    }
                //}


            }
            catch (Exception ex)
            {

            }


        }

        /// <summary>
        /// 测试
        /// </summary>
        public void text1()
        {
            //customizeGet("account");
            //approvalsMeaningGet("1","7233920");   //7233920
            ////string sql = "select id from user where name = '魏艳艳'";
            ////xoqlGet(sql);

            try
            {

                string[] str = null;
                bool fa = allApprovalsingGet("1107600", out str);
                if (fa && str.Length > 0)
                {
                    for (int a = 0; a < str.Length; a++)
                    {

                        var input = "{"
                                + $"\"approvalId\": {str[a]}"
                                + $",\"approvalUserId\": \"{"1107600"}\""
                                + $",\"comments\": \"{"销售易实施批量审批"}\""
                                + "}";

                        approvalAgree(input);
                    }
                }


            }
            catch (Exception ex)
            {

            }


        }

    }
}
