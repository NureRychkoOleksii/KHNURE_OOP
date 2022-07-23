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
                Name = nameBox.Text,
                Password = passwordBox.Text,
                Record = "0",
                CoinsCount = 0,
                Skin = "default"
            };
            var user = _userService.GetUserByName(nameBox.Text);
            if(user == null)
            {
                _userService.AddNewUser(_user);
                this.Close();
                AddThread();
            }
            else if (user.Password == _user.Password)
            {
                _user.CoinsCount = _userService.GetUserByName(_user.Name).CoinsCount;
                _user.Id = _userService.GetUserByName(_user.Name).Id;
                _user.Skin = _userService.GetUserByName(_user.Name).Skin;
                this.Close();
                AddThread();
            }
            else
            {
                MessageBox.Show("Wrong password");
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
