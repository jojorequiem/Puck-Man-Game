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
using System.Xml;
using System.Xml.Linq;
using System.Drawing;

namespace src.PuckMan.Game.Levels
{
    /// <summary>
    /// Classe représentant le labyrinthe du jeu.
    /// </summary>
    public class Maze
    {
        private static readonly Random random = new Random(); // Générateur de nombres aléatoires
        public static int cellSize = 40; // Taille d'une cellule en pixels

        // Step pour le parcours du labyrinthe, utilisé pour les connexions entre cellules
        public static int step = cellSize * 2;
        public Player Player { get; private set; }
        public Cell[,] MazeMatrix { get; set; } // Matrice des cellules du labyrinthe
        public Cell[,] VisitedNodes { get; set; } // Matrice des noeuds visités
        public Entity[,] Entities { get; set; } // Matrice des entités
        public List<Enemy> EnemyList { get; set; } // Liste des ennemis
        public List<Collectable> FragmentList { get; set; } // Liste des objets collectables
        public Collectable[,] StaticEntities { get; set; } // Matrice des entités statiques
        public List<Cell> EulerianPath { get; private set; } // Chemin eulérien du labyrinthe

        public string stringMazeMatrix; // Représentation en chaîne de caractères du labyrinthe
        public int width; // Largeur du labyrinthe
        public int height; // Hauteur du labyrinthe
        public int startX; // Coordonnée X de départ
        public int startY; // Coordonnée Y de départ
        public FrmNewGame MazeForm; // Formulaire de jeu contenant le labyrinthe

        /// <summary>
        /// Constructeur de la classe Maze.
        /// </summary>
        /// <param name="form">Formulaire de jeu contenant le labyrinthe.</param>
        /// <param name="mazeWidth">Largeur du labyrinthe.</param>
        /// <param name="mazeHeight">Hauteur du labyrinthe.</param>
        public Maze(FrmNewGame form, int mazeWidth, int mazeHeight)
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

        public Point PlayerPosition()
        {
            return new Point(startX, startY);
        }

        /// <summary>
        /// Obtient des coordonnées valides entre une valeur de départ et une valeur de fin.
        /// </summary>
        /// <param name="start">Valeur de départ.</param>
        /// <param name="end">Valeur de fin.</param>
        /// <returns>Coordonnée valide (impair) entre start et end.</returns>
        public int GetValidCoordinates(int start, int end)
        {
            int coordinate = random.Next(start, end);
            if (coordinate % 2 == 0)
                coordinate++;
            return coordinate;
        }

        /// <summary>
        /// Obtient la coordonnée de connexion entre un noeud et son voisin.
        /// </summary>
        /// <param name="node">Coordonnée du noeud.</param>
        /// <param name="neighbors">Coordonnée du voisin.</param>
        /// <returns>Coordonnée de connexion entre le noeud et le voisin.</returns>
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

        /// <summary>
        /// Obtient la cellule voisine en haut de la cellule actuelle.
        /// </summary>
        /// <param name="x">Coordonnée X de la cellule actuelle.</param>
        /// <param name="y">Coordonnée Y de la cellule actuelle.</param>
        /// <param name="step">Step pour la connexion.</param>
        /// <returns>Cellule voisine en haut.</returns>
        public Cell Top(int x, int y, int step)
        {
            int newY = (y - step) / cellSize;
            if (newY >= 0 && x / cellSize < width)
                return MazeMatrix[x / cellSize, newY];
            return null;
        }

        /// <summary>
        /// Obtient la cellule voisine en bas de la cellule actuelle.
        /// </summary>
        /// <param name="x">Coordonnée X de la cellule actuelle.</param>
        /// <param name="y">Coordonnée Y de la cellule actuelle.</param>
        /// <param name="step">Step pour la connexion.</param>
        /// <returns>Cellule voisine en bas.</returns>
        public Cell Bottom(int x, int y, int step)
        {
            int newY = (y + step) / cellSize;
            if (newY < height && x / cellSize < width)
                return MazeMatrix[x / cellSize, newY];
            return null;
        }

