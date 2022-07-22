using Core.Methods;
using Core.NewModels;
using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.Linq;

namespace WinFormsApp
{
    public partial class LevelEditor : Form
    {
        private Map map;
        private bool playerExists = false;
        private bool ballExists = false;
        private GraphicEngine _engine = new GraphicEngine();
        private Button clickedButton;
        private MapService _mapService = new MapService();

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
        }

        private void createMapButton_Click(object sender, EventArgs e)
        {
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
            createMapButton.Enabled = false;
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
                map.map[picture.Location.X / 15, picture.Location.Y / 15] = DetermineElement(picture.Location.X / 15, picture.Location.Y / 15);
            }
            else
            {
                picture.BackgroundImage = null;
                map.map[picture.Location.X / 15, picture.Location.Y / 15] = new Empty(picture.Location.X / 15, picture.Location.Y / 15);
            }
           
            map.UpdateMap();
        }

        private void CheckMap()
        {
            foreach(var i in pictureBox1.Controls)
            {
                foreach(var item in map.map)
                {
                    if(i is PictureBox picture && item.X == picture.Location.X / 15 && item.Y == picture.Location.Y / 15)
                    {
                        picture.BackgroundImage = (Image)DeterminePicture(item);
                        picture.BackgroundImageLayout = ImageLayout.Stretch;
                    }
                }
            }
            
        }

        private BaseElement DetermineElement(int x, int y)
        {
            BaseElement res = clickedButton.Tag switch
            {
                "coin" => new EnergyBall(x, y),
                "player" => new Player(x, y),
                "wall" => new Wall(x, y),
                "ball" => new Ball(x, y),
                "tp" => new Teleport(x,y),
                _ => new Empty(x,y)
            };
            if(res is Player)
            {
                player.Enabled = false;
            }
            if(res is Ball)
            {
                ball.Enabled = false;   
            }
            playerExists = res is Player ? true : playerExists;
            ballExists = res is Ball ? true : playerExists;

            return res;
        }

        private void DetermineKeyElements()
        {
            foreach(var item in map.map)
            {
                if(item is Player)
                {
                    playerExists = true;
                }    
                if(item is Ball)
                {
                    ballExists = true;
                }
            }
        }

        private Bitmap DeterminePicture(BaseElement picture)
        {
            var image = picture switch
            {
                Player => ((Player)picture).reverseSlash ? Properties.Resources.reverseSlash : Properties.Resources.slash,
                Wall => Properties.Resources.wall,
                Ball => Properties.Resources.Table_tennis_ball,
                EnergyBall => Properties.Resources.coin,
                Teleport => Properties.Resources.teleport,
                _ => null
            };

            return image;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            DetermineKeyElements();
            if(!(playerExists && ballExists))
            {
                MessageBox.Show("You didn't create player or ball, or each of them!");
                return;
            }
            map.Name = mapsBox.Text;
            if(_mapService.GetMaps().FirstOrDefault(map => map.Name == map.Name) != null)
            {
                _mapService.DeleteMap(map.Name);
            }
            _mapService.AddNewMap(map);
            this.Close();
        }

        private void maps_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var name = maps.HitTest(e.X, e.Y);

            var item = name.Item;
            var _map = _mapService.GetMaps().FirstOrDefault(x => x.Name == item.Text);
            map = _map;
            CheckMap();
        }
    }
}
