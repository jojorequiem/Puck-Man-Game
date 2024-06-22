using Puck_Man_Game.src.PuckMan.Game.Entities;
using Puck_Man_Game.src.PuckMan.Game.Levels;
using src.PuckMan.Game.Levels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Puck_Man_Game.src.PuckMan.Engine.Entities
{
    /// <summary>
    /// Classe abstraite représentant un ennemi dans le jeu.
    /// </summary>
    public abstract class Enemy : Entity
    {
        /// <summary>
        /// Classe de l'ennemi (type d'ennemi).
        /// </summary>
        public string EnemyClass { get; set; }

        /// <summary>
        /// Dégâts infligés par l'ennemi.
        /// </summary>
        public int Damage { get; set; }

        /// <summary>
        /// Labyrinthe dans lequel se trouve l'ennemi.
        /// </summary>
        public Maze Maze { get; set; }

        /// <summary>
        /// Timer pour déplacer l'ennemi périodiquement.
        /// </summary>
        public Timer moveEnemyTimer;

        // Dernière direction prise par l'ennemi
        public Point previousDirection;

        // Dictionnaire pour stocker le temps du dernier attaque pour chaque ennemi
        private readonly Dictionary<Enemy, DateTime> lastAttackTime = new Dictionary<Enemy, DateTime>();

        // Délai de récupération entre deux attaques
        private readonly TimeSpan attackCooldown = TimeSpan.FromSeconds(10);

        // Indicateur pour savoir si l'ennemi fait face à droite
        private bool isFacingRight = true;

        /// <summary>
        /// Initialise une nouvelle instance de la classe Enemy.
        /// </summary>
        /// <param name="name">Nom de l'ennemi.</param>
        /// <param name="x">Position X initiale de l'ennemi.</param>
        /// <param name="y">Position Y initiale de l'ennemi.</param>
        /// <param name="maze">Labyrinthe dans lequel l'ennemi se trouve.</param>
        public Enemy(string name, int x, int y, Maze maze) : base(x, y, name)
        {
            lastAttackTime[this] = DateTime.MinValue;
            HP = 3;
            Maze = maze;
            EntitySpeed = Maze.cellSize;
            previousDirection = new Point(0, 0);
        }

        /// <summary>
        /// Déplace l'ennemi dans une direction valide.
        /// </summary>
        public virtual void Move()
        {
            List<Point> possibleMoves = new List<Point>();

            // Récupère les directions possibles pour le déplacement
            foreach (Point direction in GetPossibleDirections())
            {
                if (!CheckWallCollision(direction.X * Maze.cellSize, direction.Y * Maze.cellSize))
                    possibleMoves.Add(direction);
            }

            bool dontMove = false;
            if (possibleMoves.Count > 0)
            {
                // Exclure la direction opposée à la précédente pour éviter les allers-retours
                Point oppositePreviousDirection = new Point(-previousDirection.X, -previousDirection.Y);
                possibleMoves.Remove(oppositePreviousDirection);

                // Si après avoir exclu la direction opposée, il n'y a plus de mouvements possibles
                if (possibleMoves.Count == 0)
                    possibleMoves.Add(oppositePreviousDirection); // Réajouter la direction opposée

                Random random = new Random();
                Point selectedMove = possibleMoves[random.Next(possibleMoves.Count)];

                // Chercher une case qui n'est pas déjà occupée
                while (possibleMoves.Count > 0 && (Maze.Entities[X + selectedMove.X * Maze.cellSize, Y + selectedMove.Y * Maze.cellSize] != null))
                {
                    var targetEntity = Maze.Entities[X + selectedMove.X * Maze.cellSize, Y + selectedMove.Y * Maze.cellSize];
                    if (targetEntity is Player player &&
                        (!lastAttackTime.ContainsKey(this) || DateTime.Now - lastAttackTime[this] > attackCooldown))
                    {
                        player.DamageReceived(Damage); // Inflige des dégâts au joueur
                        dontMove = true;
                        lastAttackTime[this] = DateTime.Now;
                    }
                    possibleMoves.Remove(selectedMove);
                    if (possibleMoves.Count > 0)
                        selectedMove = possibleMoves[random.Next(possibleMoves.Count)];
                }

                // Si après avoir exclu la direction opposée, il n'y a plus de mouvements possibles
                if (possibleMoves.Count == 0)
                    selectedMove = oppositePreviousDirection; // Réajouter la direction opposée

                // Déplace l'ennemi si la case cible est libre
                if (!dontMove && Maze.Entities[X + selectedMove.X * Maze.cellSize, Y + selectedMove.Y * Maze.cellSize] == null)
                {
                    MoveEnemy(selectedMove.X * Maze.cellSize, selectedMove.Y * Maze.cellSize);
                    previousDirection = selectedMove;
                }
            }
        }

        /// <summary>
        /// Gère le déplacement de l'ennemi à chaque tick du timer.
        /// </summary>
        public void MoveEnemyTimer_Tick(object sender, EventArgs e)
        {
            Move();
        }

        /// <summary>
        /// Obtient les directions possibles pour le déplacement.
        /// </summary>
        /// <returns>Liste des directions possibles.</returns>
        protected List<Point> GetPossibleDirections()
        {
            return new List<Point>
            {
                new Point(0, -1), // Haut
                new Point(0, 1),  // Bas
                new Point(-1, 0), // Gauche
                new Point(1, 0)   // Droite
            };
        }

        /// <summary>
        /// Déplace l'ennemi de la quantité spécifiée en X et Y.
        /// </summary>
        /// <param name="deltaX">Quantité de déplacement en X.</param>
        /// <param name="deltaY">Quantité de déplacement en Y.</param>
        protected void MoveEnemy(int deltaX, int deltaY)
        {
            if (!CheckWallCollision(deltaX, deltaY))
            {
                Maze.Entities[X, Y] = null;
                X += deltaX;
                Y += deltaY;
                Image.Location = new Point(X, Y);

                // Gère la rotation de l'image en fonction de la direction
                if (deltaX > 0 && !isFacingRight)
                {
                    Image.Image.RotateFlip(RotateFlipType.RotateNoneFlipX);
                    isFacingRight = true;
                }
                else if (deltaX < 0 && isFacingRight)
                {
                    Image.Image.RotateFlip(RotateFlipType.RotateNoneFlipX);
                    isFacingRight = false;
                }
                Image.BringToFront();
                Maze.Entities[X, Y] = this;
            }
        }

        /// <summary>
        /// Vérifie s'il y a une collision avec un mur à la position spécifiée.
        /// </summary>
        /// <param name="deltaX">Quantité de déplacement en X.</param>
        /// <param name="deltaY">Quantité de déplacement en Y.</param>
        /// <returns>True si collision avec un mur, sinon False.</returns>
        public bool CheckWallCollision(int deltaX, int deltaY)
        {
            Rectangle newBounds = new Rectangle(X + deltaX, Y + deltaY, Image.Width, Image.Height);
            List<Cell> neighbors = Maze.GetNeighborCells(X, Y);
            foreach (Cell cell in neighbors)
            {
                if (cell.IsWall && newBounds.IntersectsWith(new Rectangle(cell.X, cell.Y, cell.Image.Width, cell.Image.Height)))
                    return true;
            }
            return false;
        }
    }

    /// <summary>
    /// Représente un ennemi de type Berserker.
    /// </summary>
    public class BerserkerEnemy : Enemy
    {
        // Dernière direction prise par l'ennemi
        private new Point previousDirection;

        // Dictionnaire pour stocker le temps du dernier attaque pour chaque ennemi
        private readonly Dictionary<Enemy, DateTime> lastAttackTime;

        // Délai de récupération entre deux attaques
        private readonly TimeSpan attackCooldown;

        /// <summary>
        /// Initialise une nouvelle instance de la classe BerserkerEnemy.
        /// </summary>
        /// <param name="x">Position X initiale de l'ennemi.</param>
        /// <param name="y">Position Y initiale de l'ennemi.</param>
        /// <param name="maze">Labyrinthe dans lequel l'ennemi se trouve.</param>
        public BerserkerEnemy(int x, int y, Maze maze) : base("Égaré Berserker", x, y, maze)
        {
            Damage = 3;
            Image.Image = Puck_Man_Game.Properties.Resources.berserkerEnemy;
            moveEnemyTimer = new Timer { Interval = 180 };
            moveEnemyTimer.Tick += MoveEnemyTimer_Tick;
            moveEnemyTimer.Start();
            previousDirection = new Point(0, 0);
            lastAttackTime = new Dictionary<Enemy, DateTime>();
            attackCooldown = TimeSpan.FromSeconds(2);
        }
    }

    /// <summary>
    /// Représente un ennemi de type Confused.
    /// </summary>
    public class ConfusedEnemy : Enemy
    {
        // Dernière direction prise par l'ennemi
        private new Point previousDirection;

        // Dictionnaire pour stocker le temps du dernier attaque pour chaque ennemi
        private readonly Dictionary<Enemy, DateTime> lastAttackTime;

        // Délai de récupération entre deux attaques
        private readonly TimeSpan attackCooldown;

        /// <summary>
        /// Initialise une nouvelle instance de la classe ConfusedEnemy.
        /// </summary>
        /// <param name="x">Position X initiale de l'ennemi.</param>
        /// <param name="y">Position Y initiale de l'ennemi.</param>
        /// <param name="maze">Labyrinthe dans lequel l'ennemi se trouve.</param>
        public ConfusedEnemy(int x, int y, Maze maze) : base("Égaré Confus", x, y, maze)
        {
            Damage = 1;
            Image.Image = Puck_Man_Game.Properties.Resources.confusedEnemy;
            moveEnemyTimer = new Timer { Interval = 320 };
            moveEnemyTimer.Tick += MoveEnemyTimer_Tick;
            moveEnemyTimer.Start();
            previousDirection = new Point(0, 0);
            lastAttackTime = new Dictionary<Enemy, DateTime>();
            attackCooldown = TimeSpan.FromSeconds(2);
        }
    }

    public class StandardEnemy : Enemy
    {
        // Dernière direction prise par l'ennemi
        private new Point previousDirection;

        // Dictionnaire pour stocker le temps du dernier attaque pour chaque ennemi
        private readonly Dictionary<Enemy, DateTime> lastAttackTime;

        // Délai de récupération entre deux attaques
        private readonly TimeSpan attackCooldown;

        /// <summary>
        /// Initialise une nouvelle instance de la classe StandardEnemy.
        /// </summary>
        /// <param name="x">Position X initiale de l'ennemi.</param>
        /// <param name="y">Position Y initiale de l'ennemi.</param>
        /// <param name="maze">Labyrinthe dans lequel l'ennemi se trouve.</param>
        public StandardEnemy(int x, int y, Maze maze) : base("Égaré Standard", x, y, maze)
        {
            Damage = 1;
            Image.Image = Puck_Man_Game.Properties.Resources.standardEnemy;
            moveEnemyTimer = new Timer { Interval = 250 };
            moveEnemyTimer.Tick += MoveEnemyTimer_Tick;
            moveEnemyTimer.Start();
            previousDirection = new Point(0, 0);
            lastAttackTime = new Dictionary<Enemy, DateTime>();
            attackCooldown = TimeSpan.FromSeconds(2);
        }

    }

    public class DFSEnemy : Enemy
    {
        private readonly TimeSpan attackCooldown;
        private Stack<Point> dfsStack;
        private HashSet<Point> visited;
        private Point lastMoveDirection;

        /// <summary>
        /// Initialise une nouvelle instance de la classe DFSEnemy.
        /// </summary>
        /// <param name="x">Position X initiale de l'ennemi.</param>
        /// <param name="y">Position Y initiale de l'ennemi.</param>
        /// <param name="maze">Labyrinthe dans lequel l'ennemi se trouve.</param>
        public DFSEnemy(int x, int y, Maze maze) : base("DFSEnemy", x, y, maze)
        {
            Damage = 0;
            Image.Image = Puck_Man_Game.Properties.Resources.skullIcon; // Changer l'image en conséquence
            moveEnemyTimer = new Timer { Interval = 100 }; // Intervalle de déplacement
            moveEnemyTimer.Tick += MoveEnemyTimer_Tick;
            moveEnemyTimer.Start();
            dfsStack = new Stack<Point>();
            visited = new HashSet<Point>();
            attackCooldown = TimeSpan.FromSeconds(2);
            lastMoveDirection = new Point(0, 0);
        }

        public override void Move()
        {
            Point currentPos = new Point(X, Y);

            // Marquer la position actuelle comme visitée
            visited.Add(currentPos);

            if (dfsStack.Count == 0)
            {
                // Initialiser le DFS avec les directions possibles
                List<Point> possibleMoves = GetPossibleDirections();
                Shuffle(possibleMoves); // Mélanger les directions pour éviter les patterns prévisibles

                foreach (Point direction in possibleMoves)
                {
                    Point neighbor = new Point(currentPos.X + direction.X, currentPos.Y + direction.Y);

                    if (!visited.Contains(neighbor) && !IsWall(neighbor.X, neighbor.Y))
                    {
                        dfsStack.Push(neighbor);
                        lastMoveDirection = direction;
                        break;
                    }
                }
            }

            if (dfsStack.Count > 0)
            {
                Point nextMove = dfsStack.Peek();
                Point moveDirection = new Point(nextMove.X - currentPos.X, nextMove.Y - currentPos.Y);

                // Si la prochaine direction est valide et ne conduit pas à une collision
                if (moveDirection.X != 0 || moveDirection.Y != 0)
                {
                    if (!IsWall(nextMove.X, nextMove.Y))
                    {
                        // Vérifie si l'ennemi peut attaquer
                        var targetEntity = Maze.Entities[nextMove.X, nextMove.Y];
                        if (targetEntity is Player player)
                        {
                            player.DamageReceived(Damage); // Inflige des dégâts au joueur
                        }

                        // Déplace l'ennemi
                        MoveEnemy(moveDirection.X, moveDirection.Y);
                        dfsStack.Pop();

                        // Mettre à jour la dernière direction de mouvement
                        lastMoveDirection = new Point(-moveDirection.X, -moveDirection.Y);
                    }
                    else
                    {
                        // Retirer la direction non valide de la pile
                        dfsStack.Pop();
                    }
                }
                else
                {
                    // Retirer la direction non valide de la pile
                    dfsStack.Pop();
                }
            }
            else
            {
                // Si dfsStack est vide, réinitialiser les cellules visitées pour permettre le retour en arrière
                visited.Clear();

                // Recherche de nouvelles directions valides
                List<Point> possibleMoves = GetPossibleDirections();
                Shuffle(possibleMoves);

                foreach (Point direction in possibleMoves)
                {
                    Point neighbor = new Point(currentPos.X + direction.X, currentPos.Y + direction.Y);

                    // Vérifier si la nouvelle position est valide et n'est pas un mur
                    if (!visited.Contains(neighbor) && !IsWall(neighbor.X, neighbor.Y))
                    {
                        dfsStack.Push(neighbor);
                        lastMoveDirection = direction;
                        break;
                    }
                }
            }
        }

        private bool IsWall(int x, int y)
        {
            if (x < 0 || y < 0 || x >= Maze.MazeMatrix.GetLength(0) * Maze.cellSize || y >= Maze.MazeMatrix.GetLength(1) * Maze.cellSize)
                return true; // En dehors des limites du labyrinthe

            Cell cell = Maze.MazeMatrix[x / Maze.cellSize, y / Maze.cellSize];
            return cell != null && cell.IsWall;
        }

        private new void MoveEnemyTimer_Tick(object sender, EventArgs e)
        {
            Move();
        }

        // Méthode pour obtenir les directions possibles (haut, bas, gauche, droite)
        private new List<Point> GetPossibleDirections()
        {
            List<Point> possibleMoves = new List<Point>
        {
            new Point(0, -Maze.cellSize), // Haut
            new Point(0, Maze.cellSize),  // Bas
            new Point(-Maze.cellSize, 0), // Gauche
            new Point(Maze.cellSize, 0)   // Droite
        };

            return possibleMoves;
        }

        // Méthode pour mélanger aléatoirement une liste de points
        private void Shuffle(List<Point> points)
        {
            Random rng = new Random();
            int n = points.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Point value = points[k];
                points[k] = points[n];
                points[n] = value;
            }
        }
    }

    public class ScoutEnemy : Enemy
    {
        private Queue<Point> bfsQueue; // File pour BFS
        private HashSet<Point> visited; // Ensemble pour enregistrer les cellules visitées
        private Stack<Point> moveHistory; // Historique des mouvements

        private Point lastMoveDirection; // Dernière direction de déplacement

        public ScoutEnemy(int x, int y, Maze maze) : base("ScoutEnemy", x, y, maze)
        {
            Damage = 2;
            Image.Image = Puck_Man_Game.Properties.Resources.skullIcon; // Changer l'image en conséquence
            moveEnemyTimer = new Timer { Interval = 120 }; // Intervalle de déplacement
            moveEnemyTimer.Tick += MoveEnemyTimer_Tick;
            moveEnemyTimer.Start();
            bfsQueue = new Queue<Point>();
            visited = new HashSet<Point>();
            moveHistory = new Stack<Point>(); // Initialisation de l'historique
            lastMoveDirection = new Point(0, 0); // Initialisation de la dernière direction
        }

        public override void Move()
        {
            Point currentPos = new Point(X, Y);

            // Marquer la position actuelle comme visitée
            visited.Add(currentPos);

            // Si l'ennemi est sur une cellule visitée, il la marque à nouveau et continue
            visited.Add(currentPos);

            // Si la file BFS est vide, initialiser avec les cellules voisines valides
            if (bfsQueue.Count == 0)
            {
                List<Point> possibleMoves = GetPossibleDirections();
                foreach (Point direction in possibleMoves)
                {
                    Point neighbor = new Point(currentPos.X + direction.X, currentPos.Y + direction.Y);

                    if (!visited.Contains(neighbor) && !IsWall(neighbor.X, neighbor.Y))
                    {
                        bfsQueue.Enqueue(neighbor);
                        visited.Add(neighbor); // Marquer comme visité pour éviter de revisiter
                        moveHistory.Push(currentPos); // Ajouter la position actuelle à l'historique
                    }
                }
            }

            // Si la file BFS contient des cellules, déplacer vers la première cellule en file
            if (bfsQueue.Count > 0)
            {
                Point nextMove = bfsQueue.Dequeue();
                Point moveDirection = new Point(nextMove.X - currentPos.X, nextMove.Y - currentPos.Y);

                // Vérifier si le mouvement est valide et ne conduit pas à une collision
                if (moveDirection.X != 0 || moveDirection.Y != 0)
                {
                    if (!IsWall(nextMove.X, nextMove.Y))
                    {
                        // Vérifier s'il peut attaquer
                        var targetEntity = Maze.Entities[nextMove.X, nextMove.Y];
                        if (targetEntity is Player player)
                        {
                            player.DamageReceived(Damage); // Infliger des dégâts au joueur
                        }

                        // Déplacer l'ennemi
                        MoveEnemy(moveDirection.X, moveDirection.Y);
                        moveHistory.Push(currentPos); // Ajouter la position actuelle à l'historique

                        // Mettre à jour la dernière direction de déplacement
                        lastMoveDirection = moveDirection;
                    }
                }
            }
            else
            {
                // Si la file BFS est vide, réinitialiser les cellules visitées pour permettre le retour en arrière
                visited.Clear();

                // Recherche de nouvelles directions valides en regardant l'historique des mouvements
                bool foundValidMove = false;
                while (moveHistory.Count > 0)
                {
                    Point lastVisited = moveHistory.Pop();
                    Point reevaluatedMoveDirection = new Point(lastVisited.X - currentPos.X, lastVisited.Y - currentPos.Y);

                    if (reevaluatedMoveDirection.X != 0 || reevaluatedMoveDirection.Y != 0)
                    {
                        if (!IsWall(lastVisited.X, lastVisited.Y) && reevaluatedMoveDirection != lastMoveDirection)
                        {
                            MoveEnemy(reevaluatedMoveDirection.X, reevaluatedMoveDirection.Y);
                            foundValidMove = true;
                            break;
                        }
                    }
                }

                // Si aucune direction valide trouvée dans l'historique, recherche de nouvelles directions
                if (!foundValidMove)
                {
                    List<Point> possibleMoves = GetPossibleDirections();
                    foreach (Point direction in possibleMoves)
                    {
                        Point neighbor = new Point(currentPos.X + direction.X, currentPos.Y + direction.Y);

                        // Vérifier si la nouvelle position est valide et n'est pas un mur
                        if (!visited.Contains(neighbor) && !IsWall(neighbor.X, neighbor.Y))
                        {
                            bfsQueue.Enqueue(neighbor);
                            visited.Add(neighbor); // Marquer comme visité pour éviter de revisiter
                            moveHistory.Push(currentPos); // Ajouter la position actuelle à l'historique
                            break;
                        }
                    }
                }
            }
        }

        private bool IsWall(int x, int y)
        {
            if (x < 0 || y < 0 || x >= Maze.MazeMatrix.GetLength(0) * Maze.cellSize || y >= Maze.MazeMatrix.GetLength(1) * Maze.cellSize)
                return true; // En dehors des limites du labyrinthe

            Cell cell = Maze.MazeMatrix[x / Maze.cellSize, y / Maze.cellSize];
            return cell != null && cell.IsWall;
        }

        private new void MoveEnemyTimer_Tick(object sender, EventArgs e)
        {
            Move();
        }

        private new List<Point> GetPossibleDirections()
        {
            List<Point> possibleMoves = new List<Point>
            {
                new Point(0, -Maze.cellSize), // Haut
                new Point(0, Maze.cellSize),  // Bas
                new Point(-Maze.cellSize, 0), // Gauche
                new Point(Maze.cellSize, 0)   // Droite
            };

            return possibleMoves;
        }
    }

    public class DijkstraEnemy : Enemy
    {
        private List<Point> pathToPlayer;
        private int currentPathIndex;

        public DijkstraEnemy(int x, int y, Maze maze) : base("DijkstraEnemy", x, y, maze)
        {
            Damage = 2;
            Image.Image = Puck_Man_Game.Properties.Resources.skullIcon; // Changer l'image en conséquence
            moveEnemyTimer = new System.Windows.Forms.Timer { Interval = 120 }; // Intervalle de déplacement
            moveEnemyTimer.Tick += MoveEnemyTimer_Tick;
            moveEnemyTimer.Start();

            pathToPlayer = new List<Point>();
            currentPathIndex = 0;
        }

        public override void Move()
        {
            Point currentPosition = new Point(X, Y);
            Point playerStartPosition = new Point(Maze.startX, Maze.startY); // Position de départ du joueur

            // Calculer le chemin le plus court vers la position de départ du joueur
            pathToPlayer = CalculateShortestPath(currentPosition, playerStartPosition);

            // Suivre le chemin calculé
            if (currentPathIndex < pathToPlayer.Count)
            {
                Point nextMove = pathToPlayer[currentPathIndex];
                Point moveDirection = new Point(nextMove.X - currentPosition.X, nextMove.Y - currentPosition.Y);

                // Déplacer l'ennemi
                MoveEnemy(moveDirection.X, moveDirection.Y);

                // Mettre à jour l'index du chemin actuel
                currentPathIndex++;

                // Vérifier si l'ennemi atteint la position de départ du joueur
                if (nextMove == playerStartPosition)
                {
                    // L'ennemi a atteint la position de départ du joueur
                    // À vous de décider ce que vous souhaitez faire à ce moment-là
                }
            }
            else
            {
                // Si l'ennemi atteint la fin du chemin sans atteindre la position de départ du joueur, réinitialiser l'index du chemin
                currentPathIndex = 0;
            }
        }

        private List<Point> CalculateShortestPath(Point start, Point target)
        {
            // Pour un chemin direct, simplement retourner une liste avec les deux points
            List<Point> path = new List<Point>();
            path.Add(start);
            path.Add(target);
            return path;
        }

        private new void MoveEnemy(int deltaX, int deltaY)
        {
            // Vérifier les collisions avec les murs
            if (!IsWall(X + deltaX, Y + deltaY))
            {
                Maze.Entities[X, Y] = null;
                X += deltaX;
                Y += deltaY;
                Maze.Entities[X, Y] = this;
                Image.Location = new Point(X, Y);
            }
        }

        private bool IsWall(int x, int y)
        {
            if (x < 0 || y < 0 || x >= Maze.MazeMatrix.GetLength(0) * Maze.cellSize || y >= Maze.MazeMatrix.GetLength(1) * Maze.cellSize)
                return true; // En dehors des limites du labyrinthe

            Cell cell = Maze.MazeMatrix[x / Maze.cellSize, y / Maze.cellSize];
            return cell != null && cell.IsWall;
        }

        private new void MoveEnemyTimer_Tick(object sender, EventArgs e)
        {
            Move();
        }
    }
}
