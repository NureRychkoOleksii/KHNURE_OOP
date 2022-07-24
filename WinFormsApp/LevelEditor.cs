using Core.Methods;
using Core.NewModels;
using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.Linq;
using WinFormsApp.Services;

namespace WinFormsApp
{
    public partial class LevelEditor : Form
    {
        private Map map;
        private bool _playerExists = false;
        private bool _ballExists = false;
        private bool _coinsExist = false;
        private GraphicEngine _engine = new GraphicEngine();
        private Button clickedButton;
        private MapService _mapService = new MapService();
        private LevelEditorHelper helper = new LevelEditorHelper();

        public LevelEditor()
        {
            InitializeComponent();
            _engine.SetEditor(this);
            BaseElement.DrawElement += _engine.DrawLevelEditor;
            var items = _mapService.GetMaps();
            foreach (var i in items)
            {
                maps.Items.Add(i.Name);
            }
            map = new Map(50, 50);
            CreateMap();
            MakeClickEvent();
        }
        
        private void CreateMap()
        {
            map.CreateEmptyMap();
            map.UpdateMap();
            BaseElement.DrawElement -= _engine.DrawLevelEditor;
            BaseElement.DrawElement += _engine.Draw;
        }

        private void buttonsClick(object sender, EventArgs e)
        {
            if(sender is not Button button)
            {
                return;
            }


            var image = new Bitmap(button.BackgroundImage, 15, 15);

            Cursor = new Cursor(image.GetHicon());
            clickedButton = button;
        }

        private void MakeClickEvent()
        {
            foreach(var i in this.pictureBox1.Controls)
            {
                if(i is PictureBox picture)
                {
                    picture.Click += ClickEvent;
                }
            }
        }

        public void ClickEvent(object? sender, EventArgs e)
        {
            if(sender is not PictureBox picture)
            {
                return;
            }
            if(!clickedButton.Tag.Equals("clear"))
            {
                picture.BackgroundImage = clickedButton.BackgroundImage;
                picture.BackgroundImageLayout = ImageLayout.Stretch;
                map.map[picture.Location.X / 15, picture.Location.Y / 15] = helper.DetermineElement(picture.Location.X / 15, picture.Location.Y / 15, clickedButton, player, wall);
            }
            else
            {
                picture.BackgroundImage = null;
                map.map[picture.Location.X / 15, picture.Location.Y / 15] = new Empty(picture.Location.X / 15, picture.Location.Y / 15);
            }
           
            map.UpdateMap();
        }

        private void LoadMap()
        {
            foreach(var i in pictureBox1.Controls)
            {
                foreach(var item in map.map)
                {
                    if(i is PictureBox picture && item.X == picture.Location.X / 15 && item.Y == picture.Location.Y / 15)
                    {
                        picture.BackgroundImage = (Image)helper.DeterminePicture(item);
                        picture.BackgroundImageLayout = ImageLayout.Stretch;
                    }
                }
            }
            
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (mapsBox.Text == String.Empty)
            {
                MessageBox.Show("Enter name of map");
                return;
            }
            helper.DetermineKeyElements(ref _playerExists, ref _ballExists, ref _coinsExist, map);
            if(!(_playerExists && _ballExists && _coinsExist))
            {
                MessageBox.Show("You didn't create player, coin or ball, or each of them!");
                return;
            }
            map.Name = mapsBox.Text;
            if(_mapService.GetMaps().FirstOrDefault(_map => map.Name == _map.Name) != null)
            {
                _mapService.DeleteMap(map.Name);
            }
            _mapService.AddNewMap(map);
            this.Close();
        }

        private void maps_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(DialogResult.OK == MessageBox.Show("You didn't save your map, you sure you want to load another map?", "Alert", MessageBoxButtons.OKCancel))
            {
                var name = maps.HitTest(e.X, e.Y);

                var item = name.Item;
                var _map = _mapService.GetMaps().FirstOrDefault(x => x.Name == item.Text);
                map = _map;
                LoadMap();
            }
            else
            {
                return;
            }
        }
    }
}
