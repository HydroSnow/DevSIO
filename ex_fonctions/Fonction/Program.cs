/************************************************************************************************************
 * 
 * Mme Le Ray
 * BTS SIO1 SI4
 * TP Fonction / Procédure
 * 
 * **********************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TestFonction;
using static System.Net.Mime.MediaTypeNames;

namespace Fonction
{
    class Program
    {
        [DllImport("kernel32.dll", EntryPoint = "GetConsoleWindow", SetLastError = true)]
        private static extern IntPtr GetConsoleHandle();

        static void Main(string[] args)
        {
            //Chargement de l'image
            var handler = GetConsoleHandle();
            using (var graphics = Graphics.FromHwnd(handler))
            using (var image = System.Drawing.Image.FromFile(@"image/images.png"))
                graphics.DrawImage(image, 5, 5, 250, 200);

            //Retire le /* et  */ pour commencer ce TP
            /*
            // Déclaration
            string nom = 
            string prenom = 
            
            string sPrenom =
            string sClasse = 
            string sNote = 
            string sPhrase =
            int nFois = 
            int nPlus = 
            int nPuis = 
            int nFac = 

            //Identification
            Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n");
            Console.WriteLine(".".PadRight(90, '.'));
            Console.Write("\n");
            Console.Write(" NOM".PadRight(20, '.'));
            Console.WriteLine(": " + nom);
            Console.Write(" PRENOM".PadRight(20, '.'));
            Console.WriteLine(": " + prenom);
            Console.WriteLine("\n.".PadRight(90, '.'));

            //Description
            Console.WriteLine("\nBonjour je m'appelle {0} et je suis en {1}. J'ai eu la note de {2} en \ninformatique. Je dois toujours dire la phrase suivante :\"{3}\", \nquand je me présente à une nouvelle personne.\nJe connais ma table de multiplication de 2 :", sPrenom, sClasse, sNote,sPhrase);
                //Affichage de la table de multiplication

            Console.WriteLine("J'adore les mathématiques. Et je sais que 4 fois 5 font {0},...4 plus 3 font {1}...,\n4 puissance 2 font {2}... et 3 factorielle 4 font {3}...", nFois, nPlus,nPuis,nFac);
            Console.ReadLine(); //Ici pour la mise en attente de l'affichage
            */

        }


    }
}

