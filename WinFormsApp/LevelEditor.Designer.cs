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
            ((System.ComponentModel.ISupportInitialize)(this.mapPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // playerButton
            // 
            this.playerButton.BackgroundImage = global::WinFormsApp.Properties.Resources.coin;
            this.playerButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.playerButton.Location = new System.Drawing.Point(996, 68);
            this.playerButton.Name = "playerButton";
            this.playerButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.playerButton.Size = new System.Drawing.Size(25, 22);
            this.playerButton.TabIndex = 0;
            this.playerButton.Tag = "coin";
            this.playerButton.UseVisualStyleBackColor = true;
            this.playerButton.Click += new System.EventHandler(this.buttonsClick);
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::WinFormsApp.Properties.Resources.slash;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Location = new System.Drawing.Point(1027, 68);
            this.button1.Name = "button1";
            this.button1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button1.Size = new System.Drawing.Size(25, 22);
            this.button1.TabIndex = 1;
            this.button1.Tag = "player";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.buttonsClick);
            // 
            // button2
            // 
            this.button2.BackgroundImage = global::WinFormsApp.Properties.Resources.wall;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.Location = new System.Drawing.Point(1058, 68);
            this.button2.Name = "button2";
            this.button2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button2.Size = new System.Drawing.Size(25, 22);
            this.button2.TabIndex = 2;
            this.button2.Tag = "wall";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.buttonsClick);
            // 
            // button4
            // 
            this.button4.BackgroundImage = global::WinFormsApp.Properties.Resources.Table_tennis_ball;
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button4.Location = new System.Drawing.Point(965, 68);
            this.button4.Name = "button4";
            this.button4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button4.Size = new System.Drawing.Size(25, 22);
            this.button4.TabIndex = 4;
            this.button4.Tag = "ball";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.buttonsClick);
            // 
            // button5
            // 
            this.button5.BackgroundImage = global::WinFormsApp.Properties.Resources.teleport;
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button5.Location = new System.Drawing.Point(1089, 68);
            this.button5.Name = "button5";
            this.button5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button5.Size = new System.Drawing.Size(25, 22);
            this.button5.TabIndex = 5;
            this.button5.Tag = "tp";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.buttonsClick);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(1006, 171);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(68, 23);
            this.button6.TabIndex = 9;
            this.button6.Text = "Create";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // mapPicture
            // 
            this.mapPicture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mapPicture.Location = new System.Drawing.Point(206, 68);
            this.mapPicture.Name = "mapPicture";
            this.mapPicture.Size = new System.Drawing.Size(356, 294);
            this.mapPicture.TabIndex = 10;
            this.mapPicture.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Aqua;
            this.pictureBox1.Location = new System.Drawing.Point(172, 29);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(750, 750);
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(27, 84);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(117, 23);
            this.nameTextBox.TabIndex = 12;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(41, 131);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(89, 23);
            this.saveButton.TabIndex = 13;
            this.saveButton.Text = "Save and Play";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // LevelEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1138, 851);
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
            this.Text = "LevelEditor";
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
    }
}