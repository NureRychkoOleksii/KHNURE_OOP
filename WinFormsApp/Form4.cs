using System.Threading;
using System.Windows.Forms;
using WinFormsApp.Models;

namespace WinFormsApp
{
    public partial class Form4 : Form
    {
        private Thread _th;
        private readonly User _user;
        public Form4(User user)
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
            Application.Run(new Form1(_user));
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
    }
}
