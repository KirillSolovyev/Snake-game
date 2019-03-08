using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake {
    class GameState {                                                 // Основной класс игры. Отвечает за запуск игры
        Serpent snake;
        Food food;
        Wall walls;
        GameInterface IntFace;

        public GameState() {                                          // При создании класса инициализировать все игровый объекты
            IntFace = new GameInterface();
            Console.CursorVisible = false;
            Console.SetWindowSize(40, 30);
            Console.SetBufferSize(40, 30);
            //Console.SetWindowPosition(40, 40);
            snake = new Serpent('0', 20, 10, new List<ConsoleColor> { ConsoleColor.Green, ConsoleColor.DarkGreen });
            walls = new Wall('#', "Level1", new List<ConsoleColor> { ConsoleColor.Red, ConsoleColor.Red });
            food = new Food('@', new List<Objects> { snake, walls }, new List<ConsoleColor> { ConsoleColor.Yellow, ConsoleColor.Yellow });
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
            Console.Clear();
            GameState game = new GameState();
            game.DrawScene();
            game.StartGame();
        }

        // Запуск игры
        public void StartGame() {
            ConsoleKeyInfo pressed;
            bool _continue = true;
            while(_continue) {
                pressed = Console.ReadKey(true);
                switch(pressed.Key) {
                    case ConsoleKey.W:
                        snake.Move(0, -1);
                        break;
                    case ConsoleKey.S:
                        snake.Move(0, 1);
                        break;
                    case ConsoleKey.A:
                        snake.Move(-1, 0);
                        break;
                    case ConsoleKey.D:
                        snake.Move(1, 0);
                        break;
                    case ConsoleKey.X:
                        break;
                }
                _continue = CheckPosition(); // Проверка на столкновение. Если _continue == false, то игры прерывается
            }
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
