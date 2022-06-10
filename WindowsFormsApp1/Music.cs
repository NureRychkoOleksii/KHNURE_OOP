using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Music
    {
        public void Play()
        {
            var soundPlayer = new SoundPlayer(@"..\\..\\..\\BLL\\music\\music.wav");
            soundPlayer.PlayLooping();
        }
    }
}