        /// <summary>
        /// Obtient la cellule voisine à gauche de la cellule actuelle.
        /// </summary>
        /// <param name="x">Coordonnée X de la cellule actuelle.</param>
        /// <param name="y">Coordonnée Y de la cellule actuelle.</param>
        /// <param name="step">Step pour la connexion.</param>
        /// <returns>Cellule voisine à gauche.</returns>
        public Cell Left(int x, int y, int step)
        {
            int newX = (x - step) / cellSize;
            if (newX >= 0 && y / cellSize < height)
                return MazeMatrix[newX, y / cellSize];
            return null;
        }

        /// <summary>
        /// Obtient la cellule voisine à droite de la cellule actuelle.
        /// </summary>
        /// <param name="x">Coordonnée X de la cellule actuelle.</param>
        /// <param name="y">Coordonnée Y de la cellule actuelle.</param>
        /// <param name="step">Step pour la connexion.</param>
        /// <returns>Cellule voisine à droite.</returns>
        public Cell Right(int x, int y, int step)
        {
            int newX = (x + step) / cellSize;
            if (newX < width && y / cellSize < height)
                return MazeMatrix[newX, y / cellSize];
            return null;
        }


        /// <summary>
        /// Obtient les cellules voisines d'une position donnée dans le labyrinthe.
        /// </summary>
        /// <param name="X">Coordonnée X de la cellule.</param>
        /// <param name="Y">Coordonnée Y de la cellule.</param>
        /// <returns>Liste des cellules voisines valides.</returns>
        public List<Cell> GetNeighborCells(int X, int Y)
        {
            List<Cell> neighbors = new List<Cell>();
            Cell top = Top(X, Y, cellSize);
            Cell bottom = Bottom(X, Y, cellSize);
            Cell left = Left(X, Y, cellSize);
            Cell right = Right(X, Y, cellSize);

            // Ajout des voisins non null à la liste
            if (top != null) neighbors.Add(top);
            if (bottom != null) neighbors.Add(bottom);
            if (left != null) neighbors.Add(left);
            if (right != null) neighbors.Add(right);

            return neighbors;
        }

        /// <summary>
        /// Vérifie si une cellule est un mur.
        /// </summary>
        /// <param name="node">Cellule à vérifier.</param>
        /// <returns>Vrai si la cellule est un mur, sinon faux.</returns>
        public bool IsWall(Cell node)
        {
            if (node != null)
                return node.IsWall;
            return false;
        }
        /// <summary>
        /// Initialise le labyrinthe en créant les cellules et en définissant leurs propriétés initiales.
        /// </summary>
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
                        // Génère une bordure de mur solide sur les côtés et un semi-quadrillage
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
                        // Remplit 83% des connections avec des murs
                        else if (random.NextDouble() < 0.90)
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
        /// <summary>
        /// Génère aléatoirement le labyrinthe en ajustant les murs et les espaces vides. (SAE 2.2)
        /// </summary>
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

