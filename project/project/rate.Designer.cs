﻿namespace project
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
            this.C = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rate_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // rate_panel
            // 
            this.rate_panel.Controls.Add(this.label1);
            this.rate_panel.Controls.Add(this.textBox1);
            this.rate_panel.Controls.Add(this.C);
            this.rate_panel.Controls.Add(this.label5);
            this.rate_panel.Location = new System.Drawing.Point(0, 0);
            this.rate_panel.Name = "rate_panel";
            this.rate_panel.Size = new System.Drawing.Size(826, 560);
            this.rate_panel.TabIndex = 4;
            // 
            // C
            // 
            this.C.FormattingEnabled = true;
            this.C.Location = new System.Drawing.Point(283, 124);
            this.C.Name = "C";
            this.C.Size = new System.Drawing.Size(225, 24);
            this.C.TabIndex = 1;
            this.C.SelectedIndexChanged += new System.EventHandler(this.C_SelectedIndexChanged);
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
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(283, 360);
            this.textBox1.MaxLength = 10;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(225, 22);
            this.textBox1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(279, 304);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 23);
            this.label1.TabIndex = 3;
            this.label1.Text = "Enter Rate";
            this.label1.Click += new System.EventHandler(this.label1_Click);
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
        private System.Windows.Forms.ComboBox C;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
    }
}
