using System;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using System.Net;
using System.Diagnostics;

class Sandwich
{
    static bool verbose = false;

    public static void Main(string[] args)
    {
        Console.WriteLine("Salut !");

        bool cont = true;
        while (cont)
        {
            int program = int_rcons("Entrez l'identifiant du programme : ");

            Console.WriteLine("-- début programme --");
            
            switch (program)
            {
                case 3:
                    program_3();
                    break;
                case 4:
                    program_4();
                    break;
                case 5:
                    program_5();
                    break;
                case 6:
                    program_6();
                    break;
                case 7:
                    program_7();
                    break;
                case 8:
                    program_8();
                    break;
                case 9:
                    program_9();
                    break;
                case 10:
                    program_10();
                    break;
                case 11:
                    program_11();
                    break;
                case 12:
                    program_12();
                    break;
                case 13:
                    program_13();
                    break;
                case 14:
                    program_14();
                    break;
                case 15:
                    program_15();
                    break;
                case 16:
                    program_16();
                    break;
                case 17:
                    program_17();
                    break;
                case 1337:
                    cont = false;
                    break;
                default:
                    Console.WriteLine("Le programme " + program + " n'existe pas !");
                    break;
            }

            Console.WriteLine("-- fin programme --");
        }

        Console.WriteLine("Fin dans 50 secondes.");
        Thread.Sleep(50000);
    }

    private static void program_3()
    {
        const int s = 5;
        double b = 0;

        for (int a = 0; a < s; a++)
            b += double_rcons("Entrez le nombre " + (a + 1) + " : ");

        b /= s;

        Console.WriteLine("Moyenne = " + b);
    }

    private static void program_4()
    {
        int a = int_rcons("Entrez le nombre a : ");
        int b = int_rcons("Entrez le nombre b : ");

        int t = b;
        b = a;
        a = t;

        Console.WriteLine("a = " + a);
        Console.WriteLine("b = " + b);
    }

    private static void program_5()
    {
        Console.WriteLine("Lancement du serveur de moyennes...");
        new Thread(new ThreadStart(net_moy_srv)).Start();

        double a = double_rcons("Entrez le nombre a : ");
        double b = double_rcons("Entrez le nombre b : ");
        double c = net_moy_cli(a, b);
        Console.WriteLine("Moyenne = " + c);
    }

    private static void program_6()
    {
        int a = int_rcons("Entrez le nombre de tests : ");

        Stopwatch sw1 = new Stopwatch();
        sw1.Start();
        for (int b = 0; b < a; b++)
            Console.WriteLine("yo " + b);
        sw1.Stop();
        long l1 = sw1.ElapsedMilliseconds;

        Stopwatch sw2 = new Stopwatch();
        sw2.Start();
        for (int b = 0; b < a; b++)
            Console.WriteLine("yo {0}", b);
        sw2.Stop();
        long l2 = sw2.ElapsedMilliseconds;

        Console.WriteLine("Durée 1 : " + l1);
        Console.WriteLine("Durée 2 : " + l2);
    }

    private static void program_7()
    {
        while (true)
        {
            string str = "Que souhaitez-vous faire ?";
            str += "\n 1 - Entrez le choix des élèves";
            str += "\n 2 - Lire le choix des élèves";
            str += "\n 3 - Quitter le programme";
            str += "\nChoix : ";
            Console.Write(str);
            int input = int_rcons(str);

            switch (input)
            {
                case 1:
                    const int size = 24;
                    for (int a = 0; a < size; a++)
                    {
                        Console.WriteLine("--- Elève " + (a + 1) + " sur " + size + " ---");

                        Console.Write(" Entrez votre nom : ");
                        string nom = Console.ReadLine();

                        Console.Write(" Entrez votre prénom : ");
                        string prenom = Console.ReadLine();

                        Console.Write(" Entrez votre choix d'option : ");
                        string option = Console.ReadLine();

                        if (option.ToLower() == "sisr")
                        {
                            Console.WriteLine(" Nous avons pris en compte le choix de l'élève {0} {1} d'aller en SISR", prenom, nom);
                        }
                        if (option.ToLower() == "slam")
                        {
                            Console.WriteLine(" Nous avons pris en compte le choix de l'élève {0} {1} d'aller en SLAM", prenom, nom);
                        }
                    }
                    Console.WriteLine("-----------------------");
                    break;
                case 2:
                    break;
                case 3:
                    return;
                default:
                    Console.Write("Choix invalide... ");
                    break;
            }
        }
    }

