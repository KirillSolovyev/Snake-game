using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Snake {
    [Serializable]
    public class RecordTable {
        public List<KeyValuePair<string, int>> records = new List<KeyValuePair<string, int>>();
        [NonSerialized]
        //XmlSerializer Xser = new XmlSerializer(typeof(RecordTable));
        BinaryFormatter bin = new BinaryFormatter();

        public RecordTable(){
            records = ReadRecords();
            //records.Add(new KeyValuePair<string, int>("Kirill", 50));
            //records.Add(new KeyValuePair<string, int>("SnakeKing", 40));
            //records.Add(new KeyValuePair<string, int>("Python", 30));
            //records.Add(new KeyValuePair<string, int>("Cobra", 20));
            //records.Add(new KeyValuePair<string, int>("Berik", 1));
        }

        public List<KeyValuePair<string, int>> ReadRecords() {
            List<KeyValuePair<string, int>> fromFile;
            using(FileStream fs = new FileStream(@"D:\repos\Snake\Snake\RecordsFile.bin", FileMode.Open, FileAccess.Read)) {
                fromFile = (bin.Deserialize(fs) as RecordTable).records;
            }
            return fromFile;
        }

        public void ShowRecords() {
            int i = 0;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(11, 27);
            Console.Write("-------RECORDS-------");
            foreach(var el in records) {
                Console.SetCursorPosition(15, 28 + i);
                Console.WriteLine(el.Key + " -- " + el.Value);
                i++;
            }
        }

        public void WriteRecord() {
            using(FileStream fs = new FileStream(@"D:\repos\Snake\Snake\RecordsFile.bin", FileMode.Open)) {
                bin.Serialize(fs, this);
            }
        }

        void moveRecords(KeyValuePair<string, int> el, int ind) {
            for(int i = ind; i >= 0; i--) {
                //var temp = 
            }
        }

        public bool CheckRecord(string playerName, int playerPoints) {
            bool ans = false;
            for(int i = records.Count - 1; i >= 0; i--) {
                var item = records.ElementAt(i);
                if(playerPoints >= item.Value) {
                    records.Insert(i, new KeyValuePair<string, int>(playerName, playerPoints));
                    ans = true;
                    records.RemoveAt(records.Count - 1);
                    break;
                }
            }
            return ans;
        }
    }
}
