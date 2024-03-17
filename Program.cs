using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;

namespace Lab6Serialization
{
    internal class Program
    {
        static void Main(string[] args)
        {
#pragma warning disable SYSLIB0011

            Event hackathon = new Event(1, "Calgary", "Tech Competition");
            Event hackOthon = new Event(2, "Mars", "Tech Expo");
            Event hackatonn = new Event(3, "Siberia", "Classified");
            Event hackNslash = new Event(4, "Mordor", "Epic fantasy confrontation between good and evil");
            List<Event> eventList = new List<Event>();
            eventList.Add(hackathon);
            eventList.Add(hackOthon);
            eventList.Add(hackatonn);
            eventList.Add(hackNslash);

            string baseDir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
           
            string pathBin = baseDir + "/event.bin";
            string pathJson = baseDir + "/event.json";

            SerializeEvent(hackathon, pathBin);
            DeserializeEvent(pathBin);
            SerializeEventList(eventList, pathJson);
            DeserializeEventList(pathJson);

            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"../../../example.txt");
            using (StreamReader sr = new StreamReader(path))
            {
                string line = sr.ReadLine();
                //int midChar = Math.Floor(line.Length / 2);
                Console.WriteLine(
                    $"\nThe first character is: {line[0]}" +
                    $"\n\nThe middle character is: {line[line.Length / 2]}" +
                    $"\n\nThe last character is: {line[line.Length - 1]}"
                    );
            }
        }

        private static void SerializeEvent(Event e, string path)
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                bf.Serialize(fs, e);
            }
            //Console.WriteLine("Binary Serialization done.");
        }

        private static void DeserializeEvent(string path)
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                Event hackathon = (Event)bf.Deserialize(fs);
                Console.WriteLine(hackathon);
            }
        }

        private static void SerializeEventList(List<Event> list, string path)
        {
            string stringJSON = JsonSerializer.Serialize(list);
            File.WriteAllText(path, stringJSON);
        }

        private static void DeserializeEventList(string path)
        {
            List<Event> list = JsonSerializer.Deserialize<List<Event>>(File.ReadAllText(path));
            if (list != null)
            {
                foreach (Event e in list)
                {
                    Console.WriteLine($"\n{e.EventNumber} {e.Location}");
                }
            }
        }
    }
}
