using System;

namespace CalculatorApp
{
    class Program
    {
        static void Main()
        {
            bool continuer = true;

            while (continuer)
            {
                Console.WriteLine("Choisissez une option :");
                Console.WriteLine("1. Calculer une expression mathématique");
                Console.WriteLine("2. Quitter");

                char choix = Console.ReadKey().KeyChar;
                Console.WriteLine(); // Nouvelle ligne pour une meilleure mise en forme

                switch (choix)
                {
                    case '1':
                        Console.WriteLine("Entrez une expression mathématique (par exemple, '2 + 3 * 4') : ");
                        string? expression = Console.ReadLine();

                        // Check for null or use null-forgiving operator depending on your needs
                        if (expression != null)
                        {
                            Calculator.Calcul(expression);
                        }
                        else
                        {
                            Console.WriteLine("Erreur : L'expression est nulle.");
                        }
                        break;

                    case '2':
                        continuer = false;
                        break;

                    default:
                        Console.WriteLine("Option invalide. Veuillez choisir une option valide.");
                        break;
                }
            }
        }
    }
}
