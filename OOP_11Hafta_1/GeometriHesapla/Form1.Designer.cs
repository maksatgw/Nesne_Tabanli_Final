
namespace GeometriHesapla
{
    partial class Form1
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.aln_hsp = new System.Windows.Forms.Button();
            this.alan_txtbx = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.kaydt_btn = new System.Windows.Forms.Button();
            this.kyt_getr = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(203, 35);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(184, 21);
            this.comboBox1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(70, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Geometrik Şekli Seçiniz";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(101, 105);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(130, 20);
            this.textBox1.TabIndex = 2;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(101, 131);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(130, 20);
            this.textBox2.TabIndex = 3;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(101, 157);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(130, 20);
            this.textBox3.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Yaricap";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(48, 160);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Uzunluk";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(48, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Kenar";
            // 
            // aln_hsp
            // 
            this.aln_hsp.Location = new System.Drawing.Point(269, 131);
            this.aln_hsp.Name = "aln_hsp";
            this.aln_hsp.Size = new System.Drawing.Size(75, 23);
            this.aln_hsp.TabIndex = 8;
            this.aln_hsp.Text = "Alan Hesapla";
            this.aln_hsp.UseVisualStyleBackColor = true;
            this.aln_hsp.Click += new System.EventHandler(this.aln_hsp_Click);
            // 
            // alan_txtbx
            // 
            this.alan_txtbx.Location = new System.Drawing.Point(379, 133);
            this.alan_txtbx.Name = "alan_txtbx";
            this.alan_txtbx.Size = new System.Drawing.Size(100, 20);
            this.alan_txtbx.TabIndex = 9;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(30, 382);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(544, 212);
            this.listBox1.TabIndex = 10;
            // 
            // kaydt_btn
            // 
            this.kaydt_btn.Location = new System.Drawing.Point(194, 250);
            this.kaydt_btn.Name = "kaydt_btn";
            this.kaydt_btn.Size = new System.Drawing.Size(218, 23);
            this.kaydt_btn.TabIndex = 11;
            this.kaydt_btn.Text = "Kaydet";
            this.kaydt_btn.UseVisualStyleBackColor = true;
            this.kaydt_btn.Click += new System.EventHandler(this.kaydt_btn_Click);
            // 
            // kyt_getr
            // 
            this.kyt_getr.Location = new System.Drawing.Point(194, 341);
            this.kyt_getr.Name = "kyt_getr";
            this.kyt_getr.Size = new System.Drawing.Size(218, 23);
            this.kyt_getr.TabIndex = 12;
            this.kyt_getr.Text = "Kayıt Getir";
            this.kyt_getr.UseVisualStyleBackColor = true;
            this.kyt_getr.Click += new System.EventHandler(this.kyt_getr_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 632);
            this.Controls.Add(this.kyt_getr);
            this.Controls.Add(this.kaydt_btn);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.alan_txtbx);
            this.Controls.Add(this.aln_hsp);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button aln_hsp;
        private System.Windows.Forms.TextBox alan_txtbx;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button kaydt_btn;
        private System.Windows.Forms.Button kyt_getr;
    }
}

