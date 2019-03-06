using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake {
    class Serpent : Objects{

        public Serpent(char sign, int x, int y) : base(sign, x, y){

        }

        public void ChangePos(Point p, int speedX, int speedY) {
                p.X += speedX;
                p.Y += speedY;
        }

        public void Move(int speedX, int speedY, Food food, Wall walls) {
            ClearObject();
            ChangePos(Points[0], speedX, speedY);
            CheckPositionWall(walls);
            CheckPositionFood(food);

            for(int i = Points.Count - 1; i > 0; i--) {
                int x = Points[i - 1].X;
                int y = Points[i - 1].Y;
                Points[i].X = x;
                Points[i].Y = y;
            }

            DrawObject();
        }

        public void CheckPositionFood(Food food) {
            if(Points[0].X == food.GetHead.X && Points[0].Y == food.GetHead.Y) {
                Points.Add(new Point(Points[0].sign, Points[Points.Count - 1].X, Points[Points.Count - 1].Y));
                food.GenerateFood();
            }
        }

        public void CheckPositionWall(Wall walls) {
            for(int i = 0; i < walls.Points.Count; i++) {
                if(Points[0].X == walls.Points[i].X && Points[0].Y == walls.Points[i].Y) {
                    Console.SetCursorPosition(0, 19);
                    Console.WriteLine("Game Over!");
                    break;
                }
            }
        }
    }
}
