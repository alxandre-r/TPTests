namespace MorpionApp
{
    public class Morpion : Jeu
    {
        public Morpion() : base()
        {
        }

        protected override void TourJoueur()
        {
            int row = 0, column = 0;
            bool moved = false;

            while (!quitterJeu && !moved)
            {
                Console.Clear();
                AffichePlateau();
                Console.WriteLine();
                Console.WriteLine("Choisir une case valide et appuyer sur [Entrer]");
                Console.SetCursorPosition(column * 4 + 2, row * 2);

                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.Escape:
                        quitterJeu = true;
                        Console.Clear();
                        break;

                    case ConsoleKey.RightArrow:
                        column = (column + 1) % 3;
                        break;

                    case ConsoleKey.LeftArrow:
                        column = (column + 2) % 3;
                        break;

                    case ConsoleKey.UpArrow:
                        row = (row + 2) % 3;
                        break;

                    case ConsoleKey.DownArrow:
                        row = (row + 1) % 3;
                        break;

                    case ConsoleKey.Enter:
                        if (grille[row, column] == ' ')
                        {
                            grille[row, column] = 'X';
                            moved = true;
                        }
                        break;
                }
            }
        }
        
        protected override bool VerifVictoire(char c)
        {
            return grille[0, 0] == c && grille[0, 1] == c && grille[0, 2] == c ||
                   grille[1, 0] == c && grille[1, 1] == c && grille[1, 2] == c ||
                   grille[2, 0] == c && grille[2, 1] == c && grille[2, 2] == c ||
                   grille[0, 0] == c && grille[1, 0] == c && grille[2, 0] == c ||
                   grille[0, 1] == c && grille[1, 1] == c && grille[2, 1] == c ||
                   grille[0, 2] == c && grille[1, 2] == c && grille[2, 2] == c ||
                   grille[0, 0] == c && grille[1, 1] == c && grille[2, 2] == c ||
                   grille[0, 2] == c && grille[1, 1] == c && grille[2, 0] == c;
        }
        
        protected override bool VerifEgalite()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (grille[i, j] == ' ')
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        protected override void FinPartie(string message)
        {
            Console.Clear();
            AffichePlateau();
            Console.WriteLine(message);
        }
    }
}
