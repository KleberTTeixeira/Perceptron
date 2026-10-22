namespace Bender
{
    using Maze;
    using System;
    using System.Linq;
    using static Bender.Training;

    public static class Hyperparameters
    {
        public static int SpeedView { get; set; } = 0;
        internal static int OutputSize { get; set; } = 2;
        public static double[] OutputActions { get; set; } = [];
        public static int StepsLength { get; set; } = 1000;


        public static int ExploreLength { get; set; } = 100;
        public static double Noise { get; set; } = 0.01;
        public static double NoiseMin { get; set; } = 0.01;
        public static double NoiseMax { get; set; } = 0.6;
        public static double LearningRate { get; set; } = 0.1;
        public static double LearningRateMin { get; set; } = 0.6;
        public static double LearningRateMax { get; set; } = 0.99;
        public static double DiscountFactor { get; set; } = 0.1;
        public static double DiscountFactorMin { get; set; } = 0.7;
        public static double DiscountFactorMax { get; set; } = 0.99;
        //determina a importância dada a recompensas futuras em relação a recompensas imediatas
        // próximo de 1, o agente dará grande importância a recompensas futuras
        // próximo de 0, o agente se concentrará principalmente em recompensas imediatas
    }

    public class Training
    {
        public int[] EstadoAtual { get; set; }
        public int Trys { get; set; } = 0;
        public int Goals { get; set; } = 0;
        public int Footsteps { get; set; } = 0;
        public int BestFootsteps { get; set; } = 0;
        public bool FinshTraing { get; set; } = false;

        public Dictionary<int, (int noise, int learningRate, int DiscountFactor, double Reward)> RsultReward = new Dictionary<int, (int, int, int, double)>();

        public enum TypeHP
        {
            l0a = 1,
            q1a = 2,
            q2a = 3,
            l0d = 4,
            q1d = 5,
            q2d = 6
        }

        public Training()
        {
            EstadoAtual = new int[Hyperparameters.OutputActions.Length];
        }

        public double Explore(MazeEnv env, Policy policy, double noise)
        {
            int[] state = env.Reset();
            bool done = false;
            double sumRewards = 0;
            int numPlays = 0;

            while (!done && numPlays < Hyperparameters.ExploreLength)
            {
                int action = policy.ChooseAction(state, noise);
                int[] oldState = state;
                var stepResult = env.Step(action);

                double LocalReward = stepResult.Item2;

                done = stepResult.Item3;
                if (done)
                {
                    if (BestFootsteps == 0) BestFootsteps = numPlays;
                    else if (numPlays <= BestFootsteps) BestFootsteps = numPlays;
                    Goals++;
                }

                double qreward = qTableUpdate(policy, state, action, LocalReward);

                state = stepResult.Item1; // Atualiza o estado
                EstadoAtual = state;

                sumRewards += qreward;
                numPlays++;
                //Console.WriteLine($"Steps: {numPlays}");
                //Console.WriteLine($"qreward: {qreward}");
                //Console.WriteLine($"sumRewards: {sumRewards}");
                //env.PrintMaze();

                if (Hyperparameters.SpeedView > 0) Thread.Sleep(Hyperparameters.SpeedView);
            }

            Footsteps = numPlays;

            return 100 - (((double)numPlays * 100) / (double)Hyperparameters.ExploreLength);
        }

        private double qTableUpdate(Policy policy, int[] state, int action, double reward)
        {
            // Encontra o maior valor de Q para o próximo estado (nextState)
            double maxQ = policy.qTable[state[1], state[0], action];
            for (int a = 1; a < Hyperparameters.OutputSize; a++)
            {
                if (policy.qTable[state[1], state[0], action] > maxQ)
                {
                    maxQ = policy.qTable[state[1], state[0], action];
                }
            }

            // Calcula o novo valor de Q para o estado atual (state) e ação escolhida (action)
            double pol = policy.qTable[state[1], state[0], action];
            double disc = Hyperparameters.DiscountFactor;
            double lRate = Hyperparameters.LearningRate;

            double newQ = (pol + lRate * (reward + disc * maxQ - pol));

            policy.qTable[state[1], state[0], action] = newQ;

            return newQ;
        }

        public void Train(MazeEnv env, Policy policy, bool fullTypes = false)
        {
            Hyperparameters.ExploreLength = (int)(env.FindShortestPath(env.maze, env.startX, env.startY) * 10);

            if (Hyperparameters.SpeedView <= 1) Hyperparameters.SpeedView = 1;
            if (Hyperparameters.SpeedView >= 200) Hyperparameters.SpeedView = 200;

            if (!fullTypes)
            {
                double reward = 0;
                for (int StepsLength = 0; StepsLength < Hyperparameters.StepsLength; StepsLength++)
                {
                    Trys++;

                    Hyperparameters.Noise = SwitchHP((TypeHP)6, StepsLength, Hyperparameters.NoiseMin, Hyperparameters.NoiseMax);
                    Hyperparameters.LearningRate = SwitchHP((TypeHP)1, StepsLength, Hyperparameters.LearningRateMin, Hyperparameters.LearningRateMax);
                    Hyperparameters.DiscountFactor = SwitchHP((TypeHP)2, StepsLength, Hyperparameters.DiscountFactorMin, Hyperparameters.DiscountFactorMax);

                    reward += Explore(env, policy, Hyperparameters.Noise);
                }
            }
            else
            {
                int DiscountFactor = 0;

                for (int n = 1; n <= 6; n++)
                {
                    for (int l = 1; l <= 6; l++)
                    {
                        for (int d = 1; d <= 6; d++)
                        {
                            double reward = 0;

                            for (int StepsLength = 0; StepsLength < Hyperparameters.StepsLength; StepsLength++)
                            {
                                Hyperparameters.Noise = SwitchHP((TypeHP)n, StepsLength, Hyperparameters.NoiseMin, Hyperparameters.NoiseMax);
                                Hyperparameters.LearningRate = SwitchHP((TypeHP)l, StepsLength, Hyperparameters.LearningRateMin, Hyperparameters.LearningRateMax);
                                Hyperparameters.DiscountFactor = SwitchHP((TypeHP)d, StepsLength, Hyperparameters.DiscountFactorMin, Hyperparameters.DiscountFactorMax);
                                
                                reward += Explore(env, policy, Hyperparameters.Noise);
                                Trys++;
                            }

                            if (RsultReward.ContainsKey(DiscountFactor)) RsultReward.Add(DiscountFactor, (n, l, d, reward));
                            else RsultReward[DiscountFactor] = (n, l, d, reward);
                            DiscountFactor++;

                            policy.qTableSave($"[{n}-{l}-{d}]");
                            policy.qTableSeset(env.xSize, env.ySize);

                            Trys = 0;
                        }
                        Trys = 0;
                    }
                    Trys = 0;
                }
            }

            FinshTraing = true;
        }

        internal double SwitchHP(TypeHP typehp, int StepsLenght, double minValue = 0.1, double maxValue = 0.99)
        {
            switch (typehp)
            {
                case TypeHP.l0a:
                    return LinearAcceleration(minValue, maxValue, StepsLenght);
                case TypeHP.q1a:
                    return QuadraticAcceleration(minValue, maxValue, StepsLenght);
                case TypeHP.q2a:
                    return QuadraticAcceleration2(minValue, maxValue, StepsLenght);
                case TypeHP.l0d:
                    return LinearDeceleration(maxValue, minValue, StepsLenght);
                case TypeHP.q1d:
                    return QuadraticDeceleration(maxValue, minValue, StepsLenght);
                case TypeHP.q2d:
                    return QuadraticDeceleration2(maxValue, minValue, StepsLenght);
            }

            return 0;
        }

        private double QuadraticAcceleration(double startValue, double finshValue, int step)
        {
            // Aceleração quadrática
            return startValue + ((finshValue - startValue) * Math.Pow(step / (double)Hyperparameters.StepsLength, 2));
        }

        private double LinearAcceleration(double startValue, double finshValue, int step)
        {
            // Aceleração linear
            return startValue + ((finshValue - startValue) * (double)step / (double)Hyperparameters.StepsLength);
        }

        private double QuadraticAcceleration2(double startValue, double finshValue, int step)
        {
            // Aceleração quadrática 2
            return startValue + ((finshValue - startValue) * Math.Sqrt((double)step / (double)Hyperparameters.StepsLength));
        }

        private double QuadraticDeceleration(double startValue, double finshValue, int step)
        {
            // Desaceleração quadrática
            return startValue - ((startValue - finshValue) * Math.Pow((double)step / (double)Hyperparameters.StepsLength, 2));
        }

        private double LinearDeceleration(double startValue, double finshValue, int step)
        {
            // Desaceleração linear
            return startValue - ((startValue - finshValue) * (double)step / (double)Hyperparameters.StepsLength);
        }

        private double QuadraticDeceleration2(double startValue, double finshValue, int step)
        {
            // Desaceleração quadrática 2
            return startValue - ((startValue - finshValue) * Math.Sqrt((double)step / (double)Hyperparameters.StepsLength));

        }
    }

    public class Oracle
    {
        public static double RandomActions(double[] numeros)
        {
            Random random = new Random();

            for (int j = numeros.Length - 1; j > 0; j--)
            {
                int k = random.Next(j + 1);
                double temp = numeros[j];
                numeros[j] = numeros[k];
                numeros[k] = temp;
            }

            return numeros[random.Next(0, numeros.Length)];
        }
    }

    public class Policy
    {
        public double[,,] qTable { get; set; }

        public Policy(MazeEnv env)
        {
            Random random = new Random();
            Hyperparameters.OutputSize = Hyperparameters.OutputActions.Length;

            int xSize = env.xSize;
            int ySize = env.ySize;

            qTable = new double[xSize, ySize, Hyperparameters.OutputSize];

            qTableSeset(xSize, ySize);
        }

        public void qTableSeset(int xSize, int ySize)
        {
            for (int y = 0; y < ySize; y++)
            {
                for (int x = 0; x < xSize; x++)
                {
                    for (int action = 0; action < Hyperparameters.OutputSize; action++)
                    {
                        qTable[x, y, action] = 0.01;
                    }
                }
            }
        }

        public void qTableSave(string reference)
        {
            // Salva a tabela Q em um arquivo
            using (StreamWriter writer = new StreamWriter("qTable-" + reference + "-" + DateTime.Now.ToString("-yyyyMMdd-HHmmss") + ".txt"))
            {
                for (int x = 0; x < qTable.GetLength(0); x++)
                {
                    for (int y = 0; y < qTable.GetLength(1); y++)
                    {
                        for (int action = 0; action < Hyperparameters.OutputSize; action++)
                        {
                            writer.Write($"{qTable[x, y, action]} ");
                        }
                        writer.WriteLine();
                    }
                }
            }
        }

        public int ChooseAction(int[] state, double epsilon)
        {
            Random random = new Random();

            if (random.NextDouble() < epsilon)
            {
                // Exploração: escolhe uma ação aleatória
                return (int)Oracle.RandomActions(Hyperparameters.OutputActions);
            }
            else
            {
                // Verifica se existe uma melhor ação conhecida
                double[] _val = new double[Hyperparameters.OutputSize];
                for (int n = 0; n < _val.Length; n++) _val[n] = qTable[state[1], state[0], n];
                double _ref = _val[0];

                if (_val.All(val => val == _ref))
                    return (int)Oracle.RandomActions(Hyperparameters.OutputActions);

                // Retorna a melhor ação conhecida
                return Enumerable.Range(0, Hyperparameters.OutputSize).Aggregate((a, b) => qTable[state[1], state[0], a] > qTable[state[1], state[0], b] ? a : b);
            }
        }

        public void PrintqTable(MazeEnv env)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            for (int x = 0; x < qTable.GetLength(0); x++)
            {
                for (int k = 0; k < Hyperparameters.OutputSize; k++)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("| ");
                    for (int y = 0; y < qTable.GetLength(1); y++)
                    {
                        string _val = "";
                        double qt = 0;

                        if (env.maze[x, y] == 1)
                        {
                            _val = "######";
                        }
                        else if (x == env.goalX && y == env.goalY)
                        {
                            _val = ">>>>>>";
                        }
                        else
                        {
                            qt = qTable[x, y, k];
                            _val = qt.ToString("F4");
                            _val = _val.Replace(",", ".");
                        }

                        string _sN = " ";
                        if (qt < 0) _sN = "";

                        if (x == env.goalX && y == env.goalY)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.Write($" >>>{_sN}{_val} ");
                        }
                        else if (env.maze[x, y] == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write($" ({k}){_sN}{_val} ");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.Write($" ###{_sN}{_val} ");
                        }
                    }

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(" |");
                }

                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("| ");
                for (int y = 0; y < qTable.GetLength(1); y++) Console.Write("            ");
                Console.WriteLine(" |");
            }
            Console.WriteLine("\n");
        }
    }
}