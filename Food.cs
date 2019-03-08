using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake {
    class Food : Objects{                                                           // Игровой объект - случано генерируемая еда
        public Food(char sign, List<Objects> ToComp, List<ConsoleColor> colors) : base(sign, colors){
            GenerateFood(ToComp);
        }

        public void GenerateFood() {                                                // Генерация случайных чисел и назначение этих чисел в качестве координат еды
            Random randNum = new Random();
            Points[0].X = randNum.Next(0, Console.BufferWidth);
            Points[0].Y = randNum.Next(0, Console.BufferHeight);
        }

        // Проверка доступных точек и генерация случайных чисел
        public void GenerateFood(List<Objects> ToCompare) {                         // ToCompare - игровой объект класса Objects                   
            GenerateFood();

            CheckAgain:
            for(int i = 0; i < ToCompare.Count; i++) {                              // Проверка сгенерированных чисел на наслоение на существующиеся точки
                for(int j = 0; j < ToCompare[i].Points.Count; j++) {
                    if(Points[0].X == ToCompare[i].Points[j].X && Points[0].Y == ToCompare[i].Points[j].Y) {
                        GenerateFood();
                        goto CheckAgain;                                            // Повторная генерация в случае наслоения
                    }
                }
            }
            DrawObject();
        }
    }
}
