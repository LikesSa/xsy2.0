using System;
using System.ServiceProcess;
using System.Timers;
using xsy.likes.Base;
using xsy.likes.Log;
using xsy.likes.szs;

namespace xsy.szsyy.WindowsService
{
    public partial class XsyIfService : ServiceBase
    {
        private string custbacktime = ConfigContent.AppSettingsGet("custbacktime");
        private string cusshortnametime = ConfigContent.AppSettingsGet("cusshortnametime");
        private SzsData sd = new SzsData();
        System.Timers.Timer custbacktimer = new Timer();
        System.Timers.Timer cusshortnametimer = new Timer();

 
        public XsyIfService()
        {
            InitializeComponent();
            InitTimer();

        }

        private void InitTimer()
        {
            try
            {
                custbacktimer.Interval = Convert.ToDouble(custbacktime) * 60 * 1000;
                cusshortnametimer.Interval = Convert.ToDouble(cusshortnametime) * 60 * 1000;


                //设置执行一次（false）还是一直执行(true)
                custbacktimer.AutoReset = true;
                cusshortnametimer.AutoReset = true;

                //设置是否执行System.Timers.Timer.Elapsed事件

                custbacktimer.Enabled = true;
                cusshortnametimer.Enabled = true;

                //绑定Elapsed事件
                custbacktimer.Elapsed += new System.Timers.ElapsedEventHandler(TimerUp);
                cusshortnametimer.Elapsed += new System.Timers.ElapsedEventHandler(TimerUp1);
               


            }
            catch (Exception exception)
            {
                LogHelper.Error($"初始化启动XSYIF时错误：{exception.Message}");
            }
        }

        /// <summary>
        /// 客户名称简称
        /// </summary>
        private void TimerUp1(object sender, ElapsedEventArgs e)
        {
            try
            {
                sd.CustomerNameToShorthand();
                sd.CustomercodeTochar1(); //客户编码补写
            }
            catch (Exception ex)
            {
                LogHelper.Info(ex.ToString());

            }
            finally
            {
                cusshortnametimer.Start();
            }
        }

        /// <summary>
        /// 客户同步和更改
        /// </summary>
        private void TimerUp(object sender, ElapsedEventArgs e)
        {
            try
            {
                sd.CustomerToErp();
                sd.CustomerChange();
            }
            catch (Exception ex)
            {
                LogHelper.Info(ex.ToString());

            }
            finally
            {
                custbacktimer.Start();
            }
        }

        protected override void OnStart(string[] args)
        {
            custbacktimer.Start();
            cusshortnametimer.Start();

        }

        protected override void OnStop()
        {
            custbacktimer.Stop();
            cusshortnametimer.Stop();
        }
    }
}
