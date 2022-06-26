using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp.Models
{
    internal class Items
    {
        public List<PictureBox> Walls { get; set; }

        public List<PictureBox> EnergyBalls { get; set; }

        public Items()
        {
            Walls = new List<PictureBox>();
            EnergyBalls = new List<PictureBox>();
        }

        public void CreateItems()
        {
            for(int i = 0;i<10;i++)
            {
                Walls.Add(new PictureBox()
                {
                    Name = $"wall{i + 1}",
                    Size = new Size(15, 15),
                    Location = new Point(new Random().Next(1, 660), new Random().Next(1, 660)),
                    BackColor = Color.Red
                });
                EnergyBalls.Add(new PictureBox()
                {
                    Name = $"energyBall{i + 1}",
                    Size = new Size(15, 15),
                    Location = new Point(new Random().Next(1, 660), new Random().Next(1, 660)),
                    BackColor = Color.Green
                });
            }
        }
    }
}
