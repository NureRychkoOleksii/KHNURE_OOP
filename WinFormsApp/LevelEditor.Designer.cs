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
            this.coin = new System.Windows.Forms.Button();
            this.player = new System.Windows.Forms.Button();
            this.wall = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.tp = new System.Windows.Forms.Button();
            this.createMapButton = new System.Windows.Forms.Button();
            this.mapPicture = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.mapsBox = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.clear = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.mapPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // coin
            // 
            resources.ApplyResources(this.coin, "coin");
            this.coin.BackgroundImage = global::WinFormsApp.Properties.Resources.coin;
            this.coin.Name = "coin";
            this.coin.Tag = "coin";
            this.coin.UseVisualStyleBackColor = true;
            this.coin.Click += new System.EventHandler(this.buttonsClick);
            // 
            // player
            // 
            resources.ApplyResources(this.player, "player");
            this.player.BackgroundImage = global::WinFormsApp.Properties.Resources.slash;
            this.player.Name = "player";
            this.player.Tag = "player";
            this.player.UseVisualStyleBackColor = true;
            this.player.Click += new System.EventHandler(this.buttonsClick);
            // 
            // wall
            // 
            resources.ApplyResources(this.wall, "wall");
            this.wall.BackgroundImage = global::WinFormsApp.Properties.Resources.wall;
            this.wall.Name = "wall";
            this.wall.Tag = "wall";
            this.wall.UseVisualStyleBackColor = true;
            this.wall.Click += new System.EventHandler(this.buttonsClick);
            // 
            // button4
            // 
            resources.ApplyResources(this.button4, "button4");
            this.button4.BackgroundImage = global::WinFormsApp.Properties.Resources.Table_tennis_ball;
            this.button4.Name = "button4";
            this.button4.Tag = "ball";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.buttonsClick);
            // 
            // tp
            // 
            resources.ApplyResources(this.tp, "tp");
            this.tp.BackgroundImage = global::WinFormsApp.Properties.Resources.teleport;
            this.tp.Name = "tp";
            this.tp.Tag = "tp";
            this.tp.UseVisualStyleBackColor = true;
            this.tp.Click += new System.EventHandler(this.buttonsClick);
            // 
            // createMapButton
            // 
            resources.ApplyResources(this.createMapButton, "createMapButton");
            this.createMapButton.Name = "createMapButton";
            this.createMapButton.UseVisualStyleBackColor = true;
            this.createMapButton.Click += new System.EventHandler(this.createMapButton_Click);
            // 
            // mapPicture
            // 
            resources.ApplyResources(this.mapPicture, "mapPicture");
            this.mapPicture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mapPicture.Name = "mapPicture";
            this.mapPicture.TabStop = false;
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.BackColor = System.Drawing.Color.Aqua;
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // mapsBox
            // 
            resources.ApplyResources(this.mapsBox, "mapsBox");
            this.mapsBox.Name = "mapsBox";
            // 
            // saveButton
            // 
            resources.ApplyResources(this.saveButton, "saveButton");
            this.saveButton.Name = "saveButton";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // clear
            // 
            resources.ApplyResources(this.clear, "clear");
            this.clear.BackgroundImage = global::WinFormsApp.Properties.Resources.lastik_dlya_karandashey_chernil_koh_noor_bluestar_6521_0;
            this.clear.Name = "clear";
            this.clear.Tag = "clear";
            this.clear.UseVisualStyleBackColor = true;
            this.clear.Click += new System.EventHandler(this.buttonsClick);
            // 
            // LevelEditor
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.clear);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.mapsBox);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.mapPicture);
            this.Controls.Add(this.createMapButton);
            this.Controls.Add(this.tp);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.wall);
            this.Controls.Add(this.player);
            this.Controls.Add(this.coin);
            this.Name = "LevelEditor";
            ((System.ComponentModel.ISupportInitialize)(this.mapPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button coin;
        private System.Windows.Forms.Button player;
        private System.Windows.Forms.Button wall;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button tp;
        private System.Windows.Forms.Button createMapButton;
        private System.Windows.Forms.PictureBox mapPicture;
        public System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox mapsBox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button clear;
    }
}