using Core.Methods;
using Core.Models;
using Core.NewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp
{
    public partial class ChooseMapForm : Form
    {
        private readonly MapService _mapService = new MapService();
        private Map _map;
        private User user;
        private Thread _thread;
        public ChooseMapForm(User _user)
        {
            user = _user;
            InitializeComponent();
            AddItems();
        }

        private void AddItems()
        {
            var items = _mapService.GetMaps();
            foreach(var i in items)
            {
                listView.Items.Add(i.Name);
            }
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var name = listView.HitTest(e.X, e.Y);

            var item = name.Item;
            if(listView == null || item is null)
            {
                return;
            }

            var map = _mapService.GetMaps().FirstOrDefault(x => x.Name == item.Text);
            _map = map;

        }

        private void startButton_Click(object sender, EventArgs e)
        {
                this.Close();
                _thread = new Thread(OpenNewForm);
                _thread.SetApartmentState(ApartmentState.STA);
                _thread.Start();
        }

        private void OpenNewForm()
        {
            Application.Run(new GameForm(user, _map));
        }
    }
}
