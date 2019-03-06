using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake {
    class Objects {
        public List<Point> Points = new List<Point>();

        public Point GetHead {
            get {
                return Points[0];
            }
        }

        public Objects(char sign) {
            Points.Add(new Point(sign, 0, 0));
        }

        public Objects(char sign, int x, int y) {
            Points.Add(new Point(sign, x, y));
        }

        public void DrawObject() {
            foreach(var point in Points) {
                Console.SetCursorPosition(point.X, point.Y);
                Console.Write(point.sign);
            }
        }

        public void ClearObject() {
            foreach(var p in Points) {
                Console.SetCursorPosition(p.X, p.Y);
                Console.Write(' ');
            }
        }
    }
}
