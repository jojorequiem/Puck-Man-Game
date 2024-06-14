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
    public class Collectable : Entity
    {
        public bool DejaCollecte;
        public Collectable(string name, int x, int y) : base(x, y, name)
        {
            DejaCollecte = false;
            if (EntityName == "fragment")
                Image.Image = Puck_Man_Game.Properties.Resources.fragment;
            if (EntityName == "soin")
                Image.Image = Puck_Man_Game.Properties.Resources.puceSoin;
            if (EntityName == "potion degat")
                Image.Image = Puck_Man_Game.Properties.Resources.deathPotion;
            if (EntityName == "portail teleportation")
                Image.Image = Puck_Man_Game.Properties.Resources.portal;
        }
        public void Collecte(FrmNouvellePartie Formulaire)
        {
            if  (!DejaCollecte)
            {
                Player player = Formulaire.P1;
                if (player.Maze.StaticEntities[X, Y] == this)
                    player.Maze.StaticEntities[X, Y] = null;

                DejaCollecte = true;
                Image.Hide();

                if (EntityName == "fragment")
                {
                    player.Maze.FragmentList.Remove(this);
                    Formulaire.UpdateFragmentdisplay();
                    if (player.Maze.FragmentList.Count() <= 0)
                        Formulaire.NiveauSuivant(); 
                }

                else if (EntityName == "soin")
                    player.Heal(1);

                else if (EntityName == "potion degat")
                    player.DamageReceived(1);

                else if (EntityName == "portail teleportation")
                {
                    DejaCollecte = false;
                    Image.Show();
                    int newX = 0;int newY = 0;
                    while (player.Maze.MazeMatrix[newX / Maze.cellSize, newY / Maze.cellSize].IsWall || player.Maze.Entities[newX, newY] !=null)
                    {
                        Random random = new Random();
                        newX = random.Next(1,player.Maze.width-1) * Maze.cellSize;
                        newY = random.Next(1,player.Maze.height-1) * Maze.cellSize;
                    }
                    
                    //téléporter le joueur
                    player.Maze.Entities[player.X, player.Y] = null;
                    player.X = newX;
                    player.Y = newY;
                    player.Maze.Entities[newX, newY] = player;
                    player.Image.Location = new Point(newX, newY);

                    //teleporter le portail aussi
                    while (player.Maze.MazeMatrix[newX / Maze.cellSize, newY / Maze.cellSize].IsWall || player.Maze.StaticEntities[newX, newY] != null)
                    {
                        Random random = new Random();
                        newX = random.Next(1, player.Maze.width - 1) * Maze.cellSize;
                        newY = random.Next(1, player.Maze.height - 1) * Maze.cellSize;
                    }
                    player.Maze.StaticEntities[X, Y] = null;
                    X = newX; Y = newY;
                    Image.Location = new Point(X, Y);
                    player.Maze.StaticEntities[X, Y] = this;
                }
            }
        }
    }
}
