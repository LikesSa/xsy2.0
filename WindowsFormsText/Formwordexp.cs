using System;
using System.Windows.Forms;
using xsy.likes.Base;
using xsy.likkes.jvjc;

namespace WindowsFormsText
{
    public partial class Formwordexp : Form
    {
        public Formwordexp()
        {
            InitializeComponent();
        }

        private void button_chose_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog path = new FolderBrowserDialog();
            path.ShowDialog();
            this.textBox_urldz.Text = path.SelectedPath;
        }

        private void textBox_urldz_TextChanged(object sender, EventArgs e)
        {

        }

        private void button_dc_Click(object sender, EventArgs e)
        {
            WordHelp.CreateWordFile(this.textBox_urldz.Text,"ceshi");

        }

        private void button_que_Click(object sender, EventArgs e)
        {
            Jydata jv = new Jydata();
            System.Data.DataTable dt = jv.Text();
           
            dataGridView_show.DataSource = dt;
        }
    }
}
