using Bender;
using Maze;

namespace LabirintoVisual
{
    public partial class formMaze : Form
    {
        private int[,] maze = {
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,1,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0},
                {0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,1,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,1,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,1,0,1,1,1,1,1,1,0,1,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
                {0,1,0,0,0,1,0,0,0,1,0,0,0,1,0,1,0,0,0,0,0,0,0,1,0,0,0,1,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,1,1,1,1,0,1,1,1,0,1,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0},
                {0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,0,0,1,0,0,0,1,0,1,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,1,1,1,1,1,1,1,1,1,1,1,1,0,1,1,1,0},
                {0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0},
                {0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,1,1,1,1,1,1,1,1,1,1,1,1,0,1,0},
                {0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,0,0,0,0,0,0,0,0,0,0,1,0,1,0},
                {0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,0,0,1,0,1,0,1,0,1,1,1,1,1,1,1,1,1,0,1,0,1,0},
                {0,0,0,1,0,0,0,1,0,0,0,1,0,0,0,0,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,0,0,0,0,0,0,0,0,1,0,1,0,1,0},
                {0,1,1,1,1,1,1,1,0,1,1,1,1,1,1,1,1,1,0,1,0,1,0,1,0,1,0,1,0,1,0,0,0,1,0,1,1,1,1,1,1,1,0,1,0,1,0,1,0},
                {0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,1,0,1,0,1,0,1,0,1,0,1,0,1,1,1,0,1,0,0,0,0,0,1,0,1,0,0,0,1,0},
                {0,1,0,1,1,1,1,1,1,1,0,1,1,1,1,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,0,0,1,0,1,1,1,0,1,0,1,0,1,0,1,0},
                {0,1,0,1,0,0,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,0,0,1,0,1,0,1,0,1,0,1,0},
                {0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,1,1,0,1,0,1,0,1,0,1,0},
                {0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,0,0,0,0,0,0,1,0,1,0,0,0},
                {0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,0,0,1,0,1,0,0,0,1,0,0,0,1,0,1,0,1,0,1,0,1,1,1,1,1,1,1,0,1,0,1,0,1,0},
                {0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,1,1,1,1,1,1,1,1,1,1,0,1,0,1,0,1,0,0,0,0,0,0,0,0,0,1,0,1,0,1,0},
                {0,1,0,0,0,1,0,0,0,0,0,1,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,1,0,1,1,1,1,1,1,1,1,1,1,1,0,1,0,1,0},
                {0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,1,1,1,1,1,1,1,1,1,1,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,1,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,1,0,0,0,1,0,1,1,1,1,0,1,1,1,1,1,1,1,1,1,1,0,1,0},
                {0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,1,1,1,1,1,1,1,1,1,0,1,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0},
                {0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,1,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0},
                {0,1,0,1,1,1,1,1,1,1,1,1,1,1,1,1,0,1,0,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,1,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0},
                {0,1,1,1,1,1,1,1,1,1,1,1,1,1,0,1,0,1,1,1,1,1,1,1,1,1,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,1,0,0,0,0,0,0,0,0,0,1,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
                {0,1,0,1,1,1,1,1,1,1,1,1,1,1,1,1,0,1,0,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,1,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0},
                {0,1,1,1,1,1,1,1,1,1,1,1,1,1,0,1,0,1,1,1,1,1,1,1,1,1,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1}
        };

        // Posição autal do agente
        public int stateX = 0;
        public int stateY = 0;
        // Posição inicial do agente
        public int startX = 32;
        public int startY = 0;
        //Posição da chegada
        private int goalX = 16;
        private int goalY = 38;
        Training train = new();


        public int expLeng = 0;
        bool started = false;

        private Dictionary<int, (double Noise, double LearningRate, double DiscountFactor)> HistoVals = [];
        int HistoValsControl = 0;
        bool finshTrain = false;

        public formMaze()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            var atualizarPictureBoxTask = IniciarImageAsync();
            await Task.WhenAll(atualizarPictureBoxTask);
        }

        private async Task IniciarProcessosAsync()
        {
            await Task.Yield();

            // Instancie o ambiente labirinto (MazeEnv)
            MazeEnv env = new MazeEnv(maze, startX, startY, goalX, goalY);

            // 0 = parado, 1 = cima, 2 = baixo, 3 = esquerda, 4 = direita
            Hyperparameters.OutputActions = [0, 1, 2, 3, 4];
            Hyperparameters.StepsLength = 100;

            expLeng = env.FindShortestPath(env.maze, env.startX, env.startY); // Encontra o caminho mais curto    

            Policy policy = new(env);

            await Task.Run(() => train.Train(env, policy));
        }

