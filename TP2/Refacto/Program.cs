using System;

namespace MorpionApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Jouer à quel jeu ? Taper [X] pour le morpion et [P] pour le puissance 4.");

            while (true)
            {
                var key = Console.ReadKey(true).Key;
                Jeu jeu;

                switch (key)
                {
                    case ConsoleKey.X:
                        jeu = new Morpion();
                        jeu.BoucleJeu();
                        break;

                    case ConsoleKey.P:
                        jeu = new PuissanceQuatre();
                        jeu.BoucleJeu();
                        break;

                    default:
                        Console.WriteLine("Taper [X] pour le morpion et [P] pour le puissance 4.");
                        continue;
                }

                Console.WriteLine("Jouer à un autre jeu ? Taper [R] pour changer de jeu. Taper [Echap] pour quitter.");

                var keyInfo = Console.ReadKey(true).Key;

                if (keyInfo == ConsoleKey.Escape)
                {
                    break;
                }

                while (keyInfo != ConsoleKey.R && keyInfo != ConsoleKey.Escape)
                {
                    keyInfo = Console.ReadKey(true).Key;
                }

                if (keyInfo == ConsoleKey.Escape)
                {
                    break;
                }
            }
        }
    }
}
