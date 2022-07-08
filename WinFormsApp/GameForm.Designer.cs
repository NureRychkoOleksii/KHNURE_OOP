namespace WinFormsApp
{
    partial class GameForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameForm));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.score = new System.Windows.Forms.Label();
            this.scoreBox = new System.Windows.Forms.Label();
            this.ball = new System.Windows.Forms.PictureBox();
            this.player = new System.Windows.Forms.PictureBox();
            this.pauseButton = new System.Windows.Forms.Button();
            this.Decrease = new System.Windows.Forms.Button();
            this.Add = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ball)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.player)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Aqua;
            this.pictureBox1.Location = new System.Drawing.Point(307, 12);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(797, 788);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
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
            // 
            // ball
            // 
            this.ball.Location = new System.Drawing.Point(0, 0);
            this.ball.Name = "ball";
            this.ball.Size = new System.Drawing.Size(0, 0);
            this.ball.TabIndex = 7;
            this.ball.TabStop = false;
            // 
            // player
            // 
            this.player.Location = new System.Drawing.Point(86, 184);
            this.player.Name = "player";
            this.player.Size = new System.Drawing.Size(1, 1);
            this.player.TabIndex = 6;
            this.player.TabStop = false;
            // 
            // pauseButton
            // 
            this.pauseButton.Location = new System.Drawing.Point(1189, 193);
            this.pauseButton.Name = "pauseButton";
            this.pauseButton.Size = new System.Drawing.Size(117, 55);
            this.pauseButton.TabIndex = 8;
            this.pauseButton.Text = "Pause/Play music";
            this.pauseButton.UseVisualStyleBackColor = true;
            this.pauseButton.Click += new System.EventHandler(this.pauseButton_Click);
            // 
            // Decrease
            // 
            this.Decrease.Location = new System.Drawing.Point(1191, 344);
            this.Decrease.Name = "Decrease";
            this.Decrease.Size = new System.Drawing.Size(115, 23);
            this.Decrease.TabIndex = 9;
            this.Decrease.Text = "Decrease volume";
            this.Decrease.UseVisualStyleBackColor = true;
            this.Decrease.Click += new System.EventHandler(this.Decrease_Click);
            // 
            // Add
            // 
            this.Add.Location = new System.Drawing.Point(1191, 315);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(115, 23);
            this.Add.TabIndex = 10;
            this.Add.Text = "Add volume";
            this.Add.UseVisualStyleBackColor = true;
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1381, 1109);
            this.Controls.Add(this.Add);
            this.Controls.Add(this.Decrease);
            this.Controls.Add(this.pauseButton);
            this.Controls.Add(this.ball);
            this.Controls.Add(this.player);
            this.Controls.Add(this.scoreBox);
            this.Controls.Add(this.score);
            this.Controls.Add(this.pictureBox1);
            this.Location = new System.Drawing.Point(15, 15);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "GameForm";
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
        public System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox ball;
        private System.Windows.Forms.PictureBox player;
        public System.Windows.Forms.Label scoreBox;
        private System.Windows.Forms.Button pauseButton;
        private System.Windows.Forms.Button Decrease;
        private System.Windows.Forms.Button Add;
    }
}

