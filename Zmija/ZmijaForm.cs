using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using System.Threading;
using System.Drawing.Drawing2D;
using System.Timers;

namespace Zmija
{
    public partial class ZmijaForm : Form
    {
        /// <summary>
        /// Lista hrane i zidova na ploci
        /// </summary>
        private List<BasicFood> Food = new List<BasicFood>();
        /// <summary>
        /// Lista jedinica zmije
        /// </summary>
        private List<Unit> Snake = new List<Unit>();
        /// <summary>
        /// Bodovi
        /// </summary>
        private int scoreInt = 0;
        /// <summary>
        /// Zivoti
        /// </summary>
        private int lives = 3;
        /// <summary>
        /// Faktor za kretanje za neki broj
        /// </summary>
        private int factor = 1;
        /// <summary>
        /// Dimenzije ploce
        /// </summary>
        private int rows, cols;
        /// <summary>
        /// Dopustene klase hrane
        /// </summary>
        private List<Type> types = new List<Type>();
        /// <summary>
        /// Trenutni level (1-10)
        /// </summary>
        private int level;
        /// <summary>
        /// Razlika izmedju levela
        /// </summary>
        private int levelLimit;
        /// <summary>
        /// Matrica koja pamti polozaje hrane i zidova na ploci
        /// </summary>
        private string[,] matrix;
        /// <summary>
        /// Timer koji prati trajanje efekta neunistivosti
        /// </summary>
        private System.Timers.Timer invTimer;
        /// <summary>
        /// Varijabla koja oznacava je li efekt neunistivosti trenutno aktivan
        /// </summary>
        private bool invTimerActive;
        /// <summary>
        /// Varijabla koja pamti pocetno vrijeme aktivacije efekta neunistivosti
        /// </summary>
        private DateTime invStartTime;
        /// <summary>
        /// Brzina kretanja zmije (manji timer - veca brzina)
        /// </summary>
        private int sleepy_timer;
        /// <summary>
        /// Varijabla koja oznacava pomice li se trenutno nasa ili protivnicka zmija
        /// </summary>
        private bool player;
        /// <summary>
        /// Lista jedinica protivnicke zmije
        /// </summary>
        private List<Unit> EnemySnake = new List<Unit>();
        /// <summary>
        /// Trenutni smjer kretanja protivnicke zmije
        /// </summary>
        private string enemySnakeDirection;
        /// <summary>
        /// Kontrola brzine zmije
        /// </summary>
        private int currentSleep;
        /// <summary>
        /// Kontrola brzine protivnicke zmije
        /// </summary>
        private int enemySleep;
        /// <summary>
        /// Lista koji pamti odabrane smjerove
        /// </summary>
        private List<String> movement = new List<string>();
        /// <summary>
        /// Smjer kretanja zmije
        /// </summary>
        private string snake_move;

        /// <summary>
        /// Random varijabla za odabir nasumicnih mjesta na ploci
        /// </summary>
        Random rand = new Random();
        /// <summary>
        /// Postavke za kretanje
        /// </summary>
        public static Settings settings;

        public ZmijaForm()
        {
            this.KeyPreview = true;
            InitializeComponent();
            settings = new Settings();
            setHelpText();
        }

        /// <summary>
        /// Metoda registrira i sprema (ukoliko je validan) unos tipkovnice.
        /// </summary>
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
                setHelpText();
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

