using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace Snake {
    class Program {
        static void Main(string[] args) {
            //RecordTable r = new RecordTable();
            ////XmlSerializer x = new XmlSerializer(typeof(RecordTable));
            //BinaryFormatter bin = new BinaryFormatter();
            //using(FileStream fs = new FileStream("RecordsFile.bin", FileMode.Create, FileAccess.Write)) {
            //    bin.Serialize(fs, r);
            //}
            GameState game = new GameState();
            game.DrawScene(); // Выведение в консоль всех игровых объектов
            game.StartGame(); // Запуск игры
        }
    }
}
