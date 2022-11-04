using System.IO;
using UnityEngine;

namespace FallingBalls.SaveLoadSystem
{
    public class JsonSaver : ISaver
    {
        public void Save(ISaveable obj)
        {
            var json = JsonUtility.ToJson(obj.GetObject());
            using var writer = new StreamWriter(obj.GetFileName());
        
            writer.Write(json);
        }

        public void Load(ISaveable obj)
        {
            string json = "";
            using (var reader = new StreamReader(obj.GetFileName()))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    json += line;
                }
            }

            JsonUtility.FromJsonOverwrite(json, obj.GetObject());
        }

        public bool IsFileExist(ISaveable obj)
        {
            return File.Exists(obj.GetFileName());
        }
    }
}