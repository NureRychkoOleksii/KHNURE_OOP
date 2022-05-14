using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace Lab1Rychko.Models
{
    class Music
    {
        public void Play()
        {
            var soundPlayer = new SoundPlayer("music.wav");
            soundPlayer.PlayLooping();
        }
    }
}
