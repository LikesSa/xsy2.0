using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Timers;
using System.Windows.Forms;
using xsy.likes.szs;

namespace WindowsFormsText
{
    public partial class FormUntil : Form
    {
        public FormUntil()
        {
            InitializeComponent();
        }

        //创建神州神链接
        private SzsData sd = new SzsData();
        //创建神州神的客户简称定时器
        System.Timers.Timer timerOfSszCustomerShotname;


        private void button_start1_Click(object sender, EventArgs e)
        {
            button_start1.Enabled = false;
            timerOfSszCustomerShotname.Start();


        }

        private void FormUntil_Load(object sender, EventArgs e)
        {
            InitTimer();
        }

        private void InitTimer()
        {
            try
            {
                string tszs = textBox_infiszsshorname.Text;
                timerOfSszCustomerShotname = new System.Timers.Timer(1000 * 60 * Convert.ToInt32(tszs));

                //设置执行一次（false）还是一直执行(true)
                timerOfSszCustomerShotname.AutoReset = true;

                //设置是否执行System.Timers.Timer.Elapsed事件

                timerOfSszCustomerShotname.Enabled = true;

                //绑定Elapsed事件
                timerOfSszCustomerShotname.Elapsed += new System.Timers.ElapsedEventHandler(TimerSzsUp);
                timerOfSszCustomerShotname.Stop();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void TimerSzsUp(object sender, ElapsedEventArgs e)
        {
            try
            {

                sd.CustomerNameToShorthand();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
        }

        private void button_stop1_Click(object sender, EventArgs e)
        {
            button_start1.Enabled = true;
        }

        private void button_szsif_Click(object sender, EventArgs e)
        {
            string cc = "77888";
            cc = sd.ifText();
            if (string.IsNullOrEmpty(cc) || cc.Equals("77888"))
            {
                MessageBox.Show("接口未连接，请检查网络和配置文件！");
            }
            else
            {
                MessageBox.Show("接口已成功连接，可以进行下一步操作。");
            }
            
        }

        private void button_exit_Click(object sender, EventArgs e)
        {
            MessageBoxButtons messButton = MessageBoxButtons.OKCancel;
            DialogResult dr = MessageBox.Show("确定要退出吗?", "此操作是程序完全退出", messButton);
            if (dr == DialogResult.OK)//如果点击“确定”按钮

            {
                Dispose();
                Environment.Exit(0);
            }
        }

        /// <summary>
        /// 最小化去掉任务栏图标
        /// </summary>
        private void FormUntil_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)  //判断是否最小化
            {
                this.ShowInTaskbar = false;  //不显示在系统任务栏
            }
        }

        /// <summary>
        /// 关闭改为最小化
        /// </summary>
        private void FormUntil_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            // 将窗体变为最小化
            this.WindowState = FormWindowState.Minimized;
        }

        private void ntfi_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.ShowInTaskbar = true;  //显示在系统任务栏
            this.WindowState = FormWindowState.Normal;  //还原窗体
        }
    }
}
