using WMPLib;

namespace WinFormsApp
{
    public class Music
    {
        private bool isPlaying = false;

        WindowsMediaPlayer player = new WindowsMediaPlayer();
        public void Play()
        {
            player.URL = "music.wav";
            player.controls.play();
            isPlaying = true;
        }

        public void ChangeVolume(int value)
        {
            player.settings.volume += value;
        }

        public void Pause()
        {
            if(isPlaying)
            {
                player.controls.pause();
            }
            else
            {
                player.controls.play();
            }

            isPlaying = !isPlaying;
        }
    }
}
