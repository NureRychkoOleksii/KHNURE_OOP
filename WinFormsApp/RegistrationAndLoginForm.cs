using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Core.Models;
using WinFormsApp.Services;

namespace WinFormsApp
{
    public partial class RegistrationAndLoginForm : Form
    {
        private readonly SerializationWorker _serializationWorker = new SerializationWorker();
        private List<User> _data = new List<User>();
        private readonly string _path = "..\\..\\..\\Data\\Users.json";
        private Thread _thread;
        private static User _user;
        public RegistrationAndLoginForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            _user = new User()
            {
                Name = textBox1.Text,
                Password = textBox2.Text,
                Record = "0"
            };
            if (GetUserByName(_path, textBox1.Text) != null)
            {
                this.Close();
                _thread = new Thread(OpenNewForm);
                _thread.SetApartmentState(ApartmentState.STA);
                _thread.Start();
            }
            else
            {
                CreateObject(_user, _path);
                this.Close();
                _thread = new Thread(OpenNewForm);
                _thread.SetApartmentState(ApartmentState.STA);
                _thread.Start();
            }
        }

        private void OpenNewForm()
        {
            Application.Run(new Instruction(_user));
        }

        public IEnumerable<User> GetAllUsers(string path)
        {
            return _serializationWorker.Deserialize<IEnumerable<User>>(path);
        }

        public User GetUserByName(string path, string name)
        {
            var res = GetAllUsers(path);
            return res.Where(user => user.Name == name).FirstOrDefault();
        }

        public void CreateObject(User obj, string path)
        {
            _data = GetAllUsers(path).ToList();
            _data.Add(obj);
            _serializationWorker.Serialize<IEnumerable<User>>(_data, path);
        }

        public void DeleteObject(User obj, string path)
        {
            _data = _serializationWorker.Deserialize<IEnumerable<User>>(path).ToList();
            _data.RemoveAll(x => x.Name == obj.Name);
            _serializationWorker.Serialize<IEnumerable<User>>(_data, path);
        }
    }
}
