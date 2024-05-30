using Puck_Man_Game.src.PuckMan.Engine.Entities;
using Puck_Man_Game.src.PuckMan.Game;
using Puck_Man_Game.src.PuckMan.Game.Levels;
using Puck_Man_Game.src.PuckMan.UI.Screens;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers; // Importe le namespace System.Timers


namespace src.PuckMan.Game.Levels
{
    public class Maze
    {
        private static readonly Random random = new Random();
        public static int cellSize = 40;

        //on effectue des step de 2 en 2 car on ne veut intéragir que avec les nodes, step avec les connections
        public static int step = cellSize * 2;
        public Cell[,] MazeMatrix { get; set; }
        public Cell[,] VisitedNodes { get; set; }
        public Entity[,] Entities { get; set; }


        public int width;
        public int height;
        public int startX;
        public int startY;
        public int numGeneratedFragments;
        public int numberOfOpponents;
        public NouvellePartie MazeForm;

        public int GetValidCoordinates(int start, int end)
        {
            //une coordinate est valide si elle est impair et entre start et end
            int coordinate = random.Next(start, end);

            // Si le namebre aléatoire est pair, on l'incrémente de 1 pour le rendre impair
            if (coordinate % 2 == 0)
            {
                coordinate++;
            }
            return coordinate;
        }

        public int GetConnectionCoordinate(int node, int neighbors)
        {
            int connection;
            if (neighbors > node)
                connection = node + cellSize;
            else if (neighbors < node)
                connection = node - cellSize;
            else
                connection = node;
            return connection;
        }

        //return neighbors du dessus, du dessous, à droite, à gauche
        public Cell Top(int x, int y, int step)
        {
            if (y - step >= 0)
                return MazeMatrix[x / cellSize, (y - step) / cellSize];
            return null;
        }

        public Cell Bottom(int x, int y, int step)
        {
            if (y + step < height * cellSize)
                return MazeMatrix[x / cellSize, (y + step) / cellSize];
            return null;
        }

        public Cell Left(int x, int y, int step)
        {
            if (x - step >= 0)
                return MazeMatrix[(x - step) / cellSize, y / cellSize];
            return null;
        }

        public Cell Right(int x, int y, int step)
        {
            if (x + step < width * cellSize)
                return MazeMatrix[(x + step) / cellSize, y / cellSize];
            return null;
        }

        public bool IsWall(Cell node)
        {
            if (node != null)
                return node.IsWall;
            return false;
        }

