using Core.Methods;
using Core.Models;
using Core.NewModels;
using System;
using System.Linq;
using System.Windows.Forms;

namespace WinFormsApp
{
    public partial class ChooseMapForm : Form
    {
        private readonly MapService _mapService = new MapService();
        private Map _map;
        private User user;
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

            _map = _mapService.GetMaps().FirstOrDefault(x => x.Name == item.Text);
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form = new GameForm(user, _map);
            form.Show();
        }
    }
}
