using System.Media;

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
