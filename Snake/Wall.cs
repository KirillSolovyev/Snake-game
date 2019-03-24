using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake {
    class Wall : Objects{                                                                               // Игровой объект - стены
        public string LevelName { get; private set; }
        public int PointToGet { get; private set; }
        FileSystemInfo[] Levels = new DirectoryInfo(@"D:\repos\Snake\Snake\Levels").GetFileSystemInfos();

        public Wall(char sign, int LevelNumber, List<ConsoleColor> colors) : base(sign, colors){
            LoadLevel(LevelNumber);
        }

        // Загрузка уровня и вывод в консоль всех стен 
        public void LoadLevel(int number) {
            LevelName = Path.GetFileNameWithoutExtension(Levels[number].Name);
            using(StreamReader sr = new StreamReader(Levels[number].FullName)) { // Чнение расположения всех стен из файла уровня
                PointToGet = Convert.ToInt32(sr.ReadLine());
                int Y = 0;
                while(!sr.EndOfStream) {
                    string row = sr.ReadLine();
                    for(int X = 0; X < row.Length; X++) {
                        if(row[X] == '#') {
                            Points.Add(new Point('#', X, Y));                    // Добавление точки с заданными координатами 
                        }
                    }
                    Y++;
                }
            }
        }
    }
}
