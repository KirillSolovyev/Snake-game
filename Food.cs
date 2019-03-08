using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake {
    class Food : Objects{
        public Food(char sign, List<Objects> ToComp, List<ConsoleColor> colors) : base(sign, colors){
            GenerateFood(ToComp);
        }

        public void GenerateFood() {
            Random randNum = new Random();
            Points[0].X = randNum.Next(0, Console.BufferWidth);
            Points[0].Y = randNum.Next(0, Console.BufferHeight);
        }

        public void GenerateFood(List<Objects> ToCompare) {
            GenerateFood();

            CheckAgain:
            for(int i = 0; i < ToCompare.Count; i++) {
                for(int j = 0; j < ToCompare[i].Points.Count; j++) {
                    if(Points[0].X == ToCompare[i].Points[j].X && Points[0].Y == ToCompare[i].Points[j].Y) {
                        GenerateFood();
                        goto CheckAgain;
                    }
                }
            }
            DrawObject();
        }
    }
}