        /// <summary>
        /// Génère le labyrinthe en utilisant l'algorithme de recherche en profondeur (DFS).
        /// </summary>
        public void MazeGenerationByDFS()
        {
            VisitedNodes = new Cell[width * cellSize, height * cellSize];

            // Sélection d'une position de départ aléatoire
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

            // Tant que la pile n'est pas vide
            while (pile.Count > 0)
            {
                // Récupération du nœud en haut de la pile
                node = pile.Peek();

                List<Cell> unvisitedNeighbors = new List<Cell>();

                Cell topConnection = Top(node.X, node.Y, step);
                Cell bottomConnection = Bottom(node.X, node.Y, step);
                Cell leftConnection = Left(node.X, node.Y, step);
                Cell rightConnection = Right(node.X, node.Y, step);

                // Ajout des voisins valides non visités
                if (topConnection != null && VisitedNodes[topConnection.X, (topConnection.Y)] == null)
                    unvisitedNeighbors.Add(topConnection);
                if (bottomConnection != null && VisitedNodes[bottomConnection.X, bottomConnection.Y] == null)
                    unvisitedNeighbors.Add(bottomConnection);
                if (leftConnection != null && VisitedNodes[leftConnection.X, leftConnection.Y] == null)
                    unvisitedNeighbors.Add(leftConnection);
                if (rightConnection != null && VisitedNodes[rightConnection.X, rightConnection.Y] == null)
                    unvisitedNeighbors.Add(rightConnection);

                // Si le nœud actuel a des voisins non visités
                if (unvisitedNeighbors.Count > 0)
                {
                    // Choix d'un voisin aléatoire non visité
                    Cell neighbors = unvisitedNeighbors[random.Next(0, unvisitedNeighbors.Count)];

                    // Coordonnées de la connexion entre le nœud et son voisin
                    int connectionX = GetConnectionCoordinate(node.X, neighbors.X);
                    int connectionY = GetConnectionCoordinate(node.Y, neighbors.Y);

                    // Création d'un chemin entre le nœud et son voisin
                    MazeMatrix[connectionX / cellSize, connectionY / cellSize].IsWall = false;
                    MazeMatrix[connectionX / cellSize, connectionY / cellSize].Image.Image = Puck_Man_Game.Properties.Resources.vide;

                    // Marquer le voisin comme visité
                    VisitedNodes[neighbors.X, neighbors.Y] = neighbors;

                    // Ajouter le voisin à la pile pour exploration future
                    pile.Push(neighbors);
                }
                else
                {
                    pile.Pop(); // Si le nœud n'a plus de neighbors à explorer, le retirer de la pile
                }
            }

            // Retirer les murs isolés après la génération du labyrinthe
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                    RemoveIsolatedWalls(x, y);
            }
        }

        /// <summary>
        /// Génère le labyrinthe à partir d'une matrice spécifiée dans un fichier texte.
        /// </summary>
        /// <param name="niveau">Niveau du labyrinthe à générer.</param>
        public void MazeGenerationFromMatrix(int niveau)
        {
            // Chemin du fichier contenant les données du labyrinthe
            string filePath = "src/database/MazeStoryMode.txt";

            // Vérifie si le fichier existe
            if (File.Exists(filePath))
            {
                // Lecture de toutes les lignes du fichier
                string[] lines = File.ReadAllLines(filePath, Encoding.UTF8);

                bool isCorrectLevel = false;
                List<string> matrixLines = new List<string>();

                // Parcours des lignes du fichier
                foreach (string line in lines)
                {
                    // Vérifie si nous avons trouvé le niveau correct dans le fichier
                    if (line == niveau.ToString())
                    {
                        isCorrectLevel = true;
                        continue;
                    }

                    // Si nous sommes dans le bon niveau, ajoutons les lignes de la matrice
                    if (isCorrectLevel)
                    {
                        if (string.IsNullOrWhiteSpace(line))
                            break; // Arrête la lecture lorsqu'une ligne vide est rencontrée après la matrice

                        matrixLines.Add(line);
                    }
                }

                // Si des lignes de matrice ont été récupérées, générer le labyrinthe
                if (matrixLines.Count > 0)
                    GenerateMaze(matrixLines);
            }
        }

