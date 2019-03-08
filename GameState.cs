using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake {
    class GameState {
        Serpent snake;
        Food food;
        Wall walls;
        GameInterface IntFace;

        public GameState() {
            IntFace = new GameInterface();
            Console.CursorVisible = false;
            Console.SetWindowSize(40, 30);
            Console.SetBufferSize(40, 30);
            //Console.SetWindowPosition(40, 40);
            snake = new Serpent('0', 20, 10, new List<ConsoleColor> { ConsoleColor.Green, ConsoleColor.DarkGreen });
            walls = new Wall('#', "Level1", new List<ConsoleColor> { ConsoleColor.Red, ConsoleColor.Red });
            food = new Food('@', new List<Objects> { snake, walls }, new List<ConsoleColor> { ConsoleColor.Yellow, ConsoleColor.Yellow });
        }

        public void DrawScene() {
            snake.DrawObject();
            food.DrawObject();
            walls.DrawObject();
            IntFace.DisplayInterface(walls.LevelName);
        }

        public bool CheckPosition() {
            bool cont = true;

            if(HasSamePosition(snake.Points[0], food.Points[0])) {
                snake.Points.Add(new Point(snake.Points[0].sign, snake.Points[snake.Points.Count - 1].X, snake.Points[snake.Points.Count - 1].Y));
                food.GenerateFood(new List<Objects> { snake, walls });
                IntFace.PointsUp(walls.LevelName);
            } else if(CollidesWith(snake.Points[0], walls) || CollidesWith(snake.Points[0], snake)){
                snake.Death();
                IntFace.GameOver();
                cont = false;
            }
            return cont;
        }

        public bool HasSamePosition(Point p1, Point p2) {
            return (p1.X == p2.X && p1.Y == p2.Y ? true : false);
        }

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

        public void RestartGame() {
            Console.Clear();
            GameState game = new GameState();
            game.DrawScene();
            game.StartGame();
        }

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
                _continue = CheckPosition();
            }
            bool restart = false;
            while(!restart) {
                pressed = Console.ReadKey(true);
                if(pressed.Key == ConsoleKey.R) {
                    restart = true;
                    RestartGame();
                }
            }
        }
    }
}
