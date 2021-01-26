using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    public partial class Snake : Form
    {
        enum Polinja
        {
            Prazno,
            Finki,
            Food
        };

        enum Directions
        {
            Up,
            Down,
            Left,
            Right
        };


        Polinja[,] pole;
        List<Coordinates> coordinates = new List<Coordinates>();

        int snakeLength;
        Directions direction;
        Graphics g;
        Random random = new Random();

        public Snake()
        {
            InitializeComponent();
            Scores();
            pole = new Polinja[12, 12];
            // 12x12 e celata staza, a 11x11 kade shto se dvizhi zmijata
            for (int i = 0; i < 144; i++)
            {
                coordinates.Add(new Coordinates(0, 0));
            }
        }

        private void gameBoard_Click(object sender, EventArgs e)
        {

        }

        private void frmSnake_Load(object sender, EventArgs e)
        {
            board.Image = new Bitmap(650, 650);
            g = Graphics.FromImage(board.Image);
            g.Clear(Color.White);

            for (int i = 1; i <= 11; i++)
            {
                //Gore i dole
                g.DrawImage(sliki.Images[6], i * 50, 0);
                g.DrawImage(sliki.Images[6], i * 50, (12 * 50));
            }

            for (int i = 0; i <= 12; i++)
            {
                //Levo i desno
                g.DrawImage(sliki.Images[6], 0, i * 50);
                g.DrawImage(sliki.Images[6], (12 * 50), i * 50);
            }


            coordinates.Insert(0, new Coordinates(6, 6));
            coordinates.Insert(1, new Coordinates(6, 7));
            coordinates.Insert(2, new Coordinates(6, 8));

            g.DrawImage(sliki.Images[5], 6 * 50, 6 * 50); // glava
            pole[6, 6] = Polinja.Finki;

            g.DrawImage(sliki.Images[4], 6 * 50, 7 * 50);
            pole[6, 7] = Polinja.Finki;

            g.DrawImage(sliki.Images[4], 6 * 50, 8 * 50);
            pole[6, 8] = Polinja.Finki;

            direction = Directions.Up; // Vo start odi nagore
            snakeLength = 3;

            // Vo start se pojavuvaat 4 jadenja
            for (int i = 0; i < 4; i++)
            {
                Hrana();
            }
        }

        private void Hrana()
        {
            int x, y;


            x = random.Next(1, 11);
            y = random.Next(1, 11);

            while (pole[x, y] != Polinja.Prazno) {
                x = random.Next(1, 11);
                y = random.Next(1, 11);
            }

            pole[x, y] = Polinja.Food;
            g.DrawImage(sliki.Images[random.Next(0, 4)], x * 50, y * 50);
        }

        private void pritisnatoKopche(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                direction = Directions.Up;
            }
            else if (e.KeyCode == Keys.Down)
            {
                direction = Directions.Down;
            }
            else if (e.KeyCode == Keys.Left)
            {
                direction = Directions.Left;
            }
            else if (e.KeyCode == Keys.Right)
            {
                direction = Directions.Right;
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        { 
            // Oboi belo koga kje se trgne zmijata
            g.FillRectangle(Brushes.White, coordinates.ElementAt(snakeLength - 1).x * 50, coordinates.ElementAt(snakeLength - 1).y * 50, 50, 50);
            pole[coordinates.ElementAt(snakeLength - 1).x, coordinates.ElementAt(snakeLength - 1).y] = Polinja.Prazno;
            board.Refresh();

            // move
            for (int i = snakeLength; i >= 1; i--)
            {
                coordinates.ElementAt(i).x = coordinates.ElementAt(i - 1).x;
                coordinates.ElementAt(i).y = coordinates.ElementAt(i - 1).y;
            }

            g.DrawImage(sliki.Images[4], coordinates.ElementAt(0).x * 50, coordinates.ElementAt(0).y * 50);

            if (direction == Directions.Up)
            {
                coordinates.ElementAt(0).y = coordinates.ElementAt(0).y - 1;
            }
            else if (direction == Directions.Down)
            {
                coordinates.ElementAt(0).y = coordinates.ElementAt(0).y + 1;
            }
            else if (direction == Directions.Left)
            {
                coordinates.ElementAt(0).x = coordinates.ElementAt(0).x - 1;
            }
            else if (direction == Directions.Right)
            {
                coordinates.ElementAt(0).x = coordinates.ElementAt(0).x + 1;
            }

            // Ako udri dzid
            if (coordinates.ElementAt(0).x < 1 || coordinates.ElementAt(0).x > 10 || coordinates.ElementAt(0).y < 1 || coordinates.ElementAt(0).y > 10)
            {
                GameOver("FEIT killed FINKI");
                board.Refresh();
                return;
            }

            // Ako se grizne
            if (pole[coordinates.ElementAt(0).x, coordinates.ElementAt(0).y] == Polinja.Finki)
            {
                GameOver("FINKI ate itself");
                board.Refresh();
                return;
            }

            // Ako grizne hrana
            if (pole[coordinates.ElementAt(0).x, coordinates.ElementAt(0).y] == Polinja.Food)
            {
                g.DrawImage(sliki.Images[4], coordinates.ElementAt(snakeLength).x * 50, coordinates.ElementAt(snakeLength).y * 50);
                pole[coordinates.ElementAt(snakeLength).x, coordinates.ElementAt(snakeLength).y] = Polinja.Finki;
                snakeLength++;
                scoreLabel.Text = "Score: " + (snakeLength - 3);
                Hrana();
            }

            g.DrawImage(sliki.Images[5], coordinates.ElementAt(0).x * 50, coordinates.ElementAt(0).y * 50);
            pole[coordinates.ElementAt(0).x, coordinates.ElementAt(0).y] = Polinja.Finki;

            board.Refresh();
        }

        private void Scores()
        {
            if (!File.Exists("scores.txt"))
            {
                TextWriter textWriter = new StreamWriter("scores.txt");
                textWriter.Close();
            }
            StreamReader textReader = new StreamReader("scores.txt");
            highScores.Text = textReader.ReadToEnd();
            textReader.Close();
        }

        private void DodajScore(string text)
        {
            string oldScores;
            using(StreamReader streamReader = new StreamReader("scores.txt"))
            {
                oldScores = streamReader.ReadToEnd();
            }

            File.Delete("scores.txt");

            Scores();

            using (StreamWriter textWriter = File.AppendText("scores.txt"))
            {
                textWriter.WriteLine("\n" + text + "\n" + oldScores);
                textWriter.Close();
            }

            Scores();
        }

        private void GameOver(string text)
        {
            timer.Enabled = false;

            Form2 f2 = new Form2();
            f2.ShowDialog();
            string newScore = f2.getScore();
            DodajScore(newScore + ": " + (snakeLength - 3));
            if ((MessageBox.Show("Дали сакаш да играш повторно?", "Message", MessageBoxButtons.YesNo)) ==
                DialogResult.Yes)
            {
                Application.Restart();
            }
        }
    }
}
