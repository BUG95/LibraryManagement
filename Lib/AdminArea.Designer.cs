namespace Lib
{
    partial class AdminArea
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnStergeClient = new System.Windows.Forms.Button();
            this.btnStergeCarte = new System.Windows.Forms.Button();
            this.btnEdtCarte = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button6 = new System.Windows.Forms.Button();
            this.txtTitlu = new System.Windows.Forms.TextBox();
            this.txtAutor = new System.Windows.Forms.TextBox();
            this.txtEd = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.searchBook = new System.Windows.Forms.TextBox();
            this.button7 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(119, 12);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(235, 199);
            this.listBox1.TabIndex = 0;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(425, 12);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(246, 199);
            this.listBox2.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(116, 226);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(97, 48);
            this.button1.TabIndex = 2;
            this.button1.Text = "Afiseaza lista clienti";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(219, 226);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(97, 48);
            this.button2.TabIndex = 3;
            this.button2.Text = "Afiseaza lista carti";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnStergeClient
            // 
            this.btnStergeClient.Location = new System.Drawing.Point(322, 226);
            this.btnStergeClient.Name = "btnStergeClient";
            this.btnStergeClient.Size = new System.Drawing.Size(97, 48);
            this.btnStergeClient.TabIndex = 4;
            this.btnStergeClient.Text = "Sterge client";
            this.btnStergeClient.UseVisualStyleBackColor = true;
            this.btnStergeClient.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnStergeCarte
            // 
            this.btnStergeCarte.Location = new System.Drawing.Point(425, 226);
            this.btnStergeCarte.Name = "btnStergeCarte";
            this.btnStergeCarte.Size = new System.Drawing.Size(97, 48);
            this.btnStergeCarte.TabIndex = 5;
            this.btnStergeCarte.Text = "Sterge carte";
            this.btnStergeCarte.UseVisualStyleBackColor = true;
            this.btnStergeCarte.Click += new System.EventHandler(this.button4_Click);
            // 
            // btnEdtCarte
            // 
            this.btnEdtCarte.Location = new System.Drawing.Point(425, 298);
            this.btnEdtCarte.Name = "btnEdtCarte";
            this.btnEdtCarte.Size = new System.Drawing.Size(97, 33);
            this.btnEdtCarte.TabIndex = 6;
            this.btnEdtCarte.Text = "Editeaza carte";
            this.btnEdtCarte.UseVisualStyleBackColor = true;
            this.btnEdtCarte.Click += new System.EventHandler(this.button5_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(307, 305);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 7;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Titlu",
            "Autor",
            "Editura"});
            this.comboBox1.Location = new System.Drawing.Point(163, 305);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 8;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(425, 351);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(97, 33);
            this.button6.TabIndex = 9;
            this.button6.Text = "Adauga carte";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // txtTitlu
            // 
            this.txtTitlu.Location = new System.Drawing.Point(57, 358);
            this.txtTitlu.Name = "txtTitlu";
            this.txtTitlu.Size = new System.Drawing.Size(100, 20);
            this.txtTitlu.TabIndex = 10;
            // 
            // txtAutor
            // 
            this.txtAutor.Location = new System.Drawing.Point(182, 358);
            this.txtAutor.Name = "txtAutor";
            this.txtAutor.Size = new System.Drawing.Size(100, 20);
            this.txtAutor.TabIndex = 11;
            // 
            // txtEd
            // 
            this.txtEd.Location = new System.Drawing.Point(305, 358);
            this.txtEd.Name = "txtEd";
            this.txtEd.Size = new System.Drawing.Size(100, 20);
            this.txtEd.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(84, 342);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Titlu";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(208, 342);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Autor";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(340, 342);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Editura";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(179, 285);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Modificare pentru...";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(326, 285);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Modificarea";
            // 
            // searchBook
            // 
            this.searchBook.Location = new System.Drawing.Point(307, 407);
            this.searchBook.Name = "searchBook";
            this.searchBook.Size = new System.Drawing.Size(100, 20);
            this.searchBook.TabIndex = 20;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(425, 400);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(97, 33);
            this.button7.TabIndex = 21;
            this.button7.Text = "Cauta carte";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(425, 450);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(97, 33);
            this.button3.TabIndex = 23;
            this.button3.Text = "Cauta client";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(307, 457);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(319, 441);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "Nume Prenume";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(340, 391);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "Titlu";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(528, 226);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(143, 255);
            this.button4.TabIndex = 26;
            this.button4.Text = "History";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click_1);
            // 
            // AdminArea
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 495);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.searchBook);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtEd);
            this.Controls.Add(this.txtAutor);
            this.Controls.Add(this.txtTitlu);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnEdtCarte);
            this.Controls.Add(this.btnStergeCarte);
            this.Controls.Add(this.btnStergeClient);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.listBox1);
            this.Name = "AdminArea";
            this.Text = "AdminArea";
            this.Load += new System.EventHandler(this.AdminArea_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnStergeClient;
        private System.Windows.Forms.Button btnStergeCarte;
        private System.Windows.Forms.Button btnEdtCarte;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.TextBox txtTitlu;
        private System.Windows.Forms.TextBox txtAutor;
        private System.Windows.Forms.TextBox txtEd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox searchBook;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button4;
    }
}