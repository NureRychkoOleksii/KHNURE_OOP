using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp
{
    public class Music
    {
        public void Play()
        {
            var soundPlayer = new SoundPlayer("music.wav");
            soundPlayer.PlayLooping();
        }
    }
}
