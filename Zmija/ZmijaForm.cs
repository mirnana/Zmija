using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace Zmija
{
    public partial class ZmijaForm : Form
    {
        //private Unit Food = new Unit(); // food moze biti isto lista hrane, mozemo napraviti klase BadFood i GoodFood koje ce imat los tj dobar ucinak na zmiju
        private List<BasicFood> Food = new List<BasicFood>();
        private List<Unit> Snake = new List<Unit>();
        private int scoreInt = 0;
        private int lives = 3;
        private int factor = 1;
        private bool left, right, up, down;
        private int rows, cols;
        private List<Type> types = new List<Type>();
        private int level;
        private int levelLimit;

        Random rand = new Random();
        public static Settings settings;

        public ZmijaForm()
        {
            this.KeyPreview = true;
            InitializeComponent();
            settings = new Settings();
        }

        private void ZmijaForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == settings.CloseKey)
            {
                this.Close();
            }

            // otvaranje drugih prozora:
            if (e.Control && e.KeyCode.ToString() == settings.SettingsKey)
            {
                timer.Stop();
                KeySettings s = new KeySettings();
                s.ShowDialog();
                if (!start.Enabled)
                {
                    timer.Start();
                }
            }
            if (e.Control && e.KeyCode.ToString() == settings.InstructionsKey)
            {
                timer.Stop();
                Instructions s = new Instructions();
                s.ShowDialog();
                if (!start.Enabled)
                {
                    timer.Start();
                }
            }

            // kretanje zmije:
            if (start.Enabled == false)
            {
                if ((e.KeyCode >= Keys.NumPad1 && e.KeyCode <= Keys.NumPad9)
                    || (e.KeyCode >= Keys.D1 && e.KeyCode <= Keys.D9))
                {
                    string s = e.KeyCode.ToString();
                    factor = int.Parse(s.Substring(s.Length - 1));
                }
                if (e.KeyCode.ToString() == settings.GoLeftKey && settings.Direction != "right")
                {
                    left = true;
                }
                if (e.KeyCode.ToString() == settings.GoRightKey && settings.Direction != "left")
                {
                    right = true;
                }
                if (e.KeyCode.ToString() == settings.GoUpKey && settings.Direction != "down")
                {
                    up = true;
                }
                if (e.KeyCode.ToString() == settings.GoDownKey && settings.Direction != "up")
                {
                    down = true;
                }
            }


        }
        private void ZmijaForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (factor != 1)
            {
                factor = 1;
            }
            if (e.KeyCode.ToString() == settings.GoLeftKey)
            {
                left = false;
            }
            if (e.KeyCode.ToString() == settings.GoRightKey)
            {
                right = false;
            }
            if (e.KeyCode.ToString() == settings.GoUpKey)
            {
                up = false;
            }
            if (e.KeyCode.ToString() == settings.GoDownKey)
            {
                down = false;
            }
        }

        private BasicFood CreateFood(List<Type> availableTypes)
        {
            Type type = availableTypes[rand.Next(availableTypes.Count)];
            object food = Activator.CreateInstance(type);

            PropertyInfo xProperty = type.GetProperty("X");
            xProperty.SetValue(food, rand.Next(2, cols));

            PropertyInfo yProperty = type.GetProperty("Y");
            yProperty.SetValue(food, rand.Next(2, rows));

            return (BasicFood)food;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (level < 10 && scoreInt >= levelLimit)
            {
                // provjeriti, dodati tidove, promjene polja
                switch (level)
                {
                    case 1:
                        level = 2;
                        // levelLimit = 250;     // ako zelimo druge granice
                        types.Add(typeof(BadFood));
                        Food.Add(CreateFood(types));
                        break;
                    case 2:
                        level = 3;
                        types.Add(typeof(FastFood));
                        break;
                    case 3:
                        level = 4;
                        types.Add(typeof(SlowFood));
                        break;
                    case 4:
                        level = 5;
                        Food.Add(CreateFood(types));
                        break;
                    case 5:
                        level = 6;
                        types.Add(typeof(SuperFood));
                        break;
                    case 6:
                        level = 7;
                        types.Add(typeof(DeathFood));
                        break;
                    case 7:
                        level = 8;
                        Food.Add(CreateFood(types));
                        break;
                    case 8:
                        level = 9;
                        break;
                    case 9:
                        level = 10;
                        break;
                }
                levelLimit = level * 100;
                score.Text = "BODOVI: " + scoreInt + Environment.NewLine + "ŽIVOTI: " + lives + Environment.NewLine + "LEVEL: " + level;
            }

            if (left)
            {
                settings.Direction = "left";
            }
            if (right)
            {
                settings.Direction = "right";
            }
            if (up)
            {
                settings.Direction = "up";
            }
            if (down)
            {
                settings.Direction = "down";
            }

            for (int k = 0; k < factor; k++)
            {
                for (int i = Snake.Count - 1; i >= 0; i--)
                {
                    if (i == 0)
                    {
                        switch (settings.Direction)
                        {
                            case "left":
                                Snake[i].X--;
                                break;
                            case "right":
                                Snake[i].X++;
                                break;
                            case "up":
                                Snake[i].Y--;
                                break;
                            case "down":
                                Snake[i].Y++;
                                break;
                        }

                        if (Snake[i].X < 0 || Snake[i].Y < 0 || Snake[i].X > cols || Snake[i].Y > rows)
                        {
                            DecreaseLives();
                        }

                        for (int j = 1; j < Snake.Count; j++)
                        {
                            if (Snake[i].X == Snake[j].X && Snake[i].Y == Snake[j].Y)
                            {
                                DecreaseLives();
                            }
                        }

                        // prepraviti da ne pretrazuje cijelu listu?
                        for (int j = 0; j < Food.Count; j++)
                        {
                            if (Snake[i].X == Food[j].X && Snake[i].Y == Food[j].Y)
                            {
                                EatFood(Food[j]);
                            }
                        }
                    }
                    else
                    {
                        Snake[i].X = Snake[i - 1].X;
                        Snake[i].Y = Snake[i - 1].Y;
                    }
                }
                for (int i = 0; i < Food.Count; i++)
                {
                    if (Food[i] is TimedFood && !Food[i].CheckTimer())
                    {
                        Food[i] = CreateFood(types);
                    }
                }
            }

            canvas.Invalidate();
        }

        private void start_Click(object sender, EventArgs e)
        {
            RestartGame();
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Brush color;

            for (int i = 0; i < Snake.Count; i++)
            {
                if (i == 0)
                {
                    color = Brushes.Green;
                }
                else
                {
                    color = Brushes.LightGreen;
                }

                g.FillRectangle
                    (
                        color,
                        new Rectangle
                        (
                            Snake[i].X * settings.UnitWidth,
                            Snake[i].Y * settings.UnitHeight,
                            settings.UnitWidth,
                            settings.UnitHeight
                        )
                    );
            }

            for (int i = 0; i < Food.Count; i++)
            {
                g.FillRectangle
                (
                    Food[i].Color,
                    new Rectangle
                    (
                        Food[i].X * settings.UnitWidth,
                        Food[i].Y * settings.UnitHeight,
                        settings.UnitWidth,
                        settings.UnitHeight
                    )
                );
            }
        }

        private void DecreaseLives()
        {
            lives--;
            score.Text = "BODOVI: " + scoreInt + Environment.NewLine + "ŽIVOTI: " + lives + Environment.NewLine + "LEVEL: " + level;

            if (lives <= 0)
            {
                GameOver();
            }
            else
            {
                Snake[0].X = 10;
                Snake[0].Y = 10;
                canvas.Invalidate();
            }
        }

        private void GameOver()
        {
            timer.Stop();
            start.Enabled = true;
        }

        private void EatFood(BasicFood food)
        {
            // npr:
            // ak je dobra hrana, dodaj novi Unit na kraj zmije
            // ak je losa hrana, ukloni zadnji Unit zmije

            //scoreInt += 1;
            // malo glupo rjesenje, radi trenutno (new lives < lives -> decrease)
            // mozda vratiti i speed
            int newLives;
            (scoreInt, newLives) = food.ActivateEffect(Snake, scoreInt, lives);
            if (newLives < lives)
            {
                DecreaseLives();
            }
            else
            {
                score.Text = "BODOVI: " + scoreInt + Environment.NewLine + "ŽIVOTI: " + lives + Environment.NewLine + "LEVEL: " + level;
            }

            // prebaceno u food efekt
            /*Unit rear = new Unit
            {
                X = Snake[Snake.Count - 1].X,
                Y = Snake[Snake.Count - 1].Y,
            };
            Snake.Add(rear);*/

            int ind = Food.IndexOf(food);
            if (ind > 0)
            {
                Food[ind] = CreateFood(types);
            }
            else
            {
                Food[ind] = new BasicFood { X = rand.Next(2, cols), Y = rand.Next(2, rows) };
            }
        }

        private void RestartGame()
        {
            rows = canvas.Height / settings.UnitHeight - 1;
            cols = canvas.Width / settings.UnitWidth - 1;

            Snake.Clear();

            start.Enabled = false;
            lives = 3;
            scoreInt = 0;
            level = 1;
            levelLimit = 100;
            // dodati brzinu i "do iduceg levela"?
            score.Text = "BODOVI: " + scoreInt + Environment.NewLine + "ŽIVOTI: " + lives + Environment.NewLine + "LEVEL: " + level;

            Unit head = new Unit { X = 10, Y = 10 };
            Snake.Add(head);

            for (int i = 0; i < 5; i++)
            {
                Snake.Add(new Unit());
            }

            Food.Clear();
            Food.Add(new BasicFood { X = rand.Next(2, cols), Y = rand.Next(2, rows) });
            types.Clear();
            types.Add(typeof(BasicFood));

            timer.Start();
        }
    }
}
