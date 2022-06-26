namespace WinFormsApp
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ball = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.player = new System.Windows.Forms.PictureBox();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.score = new System.Windows.Forms.Label();
            this.scoreBox = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ball)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.player)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.pictureBox1.Location = new System.Drawing.Point(307, 12);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(797, 788);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // ball
            // 
            this.ball.BackColor = System.Drawing.Color.White;
            this.ball.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ball.BackgroundImage")));
            this.ball.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ball.Location = new System.Drawing.Point(433, 70);
            this.ball.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ball.Name = "ball";
            this.ball.Size = new System.Drawing.Size(18, 17);
            this.ball.TabIndex = 1;
            this.ball.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // player
            // 
            this.player.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("player.BackgroundImage")));
            this.player.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.player.Location = new System.Drawing.Point(715, 168);
            this.player.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.player.Name = "player";
            this.player.Size = new System.Drawing.Size(18, 17);
            this.player.TabIndex = 2;
            this.player.TabStop = false;
            // 
            // score
            // 
            this.score.AutoSize = true;
            this.score.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.score.Location = new System.Drawing.Point(1191, 36);
            this.score.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.score.Name = "score";
            this.score.Size = new System.Drawing.Size(115, 39);
            this.score.TabIndex = 4;
            this.score.Text = "Score:";
            // 
            // scoreBox
            // 
            this.scoreBox.AutoSize = true;
            this.scoreBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.scoreBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.scoreBox.Location = new System.Drawing.Point(1224, 93);
            this.scoreBox.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.scoreBox.Name = "scoreBox";
            this.scoreBox.Size = new System.Drawing.Size(38, 41);
            this.scoreBox.TabIndex = 5;
            this.scoreBox.Text = "0";
            this.scoreBox.Click += new System.EventHandler(this.scoreBox_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1381, 1109);
            this.Controls.Add(this.scoreBox);
            this.Controls.Add(this.score);
            this.Controls.Add(this.player);
            this.Controls.Add(this.ball);
            this.Controls.Add(this.pictureBox1);
            this.Location = new System.Drawing.Point(15, 15);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Form1";
            this.Text = "New Ball Game";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ball)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.player)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label score;
        private System.Windows.Forms.Label scoreBox;
        public System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.PictureBox ball;
        public System.Windows.Forms.PictureBox player;
    }
}

