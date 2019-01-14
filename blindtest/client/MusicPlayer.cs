using System.IO;
using NAudio.Wave;
using System.Threading;

namespace BlindTest.client
{
    class MusicPlayer
    {
        public static void PlayMusicAsync(byte[] music)
        {
            Thread thread = new Thread(() => PlayMusic(music));
            thread.Start();
        }

        public static void PlayMusic(byte[] music)
        {
            using (MemoryStream ms = new MemoryStream(music))
            using (Mp3FileReader reader = new Mp3FileReader(ms))
            using (WaveOut waveOut = new WaveOut())
            {
                waveOut.Init(reader);
                waveOut.Play();
                while (waveOut.PlaybackState != PlaybackState.Stopped)
                {
                    Thread.Sleep(500);
                }
            }
        }
    }
}
