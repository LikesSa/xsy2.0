namespace WindowsFormsText
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button_Start = new System.Windows.Forms.Button();
            this.show_lb = new System.Windows.Forms.Label();
            this.show_textBox = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.show_dataGridView = new System.Windows.Forms.DataGridView();
            this.show_webBrowser = new System.Windows.Forms.WebBrowser();
            this.inFo_textBox = new System.Windows.Forms.TextBox();
            this.show_pictureBox = new System.Windows.Forms.PictureBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.show_dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.show_pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // button_Start
            // 
            this.button_Start.Location = new System.Drawing.Point(561, 41);
            this.button_Start.Name = "button_Start";
            this.button_Start.Size = new System.Drawing.Size(92, 35);
            this.button_Start.TabIndex = 0;
            this.button_Start.Text = "开始";
            this.button_Start.UseVisualStyleBackColor = true;
            this.button_Start.Click += new System.EventHandler(this.button_Start_Click);
            // 
            // show_lb
            // 
            this.show_lb.Location = new System.Drawing.Point(505, 143);
            this.show_lb.Name = "show_lb";
            this.show_lb.Size = new System.Drawing.Size(95, 45);
            this.show_lb.TabIndex = 1;
            // 
            // show_textBox
            // 
            this.show_textBox.Location = new System.Drawing.Point(26, 123);
            this.show_textBox.Multiline = true;
            this.show_textBox.Name = "show_textBox";
            this.show_textBox.Size = new System.Drawing.Size(454, 292);
            this.show_textBox.TabIndex = 2;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(39, 608);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(576, 23);
            this.progressBar1.TabIndex = 3;
            this.progressBar1.Visible = false;
            // 
            // show_dataGridView
            // 
            this.show_dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.show_dataGridView.Location = new System.Drawing.Point(134, 545);
            this.show_dataGridView.Name = "show_dataGridView";
            this.show_dataGridView.RowTemplate.Height = 27;
            this.show_dataGridView.Size = new System.Drawing.Size(381, 22);
            this.show_dataGridView.TabIndex = 4;
            // 
            // show_webBrowser
            // 
            this.show_webBrowser.Location = new System.Drawing.Point(893, 608);
            this.show_webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.show_webBrowser.Name = "show_webBrowser";
            this.show_webBrowser.Size = new System.Drawing.Size(109, 96);
            this.show_webBrowser.TabIndex = 5;
            // 
            // inFo_textBox
            // 
            this.inFo_textBox.Location = new System.Drawing.Point(26, 41);
            this.inFo_textBox.Name = "inFo_textBox";
            this.inFo_textBox.Size = new System.Drawing.Size(214, 25);
            this.inFo_textBox.TabIndex = 6;
            // 
            // show_pictureBox
            // 
            this.show_pictureBox.Location = new System.Drawing.Point(121, 656);
            this.show_pictureBox.Name = "show_pictureBox";
            this.show_pictureBox.Size = new System.Drawing.Size(511, 32);
            this.show_pictureBox.TabIndex = 7;
            this.show_pictureBox.TabStop = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 444);
            this.Controls.Add(this.show_pictureBox);
            this.Controls.Add(this.inFo_textBox);
            this.Controls.Add(this.show_textBox);
            this.Controls.Add(this.show_webBrowser);
            this.Controls.Add(this.show_dataGridView);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.show_lb);
            this.Controls.Add(this.button_Start);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Opacity = 0.9D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "自己测试";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.show_dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.show_pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Start;
        private System.Windows.Forms.Label show_lb;
        private System.Windows.Forms.TextBox show_textBox;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.DataGridView show_dataGridView;
        private System.Windows.Forms.WebBrowser show_webBrowser;
        private System.Windows.Forms.TextBox inFo_textBox;
        private System.Windows.Forms.PictureBox show_pictureBox;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

