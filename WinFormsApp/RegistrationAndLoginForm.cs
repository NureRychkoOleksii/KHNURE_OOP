using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Core.Methods;
using Core.Models;
using WinFormsApp.Services;

namespace WinFormsApp
{
    public partial class RegistrationAndLoginForm : Form
    {
        private readonly UserService _userService = new UserService();
        private Thread _thread;
        private static User _user;
        public RegistrationAndLoginForm()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, System.EventArgs e)
        {
            _user = new User()
            {
                Name = textBox1.Text,
                Password = textBox2.Text,
                Record = "0",
                CoinsCount = 0
            };
            if (_userService.GetUserByName(textBox1.Text) != null)
            {
                _user.CoinsCount = _userService.GetUserByName(_user.Name).CoinsCount;
                _user.Id = _userService.GetUserByName(_user.Name).Id;
                this.Close();
                AddThread();
            }
            else
            {
                _userService.AddNewUser(_user);
                this.Close();
                AddThread();
            }
        }

        private void OpenNewForm()
        {
            Application.Run(new Instruction(_user));
        }

        private void AddThread()
        {
            _thread = new Thread(OpenNewForm);
            _thread.SetApartmentState(ApartmentState.STA);
            _thread.Start();
        }
    }
}
