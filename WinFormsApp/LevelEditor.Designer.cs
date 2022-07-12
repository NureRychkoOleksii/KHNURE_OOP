namespace WinFormsApp
{
    partial class LevelEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LevelEditor));
            this.playerButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.mapPicture = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.mapPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // playerButton
            // 
            this.playerButton.BackgroundImage = global::WinFormsApp.Properties.Resources.coin;
            resources.ApplyResources(this.playerButton, "playerButton");
            this.playerButton.Name = "playerButton";
            this.playerButton.Tag = "coin";
            this.playerButton.UseVisualStyleBackColor = true;
            this.playerButton.Click += new System.EventHandler(this.buttonsClick);
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::WinFormsApp.Properties.Resources.slash;
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.Tag = "player";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.buttonsClick);
            // 
            // button2
            // 
            this.button2.BackgroundImage = global::WinFormsApp.Properties.Resources.wall;
            resources.ApplyResources(this.button2, "button2");
            this.button2.Name = "button2";
            this.button2.Tag = "wall";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.buttonsClick);
            // 
            // button4
            // 
            this.button4.BackgroundImage = global::WinFormsApp.Properties.Resources.Table_tennis_ball;
            resources.ApplyResources(this.button4, "button4");
            this.button4.Name = "button4";
            this.button4.Tag = "ball";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.buttonsClick);
            // 
            // button5
            // 
            this.button5.BackgroundImage = global::WinFormsApp.Properties.Resources.teleport;
            resources.ApplyResources(this.button5, "button5");
            this.button5.Name = "button5";
            this.button5.Tag = "tp";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.buttonsClick);
            // 
            // button6
            // 
            resources.ApplyResources(this.button6, "button6");
            this.button6.Name = "button6";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // mapPicture
            // 
            this.mapPicture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.mapPicture, "mapPicture");
            this.mapPicture.Name = "mapPicture";
            this.mapPicture.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Aqua;
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // nameTextBox
            // 
            resources.ApplyResources(this.nameTextBox, "nameTextBox");
            this.nameTextBox.Name = "nameTextBox";
            // 
            // saveButton
            // 
            resources.ApplyResources(this.saveButton, "saveButton");
            this.saveButton.Name = "saveButton";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // button3
            // 
            this.button3.BackgroundImage = global::WinFormsApp.Properties.Resources.lastik_dlya_karandashey_chernil_koh_noor_bluestar_6521_0;
            resources.ApplyResources(this.button3, "button3");
            this.button3.Name = "button3";
            this.button3.Tag = "clear";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.buttonsClick);
            // 
            // LevelEditor
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button3);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.mapPicture);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.playerButton);
            this.Name = "LevelEditor";
            ((System.ComponentModel.ISupportInitialize)(this.mapPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button playerButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.PictureBox mapPicture;
        public System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button button3;
    }
}