        private async Task IniciarImageAsync()
        {
            while (true)
            {
                if (pbLabirinto.InvokeRequired)
                {
                    pbLabirinto.Invoke(new Action(UpdateImageMaze));
                }
                else
                {
                    UpdateImageMaze();
                }

                await Task.Delay(1);
            }
        }

        private void UpdateImageMaze()
        {
            try
            {
                if (!train.FinshTraing)
                {
                    if (train.Trys == 0) HistoVals = [];

                    if (HistoValsControl != train.RsultReward.Count)
                    {
                        txtResult.Text += $"RsultReward[{HistoValsControl}] = {train.RsultReward[train.RsultReward.Count - 1]}\r\n";
                        txtResult.SelectionStart = txtResult.Text.Length;
                        txtResult.ScrollToCaret();

                        HistoValsControl = train.RsultReward.Count;
                    }

                    lblTry.Text = $"{train.Trys.ToString()} ({Hyperparameters.StepsLength.ToString()})";
                    lblGoal.Text = train.Goals.ToString();

                    lblBestFootsteps.Text = $"{train.BestFootsteps.ToString()} ({expLeng.ToString()})";

                    lblNoise.Text = Hyperparameters.Noise.ToString();
                    lblLearningRate.Text = Hyperparameters.LearningRate.ToString();
                    lblDiscountFactor.Text = Hyperparameters.DiscountFactor.ToString();

                    #region Gráficos

                    if (train.Trys > 0 && HistoVals.ContainsKey(train.Trys))
                    {
                        HistoVals[train.Trys] = (Hyperparameters.Noise, Hyperparameters.LearningRate, Hyperparameters.DiscountFactor);
                    }
                    else if (train.Trys > 0)
                    {
                        HistoVals.Add(train.Trys, (Hyperparameters.Noise, Hyperparameters.LearningRate, Hyperparameters.DiscountFactor));
                    }

                    int cellSize = 10; // Define o tamanho das células do grid

                    if (HistoVals.Count > 1)
                    {
                        #region Noise
                        Graphics gNoise = pbNoise.CreateGraphics();
                        using (Pen penNoise = new Pen(Color.White, 2))
                        using (Pen gridPen = new Pen(Color.FromArgb(20, 20, 20)))
                        {
                            int widthN = pbNoise.Width;
                            int heightN = pbNoise.Height;
                            float stepXN = (float)widthN / Hyperparameters.StepsLength; // Proporção da largura
                            float minYN = 0.1f, maxYN = 0.99f; // Intervalo de valores
                            float escalaYN = heightN / (maxYN - minYN);

                            // Desenha a grade de fundo
                            for (int x = 0; x < widthN; x += cellSize) gNoise.DrawLine(gridPen, x, 0, x, heightN);
                            for (int y = 0; y < heightN; y += cellSize) gNoise.DrawLine(gridPen, 0, y, widthN, y);

                            // Desenha o gráfico sobre a grade
                            for (int i = 1; i < HistoVals.Count; i++)
                            {
                                float x1 = (i - 1) * stepXN;
                                float y1 = (float)(heightN - ((HistoVals[i].Noise - minYN) * escalaYN));
                                float x2 = i * stepXN;
                                float y2 = (float)(heightN - ((HistoVals[i + 1].Noise - minYN) * escalaYN));

                                gNoise.DrawLine(penNoise, x1, y1, x2, y2);
                            }
                        }

                        #endregion

                        #region LearningRate
                        Graphics gLearningRate = pbLearningRate.CreateGraphics();
                        using (Pen penLearningRate = new Pen(Color.White, 2))
                        using (Pen gridPenL = new Pen(Color.FromArgb(20, 20, 20)))
                        {
                            int widthL = pbLearningRate.Width;
                            int heightL = pbLearningRate.Height;
                            float stepXL = (float)widthL / Hyperparameters.StepsLength; // Proporção da largura
                            float minYL = 0.1f, maxYL = 0.99f; // Intervalo de valores
                            float escalaYL = heightL / (maxYL - minYL);

                            // Desenha a grade de fundo
                            for (int x = 0; x < widthL; x += cellSize) gLearningRate.DrawLine(gridPenL, x, 0, x, heightL);
                            for (int y = 0; y < heightL; y += cellSize) gLearningRate.DrawLine(gridPenL, 0, y, widthL, y);

                            //desenha a linha de desenvolvimento grafico
                            for (int i = 1; i < HistoVals.Count; i++)
                            {
                                float x1 = (i - 1) * stepXL;
                                float y1 = (float)(heightL - ((HistoVals[i].LearningRate - minYL) * escalaYL));
                                float x2 = i * stepXL;
                                float y2 = (float)(heightL - ((HistoVals[i + 1].LearningRate - minYL) * escalaYL));

                                gLearningRate.DrawLine(penLearningRate, x1, y1, x2, y2);
                            }
                        }
                        #endregion

                        #region DiscountFactor
                        Graphics gDiscountFactor = pbDiscountFactor.CreateGraphics();
                        using (Pen penDiscountFactor = new Pen(Color.White, 2))
                        using (Pen gridPenD = new Pen(Color.FromArgb(20, 20, 20)))
                        {

                            int widthD = pbLearningRate.Width;
                            int heightD = pbLearningRate.Height;
                            float stepXD = (float)widthD / Hyperparameters.StepsLength; // Proporção da largura
                            float minYD = 0.1f, maxYD = 0.99f; // Intervalo de valores
                            float escalaYD = heightD / (maxYD - minYD);

                            // Desenha a grade de fundo
                            for (int x = 0; x < widthD; x += cellSize) gDiscountFactor.DrawLine(gridPenD, x, 0, x, heightD);
                            for (int y = 0; y < heightD; y += cellSize) gDiscountFactor.DrawLine(gridPenD, 0, y, widthD, y);

                            //desenha a linha de desenvolvimento grafico
                            for (int i = 1; i < HistoVals.Count; i++)
                            {
                                float x1 = (i - 1) * stepXD;
                                float y1 = (float)(heightD - ((HistoVals[i].DiscountFactor - minYD) * escalaYD));
                                float x2 = i * stepXD;
                                float y2 = (float)(heightD - ((HistoVals[i + 1].DiscountFactor - minYD) * escalaYD));

                                gDiscountFactor.DrawLine(penDiscountFactor, x1, y1, x2, y2);
                            }
                            penDiscountFactor.Dispose();

                        }
                        #endregion
                    }
                    else
                    {
                        Graphics gNoise = pbNoise.CreateGraphics();
                        gNoise.Clear(Color.Black);
                        Graphics gLearningRate = pbLearningRate.CreateGraphics();
                        gLearningRate.Clear(Color.Black);
                        Graphics gDiscountFactor = pbDiscountFactor.CreateGraphics();
                        gDiscountFactor.Clear(Color.Black);
                    }

                    #endregion

                    #region Labirinto
                    Graphics g = pbLabirinto.CreateGraphics(); //e.Graphics;
                    int celulaLargura = pbLabirinto.Width / maze.GetLength(1);
                    int celulaAltura = pbLabirinto.Height / maze.GetLength(0);

                    using (SolidBrush paredeBrush = new SolidBrush(Color.Black))
                    using (SolidBrush caminhoBrush = new SolidBrush(Color.White))
                    using (SolidBrush agenteBrush = new SolidBrush(Color.Red))
                    using (SolidBrush goalBrush = new SolidBrush(Color.Green))
                    {
                        for (int linha = 0; linha < maze.GetLength(0); linha++)
                        {
                            for (int coluna = 0; coluna < maze.GetLength(1); coluna++)
                            {
                                int x = coluna * celulaLargura;
                                int y = linha * celulaAltura;
                                Rectangle celulaRect = new Rectangle(x, y, celulaLargura, celulaAltura);

                                if (maze[linha, coluna] == 1)
                                {
                                    g.FillRectangle(paredeBrush, celulaRect);
                                }
                                else if (maze[linha, coluna] == 0)
                                {
                                    g.FillRectangle(caminhoBrush, celulaRect);
                                }

                                if (linha == goalX && coluna == goalY)
                                {
                                    g.FillRectangle(goalBrush, celulaRect);
                                }

                                if (!started)
                                {
                                    stateX = startX;
                                    stateY = startY;
                                }
                                else if (train.EstadoAtual != null && train.EstadoAtual.Length > 0)
                                {
                                    stateX = train.EstadoAtual[1];
                                    stateY = train.EstadoAtual[0];
                                }

                                // Desenha o agente
                                if (linha == stateX && coluna == stateY)
                                {
                                    g.FillEllipse(agenteBrush, x + celulaLargura / 4, y + celulaAltura / 4, celulaLargura / 2, celulaAltura / 2);
                                }
                            }
                        }
                    }
                    #endregion
                }
                else
                {
                    if (!finshTrain) txtResult.Text += "Terminou!\r\n";
                    finshTrain = true;
                }
            }
            catch (Exception er)
            {
                string err = er.Message;
            }
        }

        private async void btnStart_Click(object sender, EventArgs e)
        {
            if (!started)
            {
                started = true;
                btnStart.Text = "Close";

                var treinamentoTask = IniciarProcessosAsync();
                await Task.WhenAll(treinamentoTask);
            }
            else
            {
                started = false;
                btnStart.Text = "Start";
                this.Dispose();
                this.Close();
            }
        }
    }
}
