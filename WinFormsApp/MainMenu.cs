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
            _thread = new Thread(OpenNewForm1);
            _thread.SetApartmentState(ApartmentState.STA);
            _thread.Start();
        }

        private void OpenNewForm1(object obj)
        {
            Application.Run(new RegistrationAndLoginForm());
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
