using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake {
    class GameInterface {                                                     // Отображение всех игровых сообщений и надписей 
        string name;
        int points = 0;
        int maxPoint;
        List<string> text = new List<string>{ "Name: ", "Score: ", "Level: "};
        string[] gameOverText = new string[4] { " -----------------", "     Game Over    ", " -----------------", "    R - Restart" };
        static bool firstLaunch = true;
        RecordTable Records = new RecordTable();

        public string GetName {
            get {
                return name;
            }
            set {
                if(value != "") {
                    name = value;
                } else {
                    name = "No Name";
                }
            }
        }

        public int Points {
            get {
                return points;
            }
            private set {
                if(points + value >= maxPoint) {
                    points = value;
                    DisplayNotation(true);
                } else {
                    points = value;
                }
            }
        }

        // Запрос имени игрока
        public void InsertName() {
            Console.WriteLine("Insert you nickname");
            GetName = Console.ReadLine();
            Console.Clear();
        }

        // При запуске в первый раз запросить имя игрока
        public GameInterface(int _maxPoint) {
            maxPoint = _maxPoint;
            if(firstLaunch) {
                InsertName();
                firstLaunch = false;
            }
        }

        // Вывод всех сообщение в консоль
        public void DisplayInterface(string levelname) {
            DisplayNotation(false);
            DisplayPlayerInfo(levelname);
            Records.ShowRecords();
        }

        // Вывод всех надписей в консоль
        public void DisplayNotation(bool gained) {
            Console.SetCursorPosition(2, 21);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("W - Up  S - Down  A - Left  D - Right");
            if(gained) {
                Console.Write("              N - Next Level              ");
            }
        }

        // Вывод игровых данных в консоль
        public void DisplayPlayerInfo(string levelname) {
            string[] arr = { GetName, Points + "/" + maxPoint, levelname };
            Console.ForegroundColor = ConsoleColor.White;
            for(int i = 0; i < text.Count; i++) {
                Console.SetCursorPosition(Console.BufferWidth / 2 - 6, 23 + i);
                Console.WriteLine(text[i] + arr[i]);
            }
        }

        // Увечение очков
        public void PointsUp(string levelname) {
            Points++;
            DisplayPlayerInfo(levelname);
        }

        // Вывод сообщения о конце игры в консоль
        public void GameOver() {
            Console.ForegroundColor = ConsoleColor.White;
            for(int i = 0; i < gameOverText.Length; i++) {
                Console.SetCursorPosition(Console.BufferWidth / 2 - 8, 8 + i);
                Console.Write(gameOverText[i]);
            }
            if(Records.CheckRecord(GetName, Points)) {
                Records.WriteRecord();
            }
        }
    }
}
