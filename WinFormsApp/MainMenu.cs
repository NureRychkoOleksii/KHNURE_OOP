using System;
using System.Threading;
using System.Windows.Forms;

namespace WinFormsApp
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
            textBox.Enabled = false;
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form = new RegistrationAndLoginForm();
            form.Show();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void editorButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form = new LevelEditor();
            form.Show();
        }

        private void engButton_Click(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
            this.Controls.Clear();
            this.InitializeComponent();
        }

        private void uaButton_Click(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("uk-UA");
            this.Controls.Clear();
            this.InitializeComponent();
        }
    }
}
