using System.ComponentModel;

namespace Maze
{
    /// <summary>
    /// Classe abstrata para definir um ambiente de aprendizado por reforço.
    /// </summary>
    public interface Env
    {
        int[] Reset();
        Tuple<int[], double, bool> Step(int action);
    }

    /// <summary>
    /// Classe para definir um ambiente de labirinto.
    /// </summary>
    public class MazeEnv : Env
    {
        public int[,] maze;
        public int startX, startY;
        public int goalX, goalY;
        private int currentX, currentY;
        private int previousDistance;
        private HashSet<(int, int)> visited = new HashSet<(int, int)>();
        public int ySize { get { return maze.GetLength(1); } }
        public int xSize { get { return maze.GetLength(0); } }

        /// <summary>
        /// Inicia o construtor da classe MazeEnv.
        /// <para>maze = matriz do labirinto;</para>
        /// <para>startX = ponto da matriz X inicial;</para>
        /// <para>startY = pont da matriz Y inicial;</para>
        /// <para>goalX = pont da matriz X final;</para>
        /// <para>goalY = pont da matriz Yfinal;</para>
        /// </summary>
        public MazeEnv(int[,] maze, int startX, int startY, int goalX, int goalY)
        {
            this.maze = maze;
            this.startX = startX;
            this.startY = startY;
            this.goalX = goalX;
            this.goalY = goalY;
            this.currentX = startX;
            this.currentY = startY;
            this.previousDistance = FindShortestPath(maze, currentX, currentY);
        }

        /// <summary>
        /// Reinicia o ambiente para o estado inicial.
        /// </summary>
        /// <returns></returns>
        public int[] Reset()
        {
            currentX = startX;
            currentY = startY;
            previousDistance = FindShortestPath(maze, currentX, currentY);
            visited.Clear();
            visited.Add((currentX, currentY));
            return [currentX, currentY];
        }

        /// <summary>
        /// Executa uma ação no ambiente.
        /// </summary>
        public Tuple<int[], double, bool> Step(int actionIndex)
        {
            // Ações: 0 = parado, 1 = cima, 2 = baixo, 3 = esquerda, 4 = direita
            
            int previousX = currentX;
            int previousY = currentY;
            int nextX = currentX;
            int nextY = currentY;

            switch (actionIndex)
            {
                case 0:
                    //Console.WriteLine($"parado");
                    break;
                case 1:
                    //Console.WriteLine($"cima");
                    nextX--;
                    break;
                case 2:
                    //Console.WriteLine($"baixo");
                    nextX++;
                    break;
                case 3:
                    //Console.WriteLine($"esquerda");
                    nextY--;
                    break;
                case 4:
                    //Console.WriteLine($"direita");
                    nextY++;
                    break;
            }

            if (IsValidMove(nextX, nextY))
            {
                currentX = nextX;
                currentY = nextY;
            }

            double reward = CalculateReward();
            bool done = IsGoal();

            return Tuple.Create(GetState(), reward, done);
        }

        /// <summary>
        /// Retorna o estado atual do ambiente.
        /// </summary>
        public int[] GetState()
        {
            // Representação do estado: posição atual (y,x)
            return [currentY, currentX];
        }

        /// <summary>
        /// Verifica se um movimento é válido.
        /// </summary>
        private bool IsValidMove(int x, int y)
        {
            // Fora dos limites do labirinto é considerado invalido
            if (x < 0 || x >= xSize || y < 0 || y >= ySize)
                return false;
            return maze[x, y] == 0; // 0 = caminho livre
        }

        private bool IsWall(int x, int y)
        {
            // Fora dos limites do labirinto é considerado parede
            if (x < 0 || x >= xSize || y < 0 || y >= ySize)
                return true;
            return maze[x, y] == 1; // 1 = parede
        }

        /// <summary>
        /// Calcula a recompensa para o agente.
        /// </summary>
        private double CalculateReward()
        {
            // Recompensa grande por alcançar o objetivo
            if (IsGoal()) return 1;

            double distReward = 0;

            int distance = FindShortestPath(maze, currentX, currentY);

            if (distance < previousDistance)
            {
                previousDistance = distance;
                distReward = 0.1; // Recompensa por se aproximar do objetivo
            }
            else if (distance > previousDistance)
            {
                previousDistance = distance;
                distReward = -0.1; // Punição por se afastar do objetivo
            }
            else
            {
                distReward = -0.1; // Punição pequena por não fazer nada
            }

            // Recompensa por explorar novas áreas
            if (!visited.Contains((currentX, currentY)))
            {
                visited.Add((currentX, currentY));
                Console.WriteLine($"distancia: {distance}");
                return 0.2 + distReward;
            }

            //// Punições 
            //if (IsWall(currentX, currentY) || !IsValidMove(currentX, currentY))
            //{
            //    Console.WriteLine($"distancia: {distance}");
            //    return -0.2 + distReward; // Punição por colisão com parede
            //}

            Console.WriteLine($"distancia: {distance}");
            return distReward; // Punição pequena por não fazer nada
        }

        public int FindShortestPath(int[,] maze, int startX, int startY)
        {
            Queue<(int, int, int)> queue = new Queue<(int, int, int)>();
            bool[,] visited = new bool[xSize, ySize];

            queue.Enqueue((startX, startY, 0)); // Inicia na posição (startX, startY) com distância 0

            visited[startX, startY] = true;

            while (queue.Count > 0)
            {
                var (row, col, dist) = queue.Dequeue();

                if (row == goalX && col == goalY) return dist; // Encontrou o destino, retorna a distância

                // Movimentos possíveis (cima, baixo, esquerda, direita)
                int[] dr = { -1, 1, 0, 0 };
                int[] dc = { 0, 0, -1, 1 };

                for (int i = 0; i < 4; i++) // 4 direções
                {
                    int newRow = row + dr[i];
                    int newCol = col + dc[i];

                    if (newRow >= 0 && newRow < xSize && newCol >= 0 && newCol < ySize &&
                        maze[newRow, newCol] != 1 && !visited[newRow, newCol])
                    {
                        queue.Enqueue((newRow, newCol, dist + 1));
                        visited[newRow, newCol] = true;
                    }
                }
            }

            return -1; // Não encontrou um caminho
        }

        /// <summary>
        /// Verifica se o objetivo foi alcançado.
        /// </summary>
        private bool IsGoal()
        {
            //if (currentX == goalX && currentY == goalY)
                //Console.WriteLine("!!CHEGOU!!");
            return currentX == goalX && currentY == goalY;
        }

        /// <summary>
        /// Imprime o labirinto no console.
        /// </summary>
        public void PrintMaze()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            for (int x = 0; x < xSize; x++)
            {
                Console.Write("|");
                for (int y = 0; y < ySize; y++)
                {
                    if (x == currentX && y == currentY)
                        Console.Write(" \u0164 "); // Agente
                    else if (x == goalX && y == goalY)
                        Console.Write(" » "); // Objetivo
                    else if (maze[x, y] == 1)
                        Console.Write(" # "); // Parede
                    else
                        Console.Write(" · "); // Caminho livre
                }
                Console.WriteLine("|");
            }
            Console.WriteLine("\n");

        }

    }
}
