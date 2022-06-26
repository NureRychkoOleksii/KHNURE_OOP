using Core.NewModels;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp
{
    public class GraphicEngine
    {
        private Form1 _form { get; set; }

        public GraphicEngine(Form1 form)
        {
            _form = form;
        }

        public void Draw(object? sender, EventArgs e)
        {
            if (sender is not BaseElement pixel)
            {
                return;
            }

            var rand = new Random();

            var image = pixel switch
            {
                Player => ((Player)pixel).reverseSlash ? Properties.Resources.reverseSlash: Properties.Resources.slash,
                Wall => Properties.Resources.wall,
                Ball => Properties.Resources.Table_tennis_ball,
                _ => null
            };

            var picture = new PictureBox() {
                Name = pixel switch
                {
                    Player => "player",
                    Wall => "wall",
                    Ball => "ball",
                    _ => "empty"
                },
                Size = new Size(15, 15),
                Location = new Point(_form.pictureBox1.Location.X + rand.Next(1, 44) * 15, _form.pictureBox1.Location.Y + rand.Next(1, 44) * 15),
                BackgroundImage = image
            };

            _form.Controls.Add(picture);
            picture.BringToFront();
        }
    }
}