    private static void program_8()
    {
        int size = int_rcons("Taille : ");

        for (int a = 0; a < size; a++)
        {
            for (int b = a; b < size; b++)
            {
                Console.Write(' ');
            }
            int ns = (a * 2) + 1;
            for (int b = 0; b < ns; b++)
            {
                Console.Write('*');
            }
            Console.Write('\n');
        }
    }

    private static void program_9()
    {
        int size = int_rcons("Taille : ");

        Random r = new Random();

        for (int a = 0; a < size; a++)
        {
            for (int b = a; b < size; b++)
            {
                Console.Write(' ');
            }
            int ns = (a * 2) + 1;
            for (int b = 0; b < ns; b++)
            {
                if (r.Next() % 2 == 1)
                    Console.Write('*');
                else
                    Console.Write(' ');
            }
            Console.Write('\n');
        }
    }

    private static void program_10()
    {
        int n = int_rcons("Nombre : ");
        int s = int_rcons("Taille : ");

        for (int a = 1; a <= s; a++)
        {
            int v = n * a;
            Console.WriteLine(n + " x " + a + " = " + v);
        }
    }

    private static void program_11()
    {
        Random r = new Random();
        
        string f = str_rcon("Entrez une chaine de caractères (a-z) : ");

        bool cont = true;
        while (cont)
        {
            for (int a = 0; ; a++)
            {
                string s = "";
                for (int b = 0; b < f.Length; b++)
                {
                    s += (char) (97 + r.Next() % 26);
                }

                if (s == f)
                {
                    Console.Write(" PASS     Attempt " + a + " : ");
                    Console.WriteLine(s);
                    break;
                }
                else
                {
                    Console.Write(" INVALID  Attempt " + a + " : ");
                    Console.WriteLine(s);
                }
            }

            cont = ask_continue();
        }
    }

    private static void program_12()
    {
        int size = int_rcons("Taille : ");

        Random r = new Random();

        for (int a = 0; a < size; a++)
        {
            for (int b = a; b < size; b++)
            {
                Console.Write("          ");
            }
            int ns = (a * 2) + 1;

            if (r.Next() % 2 == 1)
            {
                for (int b = 0; b < ns; b++)
                {
                    if (r.Next() % 2 == 1)
                    {
                        Console.Write("  jeanluc ");
                    }
                    else
                    {
                        Console.Write(" mélenchon");
                    }
                }
            }
            else
            {
                for (int b = 0; b < ns; b++)
                {
                    if (r.Next() % 2 == 1)
                    {
                        Console.Write(" LA FRANCE");
                    }
                    else
                    {
                        Console.Write(" INSOUMISE");
                    }
                }
            }

            Console.Write("\n\n\n");
        }
    }

    private static void program_13()
    {
        Console.WriteLine("Lancement du serveur de moyennes...");
        new Thread(new ThreadStart(net_moy_srv)).Start();

        Random r = new Random();

        for (;;)
        {
            double a = r.NextDouble();
            double b = r.NextDouble();
            double c = net_moy_cli(a, b);
            Console.WriteLine("Moyenne = " + c);
        }
    }

    private static void program_14()
    {
        for (;;)
        {
            string expr = str_rcon("Entrez l'expression mathématique : ");
            try
            {
                double r = eval(expr);
                Console.WriteLine("Le résultat est " + r);
            }
            catch (Exception)
            {
                Console.WriteLine("Erreur : Calcul invalide !");
            }
        }
    }

