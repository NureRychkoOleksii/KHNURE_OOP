using System.Threading;
using System.Windows.Forms;
using Core.Models;

namespace WinFormsApp
{
    public partial class EndMenu : Form
    {
        private readonly User _user;
        public EndMenu(User user)
        {
            _user = user;
            InitializeComponent();
        }

        private void restartButton_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            var form = new GameForm(_user);
            form.Show();
        }


        private void exitButton_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
    }
}
