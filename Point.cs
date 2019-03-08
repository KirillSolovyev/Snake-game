using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake {
    class Point {
        int x;
        int y;
        public char sign;

        public int X {
            get {
                return x;
            }
            set {
                x = checkVal(value, Console.BufferWidth);
            }
        }

        public int Y {
            get {
                return y;
            }
            set {
                y = checkVal(value, 20);
            }
        }

        int checkVal(int val, int maxVal) {
            if(val < 0) {
                return maxVal - 1;
            } else if(val >= maxVal) {
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

        public void Draw() {
            Console.SetCursorPosition(X, Y);
            Console.Write(sign);
        }

        public void ClearPrev() {
            Console.SetCursorPosition(X, Y);
            Console.Write(' ');
        }
    }
}
