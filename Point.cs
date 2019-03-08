using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake {
    class Point { // Класс, отвечающий за отображение одной точки в консоле
        int x; 
        int y;
        public char sign; // Символ точки при выводе в консоль

        public int X { // Реализация перемещения на противоположную сторону консоли при помощи свойства и метода CheckVal
            get {
                return x;
            }
            set {
                x = checkVal(value, Console.BufferWidth);
            }
        }

        public int Y { // Реализация перемещения на противоположную сторону консоли при помощи свойства и метода CheckVal
            get {
                return y;
            }
            set {
                y = checkVal(value, 20);
            }
        }

        int checkVal(int val, int maxVal) { // Агрументы: val - зачение, которое будет проверяться, maxVal - максимальное значение, при достижении которого
            if(val < 0) {                   // происходит перемещение на противоположную сторону   
                return maxVal - 1;          // Если занчение меньше 0, то переместить на противоположную сторону
            } else if(val >= maxVal) {      // Если значение больше или равняется maxVal - противоположная сторона
                return 0;
            } else {
                return val;
            }
        }

        public Point(char _sign, int _x, int _y) {
            sign = _sign;
            X = _x;
            Y = _y;
        }

        public void Draw() {                // Вывод в консоль одной точки
            Console.SetCursorPosition(X, Y);
            Console.Write(sign);
        }

        public void ClearPrev() {           // Удаление точки из консоли
            Console.SetCursorPosition(X, Y);
            Console.Write(' ');
        }
    }
}
