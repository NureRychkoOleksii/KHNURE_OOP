using Core.NewModels;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace WinFormsApp
{
    public class GraphicEngine
    {
        private Form1 _form { get; set; }

        public PictureBox playerPicturebox { get; set; }
        
        public PictureBox ballPictureBox { get; set; }

        public GraphicEngine(Form1 form)
        {
            _form = form;
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
                    EnergyBall => Properties.Resources.energyBall,
                    _ => null
                };


            var picture = new PictureBox() {
                Size = new Size(15, 15),
                //Parent = _form.pictureBox1,
                Location = new Point(pixel.X * 15, pixel.Y * 15),
                BackgroundImage = image
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
            _form.pictureBox1.Controls.Add(picture);
            picture.BringToFront();
        }

        public void Clear(object? sender, EventArgs e)
        {
            if (sender is not BaseElement pixel || pixel is Empty)
            {
                return;
            }

            foreach(var i in _form.Controls)
            {
                if(i is PictureBox item)
                {
                    if(item.Location.X == pixel.X * 15 && item.Location.Y == pixel.Y * 15)
                    {
                        _form.Controls.Remove(item);
                    }
                }
            }
        }
    }
}
