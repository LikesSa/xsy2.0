namespace WindowsFormsText
{
    partial class FormTimeText
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_show1 = new System.Windows.Forms.TextBox();
            this.textBox_show2 = new System.Windows.Forms.TextBox();
            this.button_start = new System.Windows.Forms.Button();
            this.button_stop = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(119, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "定时器1：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(119, 156);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "定时器2：";
            // 
            // textBox_show1
            // 
            this.textBox_show1.Location = new System.Drawing.Point(249, 75);
            this.textBox_show1.Name = "textBox_show1";
            this.textBox_show1.Size = new System.Drawing.Size(189, 25);
            this.textBox_show1.TabIndex = 2;
            // 
            // textBox_show2
            // 
            this.textBox_show2.Location = new System.Drawing.Point(249, 156);
            this.textBox_show2.Name = "textBox_show2";
            this.textBox_show2.Size = new System.Drawing.Size(189, 25);
            this.textBox_show2.TabIndex = 3;
            // 
            // button_start
            // 
            this.button_start.Location = new System.Drawing.Point(122, 274);
            this.button_start.Name = "button_start";
            this.button_start.Size = new System.Drawing.Size(75, 38);
            this.button_start.TabIndex = 4;
            this.button_start.Text = "开始";
            this.button_start.UseVisualStyleBackColor = true;
            this.button_start.Click += new System.EventHandler(this.button_start_Click);
            // 
            // button_stop
            // 
            this.button_stop.Location = new System.Drawing.Point(364, 274);
            this.button_stop.Name = "button_stop";
            this.button_stop.Size = new System.Drawing.Size(74, 38);
            this.button_stop.TabIndex = 5;
            this.button_stop.Text = "停止";
            this.button_stop.UseVisualStyleBackColor = true;
            this.button_stop.Click += new System.EventHandler(this.button_stop_Click);
            // 
            // FormTimeText
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1306, 742);
            this.Controls.Add(this.button_stop);
            this.Controls.Add(this.button_start);
            this.Controls.Add(this.textBox_show2);
            this.Controls.Add(this.textBox_show1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormTimeText";
            this.Text = "FormTimeText";
            this.Load += new System.EventHandler(this.FormTimeText_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_show1;
        private System.Windows.Forms.TextBox textBox_show2;
        private System.Windows.Forms.Button button_start;
        private System.Windows.Forms.Button button_stop;
    }
}