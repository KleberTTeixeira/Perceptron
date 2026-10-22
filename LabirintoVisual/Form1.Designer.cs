namespace LabirintoVisual
{
    partial class formMaze
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pbLabirinto = new PictureBox();
            btnStart = new Button();
            label1 = new Label();
            label2 = new Label();
            lblTry = new Label();
            lblGoal = new Label();
            label3 = new Label();
            lblBestFootsteps = new Label();
            lblNoise = new Label();
            lblLearningRate = new Label();
            lblDiscountFactor = new Label();
            pbNoise = new PictureBox();
            pbLearningRate = new PictureBox();
            pbDiscountFactor = new PictureBox();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            txtResult = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pbLabirinto).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbNoise).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbLearningRate).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbDiscountFactor).BeginInit();
            SuspendLayout();
            // 
            // pbLabirinto
            // 
            pbLabirinto.BackColor = Color.Transparent;
            pbLabirinto.Location = new Point(50, 50);
            pbLabirinto.Name = "pbLabirinto";
            pbLabirinto.Size = new Size(884, 561);
            pbLabirinto.TabIndex = 0;
            pbLabirinto.TabStop = false;
            // 
            // btnStart
            // 
            btnStart.BackColor = Color.Transparent;
            btnStart.ForeColor = Color.Black;
            btnStart.Location = new Point(859, 20);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(75, 23);
            btnStart.TabIndex = 1;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = false;
            btnStart.Click += btnStart_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(493, 23);
            label1.Name = "label1";
            label1.Size = new Size(70, 15);
            label1.TabIndex = 2;
            label1.Text = "Finalizações";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(371, 23);
            label2.Name = "label2";
            label2.Size = new Size(59, 15);
            label2.TabIndex = 3;
            label2.Text = "Tentativas";
            // 
            // lblTry
            // 
            lblTry.AutoSize = true;
            lblTry.Location = new Point(436, 24);
            lblTry.Name = "lblTry";
            lblTry.Size = new Size(13, 15);
            lblTry.TabIndex = 4;
            lblTry.Text = "0";
            // 
            // lblGoal
            // 
            lblGoal.AutoSize = true;
            lblGoal.Location = new Point(569, 24);
            lblGoal.Name = "lblGoal";
            lblGoal.Size = new Size(13, 15);
            lblGoal.TabIndex = 5;
            lblGoal.Text = "0";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(618, 24);
            label3.Name = "label3";
            label3.Size = new Size(92, 15);
            label3.TabIndex = 6;
            label3.Text = "Menor distancia";
            // 
            // lblBestFootsteps
            // 
            lblBestFootsteps.AutoSize = true;
            lblBestFootsteps.Location = new Point(716, 23);
            lblBestFootsteps.Name = "lblBestFootsteps";
            lblBestFootsteps.Size = new Size(13, 15);
            lblBestFootsteps.TabIndex = 7;
            lblBestFootsteps.Text = "0";
            // 
            // lblNoise
            // 
            lblNoise.AutoSize = true;
            lblNoise.Location = new Point(1026, 28);
            lblNoise.Name = "lblNoise";
            lblNoise.Size = new Size(13, 15);
            lblNoise.TabIndex = 8;
            lblNoise.Text = "0";
            // 
            // lblLearningRate
            // 
            lblLearningRate.AutoSize = true;
            lblLearningRate.Location = new Point(1026, 235);
            lblLearningRate.Name = "lblLearningRate";
            lblLearningRate.Size = new Size(13, 15);
            lblLearningRate.TabIndex = 9;
            lblLearningRate.Text = "0";
            // 
            // lblDiscountFactor
            // 
            lblDiscountFactor.AutoSize = true;
            lblDiscountFactor.Location = new Point(1026, 442);
            lblDiscountFactor.Name = "lblDiscountFactor";
            lblDiscountFactor.Size = new Size(13, 15);
            lblDiscountFactor.TabIndex = 10;
            lblDiscountFactor.Text = "0";
            // 
            // pbNoise
            // 
            pbNoise.BorderStyle = BorderStyle.FixedSingle;
            pbNoise.Location = new Point(1026, 53);
            pbNoise.Name = "pbNoise";
            pbNoise.Size = new Size(230, 140);
            pbNoise.TabIndex = 11;
            pbNoise.TabStop = false;
            // 
            // pbLearningRate
            // 
            pbLearningRate.BackColor = Color.Black;
            pbLearningRate.BorderStyle = BorderStyle.FixedSingle;
            pbLearningRate.Location = new Point(1026, 260);
            pbLearningRate.Name = "pbLearningRate";
            pbLearningRate.Size = new Size(230, 140);
            pbLearningRate.TabIndex = 12;
            pbLearningRate.TabStop = false;
            // 
            // pbDiscountFactor
            // 
            pbDiscountFactor.BackColor = Color.Black;
            pbDiscountFactor.BorderStyle = BorderStyle.FixedSingle;
            pbDiscountFactor.Location = new Point(1026, 467);
            pbDiscountFactor.Name = "pbDiscountFactor";
            pbDiscountFactor.Size = new Size(230, 140);
            pbDiscountFactor.TabIndex = 13;
            pbDiscountFactor.TabStop = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 6.75F);
            label4.Location = new Point(1010, 51);
            label4.Name = "label4";
            label4.Size = new Size(13, 12);
            label4.TabIndex = 14;
            label4.Text = ".9";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 6.75F);
            label5.Location = new Point(1010, 258);
            label5.Name = "label5";
            label5.Size = new Size(13, 12);
            label5.TabIndex = 15;
            label5.Text = ".9";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 6.75F);
            label6.Location = new Point(1010, 465);
            label6.Name = "label6";
            label6.Size = new Size(13, 12);
            label6.TabIndex = 16;
            label6.Text = ".9";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Microsoft Sans Serif", 6.75F);
            label7.Location = new Point(1013, 181);
            label7.Name = "label7";
            label7.Size = new Size(10, 12);
            label7.TabIndex = 17;
            label7.Text = "0";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Microsoft Sans Serif", 6.75F);
            label8.Location = new Point(1013, 388);
            label8.Name = "label8";
            label8.Size = new Size(10, 12);
            label8.TabIndex = 18;
            label8.Text = "0";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Microsoft Sans Serif", 6.75F);
            label9.Location = new Point(1013, 597);
            label9.Name = "label9";
            label9.Size = new Size(10, 12);
            label9.TabIndex = 19;
            label9.Text = "0";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Microsoft Sans Serif", 6.75F);
            label10.Location = new Point(1010, 116);
            label10.Name = "label10";
            label10.Size = new Size(13, 12);
            label10.TabIndex = 20;
            label10.Text = ".5";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Microsoft Sans Serif", 6.75F);
            label11.Location = new Point(1010, 323);
            label11.Name = "label11";
            label11.Size = new Size(13, 12);
            label11.TabIndex = 21;
            label11.Text = ".5";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Microsoft Sans Serif", 6.75F);
            label12.Location = new Point(1010, 531);
            label12.Name = "label12";
            label12.Size = new Size(13, 12);
            label12.TabIndex = 22;
            label12.Text = ".5";
            // 
            // txtResult
            // 
            txtResult.BackColor = Color.Black;
            txtResult.BorderStyle = BorderStyle.FixedSingle;
            txtResult.ForeColor = Color.White;
            txtResult.Location = new Point(50, 632);
            txtResult.Multiline = true;
            txtResult.Name = "txtResult";
            txtResult.ReadOnly = true;
            txtResult.ScrollBars = ScrollBars.Vertical;
            txtResult.Size = new Size(1206, 138);
            txtResult.TabIndex = 23;
            // 
            // formMaze
            // 
            AcceptButton = btnStart;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(1310, 792);
            Controls.Add(txtResult);
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(pbDiscountFactor);
            Controls.Add(pbLearningRate);
            Controls.Add(pbNoise);
            Controls.Add(lblDiscountFactor);
            Controls.Add(lblLearningRate);
            Controls.Add(lblNoise);
            Controls.Add(lblBestFootsteps);
            Controls.Add(label3);
            Controls.Add(lblGoal);
            Controls.Add(lblTry);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnStart);
            Controls.Add(pbLabirinto);
            ForeColor = Color.White;
            Name = "formMaze";
            Padding = new Padding(50);
            Text = "Maze";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pbLabirinto).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbNoise).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbLearningRate).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbDiscountFactor).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pbLabirinto;
        private Button btnStart;
        private Label label1;
        private Label label2;
        private Label lblTry;
        private Label lblGoal;
        private Label label3;
        private Label lblBestFootsteps;
        private Label lblNoise;
        private Label lblLearningRate;
        private Label lblDiscountFactor;
        private PictureBox pbNoise;
        private PictureBox pbLearningRate;
        private PictureBox pbDiscountFactor;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private TextBox txtResult;
    }
}
