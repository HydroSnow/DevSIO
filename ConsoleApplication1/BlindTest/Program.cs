using System;
using System.IO;
using System.Media;
using System.Threading;

namespace BlindTest
{
    class Program
    {
        private static int score = 0;
        private static int total = 0;
        private static bool done = false;
        private static String[] files =
        {
            "abeille.wav",
            "despacito.wav",
            "frog.wav",
            "lion.wav",
            "genie.wav",
            "nullos.wav"
        };
        private static MemoryStream[] musics;
        private static SoundPlayer snd;

        public static void Animation()
        {
            try {
                Console.Clear();
                Console.Write("\n");
                for (int a = 0; ; a++)
                {
                    Console.Write("\r Chargement...");
                    switch (a % 8)
                    {
                        case 0:
                            Console.Write(" [O----]");
                            break;
                        case 1:
                            Console.Write(" [-O---]");
                            break;
                        case 2:
                            Console.Write(" [--O--]");
                            break;
                        case 3:
                            Console.Write(" [---O-]");
                            break;
                        case 4:
                            Console.Write(" [----O]");
                            break;
                        case 5:
                            Console.Write(" [---O-]");
                            break;
                        case 6:
                            Console.Write(" [--O--]");
                            break;
                        case 7:
                            Console.Write(" [-O---]");
                            break;
                    }
                    Thread.Sleep(100);
                }
            } catch (Exception)
            {}
        }

        static void Main(string[] args)
        {
            Thread anim = new Thread(Animation);
            anim.Start();

            musics = new MemoryStream[files.Length];

            bool all = true;

            for (int a = 0; a < files.Length; a++)
            {
                String path = files[a];
                try
                {
                    MemoryStream str = new MemoryStream();
                    using (FileStream fs = File.OpenRead(path))
                    {
                        fs.CopyTo(str);
                    }
                    musics[a] = str;
                }
                catch (Exception)
                {
                    all = false;
                    musics[a] = null;
                }
            }
            
            anim.Interrupt();

            if (!all)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.Clear();
                Console.WriteLine("Des musiques manquent ! Des questions seront peut-être ignorées.");
                spacewait();
            }

            snd = new SoundPlayer();
            
            Console.Title = "Blind Test de Monsieur Trupin";
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.Clear();

            bool loop = true;
            while (loop)
            {
                Console.Write(
                    "Que voulez-vous faire ?"
                    + "\n 1 - Faire le test"
                    + "\n 2 - Voir son score"
                    + "\n 3 - Quitter le programme"
                    + "\n> "
                );
                String inp = Console.ReadLine();
                Console.Clear();

                switch (inp)
                {
                    case "1":
                        test();
                        note();
                        break;
                    case "2":
                        note();
                        break;
                    case "3":
                        loop = false;
                        break;
                    default:
                        break;
                }
            }
            
            Console.WriteLine("Au revoir !");
            spacewait();
        }

        private static void spacewait()
        {
            Console.WriteLine("\nAppuyez sur Espace pour continuer.");
            while (true)
            {
                var t = Console.ReadKey(true);
                if (t.Key == ConsoleKey.Spacebar)
                {
                    return;
                }
            }
        }
        
