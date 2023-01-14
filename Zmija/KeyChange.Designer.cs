namespace Zmija
{
    partial class KeyChange
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.changeKey_button = new System.Windows.Forms.Button();
            this.functionality_label = new System.Windows.Forms.Label();
            this.key_label = new System.Windows.Forms.Label();
            this.command_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Funkcionalnost:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tipka:";
            // 
            // changeKey_button
            // 
            this.changeKey_button.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.changeKey_button.Location = new System.Drawing.Point(0, 57);
            this.changeKey_button.Name = "changeKey_button";
            this.changeKey_button.Size = new System.Drawing.Size(250, 23);
            this.changeKey_button.TabIndex = 5;
            this.changeKey_button.Text = "IZMIJENI";
            this.changeKey_button.UseVisualStyleBackColor = true;
            this.changeKey_button.Click += new System.EventHandler(this.changeKey_button_Click);
            // 
            // functionality_label
            // 
            this.functionality_label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.functionality_label.Location = new System.Drawing.Point(90, 3);
            this.functionality_label.Name = "functionality_label";
            this.functionality_label.Size = new System.Drawing.Size(150, 20);
            this.functionality_label.TabIndex = 6;
            // 
            // key_label
            // 
            this.key_label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.key_label.Location = new System.Drawing.Point(90, 33);
            this.key_label.Name = "key_label";
            this.key_label.Size = new System.Drawing.Size(150, 20);
            this.key_label.TabIndex = 7;
            // 
            // command_label
            // 
            this.command_label.AutoSize = true;
            this.command_label.Location = new System.Drawing.Point(41, 34);
            this.command_label.Name = "command_label";
            this.command_label.Size = new System.Drawing.Size(0, 13);
            this.command_label.TabIndex = 8;
            // 
            // KeyChange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.command_label);
            this.Controls.Add(this.key_label);
            this.Controls.Add(this.functionality_label);
            this.Controls.Add(this.changeKey_button);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "KeyChange";
            this.Size = new System.Drawing.Size(250, 80);
            this.Enter += new System.EventHandler(this.KeyChange_Enter);
            this.Leave += new System.EventHandler(this.KeyChange_Leave);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button changeKey_button;
        private System.Windows.Forms.Label functionality_label;
        private System.Windows.Forms.Label key_label;
        private System.Windows.Forms.Label command_label;
    }
}
