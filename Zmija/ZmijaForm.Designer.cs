namespace Zmija
{
    partial class ZmijaForm
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
            this.canvas = new System.Windows.Forms.PictureBox();
            this.start = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.help = new System.Windows.Forms.Label();
            this.score = new System.Windows.Forms.Label();
            this.livesAndLevel = new System.Windows.Forms.Label();
            this.invincibility = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).BeginInit();
            this.SuspendLayout();
            // 
            // canvas
            // 
            this.canvas.BackColor = System.Drawing.Color.White;
            this.canvas.Location = new System.Drawing.Point(0, 0);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(640, 640);
            this.canvas.TabIndex = 0;
            this.canvas.TabStop = false;
            this.canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.canvas_Paint);
            // 
            // start
            // 
            this.start.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.start.Location = new System.Drawing.Point(200, 641);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(240, 50);
            this.start.TabIndex = 1;
            this.start.Text = "START";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // help
            // 
            this.help.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.help.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.help.Location = new System.Drawing.Point(0, 641);
            this.help.Name = "help";
            this.help.Size = new System.Drawing.Size(200, 50);
            this.help.TabIndex = 4;
            this.help.Text = "POSTAVKE: ctrl  + P\r\nUPUTE: ctrl + U";
            // 
            // score
            // 
            this.score.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.score.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.score.Location = new System.Drawing.Point(440, 641);
            this.score.Name = "score";
            this.score.Size = new System.Drawing.Size(200, 50);
            this.score.TabIndex = 5;
            // 
            // livesAndLevel
            // 
            this.livesAndLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.livesAndLevel.Location = new System.Drawing.Point(240, 498);
            this.livesAndLevel.Name = "livesAndLevel";
            this.livesAndLevel.Size = new System.Drawing.Size(120, 33);
            this.livesAndLevel.TabIndex = 6;
            // 
            // invincibility
            // 
            this.invincibility.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.invincibility.Location = new System.Drawing.Point(360, 498);
            this.invincibility.Name = "invincibility";
            this.invincibility.Size = new System.Drawing.Size(120, 33);
            this.invincibility.TabIndex = 7;
            // 
            // ZmijaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.invincibility);
            this.Controls.Add(this.livesAndLevel);
            this.ClientSize = new System.Drawing.Size(641, 690);
            this.Controls.Add(this.score);
            this.Controls.Add(this.help);
            this.Controls.Add(this.start);
            this.Controls.Add(this.canvas);
            this.MaximizeBox = false;
            this.Name = "ZmijaForm";
            this.Text = "Zmija";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ZmijaForm_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ZmijaForm_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox canvas;
        private System.Windows.Forms.Button start;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label help;
        private System.Windows.Forms.Label score;
        private System.Windows.Forms.Label livesAndLevel;
        private System.Windows.Forms.Label invincibility;
    }
}

