﻿using NPinyin;
using System;
using System.Text;
using System.Windows.Forms;
using xsy.likes.Base;
using xsy.likes.szs;
using xsy.likes.WebServices;
using xsy.likkes.jvjc;

namespace WindowsFormsText
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        private string custbackime = ConfigContent.AppSettingsGet("custbackime");
        private string cusshortnametime = ConfigContent.AppSettingsGet("cusshorttime");
        private void Form1_Load(object sender, EventArgs e)
        {

            //this.reportViewer1.RefreshReport();
        }


        private void button_Start_Click(object sender, EventArgs e)
        {
            //string m = inFo_textBox.Text;
            //Encoding gb2312 = Encoding.GetEncoding("GB2312");
            //string s = Pinyin.ConvertEncoding(m, Encoding.UTF8, gb2312);

            //show_textBox.Text = Pinyin.GetInitials(s, gb2312);



            //Jydata jd = new Jydata();

            //jd.Text();

            //jd.Text();
            //OpenFileDialog dialog = new OpenFileDialog();
            //if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            //{

            //    show_textBox.Text = dialog.FileName;

            //}

            //show_pictureBox.Image = Image.FromFile(@"C:\Users\Likes\Pictures\888\5ae343110306b255.jpeg"); ;

            //WallPageGet wpg = new WallPageGet();
            //wpg.picSavebyUrl();





        }


        #region 注释


        //OpenFileDialog dialog = new OpenFileDialog();
        //dialog.Multiselect = false;//该值确定是否可以选择多个文件
        //    dialog.Title = "请选择文件夹";
        //    dialog.Filter = "所有文件(*.*)|*.*";
        //    if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
        //    {
        //        show_textBox.Text = dialog.FileName;
        //    }


        // show_webBrowser.Url = new Uri("http://ie.icoa.cn/");
        ////Debug.WriteLine("nihao ");
        //FormPrb fm = new FormPrb(0, 100);
        //fm.StartPosition = FormStartPosition.CenterScreen;
        //fm.Show(this); //设置父窗体


        //for (int i = 0; i <= 100; i++)
        //{ 
        //    fm.setPos(i);//设置进度条位置
        //    Thread.Sleep(10);//睡眠时间为100
        //    Debug.WriteLine(i.ToString());
        //}
        // fm.Close();//关闭窗体
        //ExcelHelperbynp eh = new ExcelHelperbynp(@"C:\YesIdo\MyProject\华英包装\华英销售易字段对接确认表.xlsx");
        //DataTable dt =  eh.ExcelToDataTable("Sheet1",true);
        //show_dataGridView.DataSource = dt;


        #endregion




    }
}