        private static void test()
        {
            bool loop;

            do
            {
                MemoryStream ms = musics[0];

                if (ms == null)
                {
                    break;
                }

                Console.Write(
                    "Question 1 : De quel générique provient cette musique ?"
                    + "\n a - Inspecteur Gadget"
                    + "\n b - Maia l'abeille"
                    + "\n c - Game of Thrones"
                    + "\n> "
                );

                ms.Position = 0;
                snd.Stream = ms;
                snd.PlayLooping();

                String str = Console.ReadLine();

                switch (str.ToLower())
                {
                    case "a":
                        Console.WriteLine(
                            "Mauvaise réponse !"
                            + "\n La bonne réponse était :"
                            + "\n Maia l'abeille"
                        );
                        total++;
                        loop = false;
                        break;

                    case "b":
                        Console.WriteLine(
                            "Bonne réponse !"
                            + "\n La bonne réponse était :"
                            + "\n Maia l'abeille"
                        );
                        score++;
                        total++;
                        loop = false;
                        break;

                    case "c":
                        Console.WriteLine(
                            "Mauvaise réponse !"
                            + "\n La bonne réponse était :"
                            + "\n Maia l'abeille"
                        );
                        total++;
                        loop = false;
                        break;

                    default:
                        Console.WriteLine("Vous avez mal répondu...");
                        loop = true;
                        break;
                }
            } while (loop);

            spacewait();
            Console.Clear();
            snd.Stop();

            do
            {
                MemoryStream ms = musics[1];

                if (ms == null)
                {
                    break;
                }

                Console.Write(
                    "Question 2 : Quel est l'auteur de cette musique ?"
                    + "\n a - Luis Fonsi"
                    + "\n b - Paul Trémouille"
                    + "\n c - Jul"
                    + "\n> "
                );
                
                ms.Position = 0;
                snd.Stream = ms;
                snd.PlayLooping();

                String str = Console.ReadLine();

                switch (str.ToLower())
                {
                    case "a":
                        Console.WriteLine(
                            "Bonne réponse !"
                            + "\n La bonne réponse était :"
                            + "\n Luis Fonsi"
                        );
                        score++;
                        total++;
                        loop = false;
                        break;

                    case "b":
                        Console.WriteLine(
                            "Mauvaise réponse !"
                            + "\n La bonne réponse était :"
                            + "\n Luis Fonsi"
                        );
                        total++;
                        loop = false;
                        break;

                    case "c":
                        Console.WriteLine(
                            "Mauvaise réponse !"
                            + "\n La bonne réponse était :"
                            + "\n Luis Fonsi"
                        );
                        total++;
                        loop = false;
                        break;

                    default:
                        Console.WriteLine("Vous avez mal répondu...");
                        loop = true;
                        break;
                }
            } while (loop);

            spacewait();
            Console.Clear();
            snd.Stop();

            do
            {
                MemoryStream ms = musics[3];

                if (ms == null)
                {
                    break;
                }

                Console.Write(
                    "Question 3 : Dans quel film apparaît cette musique ?"
                    + "\n a - Le Seigneur des anneaux"
                    + "\n b - Le Roi Lion"
                    + "\n c - Infinity War"
                    + "\n> "
                );
                
                ms.Position = 0;
                snd.Stream = ms;
                snd.PlayLooping();

                String str = Console.ReadLine();

                switch (str.ToLower())
                {
                    case "a":
                        Console.WriteLine(
                            "Mauvaise réponse !"
                            + "\n La bonne réponse était :"
                            + "\n Le Roi Lion"
                        );
                        total++;
                        loop = false;
                        break;

                    case "b":
                        Console.WriteLine(
                            "Bonne réponse !"
                            + "\n La bonne réponse était :"
                            + "\n Le Roi Lion"
                        );
                        score++;
                        total++;
                        loop = false;
                        break;

                    case "c":
                        Console.WriteLine(
                            "Mauvaise réponse !"
                            + "\n La bonne réponse était :"
                            + "\n Le Roi Lion"
                        );
                        total++;
                        loop = false;
                        break;

                    default:
                        Console.WriteLine("Vous avez mal répondu...");
                        loop = true;
                        break;
                }
            } while (loop);

            spacewait();
            Console.Clear();
            snd.Stop();

            do
            {
                MemoryStream ms = musics[2];

                if (ms == null)
                {
                    break;
                }

                Console.Write(
                    "Question 4 : Quel est le nom de cette musique ?"
                    + "\n a - Mad Turtle"
                    + "\n b - Disturbed Toad"
                    + "\n c - Crazy Frog"
                    + "\n> "
                );
                
                ms.Position = 0;
                snd.Stream = ms;
                snd.PlayLooping();

                String str = Console.ReadLine();

                switch (str.ToLower())
                {
                    case "a":
                        Console.WriteLine(
                            "Mauvaise réponse !"
                            + "\n La bonne réponse était :"
                            + "\n Crazy Frog"
                        );
                        total++;
                        loop = false;
                        break;

                    case "b":
                        Console.WriteLine(
                            "Mauvaise réponse !"
                            + "\n La bonne réponse était :"
                            + "\n Crazy Frog"
                        );
                        total++;
                        loop = false;
                        break;

                    case "c":
                        Console.WriteLine(
                            "Bonne réponse !"
                            + "\n La bonne réponse était :"
                            + "\n Crazy Frog"
                        );
                        score++;
                        total++;
                        loop = false;
                        break;

                    default:
                        Console.WriteLine("Vous avez mal répondu...");
                        loop = true;
                        break;
                }
            } while (loop);

            spacewait();
            Console.Clear();
            snd.Stop();

            done = true;
        }

        private static void note()
        {
            if (done)
            {
                double note = score * 20.0 / total;
                
                MemoryStream ms;
                if (note < 10)
                {
                    ms = musics[5];
                }
                else
                {
                    ms = musics[4];
                }

                if (ms != null)
                {
                    ms.Position = 0;
                    snd.Stream = ms;
                    snd.PlayLooping();
                }

                Console.WriteLine(
                    "Résultats :"
                    + "\n Nombre de questions : " + total
                    + "\n Nombre de bonnes réponses : " + score
                    + "\n Votre note : " + note + " sur 20"
                );

                if (note >= 0 && note < 4)
                {
                    Console.WriteLine(" Votre rang : NULLOS");
                }
                else if (note >= 4 && note < 8)
                {
                    Console.WriteLine(" Votre rang : Endormi");
                }
                else if (note >= 8 && note < 12)
                {
                    Console.WriteLine(" Votre rang : Débutant");
                }
                else if (note >= 12 && note < 16)
                {
                    Console.WriteLine(" Votre rang : Amateur");
                }
                else if (note >= 16 && note < 20)
                {
                    Console.WriteLine(" Votre rang : Intensif");
                }
                else
                {
                    Console.WriteLine(" Votre rang : GENIE");
                }

                spacewait();

                if (ms != null)
                {
                    snd.Stop();
                }
            }
            else
            {
                Console.WriteLine("Vous n'avez pas encore passé le test !");
                spacewait();
            }
            
            Console.Clear();
        }
    }
}