        /// <summary>
        /// Génère le labyrinthe en utilisant les lignes de matrice spécifiées.
        /// </summary>
        /// <param name="matrixLines">Lignes de la matrice représentant le labyrinthe.</param>
        private void GenerateMaze(List<string> matrixLines)
        {
            for (int y = 0; y < matrixLines.Count; y++)
            {
                // Divise la ligne en éléments séparés par un espace
                string[] elements = matrixLines[y].Split(' ');

                for (int x = 0; x < elements.Length - 1; x++)
                {
                    // Traite chaque élément en fonction de son caractère spécifique
                    switch (elements[x][0])
                    {
                        case 'X': // Mur
                            MazeMatrix[x, y].IsWall = true;
                            MazeMatrix[x, y].Image.Image = Puck_Man_Game.Properties.Resources.murModeHistoire;
                            MazeForm.Controls.Add(MazeMatrix[x, y].Image);
                            break;
                        case '.': // Espace vide
                            MazeMatrix[x, y].IsWall = false;
                            MazeMatrix[x, y].Image.Image = Puck_Man_Game.Properties.Resources.vide;
                            MazeForm.Controls.Add(MazeMatrix[x, y].Image);
                            break;
                        case 'J': // Position de départ du joueur
                            startX = x;
                            startY = y;
                            break;
                        case 'D': // Fragment de dégât
                            GenerateCollectable("fragment degat", 1, x, y);
                            break;
                        case 'F': // Fragment normal
                            GenerateCollectable("fragment", 1, x, y);
                            break;
                        case 'S': // Ennemi égaré
                            GenerateEnemy("égaré standard", 1, x, y);
                            break;
                        case 'E': // Ennemi égaré
                            GenerateEnemy("égaré", 1, x, y);
                            break;
                        case 'B': // Ennemi égaré berserker
                            GenerateEnemy("égaré berserker", 1, x, y);
                            break;
                        case 'H': // Fragment de soin
                            GenerateCollectable("soin", 1, x, y);
                            break;
                        case 'T': // Portail de téléportation
                            GenerateCollectable("portail teleportation", 1, x, y);
                            break;
                        case 'Z':
                            GenerateEnemy("égaré dfs", 1, x, y);
                            break;
                        case 'O':
                            GenerateEnemy("égaré bfs", 1, x, y);
                            break;
                        default:
                            throw new ArgumentException("Lettre non reconnu");
                    }
                }
            }
        }

        /// <summary>
        /// Remplace la position de la matrice par le code d'entité spécifié.
        /// </summary>
        /// <param name="entityCodeName">Code d'entité à placer dans la matrice.</param>
        /// <param name="X">Coordonnée X dans la matrice.</param>
        /// <param name="Y">Coordonnée Y dans la matrice.</param>
        public void ReplaceMatrixWithEntity(string entityCodeName, int X, int Y)
        {
            // Calcul de l'index dans la chaîne représentant la matrice
            int index = (Y * (width * 2 + 1)) + (X * 2);

            // Vérification des limites
            if (index < stringMazeMatrix.Length)
                stringMazeMatrix = stringMazeMatrix.Substring(0, index) + entityCodeName + stringMazeMatrix.Substring(index + 1);
        }


        /// <summary>
        /// Construit une représentation textuelle du labyrinthe pour affichage.
        /// </summary>
        /// <returns>Chaîne représentant le labyrinthe.</returns>
        public string DisplayMazeMatrix()
        {
            // Remplacer les positions de départ du joueur, des ennemis et des collectables dans la matrice
            ReplaceMatrixWithEntity("J", startX, startY);
            foreach (Enemy enemy in EnemyList)
            {
                ReplaceMatrixWithEntity("E", enemy.X / cellSize, enemy.Y / cellSize);
            }
            foreach (Collectable fragment in FragmentList)
            {
                ReplaceMatrixWithEntity("F", fragment.X / cellSize, fragment.Y / cellSize);
            }

            // Remplacer les entités génériques dans la matrice
            foreach (Entity entity in Entities)
            {
                if (entity != null)
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

            // Affichage de la matrice dans la console (pour le débogage)
            for (int i = 0; i < stringMazeMatrix.Length; i++)
                Debug.Write(stringMazeMatrix[i]);

            return stringMazeMatrix;
        }

        /// <summary>
        /// Affiche visuellement le labyrinthe dans le formulaire.
        /// </summary>
        public void DisplayMaze()
        {
            string strMazeMatrix = "";

            // Construction de la représentation textuelle du labyrinthe
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (MazeMatrix[x, y].IsWall == true)
                        strMazeMatrix += "X ";
                    else
                        strMazeMatrix += ". ";

                    // Ajout des images des Cells au formulaire pour l'affichage visuel
                    MazeForm.Controls.Add(MazeMatrix[x, y].Image);
                }
                strMazeMatrix += "\n";
            }

