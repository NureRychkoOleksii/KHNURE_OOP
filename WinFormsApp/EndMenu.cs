using System.Threading;
using System.Windows.Forms;
using Core.Models;

namespace WinFormsApp
{
    public partial class EndMenu : Form
    {
        private Thread _thread;
        private readonly User _user;
        public EndMenu(User user)
        {
            _user = user;
            InitializeComponent();
        }

        private void restartButton_Click(object sender, System.EventArgs e)
        {
            this.Close();
            _thread = new Thread(OpenNewForm);
            _thread.SetApartmentState(ApartmentState.STA);
            _thread.Start();
        }

        private void OpenNewForm()
        {
            Application.Run(new GameForm(_user));
        }

        private void exitButton_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
    }
}
