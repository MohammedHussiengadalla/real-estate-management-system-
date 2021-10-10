namespace project
{
    partial class rate
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.rate_panel = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.combox_emp = new System.Windows.Forms.ComboBox();
            this.rate_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // rate_panel
            // 
            this.rate_panel.Controls.Add(this.combox_emp);
            this.rate_panel.Controls.Add(this.button1);
            this.rate_panel.Controls.Add(this.label1);
            this.rate_panel.Controls.Add(this.textBox1);
            this.rate_panel.Controls.Add(this.label5);
            this.rate_panel.Location = new System.Drawing.Point(0, 0);
            this.rate_panel.Name = "rate_panel";
            this.rate_panel.Size = new System.Drawing.Size(826, 560);
            this.rate_panel.TabIndex = 4;
            this.rate_panel.Paint += new System.Windows.Forms.PaintEventHandler(this.rate_panel_Paint);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(303, 383);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(205, 38);
            this.button1.TabIndex = 4;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(305, 213);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 23);
            this.label1.TabIndex = 3;
            this.label1.Text = "Enter Rate";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(283, 273);
            this.textBox1.MaxLength = 10;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(225, 22);
            this.textBox1.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Cambria", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(104)))), ((int)(((byte)(186)))));
            this.label5.Location = new System.Drawing.Point(277, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(237, 33);
            this.label5.TabIndex = 0;
            this.label5.Text = "Chosse Employee";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // combox_emp
            // 
            this.combox_emp.FormattingEnabled = true;
            this.combox_emp.Location = new System.Drawing.Point(309, 123);
            this.combox_emp.Name = "combox_emp";
            this.combox_emp.Size = new System.Drawing.Size(121, 24);
            this.combox_emp.TabIndex = 5;
            // 
            // rate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.rate_panel);
            this.Name = "rate";
            this.Size = new System.Drawing.Size(826, 560);
            this.Load += new System.EventHandler(this.rate_Load);
            this.rate_panel.ResumeLayout(false);
            this.rate_panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel rate_panel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox combox_emp;
    }
}