            stringMazeMatrix = strMazeMatrix; // Stockage de la représentation textuelle
        }

        /// <summary>
        /// Génère un collectable à la position spécifiée dans le labyrinthe.
        /// </summary>
        /// <param name="name">Nom du collectable.</param>
        /// <param name="number">Nombre de collectables à générer.</param>
        /// <param name="x">Coordonnée X du collectable.</param>
        /// <param name="y">Coordonnée Y du collectable.</param>
        public void GenerateCollectable(string name, int number, int x, int y)
        {
            while (number > 0)
            {
                // Vérification si la position est libre et différente du point de départ
                if (StaticEntities[x * cellSize, y * cellSize] is null && (x != startX || y != startY))
                {
                    Collectable instance = new Collectable(name, x * cellSize, y * cellSize);
                    if (name == "fragment")
                        FragmentList.Add(instance);
                    // Ajout de l'image du collectable au formulaire
                    MazeForm.Controls.Add(instance.Image);
                    instance.Image.BringToFront();

                    number -= 1;
                    StaticEntities[x * cellSize, y * cellSize] = instance; // Enregistrement de l'entité statique
                }
                else
                {
                    // Génération de nouvelles coordonnées valides si la position est déjà occupée
                    x = GetValidCoordinates(1, width - 1);
                    y = GetValidCoordinates(1, height - 1);
                }
            }
        }


        /// <summary>
        /// Génère un ennemi à la position spécifiée dans le labyrinthe.
        /// </summary>
        /// <param name="name">Nom de l'ennemi.</param>
        /// <param name="number">Nombre d'ennemis à générer.</param>
        /// <param name="x">Coordonnée X de l'ennemi.</param>
        /// <param name="y">Coordonnée Y de l'ennemi.</param>
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
                        case "égaré standard":
                            instance = new StandardEnemy(x * cellSize, y * cellSize, this);
                            break;
                        case "égaré dfs":
                            instance = new DFSEnemy(x * cellSize, y * cellSize, this);
                            break;
                        case "égaré bfs":
                            instance = new ScoutEnemy(x * cellSize, y * cellSize, this);
                            break;
                        case "égaré dijkstra":
                            instance = new DijkstraEnemy(x * cellSize, y * cellSize, this);
                            break;
                        default:
                            throw new ArgumentException("Type d'ennemi non reconnu", nameof(name));
                    }

                    EnemyList.Add(instance);
                    MazeForm.Controls.Add(instance.Image);
                    instance.Image.BringToFront();
                    number -= 1;
                    Entities[x * cellSize, y * cellSize] = instance; // Enregistrement de l'entité dans la matrice
                }
                else
                {
                    // Génération de nouvelles coordonnées valides si la position est déjà occupée
                    x = GetValidCoordinates(1, width - 1);
                    y = GetValidCoordinates(1, height - 1);
                }
            }
        }


        /// <summary>
        /// Supprime les murs isolés aux coordonnées spécifiées dans le labyrinthe.
        /// </summary>
        /// <param name="x">Coordonnée X du mur.</param>
        /// <param name="y">Coordonnée Y du mur.</param>
        public void RemoveIsolatedWalls(int x, int y)
        {
            if (x % 2 == 0 && y % 2 == 0)
            {
                // Vérifier si les murs adjacents ne sont pas présents
                if (!IsWall(Top(x * cellSize, y * cellSize, cellSize)) &&
                    !IsWall(Bottom(x * cellSize, y * cellSize, cellSize)) &&
                    !IsWall(Left(x * cellSize, y * cellSize, cellSize)) &&
                    !IsWall(Right(x * cellSize, y * cellSize, cellSize)))
                {
                    // Supprimer le mur et mettre à jour visuellement
                    MazeMatrix[x, y].IsWall = false;
                    MazeMatrix[x, y].Image.Image = Puck_Man_Game.Properties.Resources.vide;

                    // Générer un collectable avec une certaine probabilité
                    if (random.NextDouble() > 0.3)
                        GenerateCollectable("soin", 1, x, y);
                }
            }
        }
    }
}