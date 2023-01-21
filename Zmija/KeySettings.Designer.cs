namespace Zmija
{
    partial class KeySettings
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
            this.panelLeft = new System.Windows.Forms.Panel();
            this.keyChange12 = new Zmija.KeyChange();
            this.keyChange11 = new Zmija.KeyChange();
            this.keyChange10 = new Zmija.KeyChange();
            this.label1 = new System.Windows.Forms.Label();
            this.panelRight = new System.Windows.Forms.Panel();
            this.keyChange1 = new Zmija.KeyChange();
            this.keyChange2 = new Zmija.KeyChange();
            this.keyChange3 = new Zmija.KeyChange();
            this.label2 = new System.Windows.Forms.Label();
            this.panelUp = new System.Windows.Forms.Panel();
            this.keyChange4 = new Zmija.KeyChange();
            this.keyChange5 = new Zmija.KeyChange();
            this.keyChange6 = new Zmija.KeyChange();
            this.label3 = new System.Windows.Forms.Label();
            this.panelDown = new System.Windows.Forms.Panel();
            this.keyChange7 = new Zmija.KeyChange();
            this.keyChange8 = new Zmija.KeyChange();
            this.keyChange9 = new Zmija.KeyChange();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.keyChange_instructions = new Zmija.KeyChange();
            this.keyChange_keySettings = new Zmija.KeyChange();
            this.keyChange_close = new Zmija.KeyChange();
            this.panelLeft.SuspendLayout();
            this.panelRight.SuspendLayout();
            this.panelUp.SuspendLayout();
            this.panelDown.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelLeft
            // 
            this.panelLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelLeft.Controls.Add(this.keyChange12);
            this.panelLeft.Controls.Add(this.keyChange11);
            this.panelLeft.Controls.Add(this.keyChange10);
            this.panelLeft.Controls.Add(this.label1);
            this.panelLeft.Location = new System.Drawing.Point(11, 25);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(776, 111);
            this.panelLeft.TabIndex = 0;
            // 
            // keyChange12
            // 
            this.keyChange12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.keyChange12.command = "shift + ";
            this.keyChange12.functionality = "Kretanje ulijevo do kraja";
            this.keyChange12.key = "";
            this.keyChange12.Location = new System.Drawing.Point(519, 27);
            this.keyChange12.Name = "keyChange12";
            this.keyChange12.Size = new System.Drawing.Size(250, 80);
            this.keyChange12.TabIndex = 6;
            this.keyChange12.izmijeni_Click += new System.EventHandler<string>(this.izmijeni_Click_left);
            this.keyChange12.Load += new System.EventHandler(this.Load_left);
            // 
            // keyChange11
            // 
            this.keyChange11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.keyChange11.command = "*broj* + ";
            this.keyChange11.functionality = "Kretanje ulijevo za *broj*";
            this.keyChange11.key = "";
            this.keyChange11.Location = new System.Drawing.Point(263, 27);
            this.keyChange11.Name = "keyChange11";
            this.keyChange11.Size = new System.Drawing.Size(250, 80);
            this.keyChange11.TabIndex = 5;
            this.keyChange11.izmijeni_Click += new System.EventHandler<string>(this.izmijeni_Click_left);
            this.keyChange11.Load += new System.EventHandler(this.Load_left);
            // 
            // keyChange10
            // 
            this.keyChange10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.keyChange10.command = "";
            this.keyChange10.functionality = "Kretanje ulijevo";
            this.keyChange10.key = "";
            this.keyChange10.Location = new System.Drawing.Point(7, 27);
            this.keyChange10.Name = "keyChange10";
            this.keyChange10.Size = new System.Drawing.Size(250, 80);
            this.keyChange10.TabIndex = 4;
            this.keyChange10.izmijeni_Click += new System.EventHandler<string>(this.izmijeni_Click_left);
            this.keyChange10.Load += new System.EventHandler(this.Load_left);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "KRETANJE ULIJEVO";
            // 
            // panelRight
            // 
            this.panelRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelRight.Controls.Add(this.keyChange1);
            this.panelRight.Controls.Add(this.keyChange2);
            this.panelRight.Controls.Add(this.keyChange3);
            this.panelRight.Controls.Add(this.label2);
            this.panelRight.Location = new System.Drawing.Point(11, 142);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(776, 111);
            this.panelRight.TabIndex = 1;
            // 
            // keyChange1
            // 
            this.keyChange1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.keyChange1.command = "shift + ";
            this.keyChange1.functionality = "Kretanje udesno do kraja";
            this.keyChange1.key = "";
            this.keyChange1.Location = new System.Drawing.Point(519, 27);
            this.keyChange1.Name = "keyChange1";
            this.keyChange1.Size = new System.Drawing.Size(250, 80);
            this.keyChange1.TabIndex = 6;
            this.keyChange1.izmijeni_Click += new System.EventHandler<string>(this.izmijeni_Click_right);
            this.keyChange1.Load += new System.EventHandler(this.Load_right);
            // 
            // keyChange2
            // 
            this.keyChange2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.keyChange2.command = "*broj* + ";
            this.keyChange2.functionality = "Kretanje udesno za *broj*";
            this.keyChange2.key = "";
            this.keyChange2.Location = new System.Drawing.Point(263, 27);
            this.keyChange2.Name = "keyChange2";
            this.keyChange2.Size = new System.Drawing.Size(250, 80);
            this.keyChange2.TabIndex = 5;
            this.keyChange2.izmijeni_Click += new System.EventHandler<string>(this.izmijeni_Click_right);
            this.keyChange2.Load += new System.EventHandler(this.Load_right);
            // 
            // keyChange3
            // 
            this.keyChange3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.keyChange3.command = "";
            this.keyChange3.functionality = "Kretanje udesno";
            this.keyChange3.key = "";
            this.keyChange3.Location = new System.Drawing.Point(7, 27);
            this.keyChange3.Name = "keyChange3";
            this.keyChange3.Size = new System.Drawing.Size(250, 80);
            this.keyChange3.TabIndex = 4;
            this.keyChange3.izmijeni_Click += new System.EventHandler<string>(this.izmijeni_Click_right);
            this.keyChange3.Load += new System.EventHandler(this.Load_right);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "KRETANJE UDESNO";
            // 
            // panelUp
            // 
            this.panelUp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelUp.Controls.Add(this.keyChange4);
            this.panelUp.Controls.Add(this.keyChange5);
            this.panelUp.Controls.Add(this.keyChange6);
            this.panelUp.Controls.Add(this.label3);
            this.panelUp.Location = new System.Drawing.Point(11, 259);
            this.panelUp.Name = "panelUp";
            this.panelUp.Size = new System.Drawing.Size(776, 111);
            this.panelUp.TabIndex = 2;
            // 
            // keyChange4
            // 
            this.keyChange4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.keyChange4.command = "shift + ";
            this.keyChange4.functionality = "Kretanje prema gore do kraja";
            this.keyChange4.key = "";
            this.keyChange4.Location = new System.Drawing.Point(519, 27);
            this.keyChange4.Name = "keyChange4";
            this.keyChange4.Size = new System.Drawing.Size(250, 80);
            this.keyChange4.TabIndex = 6;
            this.keyChange4.izmijeni_Click += new System.EventHandler<string>(this.izmijeni_Click_up);
            this.keyChange4.Load += new System.EventHandler(this.Load_up);
            // 
            // keyChange5
            // 
            this.keyChange5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.keyChange5.command = "*broj* + ";
            this.keyChange5.functionality = "Kretanje prema gore za *broj*";
            this.keyChange5.key = "";
            this.keyChange5.Location = new System.Drawing.Point(263, 27);
            this.keyChange5.Name = "keyChange5";
            this.keyChange5.Size = new System.Drawing.Size(250, 80);
            this.keyChange5.TabIndex = 5;
            this.keyChange5.izmijeni_Click += new System.EventHandler<string>(this.izmijeni_Click_up);
            this.keyChange5.Load += new System.EventHandler(this.Load_up);
            // 
            // keyChange6
            // 
            this.keyChange6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.keyChange6.command = "";
            this.keyChange6.functionality = "Kretanje prema gore";
            this.keyChange6.key = "";
            this.keyChange6.Location = new System.Drawing.Point(7, 27);
            this.keyChange6.Name = "keyChange6";
            this.keyChange6.Size = new System.Drawing.Size(250, 80);
            this.keyChange6.TabIndex = 4;
            this.keyChange6.izmijeni_Click += new System.EventHandler<string>(this.izmijeni_Click_up);
            this.keyChange6.Load += new System.EventHandler(this.Load_up);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(138, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "KRETANJE PREMA GORE";
            // 
            // panelDown
            // 
            this.panelDown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDown.Controls.Add(this.keyChange7);
            this.panelDown.Controls.Add(this.keyChange8);
            this.panelDown.Controls.Add(this.keyChange9);
            this.panelDown.Controls.Add(this.label4);
            this.panelDown.Location = new System.Drawing.Point(11, 376);
            this.panelDown.Name = "panelDown";
            this.panelDown.Size = new System.Drawing.Size(776, 111);
            this.panelDown.TabIndex = 3;
            // 
            // keyChange7
            // 
            this.keyChange7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.keyChange7.command = "shift + ";
            this.keyChange7.functionality = "Kretanje prema dolje do kraja";
            this.keyChange7.key = "";
            this.keyChange7.Location = new System.Drawing.Point(519, 27);
            this.keyChange7.Name = "keyChange7";
            this.keyChange7.Size = new System.Drawing.Size(250, 80);
            this.keyChange7.TabIndex = 6;
            this.keyChange7.izmijeni_Click += new System.EventHandler<string>(this.izmijeni_Click_down);
            this.keyChange7.Load += new System.EventHandler(this.Load_down);
            // 
            // keyChange8
            // 
            this.keyChange8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.keyChange8.command = "*broj* + ";
            this.keyChange8.functionality = "Kretanje prema dolje za *broj*";
            this.keyChange8.key = "";
            this.keyChange8.Location = new System.Drawing.Point(263, 27);
            this.keyChange8.Name = "keyChange8";
            this.keyChange8.Size = new System.Drawing.Size(250, 80);
            this.keyChange8.TabIndex = 5;
            this.keyChange8.izmijeni_Click += new System.EventHandler<string>(this.izmijeni_Click_down);
            this.keyChange8.Load += new System.EventHandler(this.Load_down);
            // 
            // keyChange9
            // 
            this.keyChange9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.keyChange9.command = "";
            this.keyChange9.functionality = "Kretanje prema dolje";
            this.keyChange9.key = "";
            this.keyChange9.Location = new System.Drawing.Point(7, 27);
            this.keyChange9.Name = "keyChange9";
            this.keyChange9.Size = new System.Drawing.Size(250, 80);
            this.keyChange9.TabIndex = 4;
            this.keyChange9.izmijeni_Click += new System.EventHandler<string>(this.izmijeni_Click_down);
            this.keyChange9.Load += new System.EventHandler(this.Load_down);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(141, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "KRETANJE PREMA DOLJE";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(534, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Odaberite kontrolu vezanu za željenu funkcionalnost, stisnite željenu tipku te sp" +
    "remite promjenu klikom na gumb.";
            // 
            // keyChange_instructions
            // 
            this.keyChange_instructions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.keyChange_instructions.command = "ctrl + ";
            this.keyChange_instructions.functionality = "Upute";
            this.keyChange_instructions.key = "";
            this.keyChange_instructions.Location = new System.Drawing.Point(793, 287);
            this.keyChange_instructions.Name = "keyChange_instructions";
            this.keyChange_instructions.Size = new System.Drawing.Size(250, 80);
            this.keyChange_instructions.TabIndex = 5;
            this.keyChange_instructions.izmijeni_Click += new System.EventHandler<string>(this.keyChange_instructions_izmijeni_Click);
            this.keyChange_instructions.Load += new System.EventHandler(this.keyChange_instructions_Load);
            // 
            // keyChange_keySettings
            // 
            this.keyChange_keySettings.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.keyChange_keySettings.command = "ctrl + ";
            this.keyChange_keySettings.functionality = "Postavke";
            this.keyChange_keySettings.key = "";
            this.keyChange_keySettings.Location = new System.Drawing.Point(793, 170);
            this.keyChange_keySettings.Name = "keyChange_keySettings";
            this.keyChange_keySettings.Size = new System.Drawing.Size(250, 80);
            this.keyChange_keySettings.TabIndex = 4;
            this.keyChange_keySettings.izmijeni_Click += new System.EventHandler<string>(this.keyChange_keySettings_izmijeni_Click);
            this.keyChange_keySettings.Load += new System.EventHandler(this.keyChange_keySettings_Load);
            // 
            // keyChange_close
            // 
            this.keyChange_close.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.keyChange_close.command = "";
            this.keyChange_close.functionality = "Zatvaranje prozora";
            this.keyChange_close.key = "";
            this.keyChange_close.Location = new System.Drawing.Point(793, 53);
            this.keyChange_close.Name = "keyChange_close";
            this.keyChange_close.Size = new System.Drawing.Size(250, 80);
            this.keyChange_close.TabIndex = 6;
            this.keyChange_close.izmijeni_Click += new System.EventHandler<string>(this.keyChange_close_izmijeni_Click);
            this.keyChange_close.Load += new System.EventHandler(this.keyChange_close_Load);
            // 
            // KeySettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1049, 500);
            this.Controls.Add(this.keyChange_keySettings);
            this.Controls.Add(this.panelDown);
            this.Controls.Add(this.keyChange_close);
            this.Controls.Add(this.panelUp);
            this.Controls.Add(this.keyChange_instructions);
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.panelLeft);
            this.Controls.Add(this.label5);
            this.Name = "KeySettings";
            this.Text = "Postavke";
            this.panelLeft.ResumeLayout(false);
            this.panelLeft.PerformLayout();
            this.panelRight.ResumeLayout(false);
            this.panelRight.PerformLayout();
            this.panelUp.ResumeLayout(false);
            this.panelUp.PerformLayout();
            this.panelDown.ResumeLayout(false);
            this.panelDown.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelUp;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panelDown;
        private System.Windows.Forms.Label label4;
        private KeyChange keyChange10;
        private KeyChange keyChange12;
        private KeyChange keyChange11;
        private KeyChange keyChange1;
        private KeyChange keyChange2;
        private KeyChange keyChange3;
        private KeyChange keyChange4;
        private KeyChange keyChange5;
        private KeyChange keyChange6;
        private KeyChange keyChange8;
        private KeyChange keyChange9;
        private KeyChange keyChange7;
        private KeyChange keyChange_keySettings;
        private KeyChange keyChange_instructions;
        private KeyChange keyChange_close;
        private System.Windows.Forms.Label label5;
    }
}