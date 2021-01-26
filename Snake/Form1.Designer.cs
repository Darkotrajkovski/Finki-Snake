namespace Snake
{
    partial class Snake
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Snake));
            this.board = new System.Windows.Forms.PictureBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.sliki = new System.Windows.Forms.ImageList(this.components);
            this.scoreLabel = new System.Windows.Forms.Label();
            this.highScores = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.board)).BeginInit();
            this.SuspendLayout();
            // 
            // board
            // 
            this.board.Location = new System.Drawing.Point(0, 0);
            this.board.Name = "board";
            this.board.Size = new System.Drawing.Size(900, 900);
            this.board.TabIndex = 0;
            this.board.TabStop = false;
            this.board.Click += new System.EventHandler(this.gameBoard_Click);
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 500;
            this.timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // sliki
            // 
            this.sliki.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("sliki.ImageStream")));
            this.sliki.TransparentColor = System.Drawing.Color.Transparent;
            this.sliki.Images.SetKeyName(0, "swift-og.png");
            this.sliki.Images.SetKeyName(1, "1200px-Kotlin-logo.svg.png");
            this.sliki.Images.SetKeyName(2, "download (1).png");
            this.sliki.Images.SetKeyName(3, "java-logo-png-clip-art-thumbnail.png");
            this.sliki.Images.SetKeyName(4, "logo-large-500x500_2.png");
            this.sliki.Images.SetKeyName(5, "1.png");
            this.sliki.Images.SetKeyName(6, "download.png");
            // 
            // scoreLabel
            // 
            this.scoreLabel.AutoSize = true;
            this.scoreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scoreLabel.Location = new System.Drawing.Point(906, 20);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Size = new System.Drawing.Size(94, 25);
            this.scoreLabel.TabIndex = 1;
            this.scoreLabel.Text = "Score: 0";
            // 
            // highScores
            // 
            this.highScores.AutoSize = true;
            this.highScores.Location = new System.Drawing.Point(908, 105);
            this.highScores.Name = "highScores";
            this.highScores.Size = new System.Drawing.Size(71, 17);
            this.highScores.TabIndex = 2;
            this.highScores.Text = "oldScores";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(908, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Scores:";
            // 
            // Snake
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1075, 906);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.highScores);
            this.Controls.Add(this.scoreLabel);
            this.Controls.Add(this.board);
            this.Name = "Snake";
            this.Text = "Snake Game";
            this.Load += new System.EventHandler(this.frmSnake_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.pritisnatoKopche);
            ((System.ComponentModel.ISupportInitialize)(this.board)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox board;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.ImageList sliki;
        private System.Windows.Forms.Label scoreLabel;
        private System.Windows.Forms.Label highScores;
        private System.Windows.Forms.Label label1;
    }
}

