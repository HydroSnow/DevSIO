using System;
using System.Threading;

namespace QCM
{
    class Program
    {
        static void Main(string[] args)
        {
            bool test_passed = false;
            int good_answers = 0;
            int bad_answers = 0;
            double note = 0;

            Console.WriteLine("Que voulez-vous faire ?");
            Console.WriteLine("Tapez 'help' pour l'aide.");

            bool loop = true;
            while(loop)
            {
                Console.Write("> ");
                String intent = Console.ReadLine().ToLower();

                if (intent == "test")
                {
                    good_answers = 0;
                    bad_answers = 0;
                    note = 0;

                    Question[] questions_arr = new Question[]
                    {
                        new Question("Quel est le type de la variable var prenant la valeur 2 ?", new Answer[]
                        {
                            new Answer("a", "int", true),
                            new Answer("b", "string", false),
                            new Answer("c", "char", false)
                        }),
                        new Question("Cette instruction est-elle correcte ?\n int x=10 ; if(x) Console.WriteLine(''Vous avez la moyenne !'')", new Answer[]
                        {
                            new Answer("a", "oui", false),
                            new Answer("b", "non", true)
                        }),
                        new Question("On n'a pas besoin de déclarer une variable dans le langage C# ?", new Answer[]
                        {
                            new Answer("a", "oui", false),
                            new Answer("b", "non", true),
                                            new Answer("c", "je ne sais pas", false)
                        }),
                        new Question("On peut remplacer l'instruction if...else if par switch dans tous les cas ?", new Answer[]
                        {
                            new Answer("a", "oui", false),
                            new Answer("b", "non", true),
                            new Answer("c", "cela dépend de l'expression à tester", true)
                        }),
                        new Question("Quelle est la syntaxe correcte ?", new Answer[]
                        {
                            new Answer("a", "if (a = 5) { b = 4; } else { b = 2 }", false),
                            new Answer("b", "if (a = 5) { b = 4 }; else { b = 2 };", false),
                            new Answer("c", "if (a == 5) { b = 4; } else { b = 2 }", true)
                        })
                    };

                    Answer[] answers_chosen_arr = new Answer[questions_arr.Length];

                    for (int a = 0; a < questions_arr.Length; a++)
                    {
                        int n = a + 1;
                        Question question = questions_arr[a];
                        Answer[] answers = question.answers;

                        Console.WriteLine("Question " + n + " : " + question.question);
                        for (int b = 0; b < answers.Length; b++)
                        {
                            Answer an = answers[b];
                            Console.WriteLine(" - " + an.id + " : " + an.answer);
                        }

                        for (;;)
                        {
                            bool f = false;
                            Console.Write(" > ");
                            String s = Console.ReadLine();

                            for (int b = 0; b < answers.Length; b++)
                            {
                                Answer an = answers[b];
                                if (an.id.ToLower() == s.ToLower())
                                {
                                    answers_chosen_arr[a] = an;
                                    f = true;
                                    break;
                                }
                            }

                            if (f)
                            {
                                break;
                            }

                            Console.WriteLine("Cette réponse n'existe pas...");
                        }

                        Console.WriteLine();
                    }

                    Console.WriteLine("--- RESULTATS ---\n");

                    for (int a = 0; a < questions_arr.Length && a < answers_chosen_arr.Length; a++)
                    {
                        int n = a + 1;
                        Question question = questions_arr[a];
                        Answer[] answer = question.answers;
                        Answer answer_chosen = answers_chosen_arr[a];

                        Console.WriteLine("Question " + n + " : " + question.question);

                        Console.WriteLine("Corrigé :");
                        for (int b = 0; b < answer.Length; b++)
                        {
                            Answer an = answer[b];
                            if (an.valid)
                            {
                                if (an == answer_chosen)
                                {
                                    Console.WriteLine(" > [vrai] " + an.id + " - " + an.answer);
                                }
                                else
                                {
                                    Console.WriteLine("   [vrai] " + an.id + " - " + an.answer);
                                }
                            }
                            else
                            {
                                if (an == answer_chosen)
                                {
                                    Console.WriteLine(" > [faux] " + an.id + " - " + an.answer);
                                }
                                else
                                {
                                    Console.WriteLine("   [faux] " + an.id + " - " + an.answer);
                                }
                            }
                        }

                        if (answer_chosen.valid)
                        {
                            good_answers++;
                            Console.WriteLine("Bonne réponse !");
                        }
                        else
                        {
                            bad_answers++;
                            Console.WriteLine("Mauvaise réponse !");
                        }

                        Console.WriteLine();
                    }

                    note = good_answers * 20 / questions_arr.Length;

                    Console.WriteLine("Bonnes réponses : " + good_answers);
                    Console.WriteLine("Mauvaises réponses : " + bad_answers);
                    Console.WriteLine("Votre note : " + note + " / 20");

                    test_passed = true;
                }
                else if (intent == "note")
                {
                    if (test_passed)
                    {
                        Console.WriteLine("Bonnes réponses : " + good_answers);
                        Console.WriteLine("Mauvaises réponses : " + bad_answers);
                        Console.WriteLine("Votre note : " + note + " / 20");

                        if (note < 10)
                        {
                            Console.WriteLine("Pas bien :(");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Vous n'avez pas encore passé le test !");
                    }
                }
                else if (intent == "quit")
                {
                    loop = false;
                }
                else if (intent == "help")
                {
                    Console.WriteLine("Liste des commandes :");
                    Console.WriteLine(" - test : lancer le QCM");
                    Console.WriteLine(" - note : voir votre note");
                    Console.WriteLine(" - quit : quitter le programme");
                    Console.WriteLine(" - help : afficher cette aide");
                }
                else
                {
                    Console.WriteLine("Cette commande n'existe pas !");
                }
            }
        }
    }

    class Question
    {
        public String question { get; }
        public Answer[] answers { get; }

        public Question(String question, Answer[] answers)
        {
            this.question = question;
            this.answers = answers;
        }
    }

    public class Answer
    {
        public String id { get; }
        public String answer { get; }
        public bool valid { get; }

        public Answer(String id, String answer, bool valid)
        {
            this.id = id;
            this.answer = answer;
            this.valid = valid;
        }
    }
}
