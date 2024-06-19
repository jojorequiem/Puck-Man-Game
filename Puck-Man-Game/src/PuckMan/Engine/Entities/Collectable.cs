using Puck_Man_Game.src.PuckMan.Engine.Entities;
using Puck_Man_Game.src.PuckMan.Game.Entities;
using Puck_Man_Game.src.PuckMan.UI.Screens;
using src.PuckMan.Game.Levels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Puck_Man_Game.src.PuckMan.Game
{
    /// <summary>
    /// Représente un objet collectable dans le jeu, héritant de la classe Entity.
    /// </summary>
    public class Collectable : Entity
    {
        /// <summary>
        /// Indique si l'objet a déjà été collecté.
        /// </summary>
        public bool DejaCollecte;

        /// <summary>
        /// Initialise une nouvelle instance de la classe Collectable.
        /// </summary>
        /// <param name="name">Nom de l'objet collectable.</param>
        /// <param name="x">Position X initiale de l'objet.</param>
        /// <param name="y">Position Y initiale de l'objet.</param>
        public Collectable(string name, int x, int y) : base(x, y, name)
        {
            DejaCollecte = false;

            // Sélection de l'image de l'objet en fonction de son nom
            if (EntityName == "fragment")
                Image.Image = Puck_Man_Game.Properties.Resources.fragment;
            else if (EntityName == "soin")
                Image.Image = Puck_Man_Game.Properties.Resources.hp;
            else if (EntityName == "fragment degat")
                Image.Image = Puck_Man_Game.Properties.Resources.death_fragment;
            else if (EntityName == "portail teleportation")
                Image.Image = Puck_Man_Game.Properties.Resources.portal;
        }

        /// <summary>
        /// Gère la collecte de l'objet par le joueur.
        /// </summary>
        /// <param name="Formulaire">Formulaire du jeu contenant l'état actuel du jeu et du joueur.</param>
        public void Collecte(FrmNewGame Formulaire)
        {
            if (!DejaCollecte)
            {
                Player player = Formulaire.P1;

                // Vérifie si l'objet collectable est à la position du joueur
                if (player.Maze.StaticEntities[X, Y] == this)
                    player.Maze.StaticEntities[X, Y] = null;

                DejaCollecte = true;
                Image.Hide(); // Cache l'image de l'objet collecté

                // Actions spécifiques en fonction du type d'objet collecté
                if (EntityName == "fragment")
                {
                    Program.score += 1;
                    Program.PlaySound("assets/audio/TakeFragment.wav");
                    player.Maze.FragmentList.Remove(this);
                    Formulaire.UpdateFragmentdisplay();

                    // Passe au niveau suivant si tous les fragments sont collectés
                    if (player.Maze.FragmentList.Count <= 0)
                        Formulaire.NiveauSuivant();
                }
                else if (EntityName == "soin")
                {
                    player.Heal(1); // Soigne le joueur
                }
                else if (EntityName == "fragment degat")
                {
                    Program.PlaySound("assets/audio/DeathFragment.wav");
                    player.DamageReceived(1); // Inflige des dégâts au joueur
                }
                else if (EntityName == "portail teleportation")
                {
                    Program.PlaySound("assets/audio/Teleportation.wav");
                    DejaCollecte = false;
                    Image.Show();

                    Random random = new Random();
                    int newX, newY;

                    // Téléporte le joueur à une nouvelle position aléatoire
                    do
                    {
                        newX = random.Next(1, player.Maze.width - 1) * Maze.cellSize;
                        newY = random.Next(1, player.Maze.height - 1) * Maze.cellSize;
                    } while (player.Maze.MazeMatrix[newX / Maze.cellSize, newY / Maze.cellSize].IsWall || player.Maze.Entities[newX, newY] != null);

                    player.Maze.Entities[player.X, player.Y] = null;
                    player.X = newX;
                    player.Y = newY;
                    player.Maze.Entities[newX, newY] = player;
                    player.Image.Location = new Point(newX, newY);

                    // Téléporte le portail à une nouvelle position aléatoire
                    int portalX, portalY;
                    do
                    {
                        portalX = random.Next(1, player.Maze.width - 1) * Maze.cellSize;
                        portalY = random.Next(1, player.Maze.height - 1) * Maze.cellSize;
                    } while ((portalX == newX && portalY == newY) || player.Maze.MazeMatrix[portalX / Maze.cellSize, portalY / Maze.cellSize].IsWall || player.Maze.StaticEntities[portalX, portalY] != null);

                    player.Maze.StaticEntities[X, Y] = null;
                    X = portalX;
                    Y = portalY;
                    Image.Location = new Point(X, Y);
                    player.Maze.StaticEntities[X, Y] = this;
                }
            }
        }
    }
}