    private static void program_15()
    {
        const int max_tries = 5;
        const int max_nbr = 50;

        int nbr = new Random().Next(1, max_nbr + 1);
        Console.WriteLine("Entrez un nombre entre 1 et " + max_nbr + " !");
        Console.WriteLine("Vous avez " + max_tries + " tentatives.");
        
        int tries = 0;
        while (true)
        {
            tries++;

            if (tries > 5)
            {
                Console.WriteLine("Vous avez perdu ! Le nombre était " + nbr);
                break;
            }

            int nbe = int_rcons(" " + tries + "/" + max_tries + " > ");
            
            if (nbr < nbe)
            {
                Console.WriteLine("C'est moins !");
            }
            else if (nbr > nbe)
            {
                Console.WriteLine("C'est plus !");
            }
            else if (nbr == nbe)
            {
                Console.WriteLine("Bravo !");
                break;
            }
        }
    }

    private static void program_16()
    {
        Random r = new Random();
        Array values = Enum.GetValues(typeof(ConsoleColor));
        while (true)
        {
            Console.BackgroundColor = (ConsoleColor)values.GetValue(r.Next(values.Length));
            Console.ForegroundColor = (ConsoleColor)values.GetValue(r.Next(values.Length));
            Console.Write('H');
        }
    }
    
    private static void program_17()
    {
        Random r = new Random();
        Array values = Enum.GetValues(typeof(ConsoleColor));
        while (true)
        {
            Console.BackgroundColor = (ConsoleColor)values.GetValue(r.Next(values.Length));
            Console.ForegroundColor = (ConsoleColor)values.GetValue(r.Next(values.Length));
            var t = Console.ReadKey(true);
            Console.Write(t.KeyChar);
        }
    }

    private static bool ask_continue()
    {
        Console.WriteLine("Continuer ? (o/n)");
        
        while (true)
        {
            var t = Console.ReadKey(true);
            
            if (t.Key == ConsoleKey.O)
            {
                return true;
            }
            else if (t.Key == ConsoleKey.N)
            {
                return false;
            }
        }
    }

    private static double eval(string expr)
    {
        {
            int i;
            while ((i = expr.IndexOf(' ')) != -1)
                expr.Remove(i);
        }

        if (expr.Contains("+"))
        {
            int i = expr.IndexOf('+');
            string av = expr.Substring(0, i);
            string ap = expr.Substring(i + 1, expr.Length - i - 1);
            return eval(av) + eval(ap);
        }
        else if (expr.Contains("-"))
        {
            int i = expr.IndexOf('-');
            string av = expr.Substring(0, i);
            string ap = expr.Substring(i + 1, expr.Length - i - 1);
            return eval(av) - eval(ap);
        }
        else if (expr.Contains("*"))
        {
            int i = expr.IndexOf('*');
            string av = expr.Substring(0, i);
            string ap = expr.Substring(i + 1, expr.Length - i - 1);
            return eval(av) * eval(ap);
        }
        else if (expr.Contains("/"))
        {
            int i = expr.IndexOf('/');
            string av = expr.Substring(0, i);
            string ap = expr.Substring(i + 1, expr.Length - i - 1);
            return eval(av) / eval(ap);
        }
        else if (expr.Contains("^"))
        {
            int i = expr.IndexOf('^');
            string av = expr.Substring(0, i);
            string ap = expr.Substring(i + 1, expr.Length - i - 1);
            return Math.Pow(eval(av), eval(ap));
        }
        else
        {
            return Double.Parse(expr);
        }
    }

