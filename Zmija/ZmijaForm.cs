using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using System.Threading;
using System.Drawing.Drawing2D;

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
        private string[,] matrix;
        private int invTimer;
        private int sleepy_timer;
        private bool player;
        private List<Unit> EnemySnake = new List<Unit>();
        private string enemySnakeDirection;
        private int currentSleep;
        private int enemySleep;




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
        //note to self, napraviti provjeru postoji li na ovom polju vec neka hrana
        private (int, int) FindEmptyField()
        {
            var filteredList = Enumerable.Range(0, matrix.GetLength(0))
                             .SelectMany(i => Enumerable.Range(0, matrix.GetLength(1))
                             .Select(j => new { i, j }))
                             .Where(ij => matrix[ij.i, ij.j] == "" && Snake[0].X != ij.i && Snake[0].Y != ij.j
                             && Snake[0].X + 1!= ij.i && Snake[0].Y + 1 != ij.j 
                             && Snake[0].X - 1!= ij.i && Snake[0].Y - 1 != ij.j);
            var newField = filteredList.ElementAt(rand.Next(filteredList.Count()));
            return (newField.i, newField.j);
        }

        private BasicFood CreateFood(List<Type> availableTypes)
        {
            List<Type> unusableTypes = new List<Type>();
            if (sleepy_timer > 9)
                unusableTypes.Add(typeof(SlowFood));
            if (sleepy_timer < 2)
                unusableTypes.Add(typeof(FastFood));
            if (scoreInt < 10)
                unusableTypes.Add(typeof(BadFood));
            if (invTimer > 0)
                unusableTypes.Add(typeof(InvincibleFood));
            if (Snake.Count < 5)
                unusableTypes.Add(typeof(ShortFood));
            if (lives > 1)
                unusableTypes.Add(typeof(LifeFood));

            Type type = availableTypes.Except(unusableTypes).ToList()[rand.Next(availableTypes.Except(unusableTypes).ToList().Count)];
            object food = Activator.CreateInstance(type);
            var field = FindEmptyField();

            PropertyInfo xProperty = type.GetProperty("X");
            xProperty.SetValue(food, field.Item1);

            PropertyInfo yProperty = type.GetProperty("Y");
            yProperty.SetValue(food, field.Item2);

            return (BasicFood)food;
        }

        private BasicFood CreateFood(Type type)
        {
            object food = Activator.CreateInstance(type);
            var field = FindEmptyField();

            PropertyInfo xProperty = type.GetProperty("X");
            xProperty.SetValue(food, field.Item1);

            PropertyInfo yProperty = type.GetProperty("Y");
            yProperty.SetValue(food, field.Item2);

            return (BasicFood)food;
        }

        private BasicFood CreateBrick(int xPosition, int yPosition)
        {
            Type type = typeof(BorderBlock);
            object brick = Activator.CreateInstance(type);

            PropertyInfo xProperty = type.GetProperty("X");
            xProperty.SetValue(brick, xPosition);

            PropertyInfo yProperty = type.GetProperty("Y");
            yProperty.SetValue(brick, yPosition);

            // ne radi, ne prebaci hranu, prebaci brick.... fix [1] -> .Substring(1) ako sam negdje zaboravila
            if (matrix[xPosition, yPosition] != "" && matrix[xPosition, yPosition][0] == 'f')
            {
                var field = FindEmptyField();
                int ind = int.Parse(matrix[xPosition, yPosition].Substring(1).ToString());
                Food[ind].X = field.Item1;
                Food[ind].Y = field.Item2;
                matrix[Food[ind].X, Food[ind].Y] = "f" + ind.ToString();
            }

            matrix[xPosition, yPosition] = "b";

            return (BasicFood)brick;
        }



        //U sljedecu funkciju se ulazi svaki put kada zmija napravi pomak
        //a na levelu je vecem od 1 pa sam dodala par uvjeta da se odvrsi samo jednom po levelu
        private void timer_Tick(object sender, EventArgs e)
        {
            if (player)
            {
                if (left && settings.Direction != "right")
                {
                    settings.Direction = "left";
                }
                if (right && settings.Direction != "left")
                {
                    settings.Direction = "right";
                }
                if (up && settings.Direction != "down")
                {
                    settings.Direction = "up";
                }
                if (down && settings.Direction != "up")
                {
                    settings.Direction = "down";
                }

                for (int k = 0; k < factor; k++)
                {
                    if(factor != 1 || currentSleep == 1)
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
                                    if (Snake[i].X == Snake[j].X && Snake[i].Y == Snake[j].Y && invTimer == 0)
                                    {
                                        DecreaseLives();
                                    }
                                }

                                for (int j = 0; j < EnemySnake.Count; j++)
                                {
                                    if (Snake[i].X == EnemySnake[j].X && Snake[i].Y == EnemySnake[j].Y && invTimer == 0)
                                    {
                                        DecreaseLives();
                                    }
                                }

                                if (Snake[i].X >= 0 && Snake[i].Y >= 0 && Snake[i].X <= cols && Snake[i].Y <= rows)
                                {
                                    string s = matrix[Snake[i].X, Snake[i].Y];
                                    if (s != "" && s[0] == 'f')
                                    {
                                        EatFood(Food[int.Parse(s.Substring(1).ToString())]);
                                    }
                                    else if (s == "b" && invTimer == 0)
                                    {
                                        DecreaseLives();
                                    }
                                }
                                // trenutacno samo provjeravam je li zmija udarila zid glavom
                                // ne racuna se ako neki dio zapne na zidu zbog InvincibleFood
                            }
                            else
                            {
                                Snake[i].X = Snake[i - 1].X;
                                Snake[i].Y = Snake[i - 1].Y;
                            }
                        }
                        currentSleep = sleepy_timer;
                    }
                }
                if(currentSleep > 1)
                    currentSleep--;

                factor = 1;
                player = false;
            }
            else
            {
                if (level == 10)
                {
                    (int, int) lastPlace = (0,0);
                    if (!EnemySnake.Any())
                    {
                        EnemySnake.Add(new Unit { X = 17, Y = 2 });
                        EnemySnake.Add(new Unit { X = 18, Y = 2 });
                        EnemySnake.Add(new Unit { X = 19, Y = 2 });
                        EnemySnake.Add(new Unit { X = 20, Y = 2 });
                        EnemySnake.Add(new Unit { X = 21, Y = 2 });
                        enemySnakeDirection = "left";

                        for (int j = 0; j < Snake.Count; j++)
                        {
                            if (Snake[j].X == 17 && Snake[j].Y == 2 && invTimer == 0)
                            {
                                DecreaseLives();
                            }
                        }
                    }
                    else
                    {
                        if(enemySleep == 1)
                        {
                            for (int i = EnemySnake.Count - 1; i >= 0; i--)
                            {
                                if (i == 0)
                                {
                                    if (EnemySnake[i].X < cols / 2)
                                    {
                                        if (EnemySnake[i].Y < rows / 2 && (EnemySnake[i].X + 1) % 3 == 0 && (EnemySnake[i].Y + 1) % 3 == 0)
                                        {
                                            if (enemySnakeDirection == "left")
                                            {
                                                enemySnakeDirection = "down";
                                            }
                                            else
                                            {
                                                enemySnakeDirection = "left";
                                            }
                                        }
                                        else if (EnemySnake[i].Y > rows / 2 && (EnemySnake[i].X + 1) % 3 == 0 && (EnemySnake[i].Y + 2) % 3 == 0)
                                        {
                                            if (enemySnakeDirection == "right")
                                            {
                                                enemySnakeDirection = "down";
                                            }
                                            else
                                            {
                                                enemySnakeDirection = "right";
                                            }
                                        }
                                    }
                                    else if (EnemySnake[i].X > cols / 2)
                                    {
                                        if (EnemySnake[i].Y < rows / 2 && (EnemySnake[i].X + 2) % 3 == 0 && (EnemySnake[i].Y + 1) % 3 == 0)
                                        {
                                            if (enemySnakeDirection == "left")
                                            {
                                                enemySnakeDirection = "up";
                                            }
                                            else
                                            {
                                                enemySnakeDirection = "left";
                                            }
                                        }
                                        else if (EnemySnake[i].Y > rows / 2 && (EnemySnake[i].X + 2) % 3 == 0 && (EnemySnake[i].Y + 2) % 3 == 0)
                                        {
                                            if (enemySnakeDirection == "right")
                                            {
                                                enemySnakeDirection = "up";
                                            }
                                            else
                                            {
                                                enemySnakeDirection = "right";
                                            }
                                        }
                                    }

                                    switch (enemySnakeDirection)
                                    {
                                        case "left":
                                            EnemySnake[i].X--;
                                            break;
                                        case "right":
                                            EnemySnake[i].X++;
                                            break;
                                        case "up":
                                            EnemySnake[i].Y--;
                                            break;
                                        case "down":
                                            EnemySnake[i].Y++;
                                            break;
                                    }

                                    for (int j = 0; j < Snake.Count; j++)
                                    {
                                        if (EnemySnake[i].X == Snake[j].X && EnemySnake[i].Y == Snake[j].Y && invTimer == 0)
                                        {
                                            DecreaseLives();
                                        }
                                    }
                                }
                                else
                                {
                                    if (i == EnemySnake.Count - 1)
                                    {
                                        lastPlace = (EnemySnake[i].X, EnemySnake[i].Y);
                                    }
                                    EnemySnake[i].X = EnemySnake[i - 1].X;
                                    EnemySnake[i].Y = EnemySnake[i - 1].Y;
                                }

                            }

                            enemySleep = 5;
                        }
                        else
                        {
                            enemySleep--;
                        }
                    }

                    string s = matrix[EnemySnake[0].X, EnemySnake[0].Y];
                    if (s != "" && s[0] == 'f')
                    {
                        int ind = int.Parse(s.Substring(1).ToString());
                        if (ind == 0)
                        {
                            Food[ind] = CreateFood(typeof(BasicFood));
                        }
                        else
                        {
                            Food[ind] = CreateFood(types);
                        }
                        matrix[EnemySnake[0].X, EnemySnake[0].Y] = "";
                        matrix[Food[ind].X, Food[ind].Y] = "f" + ind.ToString();

                        if (EnemySnake.Count < 20)
                        {
                            EnemySnake.Add(new Unit { X = lastPlace.Item1, Y = lastPlace.Item2 });
                        }
                    }
                }
                player = true;
            }

            if (level < 10 && scoreInt >= level * levelLimit)
            {
                // provjeriti, dodati tidove, promjene polja
                switch (level)
                {
                    case 1:
                        level = 2;
                        types.Add(typeof(BadFood));
                        Food.Add(CreateFood(typeof(BadFood)));
                        break;
                    case 2:
                        level = 3;
                        types.Add(typeof(FastFood));
                        Food.Add(CreateFood(typeof(FastFood)));
                        break;
                    case 3:
                        level = 4;
                        types.Add(typeof(SlowFood));
                        Food.Add(CreateFood(typeof(SlowFood)));
                        break;
                    case 4:
                        level = 5;
                        types.Add(typeof(ShortFood));
                        Food.Add(CreateFood(typeof(ShortFood)));
                        break;
                    case 5:
                        level = 6;
                        types.Add(typeof(SuperFood));
                        Food.Add(CreateFood(typeof(SuperFood)));
                        break;
                    case 6:
                        level = 7;
                        types.Add(typeof(DeathFood));
                        Food.Add(CreateFood(typeof(DeathFood)));
                        break;
                    case 7:
                        level = 8;
                        types.Add(typeof(InvincibleFood));
                        Food.Add(CreateFood(typeof(InvincibleFood)));
                        break;
                    case 8:
                        level = 9;
                        types.Add(typeof(LifeFood));
                        Food.Add(CreateFood(typeof(LifeFood)));
                        break;
                    case 9:
                        level = 10;
                        Food.Add(CreateFood(types));
                        break;
                }
                int ind = Food.Count-1;
                matrix[Food[ind].X, Food[ind].Y] = "f" + ind.ToString();
                for (int i = 0; i < level-1; i++)
                {
                    Food.Add(CreateBrick(level - 2 - i, i));
                    Food.Add(CreateBrick(i, cols - level + 2 + i));
                    Food.Add(CreateBrick(rows - level + 2 + i, i));
                    Food.Add(CreateBrick(rows - i, cols - level + 2 + i));
                }

                if(level == 10)
                {
                    for(int j = 1; j <= 2; j++)
                    {
                        for (int i = 0; i < level + j - 1; i++)
                        {
                            Food.Add(CreateBrick(level + j - 2 - i, i));
                            Food.Add(CreateBrick(i, cols - level - j + 2 + i));
                            Food.Add(CreateBrick(rows - level - j + 2 + i, i));
                            Food.Add(CreateBrick(rows - i, cols - level - j + 2 + i));
                        }
                    }
                }

                score.Text = "BODOVI: " + scoreInt;
                livesAndLevel.Text = "ŽIVOTI: " + lives + Environment.NewLine + "LEVEL: " + level;
            }

            for (int i = 0; i < Food.Count; i++)
            {
                if (Food[i] is TimedFood && !Food[i].CheckTimer())
                {
                    matrix[Food[i].X, Food[i].Y] = "";
                    Food[i] = CreateFood(types);
                    matrix[Food[i].X, Food[i].Y] = "f" + i.ToString();
                }
            }

            if(invTimer > 0)
            {
                invTimer--;
                if(invTimer == 0)
                {
                    invincibility.Text = "";
                }
                else if(invTimer % 100 == 9)
                {
                    invincibility.Text = "INV TIMER: " + Math.Ceiling((double)invTimer / 100);
                }
            }


            canvas.Invalidate();
            //Thread.Sleep(sleepy_timer);

        }

        private void start_Click(object sender, EventArgs e)
        {
            RestartGame();
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Brush color;

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

            for (int i = 0; i < Snake.Count; i++)
            {
                if (i == 0)
                {
                    if(invTimer > 0)
                    {
                        color = Brushes.DarkViolet;
                    }
                    else
                    {
                        color = Brushes.Green;
                    }
                }
                else
                {
                    if (invTimer > 0)
                    {
                        color = Brushes.Violet;
                    }
                    else
                    {
                        color = Brushes.LightGreen;
                    }
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

            for (int i = 0; i < EnemySnake.Count; i++)
            {
                if (i == 0)
                {
                    color = Brushes.SeaGreen;
                }
                else
                {
                    color = Brushes.MediumAquamarine;
                }

                g.FillRectangle
                    (
                        color,
                        new Rectangle
                        (
                            EnemySnake[i].X * settings.UnitWidth,
                            EnemySnake[i].Y * settings.UnitHeight,
                            settings.UnitWidth,
                            settings.UnitHeight
                        )
                    );
            }
        }

        private void canvas_Click(object sender, EventArgs e)
        {

        }

        private void DecreaseLives()
        {
            lives--;

            sleepy_timer = 5;
            currentSleep = 5;
            if(invTimer > 0)
            {
                invTimer = 0;
                invincibility.Text = "";
            }
            livesAndLevel.Text = "ŽIVOTI: " + lives + Environment.NewLine + "LEVEL: " + level;

            if (lives <= 0)
            {
                GameOver();
            }
            else
            {
                int snake_length = Snake.Count;
                Snake.Clear();
                Unit head = new Unit { X = 15, Y = 12 };
                Snake.Add(head);
                for (int i = 0; i < snake_length; i++)
                {
                    Snake.Add(new Unit());
                }
          
                settings.Direction = "down";
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
            int newLives;
            bool inv;
            (scoreInt, newLives, sleepy_timer, inv) = food.ActivateEffect(Snake, scoreInt, lives, sleepy_timer);
            if(sleepy_timer < currentSleep)
            {
                currentSleep = sleepy_timer;
            }
            
            if (newLives < lives)
            {
                DecreaseLives();
            }
            else
            {
                lives = newLives;
                score.Text = "BODOVI: " + scoreInt;
                livesAndLevel.Text = "ŽIVOTI: " + lives + Environment.NewLine + "LEVEL: " + level;
            }

            if (inv)
            {
                invTimer = 3000;
                invincibility.Text = "INV TIMER: " + Math.Ceiling((double)invTimer / 100);
            }

            int ind = Food.IndexOf(food);
            if (Food[ind].Color != Brushes.DarkGray)
            {
                // ostaviti da se moze ponovno stvoriti na istom mjestu?
                matrix[Food[ind].X, Food[ind].Y] = "";
                if (ind > 0)
                {
                    Food[ind] = CreateFood(types);
                }
                else
                {
                    var field = FindEmptyField();
                    Food[ind] = new BasicFood { X = field.Item1, Y = field.Item2 };
                }
                matrix[Food[ind].X, Food[ind].Y] = "f" + ind.ToString();
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
            invTimer = 0;
            // dodati brzinu i "do iduceg levela"?
            score.Text = "BODOVI: " + scoreInt;
            livesAndLevel.Text = "ŽIVOTI: " + lives + Environment.NewLine + "LEVEL: " + level;
            invincibility.Text = "";

            Unit head = new Unit { X = 10, Y = 10 };
            Snake.Add(head);

            for (int i = 0; i < 5; i++)
            {
                Snake.Add(new Unit());
            }

            matrix = new string[rows + 1, cols + 1];
            // microsoft doslovno ne zna bolji nacin
            for (int i = 0; i < rows + 1; i++)
            {
                for (int j = 0; j < cols + 1; j++)
                {
                    matrix[i, j] = "";
                }
            }

            Food.Clear();
            // moze se staviti da bira empty field, ali u ovom trenu je sve prazno osim zmije
            // trenutacno se moze staviti preko zmije
            Food.Add(new BasicFood { X = rand.Next(2, cols), Y = rand.Next(2, rows) });
            // f = food, 0 = index (da zmija odmah zna sto je pojela)
            // b = brick
            matrix[Food[0].X, Food[0].Y] = "f0";
            types.Clear();
            types.Add(typeof(BasicFood));

            timer.Interval = 10;
            sleepy_timer = 5;
            currentSleep = 5;
            settings.Direction = "down";
            player = true;
            EnemySnake.Clear();
            enemySleep = 5;

            timer.Start();
        }
    }
}
