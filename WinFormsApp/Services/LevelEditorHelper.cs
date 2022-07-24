using Core.NewModels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp.Services
{
    public class LevelEditorHelper
    {
        public BaseElement DetermineElement(int x, int y, Button clickedButton, Button player, Button ball)
        {
            BaseElement res = clickedButton.Tag switch
            {
                "coin" => new EnergyBall(x, y),
                "player" => new Player(x, y),
                "wall" => new Wall(x, y),
                "ball" => new Ball(x, y),
                "tp" => new Teleport(x, y),
                _ => new Empty(x, y)
            };
            if (res is Player)
            {
                player.Enabled = false;
            }
            if (res is Ball)
            {
                ball.Enabled = false;
            }

            return res;
        }
        public void DetermineKeyElements(ref bool _playerExists, ref bool _ballExists, ref bool _coinsExist, Map map)
        {
            foreach (var item in map.map)
            {
                if (item is Player)
                {
                    _playerExists = true;
                }
                if (item is Ball)
                {
                    _ballExists = true;
                }
                if (item is EnergyBall)
                {
                    _coinsExist = true;
                }
            }
        }

        public Bitmap DeterminePicture(BaseElement picture)
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
    }
}