    private static void net_moy_srv()
    {
        IPEndPoint ip = new IPEndPoint(IPAddress.Any, 58032);
        Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        socket.Bind(ip);
        socket.Listen(10);

        for (;;)
        {
            Socket cli;
            NetworkStream ns;
            StreamReader sr;
            StreamWriter sw;
            try
            {
                cli = socket.Accept();
                ns = new NetworkStream(cli);
                sr = new StreamReader(ns);
                sw = new StreamWriter(ns);
                sw.AutoFlush = true;
                if (verbose)
                {
                    Console.WriteLine(" server> connexion etablie");
                }
            }
            catch (Exception e)
            {
                if (verbose)
                {
                    Console.WriteLine(" server> erreur de connexion");
                    Console.WriteLine(e);
                }
                continue;
            }

            sw.WriteLine("ok");
            if (verbose)
            {
                Console.WriteLine(" server> pret a recevoir");
            }

            string ra = sr.ReadLine();
            double a = -1;
            try
            {
                a = double.Parse(ra);
                if (verbose)
                {
                    Console.WriteLine(" server> nombre a recu");
                }
            }
            catch (FormatException)
            {
                if (verbose)
                {
                    Console.WriteLine(" server> a n'est pas un nombre");
                }
                continue;
            }

            string rb = sr.ReadLine();
            double b = -1;
            try
            {
                b = double.Parse(rb);
                if (verbose)
                {
                    Console.WriteLine(" server> nombre b recu");
                }
            }
            catch (FormatException)
            {
                if (verbose)
                {
                    Console.WriteLine(" server> b n'est pas un nombre");
                }
                continue;
            }

            double c = (a + b) / 2.0;
            sw.WriteLine(c);
            if (verbose)
            {
                Console.WriteLine(" server> nombre r envoye");
            }
        }
    }

    private static double net_moy_cli(double a, double b)
    {
        TcpClient tcp;
        Socket cli;
        NetworkStream ns;
        StreamReader sr;
        StreamWriter sw;
        try
        {
            tcp = new TcpClient();
            tcp.Connect("localhost", 58032);
            cli = tcp.Client;
            ns = new NetworkStream(cli);
            sr = new StreamReader(ns);
            sw = new StreamWriter(ns);
            sw.AutoFlush = true;
            if (verbose)
            {
                Console.WriteLine(" client> connexion etablie");
            }
        }
        catch (Exception e)
        {
            if (verbose)
            {
                Console.WriteLine(" client> erreur de connexion");
                Console.WriteLine(e);
            }
            return -1;
        }

        string state = null;
        while (state != "ok")
            state = sr.ReadLine();
        if (verbose)
        {
            Console.WriteLine(" client> le serveur est " + state);
        }

        sw.WriteLine(a);
        if (verbose)
        {
            Console.WriteLine(" client> nombre a envoye");
        }

        sw.WriteLine(b);
        if (verbose)
        {
            Console.WriteLine(" client> nombre b envoye");
        }

        string r = sr.ReadLine();
        double c = -1;
        try
        {
            c = double.Parse(r);
            if (verbose)
            {
                Console.WriteLine(" client> nombre r recu");
            }
        }
        catch (FormatException)
        {
            if (verbose)
            {
                Console.WriteLine(" client> r n'est pas un nombre");
            }
        }

        tcp.Close();
        if (verbose)
        {
            Console.WriteLine(" client> socket ferme");
        }
        return c;
    }

    private static string str_rcon(string message)
    {
        Console.Write(message);
        return Console.ReadLine();
    }

    private static int int_rcons(string message)
    {
        for (;;)
        {
            Console.Write(message);
            string str = Console.ReadLine();

            try
            {
                return int.Parse(str);
            }
            catch (FormatException)
            {
                Console.WriteLine("Ceci n'est pas un nombre !");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Ce nombre est trop grand !");
            }
        }
    }

    private static double double_rcons(string message)
    {
        for (;;)
        {
            Console.Write(message);
            string str = Console.ReadLine();

            try
            {
                return double.Parse(str);
            }
            catch (FormatException)
            {
                Console.WriteLine("Ceci n'est pas un nombre !");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Ce nombre est trop grand !");
            }
        }
    }
}
