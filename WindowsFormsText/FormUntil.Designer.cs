namespace WindowsFormsText
{
    partial class FormUntil
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormUntil));
            this.label1 = new System.Windows.Forms.Label();
            this.button_start1 = new System.Windows.Forms.Button();
            this.button_stop1 = new System.Windows.Forms.Button();
            this.textBox_infiszsshorname = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button_szsif = new System.Windows.Forms.Button();
            this.button_exit = new System.Windows.Forms.Button();
            this.ntfi = new System.Windows.Forms.NotifyIcon(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.PaleTurquoise;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(38, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(195, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "神州神客户名称简写： 间隔";
            // 
            // button_start1
            // 
            this.button_start1.BackColor = System.Drawing.Color.PaleTurquoise;
            this.button_start1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_start1.Location = new System.Drawing.Point(228, 120);
            this.button_start1.Name = "button_start1";
            this.button_start1.Size = new System.Drawing.Size(58, 37);
            this.button_start1.TabIndex = 1;
            this.button_start1.Text = "开始";
            this.button_start1.UseVisualStyleBackColor = false;
            this.button_start1.Click += new System.EventHandler(this.button_start1_Click);
            // 
            // button_stop1
            // 
            this.button_stop1.BackColor = System.Drawing.Color.PaleTurquoise;
            this.button_stop1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_stop1.Location = new System.Drawing.Point(351, 120);
            this.button_stop1.Name = "button_stop1";
            this.button_stop1.Size = new System.Drawing.Size(81, 37);
            this.button_stop1.TabIndex = 2;
            this.button_stop1.Text = "停止";
            this.button_stop1.UseVisualStyleBackColor = false;
            this.button_stop1.Click += new System.EventHandler(this.button_stop1_Click);
            // 
            // textBox_infiszsshorname
            // 
            this.textBox_infiszsshorname.BackColor = System.Drawing.Color.PaleTurquoise;
            this.textBox_infiszsshorname.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_infiszsshorname.Location = new System.Drawing.Point(268, 64);
            this.textBox_infiszsshorname.Name = "textBox_infiszsshorname";
            this.textBox_infiszsshorname.Size = new System.Drawing.Size(45, 25);
            this.textBox_infiszsshorname.TabIndex = 3;
            this.textBox_infiszsshorname.Text = "2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.PaleTurquoise;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(348, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "分更新一次";
            // 
            // button_szsif
            // 
            this.button_szsif.BackColor = System.Drawing.Color.PaleTurquoise;
            this.button_szsif.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_szsif.Location = new System.Drawing.Point(41, 120);
            this.button_szsif.Name = "button_szsif";
            this.button_szsif.Size = new System.Drawing.Size(122, 37);
            this.button_szsif.TabIndex = 5;
            this.button_szsif.Text = "神州神if测试";
            this.button_szsif.UseVisualStyleBackColor = false;
            this.button_szsif.Click += new System.EventHandler(this.button_szsif_Click);
            // 
            // button_exit
            // 
            this.button_exit.BackColor = System.Drawing.Color.PaleTurquoise;
            this.button_exit.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_exit.Location = new System.Drawing.Point(332, 274);
            this.button_exit.Name = "button_exit";
            this.button_exit.Size = new System.Drawing.Size(100, 52);
            this.button_exit.TabIndex = 6;
            this.button_exit.Text = "退出";
            this.button_exit.UseVisualStyleBackColor = false;
            this.button_exit.Click += new System.EventHandler(this.button_exit_Click);
            // 
            // ntfi
            // 
            this.ntfi.Icon = ((System.Drawing.Icon)(resources.GetObject("ntfi.Icon")));
            this.ntfi.Text = "工具";
            this.ntfi.Visible = true;
            this.ntfi.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ntfi_MouseDoubleClick);
            // 
            // FormUntil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(471, 354);
            this.Controls.Add(this.button_exit);
            this.Controls.Add(this.button_szsif);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_infiszsshorname);
            this.Controls.Add(this.button_stop1);
            this.Controls.Add(this.button_start1);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormUntil";
            this.Text = "FormUntil";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormUntil_FormClosing);
            this.Load += new System.EventHandler(this.FormUntil_Load);
            this.SizeChanged += new System.EventHandler(this.FormUntil_SizeChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_start1;
        private System.Windows.Forms.Button button_stop1;
        private System.Windows.Forms.TextBox textBox_infiszsshorname;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_szsif;
        private System.Windows.Forms.Button button_exit;
        private System.Windows.Forms.NotifyIcon ntfi;
    }
}