        public void InitMaze()
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {

                    Cell cell = new Cell(x * cellSize, y * cellSize, "Cell");
                    MazeMatrix[x, y] = cell;

                    //on génére une bordure de mur solide sur les côtés
                    //et un semi quadrillage
                    if ((x == 0 || x == width - 1 || y == 0 || y == height - 1)
                        || ((x + y) % 2 == 0 && x % 2 == 0))
                    {
                        cell.Image.Image = Puck_Man_Game.Properties.Resources.mur;
                        cell.IsWall = true;
                    }
                    else if ((x + y) % 2 == 0 && x % 2 != 0)
                    {
                        cell.Image.Image = Puck_Man_Game.Properties.Resources.vide;
                        cell.IsWall = false;
                    }

                    //remplit 80% des connections avec des murs
                    else if (random.NextDouble() < 0.8)
                    {
                        MazeMatrix[x, y].IsWall = true;
                        MazeMatrix[x, y].Image.Image = Puck_Man_Game.Properties.Resources.mur;
                    }
                    else
                    {
                        MazeMatrix[x, y].IsWall = false;
                        MazeMatrix[x, y].Image.Image = Puck_Man_Game.Properties.Resources.vide;
                    }
                }
            }
        }
        
        public void RandomMazeGeneration()
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if ((x != 0 && y != 0 && x != width - 1 && y != height - 1)
                        && ((x + y) % 2 != 0))
                    {
                        if (random.NextDouble() < 0.5)
                            MazeMatrix[x, y].Image.Image = Puck_Man_Game.Properties.Resources.mur;
                        else
                            MazeMatrix[x, y].Image.Image = Puck_Man_Game.Properties.Resources.porte;
                    }
                }
            }
        }

        public void MazeGenerationByDFS()
        {
            VisitedNodes = new Cell[width * cellSize, height * cellSize];

            int startPositionX = GetValidCoordinates(1, width - 1);
            int startPositionY = GetValidCoordinates(1, height - 1);
            Cell node = MazeMatrix[startPositionX, startPositionY];

            startX = startPositionX;
            startY = startPositionY;

            // Marquer la Cell de départ comme visitée
            VisitedNodes[startPositionX * cellSize, startPositionY * cellSize] = node;

            // Créer une pile pour stocker les Cells à explorer
            Stack<Cell> pile = new Stack<Cell>();
            pile.Push(node);

            // Tant que la pile n'est step vide
            while (pile.Count > 0)
            {
                // Recuperer un node
                node = pile.Peek();

                List<Cell> unvisitedNeighbors = new List<Cell>();

                Cell topConnection = Top(node.X, node.Y, step);
                Cell bottomConnection = Bottom(node.X, node.Y, step);
                Cell leftConnection = Left(node.X, node.Y, step);
                Cell rightConnection = Right(node.X, node.Y, step);

                //on ajoute les neighborss valides non VisitedNodes
                if (topConnection != null && VisitedNodes[topConnection.X, (topConnection.Y)] == null)
                    unvisitedNeighbors.Add(topConnection);
                if (bottomConnection != null && VisitedNodes[bottomConnection.X, bottomConnection.Y] == null)
                    unvisitedNeighbors.Add(bottomConnection);
                if (leftConnection != null && VisitedNodes[leftConnection.X, leftConnection.Y] == null)
                    unvisitedNeighbors.Add(leftConnection);
                if (rightConnection != null && VisitedNodes[rightConnection.X, rightConnection.Y] == null)
                    unvisitedNeighbors.Add(rightConnection);

                // Si la Cell actuelle a des neighborss non VisitedNodes
                if (unvisitedNeighbors.Count > 0)
                {
                    //Choisit un neighbors aléatoire non visité
                    Cell neighbors = unvisitedNeighbors[random.Next(0, unvisitedNeighbors.Count)];

                    //coordinates de la liason entre le node et son neighbors
                    int connectionX = GetConnectionCoordinate(node.X, neighbors.X);
                    int connectionY = GetConnectionCoordinate(node.Y, neighbors.Y);

                    //on crée un chemin entre le node et son neighbors
                    MazeMatrix[connectionX / cellSize, connectionY / cellSize].IsWall = false;
                    MazeMatrix[connectionX / cellSize, connectionY / cellSize].Image.Image = Puck_Man_Game.Properties.Resources.vide;

                    //on marque le neighbors comme visité
                    VisitedNodes[neighbors.X, neighbors.Y] = neighbors;

                    //on met le neighbors dans la pile pour exploration future
                    pile.Push(neighbors);
                }
                else
                {
                    pile.Pop(); //si le node n'a plus de neighbors a exploré, on le depile
                }
            }
        }

        public void DisplayMazeMatrix()
        {
            string MazeMatrixString = "";
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    RemoveIsolatedWalls(x, y);
                    if (MazeMatrix[x, y].IsWall == true)
                        MazeMatrixString += "X ";
                    else
                        MazeMatrixString += ". ";

                    //on ajoute les Cells au formulaire (sinon aucun affichage)
                    MazeForm.Controls.Add(MazeMatrix[x, y].Image);
                }
                MazeMatrixString += "\n";
            }
            Debug.Write(MazeMatrix);
        }

        public void GenerateFragments(Type type, string name, int number)
        {
            while (number > 0)
            {
                int x = GetValidCoordinates(1, width - 1);
                int y = GetValidCoordinates(1, height - 1);
                // Vérifier s'il n'y a rien déjà à l'endroit prévu
                if (Entities[x * cellSize, y * cellSize] is null)
                {
                    Entity fragment = (Entity)Activator.CreateInstance(type, name, x * cellSize, y * cellSize);
                    MazeForm.Controls.Add(fragment.Image);
                    fragment.Image.BringToFront();
                    number -= 1;
                    Entities[x * cellSize, y * cellSize] = fragment;
                }
            }
        }
        public void GenerateEnemies(string name, int number)
        {
            while (number > 0)
            {
                int x = GetValidCoordinates(1, width - 1);
                int y = GetValidCoordinates(1, height - 1);

                // Vérifier si l'emplacement est vide
                if (Entities[x * cellSize, y * cellSize] is null)
                {
                    // Créer une instance de la classe Enemy avec les attributs spécifiques
                    Enemy enemy = new Enemy(name, 3, x * cellSize, y * cellSize, this); // Changer les valeurs par défaut si nécessaire

                    // Ajouter l'image de l'ennemi au formulaire
                    MazeForm.Controls.Add(enemy.Image);
                    enemy.Image.BringToFront();

                    // Décrémenter le nombre d'ennemis restants à générer
                    number -= 1;

                    // Ajouter l'ennemi à la matrice d'entités
                    Entities[x * cellSize, y * cellSize] = enemy;
                }
            }
        }
        
        public void RemoveIsolatedWalls(int x, int y)
        {
            if (x % 2 == 0 && y % 2 == 0)
            {
                if (!IsWall(Top(x * cellSize, y * cellSize, cellSize)) &&
                    !IsWall(Bottom(x * cellSize, y * cellSize, cellSize)) &&
                    !IsWall(Left(x * cellSize, y * cellSize, cellSize)) &&
                    !IsWall(Right(x * cellSize, y * cellSize, cellSize)))
                {
                    MazeMatrix[x, y].IsWall = false;
                    MazeMatrix[x, y].Image.Image = Puck_Man_Game.Properties.Resources.coeur;
                }
            }
        }

        public Maze(NouvellePartie form, int mazeWidth, int mazeHeight)
        {
            MazeForm = form;
            width = mazeWidth;
            height = mazeHeight;
            MazeMatrix = new Cell[width, height];
            Entities = new Entity[width * cellSize, height * cellSize];
            numGeneratedFragments = 5;
            numberOfOpponents = 2;
            InitMaze();
            //RandomMazeGeneration();
            MazeGenerationByDFS();
            DisplayMazeMatrix();
        }
    }
}
