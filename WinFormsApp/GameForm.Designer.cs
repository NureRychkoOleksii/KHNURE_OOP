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
            this.label1 = new System.Windows.Forms.Label();
            this.pause = new System.Windows.Forms.Label();
            this.add = new System.Windows.Forms.Label();
            this.decrease = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ball)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.player)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.BackColor = System.Drawing.Color.Aqua;
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // score
            // 
            resources.ApplyResources(this.score, "score");
            this.score.Name = "score";
            // 
            // scoreBox
            // 
            resources.ApplyResources(this.scoreBox, "scoreBox");
            this.scoreBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.scoreBox.Name = "scoreBox";
            // 
            // ball
            // 
            resources.ApplyResources(this.ball, "ball");
            this.ball.Name = "ball";
            this.ball.TabStop = false;
            // 
            // player
            // 
            resources.ApplyResources(this.player, "player");
            this.player.Name = "player";
            this.player.TabStop = false;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // pause
            // 
            resources.ApplyResources(this.pause, "pause");
            this.pause.Name = "pause";
            this.pause.Click += new System.EventHandler(this.label2_Click);
            // 
            // add
            // 
            resources.ApplyResources(this.add, "add");
            this.add.Name = "add";
            this.add.Click += new System.EventHandler(this.label3_Click);
            // 
            // decrease
            // 
            resources.ApplyResources(this.decrease, "decrease");
            this.decrease.Name = "decrease";
            this.decrease.Click += new System.EventHandler(this.label4_Click);
            // 
            // GameForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.decrease);
            this.Controls.Add(this.add);
            this.Controls.Add(this.pause);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ball);
            this.Controls.Add(this.player);
            this.Controls.Add(this.scoreBox);
            this.Controls.Add(this.score);
            this.Controls.Add(this.pictureBox1);
            this.Name = "GameForm";
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label pause;
        private System.Windows.Forms.Label add;
        private System.Windows.Forms.Label decrease;
    }
}

