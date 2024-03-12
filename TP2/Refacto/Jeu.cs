using System;

namespace MorpionApp
{
    public class Jeu
    {
        protected bool quitterJeu = false;
        protected bool tourDuJoueur = true;
        protected char[,] grille;

        public Jeu()
        {
            grille = new char[3, 3];
        }

        public virtual void BoucleJeu()
        {
            while (!quitterJeu)
            {
                InitialiserGrille();

                while (!quitterJeu)
                {
                    AffichePlateau();
                    TourJoueur();
                    if (VerifVictoire('X'))
                    {
                        FinPartie("Le joueur 1 a gagné !");
                        break;
                    }
                    else if (VerifVictoire('O'))
                    {
                        FinPartie("Le joueur 2 a gagné !");
                        break;
                    }
                    else if (VerifEgalite())
                    {
                        FinPartie("Aucun vainqueur, la partie se termine sur une égalité.");
                        break;
                    }
                    tourDuJoueur = !tourDuJoueur;
                }

                if (!quitterJeu)
                {
                    Console.WriteLine("Appuyez sur [Echap] pour quitter, [Entrer] pour rejouer.");
                    var key = Console.ReadKey(true).Key;
                    if (key == ConsoleKey.Escape)
                    {
                        quitterJeu = true;
                    }
                }
            }
        }

        protected virtual void TourJoueur()
        {
            // À implémenter dans les classes dérivées
        }

        protected void InitialiserGrille()
        {
            grille = new char[3, 3]
            {
                { ' ', ' ', ' ' },
                { ' ', ' ', ' ' },
                { ' ', ' ', ' ' }
            };
        }

        protected void AffichePlateau()
        {
            Console.Clear();
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($" {grille[i, 0]} | {grille[i, 1]} | {grille[i, 2]}");
                if (i < 2)
                {
                    Console.WriteLine("-----------");
                }
            }
            Console.WriteLine();
        }

        protected bool VerifVictoire(char c)
        {
            // Vérifications de victoire à implémenter dans les classes dérivées
            return false;
        }

        protected bool VerifEgalite()
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

        protected void FinPartie(string message)
        {
            Console.WriteLine(message);
        }
    }
}
