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

        public GameState() {
            Console.CursorVisible = false;
            Console.SetWindowSize(40, 20);
            Console.SetBufferSize(40, 20);
            //Console.SetWindowPosition(40, 40);
            snake = new Serpent('0', 20, 10);
            food = new Food('%');
            walls = new Wall('#', "Level1");
        }

        public void DrawScene() {
            snake.DrawObject();
            food.DrawObject();
            walls.DrawObject();
        }

        public void StartGame() {
            ConsoleKeyInfo pressed;
            while(true) {
                pressed = Console.ReadKey(true);
                switch(pressed.Key) {
                    case ConsoleKey.W:
                        snake.Move(0, -1, food, walls);
                        break;
                    case ConsoleKey.S:
                        snake.Move(0, 1, food, walls);
                        break;
                    case ConsoleKey.A:
                        snake.Move(-1, 0, food, walls);
                        break;
                    case ConsoleKey.D:
                        snake.Move(1, 0, food, walls);
                        break;
                    case ConsoleKey.X:
                        break;
                }
            }
        }
    }
}
