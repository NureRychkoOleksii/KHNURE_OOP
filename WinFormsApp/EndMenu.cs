using System.Threading;
using System.Windows.Forms;
using Core.Models;

namespace WinFormsApp
{
    public partial class EndMenu : Form
    {
        private Thread _th;
        private readonly User _user;
        public EndMenu(User user)
        {
            _user = user;
            InitializeComponent();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            this.Close();
            _th = new Thread(OpenNewForm);
            _th.SetApartmentState(ApartmentState.STA);
            _th.Start();
        }

        private void OpenNewForm()
        {
            Application.Run(new GameForm(_user));
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
    }
}
