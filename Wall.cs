using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake {
    class Wall : Objects{
        string levelName;

        public string LevelName {
            get {
                return levelName;
            }
        }

        public Wall(char sign, string _levelName, List<ConsoleColor> colors) : base(sign, colors){
            levelName = _levelName;
            LoadLevel();
        }

        public void LoadLevel() {
            using(StreamReader sr = new StreamReader(@"D:\repos\Snake\Snake\Levels\" + levelName + ".txt")) {
                int Y = 0;
                while(!sr.EndOfStream) {
                    string row = sr.ReadLine();
                    for(int X = 0; X < row.Length; X++) {
                        if(row[X] == '#') {
                            Points.Add(new Point('#', X, Y));
                        }
                    }
                    Y++;
                }
            }
        }
    }
}
