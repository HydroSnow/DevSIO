/************************************************************************************************************
 * 
 * Mme Le Ray
 * BTS SIO1 SI4
 * TP Fonction / Procédure
 * 
 * **********************************************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFonction
{
    public class Fonctions
    {
        //Exemple de procédure sans argument
        public static void proceduredemo()
        {
            Console.WriteLine("Je suis la démo procédure de ce TD/TP");
        }

        //Exemple de fonction sans argument
        public static string fonctiondemo()
        {
            String phrase = "Je suis la démo fonction de ce TD/TP";
            return phrase;
        }

        //1. Fonction PhrasePrenom(prenom:chaîne de caractères) : chaîne de caractères
        public static String PhrasePrenom(String str)
        {
            return "Je m'appelle " + str;
        }
        
        //2. Fonction PhrasePrenom_p(prenom:chaîne de caractères, classe:chaîne de caractères) : void
            //PhrasePrenom_p("Mathis","CP") affiche à la console "Je m'appelle Mathis et je suis en CP"
        public static String PhrasePrenom_p(String str0, String str1)
        {
            return "Je m'appelle " + str0 + " et je suis en " + str1;
        }

        //3. Fonction Personne(nom:chaîne de caractères, classe:chaîne de caractères, note:chaîne de caractères) : tableaux de chaînes de caractères 
        //Exemple tableau créé {nom,classe,note}
        public static String[] Personne(String str0, String str1, String str2)
        {
            return new String[] {
                str0,
                str1,
                str2
            };
        }

        //4. Fonction PhraseNomPrenom(nom:chaîne de caractères, prenom:chaîne de caractères) : chaîne de caractères
        public static String PhraseNomPrenom(String str0, String str1)
        {
            return "Je m'appelle " + str0 + " " + str1;
        }        

        //5. Fonction Multiplication(a:entier, b:entier) : entier
        public static int Multiplication(int a, int b)
        {
            return a * b;
        }

        //6. Fonction TableMultiplication(a : entier) : void
            //TableMultiplication(2) affiche à la console la table de multiplication de 2
        public static void TableMultiplication(int arg)
        {
            for(int a = 0; a < 10; a++)
            {
                Console.WriteLine(arg + " x " + (a + 1) + " = " + (a * arg));
            }
        }
        
        //7. Fonction Addition(a:entier, b:entier) : entier
        public static int Addition(int a, int b)
        {
            return a + b;
        }

        //8. Fonction Factorielle(a:entier, b:entier) : entier
            //Exemple a!=a*(a-1)....*1
        public static int Factorielle(int a)
        {
            int temp = 1;
            for (int b = a; b > 1; b--)
                temp *= b;
            return temp;
        }

        //9. Fonction Puissance(a:entier, b:entier) : entier
        //Exemple 3 puissance 2 : 3*3
        //Exemple 3 puissance 4 : 3*3*3*3
        public static int Puissance(int a, int b)
        {
            int temp = 1;
            for (int c = 0; c < b; c++)
                temp *= a;
            return temp;
        }


    }

}