                if (e.KeyCode.ToString() == settings.GoLeftKey)
                {
                    movement.Add("left");
                    if (e.Shift)
                    {
                        int koliko = Snake[0].X - 1;
                        int kamo = cols;
                        while (matrix[kamo--, Snake[0].Y] == "b")
                        {
                            koliko--;
                        }
                        factor = koliko;
                    }
                }
                if (e.KeyCode.ToString() == settings.GoRightKey)
                {
                    movement.Add("right");

                    if (e.Shift)
                    {
                        int koliko = cols - Snake[0].X - 1;
                        int kamo = 0;
                        while (matrix[kamo++, Snake[0].Y] == "b")
                        {
                            koliko--;
                        }
                        factor = koliko;
                    }
                }
                if (e.KeyCode.ToString() == settings.GoUpKey)
                {
                    movement.Add("up");

                    if (e.Shift)
                    {
                        int koliko = Snake[0].Y - 1;
                        int kamo = 0;
                        while (matrix[Snake[0].X, kamo++] == "b")
                        {
                            koliko--;
                        }
                        factor = koliko;
                    }
                }
                if (e.KeyCode.ToString() == settings.GoDownKey)
                {
                    movement.Add("down");

                    if (e.Shift)
                    {
                        int koliko = rows - Snake[0].Y - 1;
                        int kamo = rows;
                        while (matrix[Snake[0].X, kamo--] == "b")
                        {
                            koliko--;
                        }
                        factor = koliko;
                    }
                }
            }
        }

        /// <summary>
        /// Metoda pretrazuje matricu te vraca nepopunjeno (nasumicno odabrano) mjesto u matrici preko njegovih koordinata 
        /// pritom pazeci da ne odabere lokaciju koja je u neposrednoj blizini glave zmije.
        /// </summary>
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

        /// <summary>
        /// Metoda prima popis svih tipova hrane koje mozemo stvoriti. Stvara nasumicno odabran tip hrane na nasumicnoj, nezauzetoj lokaciji
        /// te vraca stvorenu hranu u obliku klase BasicFood.
        /// </summary>
        private BasicFood CreateFood(List<Type> availableTypes)
        {
            List<Type> unusableTypes = new List<Type>();
            if (sleepy_timer > 9)
                unusableTypes.Add(typeof(SlowFood));
            if (sleepy_timer < 2)
                unusableTypes.Add(typeof(FastFood));
            if (scoreInt < 10)
                unusableTypes.Add(typeof(BadFood));
            if (invTimerActive)
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

        /// <summary>
        /// Metoda prima tip hrane. Kreira taj tip hrane i stavlja ju na nasumicno odabranu nezauzetu lokaciju na ploci
        /// te vraca stvorenu hranu u obliku klase BasicFood.
        /// </summary>
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

        /// <summary>
        /// Metoda prima poziciju na kojoj zelimo staviti ciglu. Kreira ciglu te ukoliko se na toj poziciji
        /// vec nalazi hana stavlja tu hranu na nasumicno odabranu, nezauzetu lokaciju na ploci.
        /// Vraca stvorenu ciglu kao klasu BasicFood.
        /// </summary>
        private BasicFood CreateBrick(int xPosition, int yPosition)
        {
            Type type = typeof(BorderBlock);
            object brick = Activator.CreateInstance(type);

            PropertyInfo xProperty = type.GetProperty("X");
            xProperty.SetValue(brick, xPosition);

            PropertyInfo yProperty = type.GetProperty("Y");
            yProperty.SetValue(brick, yPosition);

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


        /// <summary>
        /// Metoda se poziva svako konacno vremena (definiranog varijablom timer). Metoda naizmjenice obraduje kretanje zmije 
        /// te regulira povecavanja tezine igrice i pojavu vremenski ogranicene hrane.
        /// Svakim novim levelom dodaje novu hranu, smanjuje granice ploce te posebno na desetom levelu dodaje 
        /// zlonamjernu zmiju kao prepreku trenutnoj. Konacno, obnavlja plocu u skladu sa odigranim potezom.
        /// </summary>
        private void timer_Tick(object sender, EventArgs e)
        {
            if (player)
            {
                if (factor != 1 || currentSleep == 1)
                {
                    if (movement.Count > 0)
                        snake_move = movement.Last();
                    else snake_move = settings.Direction;
                    movement.Clear();

                    switch (snake_move)
                    {
                        case "left": 
                            if( settings.Direction != "right")
                                settings.Direction = "left";
                            break;
                        case "right":
                            if (settings.Direction != "left")
                                settings.Direction = "right";
                            break;
                        case "up":
                            if (settings.Direction != "down")
                                settings.Direction = "up";
                            break;
                        case "down":
                            if (settings.Direction != "up")
                               settings.Direction = "down";
                            break;
                        default: break;
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
                                    if (Snake[i].X == Snake[j].X && Snake[i].Y == Snake[j].Y && !invTimerActive)
                                    {
                                        DecreaseLives();
                                    }
                                }

                                for (int j = 0; j < EnemySnake.Count; j++)
                                {
                                    if (Snake[i].X == EnemySnake[j].X && Snake[i].Y == EnemySnake[j].Y && !invTimerActive)
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
                                    else if (s == "b" && !invTimerActive)
                                    {
                                        DecreaseLives();
                                    }
                                }
                                // samo provjeravam je li zmija udarila zid glavom
                                // ne racuna se ako neki dio zapne na zidu zbog InvincibleFood
                            }
                            else
                            {
                                Snake[i].X = Snake[i - 1].X;
                                Snake[i].Y = Snake[i - 1].Y;
                            }
                        }
                    }
                    currentSleep = sleepy_timer;
                }
                if (currentSleep > 1)
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
                            if (Snake[j].X == 17 && Snake[j].Y == 2 && !invTimerActive)
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
                                        if (EnemySnake[i].X == Snake[j].X && EnemySnake[i].Y == Snake[j].Y && !invTimerActive)
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

                setScoreText();
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

            setScoreText(); 
            
            canvas.Invalidate();

        }

        /// <summary>
        /// Metoda se poziva pritiskom na gumb START i poziva metodu koja resetira igru.
        /// </summary>
        private void start_Click(object sender, EventArgs e)
        {
            RestartGame();
        }

        /// <summary>
        /// Metoda se poziva svaki put kada obnovimo izgleda canvas-a. Prilikom svakog poziva iznova crta i boji kvadrate
        /// koji predstavljaju obje zmije, zidove i hranu na trenutnim polozajima.
        /// </summary>
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
                    if(invTimerActive)
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
                    if (invTimerActive)
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

        /// <summary>
        /// Metoda se poziva kada zmija izgubi zivot izlazeci iz ploce, zabijajuci se u zid ili u drugu zmiju ili kada pojede
        /// hranu klase DeathFood. Svi parametri koji su promijenjeni ucinkom hrane se resetiraju. Ako je zmija izgubila sve zivote,
        /// poziva se metoda GameOver, a inace se zmija pomakne na pocetnu poziciju s nepromjenjenom dujinom.
        /// </summary>
        private void DecreaseLives()
        {
            lives--;

            sleepy_timer = 5;
            currentSleep = 5;
            if(invTimerActive)
            {
                invTimerActive = false;
                invTimer.Stop();
            }

            setScoreText();

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

        /// <summary>
        /// Metoda se poziva kada zmija izgubi sve zivote. Odvijanje igre stane i slika se zamrzne. Moze se zapoceti nova igra
        /// pritiskom na START.
        /// </summary>
        private void GameOver()
        {
            timer.Stop();
            start.Enabled = true;
        }

        /// <summary>
        /// Metoda se poziva kada zmija "pojede" hranu. Poziva se metoda ActivateEffect koja vraca parametre koje su promijenjeni
        /// zbog ucinka hrane i te promjene se azuriraju u igri. Umjesto pojedene hrane u listu Food se sprema novi objekt hrane.
        /// Klasa hrane je nasumicna za sve osim prve koja je uvijek BasicFood.
        /// </summary>
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
                setScoreText();
            }

            if (inv)
            {
                invTimer = new System.Timers.Timer(30000);
                invTimer.Elapsed += InvTimerElapsed;
                invStartTime = DateTime.Now;
                invTimer.Start();
                invTimerActive = true;
                setScoreText();
            }

            int ind = Food.IndexOf(food);
            if (Food[ind].Color != Brushes.DarkGray)
            {
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

        /// <summary>
        /// Metoda se poziva kada istekne timer efekta InvincibleFood. Oznacava da je efekt istekao.
        /// </summary>
        private void InvTimerElapsed(object sender, ElapsedEventArgs e)
        {
            invTimerActive = false;
            invTimer.Stop();
        }

        /// <summary>
        /// Metoda se poziva pritiskom na gumb START. Postavljaju se pocetne postavke. Stvara se zmija i jedan objekt hrane
        /// klase BasicFood. Zapocinje timer koji kontrolira tok igre.
        /// </summary>
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
            invTimerActive = false;
            setScoreText();

            Unit head = new Unit { X = 15, Y = 12 };
            Snake.Add(head);

            for (int i = 0; i < 5; i++)
            {
                Snake.Add(new Unit());
            }

            matrix = new string[rows + 1, cols + 1];
            for (int i = 0; i < rows + 1; i++)
            {
                for (int j = 0; j < cols + 1; j++)
                {
                    matrix[i, j] = "";
                }
            }

            Food.Clear();
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

        /// <summary>
        /// postavlja tekst o napretku igre u za to namijenjeni Label
        /// </summary>
        private void setScoreText()
        {
            score.Text = "BODOVI: " + scoreInt + Environment.NewLine
                        + "ŽIVOTI: " + lives + Environment.NewLine
                        + "LEVEL: " + level + Environment.NewLine;
            if (invTimerActive)
            {
                score.Text += "TIMER NEPOBJEDIVOSTI: " + Math.Ceiling((double)(30000 - (int)(DateTime.Now - invStartTime).TotalMilliseconds) / 1000);
            }
        }

        /// <summary>
        /// postavlja pomoćni tekst u za to namijenjeni Label
        /// </summary>
        private void setHelpText()
        {
            help.Text = "POSTAVKE: ctrl + " + settings.SettingsKey + Environment.NewLine
                        + "UPUTE: ctrl + " + settings.InstructionsKey + Environment.NewLine
                        + "ZATVARANJE PROZORA: " + settings.CloseKey;
        }
    }
}
