using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake {
    class Objects {
        public List<Point> Points = new List<Point>();
        public List<ConsoleColor> colors = new List<ConsoleColor>();

        public Point GetHead {
            get {
                return Points[0];
            }
        }

        public Objects(char sign) {
            Points.Add(new Point(sign, 0, 0));
        }

        public Objects(char sign, List<ConsoleColor> colors) {
            Points.Add(new Point(sign, 0, 0));
            this.colors = colors;
        }

        public Objects(char sign, int x, int y) {
            Points.Add(new Point(sign, x, y));
        }

        public Objects(char sign, int x, int y, List<ConsoleColor> colors) {
            Points.Add(new Point(sign, x, y));
            this.colors = colors;
        }

        public void DrawObject() {
            Console.ForegroundColor = ConsoleColor.White;
            for(int i = 0; i < Points.Count; i++) {
                Console.SetCursorPosition(Points[i].X, Points[i].Y);
                if(i == 0 && colors.Count > 0) {
                    Console.ForegroundColor = colors[0];
                } else if(colors.Count > 0) {
                    Console.ForegroundColor = colors[1];
                }
                Console.Write(Points[i].sign);
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
