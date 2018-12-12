namespace WindowsFormsText
{
    partial class Formwordexp
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
            this.button_que = new System.Windows.Forms.Button();
            this.button_dc = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_urldz = new System.Windows.Forms.TextBox();
            this.button_chose = new System.Windows.Forms.Button();
            this.dataGridView_show = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_show)).BeginInit();
            this.SuspendLayout();
            // 
            // button_que
            // 
            this.button_que.Location = new System.Drawing.Point(655, 16);
            this.button_que.Name = "button_que";
            this.button_que.Size = new System.Drawing.Size(93, 33);
            this.button_que.TabIndex = 0;
            this.button_que.Text = "查询";
            this.button_que.UseVisualStyleBackColor = true;
            this.button_que.Click += new System.EventHandler(this.button_que_Click);
            // 
            // button_dc
            // 
            this.button_dc.Location = new System.Drawing.Point(585, 73);
            this.button_dc.Name = "button_dc";
            this.button_dc.Size = new System.Drawing.Size(93, 33);
            this.button_dc.TabIndex = 1;
            this.button_dc.Text = "导出";
            this.button_dc.UseVisualStyleBackColor = true;
            this.button_dc.Click += new System.EventHandler(this.button_dc_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(112, 24);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 25);
            this.dateTimePicker1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "开始时间：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(338, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "结束时间：";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(426, 22);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 25);
            this.dateTimePicker2.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "选择路径：";
            // 
            // textBox_urldz
            // 
            this.textBox_urldz.Location = new System.Drawing.Point(112, 79);
            this.textBox_urldz.Name = "textBox_urldz";
            this.textBox_urldz.Size = new System.Drawing.Size(308, 25);
            this.textBox_urldz.TabIndex = 7;
            this.textBox_urldz.TextChanged += new System.EventHandler(this.textBox_urldz_TextChanged);
            // 
            // button_chose
            // 
            this.button_chose.Location = new System.Drawing.Point(464, 73);
            this.button_chose.Name = "button_chose";
            this.button_chose.Size = new System.Drawing.Size(93, 33);
            this.button_chose.TabIndex = 8;
            this.button_chose.Text = "选择";
            this.button_chose.UseVisualStyleBackColor = true;
            this.button_chose.Click += new System.EventHandler(this.button_chose_Click);
            // 
            // dataGridView_show
            // 
            this.dataGridView_show.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_show.Location = new System.Drawing.Point(12, 126);
            this.dataGridView_show.Name = "dataGridView_show";
            this.dataGridView_show.RowTemplate.Height = 27;
            this.dataGridView_show.Size = new System.Drawing.Size(1155, 438);
            this.dataGridView_show.TabIndex = 9;
            // 
            // Formwordexp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1179, 576);
            this.Controls.Add(this.dataGridView_show);
            this.Controls.Add(this.button_chose);
            this.Controls.Add(this.textBox_urldz);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.button_dc);
            this.Controls.Add(this.button_que);
            this.Name = "Formwordexp";
            this.Text = "导出为Word";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_show)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_que;
        private System.Windows.Forms.Button button_dc;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_urldz;
        private System.Windows.Forms.Button button_chose;
        private System.Windows.Forms.DataGridView dataGridView_show;
    }
}