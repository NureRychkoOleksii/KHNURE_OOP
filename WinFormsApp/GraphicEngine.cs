using Core.NewModels;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace WinFormsApp
{
    public class GraphicEngine
    {
        private GameForm _form { get; set; }

        private LevelEditor _editor { get; set; }

        public PictureBox playerPicturebox { get; set; }
        
        public PictureBox ballPictureBox { get; set; }

        public GraphicEngine(GameForm form)
        {
            _form = form;
        }
        public GraphicEngine()
        {
            
        }

        public void SetEditor(LevelEditor form)
        {
            _editor = form;
        }

        public void Draw(object? sender, EventArgs e)
        {
            if (sender is not BaseElement pixel || pixel is Empty || (sender is Player && playerPicturebox != null) || (sender is Ball && ballPictureBox != null))
            {
                return;
            }

            var image = pixel switch
                {
                    Player => ((Player)pixel).reverseSlash ? Properties.Resources.reverseSlash : Properties.Resources.slash,
                    Wall => Properties.Resources.wall,
                    Ball => Properties.Resources.Table_tennis_ball,
                    EnergyBall => Properties.Resources.coin,
                    Teleport => Properties.Resources.teleport,
                    _ => null
                };


            var picture = new PictureBox() {
                Size = new Size(15, 15),
                Location = new Point(pixel.X * 15, pixel.Y * 15),
                BackgroundImage = image,
                BackgroundImageLayout = ImageLayout.Stretch
            };

            if (sender is Player)
            {
                playerPicturebox = picture;
                picture.BackgroundImageLayout = ImageLayout.Stretch;
            }

            if (sender is Ball)
            {
                ballPictureBox = picture;
                picture.BackgroundImageLayout = ImageLayout.Stretch;
            }
            if(_form is null)
            {
                _editor.pictureBox1.Controls.Add(picture);
                return;
            }
            _form.pictureBox1.Controls.Add(picture);
        }

        public void DrawLevelEditor(object? sender, EventArgs e)
        {
            if (sender is not BaseElement pixel)
            {
                return;
            }
            var picture = new PictureBox() {
                Size = new Size(15, 15),
                Location = new Point(pixel.X * 15, pixel.Y * 15),
                BackColor = Color.Aqua,
                BorderStyle = BorderStyle.FixedSingle
            };
            _editor.pictureBox1.Controls.Add(picture);
        }

        public void Clear(object? sender, EventArgs e)
        {
            if (sender is not BaseElement pixel || pixel is Empty)
            {
                return;
            }

            foreach(var i in _form.pictureBox1.Controls)
            {
                if(i is PictureBox item)
                {
                    if(item.Location.X == pixel.X * 15 && item.Location.Y == pixel.Y * 15)
                    {
                        _form.pictureBox1.Controls.Remove(item);
                    }
                }
            }
        }
    }
}
