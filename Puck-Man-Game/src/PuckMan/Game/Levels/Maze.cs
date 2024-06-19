using Puck_Man_Game.src.PuckMan.Engine.Entities;
using Puck_Man_Game.src.PuckMan.Game;
using Puck_Man_Game.src.PuckMan.Game.Entities;
using Puck_Man_Game.src.PuckMan.Game.Levels;
using Puck_Man_Game.src.PuckMan.UI.Screens;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Drawing.Printing;
using System.Xml; // Importe le namespace System.Timers


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
        public List<Enemy> EnemyList { get; set; }
        public List<Collectable> FragmentList { get; set; }
        public Collectable[,] StaticEntities{ get; set; }
        public List<Cell> EulerianPath { get; private set; }

        public string stringMazeMatrix;
        public int width;
        public int height;
        public int startX;
        public int startY;
        public FrmNouvellePartie MazeForm;
        public Maze(FrmNouvellePartie form, int mazeWidth, int mazeHeight)
        {
            MazeForm = form;
            width = mazeWidth;
            height = mazeHeight;
            MazeMatrix = new Cell[width, height];
            Entities = new Entity[width * cellSize, height * cellSize];
            StaticEntities = new Collectable[width * cellSize, height * cellSize];
            EnemyList = new List<Enemy>();
            FragmentList = new List<Collectable>();

            InitMaze();
            if (form.StoryMod)
                MazeGenerationFromMatrix(MazeForm.Level);
            else
                MazeGenerationByDFS();
            DisplayMaze();
        }

        public int GetValidCoordinates(int start, int end)
        {
            //une coordinate est valide si elle est impair et entre start et end
            int coordinate = random.Next(start, end);
            
            // Si le nombre aléatoire est pair, on l'incrémente de 1 pour le rendre impair
            if (coordinate % 2 == 0)
                coordinate++;
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

        //return respectivement le neighbor du dessus, du dessous, à gauche, à droite
        public Cell Top(int x, int y, int step)
        {
            int newY = (y - step) / cellSize;
            if (newY >= 0 && x / cellSize < width)
                return MazeMatrix[x / cellSize, newY];
            return null;
        }

        public Cell Bottom(int x, int y, int step)
        {
            int newY = (y + step) / cellSize;
            if (newY < height && x / cellSize < width)
                return MazeMatrix[x / cellSize, newY];
            return null;
        }

        public Cell Left(int x, int y, int step)
        {
            int newX = (x - step) / cellSize;
            if (newX >= 0 && y / cellSize < height)
                return MazeMatrix[newX, y / cellSize];
            return null;
        }

        public Cell Right(int x, int y, int step)
        {
            int newX = (x + step) / cellSize;
            if (newX < width && y / cellSize < height)
                return MazeMatrix[newX, y / cellSize];
            return null;
        }

        //return les voisins non null
        public List<Cell> GetNeighborCells(int X, int Y)
        {
            List<Cell> neighbors = new List<Cell>();
            Cell top = Top(X, Y, cellSize);
            Cell bottom = Bottom(X, Y, cellSize);
            Cell left = Left(X, Y, cellSize);
            Cell right = Right(X, Y, cellSize);
            if (top != null) neighbors.Add(top);
            if (bottom != null) neighbors.Add(bottom);
            if (left != null) neighbors.Add(left);
            if (right != null) neighbors.Add(right);
            return neighbors;
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
                    cell.IsWall = false;
                    cell.Image.Image = Puck_Man_Game.Properties.Resources.vide;
                    
                    if (!MazeForm.StoryMod)
                    {
                        //on génére une bordure de mur solide sur les côtés et un semi quadrillage
                        if ((x == 0 || x == width - 1 || y == 0 || y == height - 1)
                            || ((x + y) % 2 == 0 && x % 2 == 0))
                        {
                            cell.Image.Image = Puck_Man_Game.Properties.Resources.murModeInfini;
                            cell.IsWall = true;
                        }
                        else if ((x + y) % 2 == 0 && x % 2 != 0)
                        {
                            cell.Image.Image = Puck_Man_Game.Properties.Resources.vide;
                            cell.IsWall = false;
                        }

                        //remplit 80% des connections avec des murs
                        else if (random.NextDouble() < 0.80)
                        {
                            MazeMatrix[x, y].IsWall = true;
                            MazeMatrix[x, y].Image.Image = Puck_Man_Game.Properties.Resources.murModeInfini;
                        }
                        else
                        {
                            MazeMatrix[x, y].IsWall = false;
                            MazeMatrix[x, y].Image.Image = Puck_Man_Game.Properties.Resources.vide;
                        }
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
                            MazeMatrix[x, y].Image.Image = Puck_Man_Game.Properties.Resources.murModeInfini;
                        else
                            MazeMatrix[x, y].Image.Image = Puck_Man_Game.Properties.Resources.vide;
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

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                    RemoveIsolatedWalls(x, y);
            }

        }

        public void MazeGenerationFromMatrix(int niveau)
        {
            string filePath = "src/database/matricesNiveaux.txt";
            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath, Encoding.UTF8);
                bool isCorrectLevel = false;
                List<string> matrixLines = new List<string>();

                foreach (string line in lines)
                {
                    // Vérifiez si nous avons trouvé le niveau correct
                    if (line == niveau.ToString())
                    {
                        isCorrectLevel = true;
                        continue;
                    }

                    // Si nous sommes dans le bon niveau, ajoutez les lignes de la matrice
                    if (isCorrectLevel)
                    {
                        if (string.IsNullOrWhiteSpace(line))
                            break; // Terminez la lecture lorsque vous trouvez une ligne vide après la matrice
                        matrixLines.Add(line);
                    }
                }
                if (matrixLines.Count > 0)
                    GenerateMaze(matrixLines);
            }
        }

        private void GenerateMaze(List<string> matrixLines)
        {
            for (int y = 0; y < matrixLines.Count; y++)
            {
                string[] elements = matrixLines[y].Split(' ');
                for (int x = 0; x < elements.Length-1; x++)
                {
                    switch (elements[x][0])
                    {
                        case 'X':
                            MazeMatrix[x, y].IsWall = true;
                            MazeMatrix[x, y].Image.Image = Puck_Man_Game.Properties.Resources.murModeHistoire;
                            MazeForm.Controls.Add(MazeMatrix[x, y].Image);
                            MazeForm.Controls.Add(MazeMatrix[x, y].Image);
                            break;
                        case '.':
                            MazeMatrix[x, y].IsWall = false;
                            MazeMatrix[x, y].Image.Image = Puck_Man_Game.Properties.Resources.vide;
                            MazeForm.Controls.Add(MazeMatrix[x, y].Image);
                            break;
                        case 'J':
                            startX = x;
                            startY = y;
                            break;
                        case 'D':
                            GenerateCollectable("fragment degat", 1, x, y);
                            break;
                        case 'F':
                            GenerateCollectable("fragment", 1, x, y);
                            break;
                        case 'E':
                            GenerateEnemy("égaré", 1, x, y);
                            break;
                        case 'B':
                            GenerateEnemy("égaré berserker", 1, x, y);
                            break;
                        case 'H':
                            GenerateCollectable("soin", 1, x, y);
                            break;
                        case 'T':
                            GenerateCollectable("portail teleportation", 1, x, y);
                            break;
                    }
                }
            }
        }

        public void ReplaceMatrixWithEntity(string entityCodeName, int X, int Y)
        {
            int index = (Y * (width * 2 + 1)) + (X * 2);
            if (index < stringMazeMatrix.Length)
                stringMazeMatrix = stringMazeMatrix.Substring(0, index) + entityCodeName + stringMazeMatrix.Substring(index + 1);
        }
        public string DisplayMazeMatrix()
        {
            ReplaceMatrixWithEntity("J", startX, startY);
            foreach(Enemy enemy in EnemyList)
            {
                ReplaceMatrixWithEntity("E", enemy.X/cellSize, enemy.Y / cellSize);
            }
            foreach (Collectable fragment in FragmentList)
            {
                ReplaceMatrixWithEntity("F", fragment.X / cellSize, fragment.Y / cellSize);
            }

            foreach (Entity entity in Entities)
            {
                if (entity!= null)
                {
                    string codeName = "F";
                    if (entity.EntityName == "égaré") codeName = "E";
                    if (entity.EntityName == "égaré berserker") codeName = "B";
                    if (entity.EntityName == "soin") codeName = "H";
                    if (entity.EntityName == "fragment degat") codeName = "D";
                    if (entity.EntityName == "portail teleportation") codeName = "T";
                    if (entity is Player) codeName = "J";
                    ReplaceMatrixWithEntity(codeName, entity.X / cellSize, entity.Y / cellSize);
                }
                    
            }

            for (int i = 0; i < stringMazeMatrix.Length; i++)
                Debug.Write(stringMazeMatrix[i]);
            return stringMazeMatrix;
        }

        public void DisplayMaze()
        {
            string strMazeMatrix = "";
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (MazeMatrix[x, y].IsWall == true)
                        strMazeMatrix += "X ";
                    else
                        strMazeMatrix += ". ";

                    //on ajoute les Cells au formulaire (sinon aucun affichage)
                    MazeForm.Controls.Add(MazeMatrix[x, y].Image);
                }
                strMazeMatrix += "\n";
            }
            stringMazeMatrix = strMazeMatrix;
        }

        public void GenerateCollectable(string name, int number, int x, int y)
        {
            while (number > 0)
            {
                // Vérifier s'il n'y a pas déjà une entité à l'endroit choisi
                if (StaticEntities[x * cellSize, y * cellSize] is null && (x != startX || y != startY))
                {
                    Collectable instance = new Collectable(name, x * cellSize, y * cellSize);
                    if (name == "fragment")
                        FragmentList.Add(instance);
                    MazeForm.Controls.Add(instance.Image);
                    instance.Image.BringToFront();
                    number -= 1;
                    StaticEntities[x * cellSize, y * cellSize] = instance;
                }
                else
                {
                    x = GetValidCoordinates(1, width - 1);
                    y = GetValidCoordinates(1, height - 1);
                }
            }
       

    }


    public void GenerateEnemy(string name, int number, int x, int y)
        {
            while (number > 0)
            {
                // Vérifier s'il n'y a pas déjà une entité à l'endroit choisi
                if (Entities[x * cellSize, y * cellSize] is null)
                {
                    Enemy instance;
                    switch (name)
                    {
                        case "égaré":
                            instance = new ConfusedEnemy(x * cellSize, y * cellSize, this);
                            break;
                        case "égaré berserker":
                            instance = new BerserkerEnemy(x * cellSize, y * cellSize, this);
                            break;
                        //case "Égaré Standard":
                        //    instance = new StandardEnemy(x * cellSize, y * cellSize, this);
                        //    break;
                        //case "Égaré Éclaireur":
                        //    instance = new ScoutEnemy(x * cellSize, y * cellSize, this);
                        //    break;
                        //case "spec":
                        //    instance = new SpectralEnemy(x * cellSize, y * cellSize, this);
                        //    break;
                        //case "Égaré Enchanteur":
                        //    instance = new EnchanterEnemy(x * cellSize, y * cellSize, this);
                        //    break;
                        //case "Système 0":
                        //    instance = new System0Enemy(x * cellSize, y * cellSize, this);
                        //    break;
                        //case "Système":
                        //    instance = new SystemEnemy(x * cellSize, y * cellSize, this);
                        //    break;
                        default:
                            throw new ArgumentException("Type d'ennemi non reconnu", nameof(name));
                    }

                    EnemyList.Add(instance);
                    MazeForm.Controls.Add(instance.Image);
                    instance.Image.BringToFront();
                    number -= 1;
                    Entities[x * cellSize, y * cellSize] = instance;
                }
                else
                {
                    x = GetValidCoordinates(1, width - 1);
                    y = GetValidCoordinates(1, height - 1);
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
                    MazeMatrix[x, y].Image.Image = Puck_Man_Game.Properties.Resources.vide;
                    if (random.NextDouble()>0.3)
                        GenerateCollectable("soin", 1, x, y);
                }
            }
        }
    }
}
