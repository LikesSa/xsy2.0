using System;
using System.Timers;
using System.Windows.Forms;
using xsy.likes.szs;

namespace WindowsFormsText
{
    public partial class FormTimeText : Form
    {
        public FormTimeText()
        {
            InitializeComponent();
        }
        int t = 1;
        int t1 = 0;

        System.Timers.Timer timer;
        System.Timers.Timer timer1;

        //定义委托
        public delegate void SetControlValue(string value);
        //定义委托2
        public delegate void SetControlValue1(string value);

        private void button_start_Click(object sender, EventArgs e)
        {

            timer.Start();
            timer1.Start();

        }

        private void FormTimeText_Load(object sender, EventArgs e)
        {
            InitTimer();
        }
        private SzsData sd = new SzsData();
        private void InitTimer()
        {
            


            timer = new System.Timers.Timer(10);
            timer1 = new System.Timers.Timer(100);
            
            //设置执行一次（false）还是一直执行(true)
            timer.AutoReset = true;
            timer1.AutoReset = true;

            //设置是否执行System.Timers.Timer.Elapsed事件

            timer.Enabled = true;
            timer1.Enabled = true;

            //绑定Elapsed事件
            timer.Elapsed += new System.Timers.ElapsedEventHandler(TimerUp);
            timer1.Elapsed += new System.Timers.ElapsedEventHandler(TimerUp1);
            timer.Stop();timer1.Stop();



        }

        private void StetextBoxText(string strValue)
        {

            this.textBox_show1.Text = this.t.ToString().Trim();

        }

        private void TimerUp(object sender, ElapsedEventArgs e)
        {
            try
            {
                sd.text();
                
                t += 1;
                this.Invoke(new SetControlValue(StetextBoxText),t.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
        }

        private void StetextBoxText1(string strValue)
        {

            this.textBox_show2.Text = this.t1.ToString().Trim();

        }
        private void TimerUp1(object sender, ElapsedEventArgs e)
        {
            try
            {
                sd.text1();
                t1 += 2;
                this.Invoke(new SetControlValue1(StetextBoxText1), t1.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
        }

        private void button_stop_Click(object sender, EventArgs e)
        {
            timer.Stop();
            timer1.Stop();
        }
    }
}
