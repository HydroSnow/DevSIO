using System.IO;
using System.Media;

namespace gandalf
{
    class BeepBeep // i'm a sheep
    {
        static SoundPlayer snd;

        public static void Load()
        {
            Stream sio = Properties.Resources.epicsaxguy;
            snd = new SoundPlayer(sio);
        }

        public static void On()
        {
            snd.PlayLooping();
        }

        public static void Off()
        {
            snd.Stop();
        }
    }
}
