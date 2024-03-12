namespace MorpionApp
{
    public class PuissanceQuatre : Jeu
    {
        public PuissanceQuatre() : base()
        {
        }

        protected override void TourJoueur()
        {
            int column = 0;
            bool moved = false;

            while (!quitterJeu && !moved)
            {
                Console.Clear();
                AffichePlateau();
                Console.WriteLine();
                Console.WriteLine("Choisir une colonne valide et appuyer sur [Entrer]");
                Console.SetCursorPosition(column * 4 + 2, 0);

                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.Escape:
                        quitterJeu = true;
                        Console.Clear();
                        break;

                    case ConsoleKey.RightArrow:
                        column = Math.Min(column + 1, 6);
                        break;

                    case ConsoleKey.LeftArrow:
                        column = Math.Max(column - 1, 0);
                        break;

                    case ConsoleKey.Enter:
                        if (PlacerJeton(column))
                        {
                            moved = true;
                        }
                        break;
                }
            }
        }

        private bool PlacerJeton(int column)
        {
            for (int i = 5; i >= 0; i--)
            {
                if (grille[i, column] == ' ')
                {
                    grille[i, column] = tourDuJoueur ? 'X' : 'O';
                    return true;
                }
            }
            return false; // Colonne pleine
        }

        protected override bool VerifVictoire(char c)
        {
            // Vérification des lignes
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (grille[i, j] == c && grille[i, j + 1] == c && grille[i, j + 2] == c && grille[i, j + 3] == c)
                    {
                        return true;
                    }
                }
            }

            // Vérification des colonnes
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    if (grille[i, j] == c && grille[i + 1, j] == c && grille[i + 2, j] == c && grille[i + 3, j] == c)
                    {
                        return true;
                    }
                }
            }

            // Vérification des diagonales ascendantes
            for (int i = 3; i < 6; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (grille[i, j] == c && grille[i - 1, j + 1] == c && grille[i - 2, j + 2] == c && grille[i - 3, j + 3] == c)
                    {
                        return true;
                    }
                }
            }

            // Vérification des diagonales descendantes
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (grille[i, j] == c && grille[i + 1, j + 1] == c && grille[i + 2, j + 2] == c && grille[i + 3, j + 3] == c)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        protected override bool VerifEgalite()
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
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
