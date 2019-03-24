using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Snake {
    class GameState {                                                 // Основной класс игры. Отвечает за запуск игры
        Serpent snake;
        Food food;
        Wall walls;
        GameInterface IntFace;
        Timer timer = new Timer(200);
        bool _continue = true;

        public int LevelNumber { get; set; } = 0;

        public GameState() {                                          // При создании класса инициализировать все игровый объекты
            Console.CursorVisible = false;
            Console.SetWindowSize(40, 35);
            Console.SetBufferSize(40, 35);
            //Console.SetWindowPosition(40, 40);
            walls = new Wall('#', LevelNumber, new List<ConsoleColor> { ConsoleColor.Red, ConsoleColor.Red });
            IntFace = new GameInterface(walls.PointToGet);
            snake = new Serpent('0', 20, 10, new List<ConsoleColor> { ConsoleColor.Green, ConsoleColor.DarkGreen });
            food = new Food('@', new List<Objects> { snake, walls }, new List<ConsoleColor> { ConsoleColor.Yellow, ConsoleColor.Yellow });
        }

        public void Run() {
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }

        public void Stop() {
            timer.Stop();
        }

        public void Timer_Elapsed(object sender, ElapsedEventArgs e) {
            snake.Move();
            _continue = CheckPosition();
        }

        // Вывод в консоль всех игровых элементов и интерфейса
        public void DrawScene() {
            snake.DrawObject();
            food.DrawObject();
            walls.DrawObject();
            IntFace.DisplayInterface(walls.LevelName);
        }

        // Проверка позиции змейки на столкновение. Возварщает true если не произошло столкновения со стеной, false если змейка столкнулась со стеной
        public bool CheckPosition() {
            bool cont = true;

            if(HasSamePosition(snake.Points[0], food.Points[0])) { // Если змейка сталкивается с едой - увеличть змейка и переместить еду
                snake.Points.Add(new Point(snake.Points[0].sign, snake.Points[snake.Points.Count - 1].X, snake.Points[snake.Points.Count - 1].Y));
                food.GenerateFood(new List<Objects> { snake, walls });
                IntFace.PointsUp(walls.LevelName);                 // Увеличить количество очков на 1
            } else if(CollidesWith(snake.Points[0], walls) || CollidesWith(snake.Points[0], snake)){ // Если змейка сталкивается с едой, то вывести "Конец игры"
                snake.Death();
                IntFace.GameOver();
                Stop();
                cont = false;
            }
            return cont;
        }

        // Проверка координат объектов
        public bool HasSamePosition(Point p1, Point p2) {       
            return (p1.X == p2.X && p1.Y == p2.Y ? true : false);
        }

        // Проверка координат объектов, содержащих больше одной точки
        public bool CollidesWith(Point p, Objects obj) {
            bool res = false;
            for(int i = 0; i < obj.Points.Count; i++) {
                if(HasSamePosition(p, obj.Points[i]) && p != obj.Points[i]) {
                    obj.Points[i].Draw();
                    res = true;
                    break;
                }
            }
            return res;
        }

        // Перезапуск игры
        public void RestartGame() {
            timer = new Timer(200);
            walls = new Wall('#', LevelNumber, new List<ConsoleColor> { ConsoleColor.Red, ConsoleColor.Red });
            string PlayerName = IntFace.GetName;
            IntFace = new GameInterface(walls.PointToGet);
            IntFace.GetName = PlayerName; 
            snake = new Serpent('0', 20, 10, new List<ConsoleColor> { ConsoleColor.Green, ConsoleColor.DarkGreen });
            food = new Food('@', new List<Objects> { snake, walls }, new List<ConsoleColor> { ConsoleColor.Yellow, ConsoleColor.Yellow });
            _continue = true;
            Console.Clear();
            DrawScene();
            StartGame();
        }

        public void NextLevel() {
            Stop();
            LevelNumber++;
            _continue = false;
            RestartGame();
        }

        // Запуск игры
        public void StartGame() {
            Run();
            ConsoleKeyInfo pressed;
            bool nextLevel = false;
            while(_continue) {
                pressed = Console.ReadKey(true); // True для того, чтобы символы нажатых клавиш не выводились в консоль
                switch(pressed.Key) {
                    case ConsoleKey.W:
                        snake.ChangeInX = 0;
                        snake.ChangeInY = -1;
                        break;
                    case ConsoleKey.S:
                        snake.ChangeInX = 0;
                        snake.ChangeInY = 1;
                        break;
                    case ConsoleKey.A:
                        snake.ChangeInX = -1;
                        snake.ChangeInY = 0;
                        break;
                    case ConsoleKey.D:
                        snake.ChangeInX = 1;
                        snake.ChangeInY = 0;
                        break;
                    case ConsoleKey.N:
                        if(IntFace.Points >= walls.PointToGet) {
                            nextLevel = true;
                            NextLevel();
                        }
                        break;
                }
            }
            if(!nextLevel) {
                bool restart = false;
                while(!restart) {               // При нажатии R игра перезапускается
                    pressed = Console.ReadKey(true);
                    if(pressed.Key == ConsoleKey.R) {
                        restart = true;
                        RestartGame();
                    }
                }
            }
        }
    }
}
