using Core.NewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp
{
    public partial class LevelEditor : Form
    {
        private Map map;
        private GraphicEngine _engine = new GraphicEngine();
        private Button clickedButton;

        public LevelEditor()
        {
            InitializeComponent();
            _engine.SetEditor(this);
            BaseElement.DrawElement += _engine.DrawLevelEditor;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            map = new Map(50, 50);
            CreateMap(50,50);
            MakeClickEvent();
        }
        
        private void CreateMap(int x, int y)
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
            picture.BackgroundImage = clickedButton.BackgroundImage;
            picture.BackgroundImageLayout = ImageLayout.Stretch;
            map[picture.Location.X / 15, picture.Location.Y / 15] = DetermineElement(picture.Location.X / 15, picture.Location.Y / 15);
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

            return res;
        }
    }
}
