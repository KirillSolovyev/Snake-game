using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake {
    class Food : Objects{
        public Food(char sign) : base(sign){
            GenerateFood();
        }

        public void GenerateFood() {
            Points[0].ClearPrev();
            Random randNum = new Random();
            Points[0].X = randNum.Next(0, Console.BufferWidth);
            Points[0].Y = randNum.Next(0, Console.BufferHeight);
            Points[0].Draw();
        }
    }
}
