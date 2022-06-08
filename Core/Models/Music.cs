using System.Media;

namespace Core.Models
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
