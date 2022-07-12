using Core.Methods;
using Core.NewModels;
using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

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

        private BaseElement DetermineElement(int x, int y)
        {
            BaseElement res = clickedButton.Tag switch
            {
                "coin" => new EnergyBall(x, y),
                "player" => new Player(x, y),
                "wall" => new Wall(x, y),
                "ball" => new Ball(x, y),
                _ => new Empty(x,y)
            };
            playerExists = res is Player ? true : playerExists;
            ballExists = res is Ball ? true : playerExists;

            return res;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if(!(playerExists && ballExists))
            {
                MessageBox.Show("You didn't create player or ball, or each of them!");
                return;
            }
            map.Name = mapsBox.Text;
            _mapService.AddNewMap(map);
            this.Close();
        }
    }
}
