using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorpionApp
{

    public class UnitTest_Morpion
    {
        [Fact]
        [Trait("Morpion", "VerifVictoire")]
        public void Test_victoire_toutes_lignes()
        {
            for (int ligne = 0; ligne < 3; ligne++)
            {
                Morpion morpion = new Morpion();
                char joueur = (ligne % 2 == 0) ? 'X' : 'O';

                for (int col = 0; col < 3; col++)
                {
                    morpion.grille[ligne, col] = joueur;
                }

                Assert.True(morpion.verifVictoire(joueur));
            }
        }

        [Fact]
        public void Test_victoire_toutes_colonnes()
        {
            for (int col = 0; col < 3; col++)
            {
                Morpion morpion = new Morpion();
                char joueur = (col % 2 == 0) ? 'X' : 'O';

                for (int ligne = 0; ligne < 3; ligne++)
                {
                    morpion.grille[ligne, col] = joueur;
                }

                Assert.True(morpion.verifVictoire(joueur));
            }
        }

        [Fact]
        public void Test_victoire_diagonale_descendante()
        {
            Morpion morpion = new Morpion();
            char joueur = 'X';

            for (int i = 0; i < 3; i++)
            {
                morpion.grille[i, i] = joueur;
            }
            Assert.True(morpion.verifVictoire(joueur));

            joueur = 'O';

            for (int i = 0; i < 3; i++)
            {
                morpion.grille[i, i] = joueur;
            }
            Assert.True(morpion.verifVictoire(joueur));
        }

        [Fact]
        public void Test_victoire_diagonale_ascendante()
        {
            Morpion morpion = new Morpion();
            char joueur = 'X';

            for (int i = 0; i < 3; i++)
            {
                morpion.grille[i, 2 - i] = joueur;
            }
            Assert.True(morpion.verifVictoire(joueur));

            joueur = 'O';

            for (int i = 0; i < 3; i++)
            {
                morpion.grille[i, 2 - i] = joueur;
            }
            Assert.True(morpion.verifVictoire(joueur));
        }

        [Fact]
        public void Test_pas_de_victoire()
        {
            Morpion morpion = new Morpion();
            Assert.False(morpion.verifVictoire('X'));
            Assert.False(morpion.verifVictoire('O'));
        }

        [Fact]
        public void Test_pas_d_egalite()
        {
            Morpion morpion = new Morpion();
            Assert.False(morpion.verifEgalite());
        }

    }


    public class Morpion
    {
        public bool quiterJeu = false;
        public bool tourDuJoueur = true;
        public char[,] grille;

        public Morpion()
        {
            grille = new char[3, 3];
        }

        public void BoucleJeu()
        {
            while (!quiterJeu)
            {
                grille = new char[3, 3]
                {
                    { ' ', ' ', ' '},
                    { ' ', ' ', ' '},
                    { ' ', ' ', ' '},
                };
                while (!quiterJeu)
                {
                    if (tourDuJoueur)
                    {
                        tourJoueur();
                        if (verifVictoire('X'))
                        {
                            finPartie("Le joueur 1 à gagné !");
                            break;
                        }
                    }
                    else
                    {
                        tourJoueur2();
                        if (verifVictoire('O'))
                        {
                            finPartie("Le joueur 2 à gagné !");
                            break;
                        }
                    }
                    tourDuJoueur = !tourDuJoueur;
                    if (verifEgalite())
                    {
                        finPartie("Aucun vainqueur, la partie se termine sur une égalité.");
                        break;
                    }
                }
                if (!quiterJeu)
                {
                    Console.WriteLine("Appuyer sur [Echap] pour quitter, [Entrer] pour rejouer.");
                GetKey:
                    switch (Console.ReadKey(true).Key)
                    {
                        case ConsoleKey.Enter:
                            break;
                        case ConsoleKey.Escape:
                            quiterJeu = true;
                            Console.Clear();
                            break;
                        default:
                            goto GetKey;
                    }
                }

            }
        }

        public void tourJoueur()
        {
            var (row, column) = (0, 0);
            bool moved = false;

            while (!quiterJeu && !moved)
            {
                Console.Clear();
                affichePlateau();
                Console.WriteLine();
                Console.WriteLine("Choisir une case valide est appuyer sur [Entrer]");
                Console.SetCursorPosition(column * 6 + 1, row * 4 + 1);

                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.Escape:
                        quiterJeu = true;
                        Console.Clear();
                        break;

                    case ConsoleKey.RightArrow:
                        if (column >= 2)
                        {
                            column = 0;
                        }
                        else
                        {
                            column = column + 1;
                        }
                        break;

                    case ConsoleKey.LeftArrow:
                        if (column <= 0)
                        {
                            column = 2;
                        }
                        else
                        {
                            column = column - 1;
                        }
                        break;

                    case ConsoleKey.UpArrow:
                        if (row <= 0)
                        {
                            row = 2;
                        }
                        else
                        {
                            row = row - 1;
                        }
                        break;

                    case ConsoleKey.DownArrow:
                        if (row >= 2)
                        {
                            row = 0;
                        }
                        else
                        {
                            row = row + 1;
                        }
                        break;
                    case ConsoleKey.Enter:
                        if (grille[row, column] is ' ')
                        {
                            grille[row, column] = 'X';
                            moved = true;
                            quiterJeu = false;
                        }
                        break;
                }

            }
        }

        public void tourJoueur2()
        {
            var (row, column) = (0, 0);
            bool moved = false;

            while (!quiterJeu && !moved)
            {
                Console.Clear();
                affichePlateau();
                Console.WriteLine();
                Console.WriteLine("Choisir une case valide est appuyer sur [Entrer]");
                Console.SetCursorPosition(column * 6 + 1, row * 4 + 1);

                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.Escape:
                        quiterJeu = true;
                        Console.Clear();
                        break;

                    case ConsoleKey.RightArrow:
                        if (column >= 2)
                        {
                            column = 0;
                        }
                        else
                        {
                            column = column + 1;
                        }
                        break;

                    case ConsoleKey.LeftArrow:
                        if (column <= 0)
                        {
                            column = 2;
                        }
                        else
                        {
                            column = column - 1;
                        }
                        break;

                    case ConsoleKey.UpArrow:
                        if (row <= 0)
                        {
                            row = 2;
                        }
                        else
                        {
                            row = row - 1;
                        }
                        break;

                    case ConsoleKey.DownArrow:
                        if (row >= 2)
                        {
                            row = 0;
                        }
                        else
                        {
                            row = row + 1;
                        }
                        break;
                    case ConsoleKey.Enter:
                        if (grille[row, column] is ' ')
                        {
                            grille[row, column] = 'O';
                            moved = true;
                            quiterJeu = false;
                        }
                        break;
                }
            }
        }

        public void affichePlateau()
        {
            Console.WriteLine();
            Console.WriteLine($" {grille[0, 0]}  |  {grille[0, 1]}  |  {grille[0, 2]}");
            Console.WriteLine("    |     |");
            Console.WriteLine("----+-----+----");
            Console.WriteLine("    |     |");
            Console.WriteLine($" {grille[1, 0]}  |  {grille[1, 1]}  |  {grille[1, 2]}");
            Console.WriteLine("    |     |");
            Console.WriteLine("----+-----+----");
            Console.WriteLine("    |     |");
            Console.WriteLine($" {grille[2, 0]}  |  {grille[1, 1]}  |  {grille[0, 2]}");
        }

        public bool verifVictoire(char c) =>
             grille[0, 0] == c && grille[1, 0] == c && grille[2, 0] == c ||
             grille[0, 1] == c && grille[1, 1] == c && grille[2, 1] == c ||
             grille[0, 2] == c && grille[1, 2] == c && grille[2, 2] == c ||
             grille[0, 0] == c && grille[1, 1] == c && grille[2, 2] == c ||
             grille[1, 0] == c && grille[1, 1] == c && grille[1, 2] == c ||
             grille[2, 0] == c && grille[2, 1] == c && grille[2, 2] == c ||
             grille[0, 0] == c && grille[1, 1] == c && grille[2, 2] == c ||
             grille[2, 0] == c && grille[1, 1] == c && grille[0, 2] == c;

        public bool verifEgalite() =>
            grille[0, 0] != ' ' && grille[1, 0] != ' ' && grille[2, 0] != ' ' &&
            grille[0, 1] != ' ' && grille[1, 1] != ' ' && grille[2, 1] != ' ' &&
            grille[0, 2] != ' ' && grille[1, 2] != ' ' && grille[2, 2] != ' ';


        public void finPartie(string msg)
        {
            Console.Clear();
            affichePlateau();
            Console.WriteLine(msg);
        }
    }
}
