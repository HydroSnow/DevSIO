using System;
using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace gandalf
{
    static class Program
    {
        static void Main()
        {
            bool shown = false;
            WebClient client = new WebClient();
            Random random = new Random();

            BeepBeep.Load();

            while (true)
            {
                try
                {
                    Thread.Sleep(random.Next() % 3000 + 1000);
                    
                    String str = client.DownloadString("https://sk.harion.fr/gandalf.txt?id=" + random.Next());

                    if (str == "1")
                    {
                        if (!shown)
                        {
                            Form1 form = new Form1();
                            Thread thread = new Thread(() => Application.Run(form));
                            thread.Start();
                            shown = true;
                        }
                    }
                    else
                    {
                        shown = false;
                    }
                }
                catch (Exception)
                {
                }
            }
        }
    }
}
