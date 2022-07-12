using System;
using System.Threading;
using System.Windows.Forms;

namespace WinFormsApp
{
    public partial class MainMenu : Form
    {
        Thread _thread;
        public MainMenu()
        {
            InitializeComponent();
            textBox.Enabled = false;
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            this.Close();
            _thread = new Thread(OpenLogin);
            _thread.SetApartmentState(ApartmentState.STA);
            _thread.Start();
        }

        private void OpenLogin(object obj)
        {
            Application.Run(new RegistrationAndLoginForm());
        }
        private void OpenEditor(object obj)
        {
            Application.Run(new LevelEditor());
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void editorButton_Click(object sender, EventArgs e)
        {
            this.Close();
            _thread = new Thread(OpenEditor);
            _thread.SetApartmentState(ApartmentState.STA);
            _thread.Start();
        }

        private void engButton_Click(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("uk-UA");
            this.Controls.Clear();
            this.InitializeComponent();
        }

        private void uaButton_Click(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
            this.Controls.Clear();
            this.InitializeComponent();
        }
    }
}
