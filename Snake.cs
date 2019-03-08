using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake {
    class Serpent : Objects{                                                                            // Игровой объект - змейка

        public Serpent(char sign, int x, int y, List<ConsoleColor> colors) : base(sign, x, y, colors){
            Points.Add(new Point(sign, x, y + 1));
            Points.Add(new Point(sign, x, y + 2));
        }

        public void ChangePos(Point p, int speedX, int speedY) {                                        // Метод для изменение позиции точки
                p.X += speedX;
                p.Y += speedY;
        }

        public void Move(int speedX, int speedY) {                                                      // Метод для перемещения всех точек змейки
            if(Points.Count == 1 || Points[0].X + speedX != Points[1].X || Points[0].Y + speedY != Points[1].Y) { // Проверка на движение назад
                ClearObject();

                for(int i = Points.Count - 1; i > 0; i--) {                                            // Перемещение каждой точки на координату следующей точки
                    Points[i].X = Points[i - 1].X;
                    Points[i].Y = Points[i - 1].Y;
                }

                ChangePos(Points[0], speedX, speedY);                                                  // Перемещение первой точки на одну координату
                DrawObject();
            }
        }

        public void Death() {                                                                          // Смерть змейки
            Console.ForegroundColor = ConsoleColor.DarkRed;
            for(int i = 0; i < Points.Count; i++) {
                Console.SetCursorPosition(Points[i].X, Points[i].Y);
                Console.Write('x');                                                                   // Изменить символы всех точек змейки на "х"
            }
        }
    }
}
