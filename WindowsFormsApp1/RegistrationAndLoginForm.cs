using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using WindowsFormsApp1.Models;
using WindowsFormsApp1.Services;

namespace WindowsFormsApp1
{
    public partial class RegistrationAndLoginForm : Form
    {
        private readonly SerializationWorker _serializationWorker = new SerializationWorker();
        private List<User> _data = new List<User>();
        private readonly string _path = "..\\..\\Data\\Users.json";
        private Thread _th;
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
            if (GetByName(_path, textBox1.Text) != null)
            {
                this.Close();
                _th = new Thread(OpenNewForm);
                _th.SetApartmentState(ApartmentState.STA);
                _th.Start();
            }
            else
            {
                CreateObject(_user, _path);
                this.Close();
                _th = new Thread(OpenNewForm);
                _th.SetApartmentState(ApartmentState.STA);
                _th.Start();
            }
        }

        private void OpenNewForm()
        {
            Application.Run(new Form3(_user));
        }

        public IEnumerable<User> GetAll(string path)
        {
            return _serializationWorker.Deserialize<IEnumerable<User>>(path);
        }

        public User GetByName(string path, string name)
        {
            var res = GetAll(path);
            return res.Where(user => user.Name == name).FirstOrDefault();
        }

        public void CreateObject(User obj, string path)
        {
            _data = GetAll(path).ToList();
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
