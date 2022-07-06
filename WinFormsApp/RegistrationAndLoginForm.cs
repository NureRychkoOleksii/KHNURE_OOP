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
        private List<User> _data = new List<User>();
        private readonly string _path = "..\\..\\..\\Data\\Users.json";
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
                Record = "0"
            };
            if (_userService.GetUserByName(_path, textBox1.Text) != null)
            {
                this.Close();
                AddThread();
            }
            else
            {
                _userService.AddUser(_user);
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
