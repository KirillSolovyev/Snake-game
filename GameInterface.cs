using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake {
    class GameInterface {
        string name;
        int points;
        List<string> text = new List<string>{ "Name: ", "Score: ", "Level: "};
        static bool firstLaunch = true;

        public string GetName {
            get {
                return name;
            }
            private set {
                if(value != "") {
                    name = value;
                } else {
                    name = "No Name";
                }
            }
        }

        public void InsertName() {
            Console.WriteLine("Insert you nickname");
            GetName = Console.ReadLine();
            Console.Clear();
        }

        public GameInterface() {
            if(firstLaunch) {
                InsertName();
                firstLaunch = false;
            }
        }

        public void DisplayInterface(string levelname) {
            DisplayNotation();
            DisplayPlayerInfo(levelname);
        }

        public void DisplayNotation() {
            Console.SetCursorPosition(2, 21);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("W - Up  S - Down  A - Left  D - Right");
            //Console.Write("R - Restart  S - Down  A - Left  D - Right");
        }

        public void DisplayPlayerInfo(string levelname) {
            List<Object> arr = new List<Object> { GetName, points, levelname };
            Console.ForegroundColor = ConsoleColor.White;
            for(int i = 0; i < text.Count; i++) {
                Console.SetCursorPosition(Console.BufferWidth / 2 - 6, 23 + i);
                Console.WriteLine(text[i] + arr[i]);
            }
        }

        public void PointsUp(string levelname) {
            points++;
            DisplayPlayerInfo(levelname);
        }

        public void GameOver() {
            string[] gameOverText = new string[4] { " -----------------", "     Game Over    ", " -----------------", "    R - Restart" };
            Console.ForegroundColor = ConsoleColor.White;
            for(int i = 0; i < gameOverText.Length; i++) {
                Console.SetCursorPosition(Console.BufferWidth / 2 - 8, 8 + i);
                Console.Write(gameOverText[i]);
            }
        }
    }
}
