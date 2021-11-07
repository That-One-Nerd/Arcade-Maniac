using Newtonsoft.Json;
using System.IO;
using That_One_Nerd.Unity.Games.ArcadeManiac.Misc.ObjectModels;
using UnityEngine.SceneManagement;

namespace That_One_Nerd.Unity.Games.ArcadeManiac.Minigames.EntityMarchDream.ObjectModels
{
    public class SaveData
    {
        public static readonly JsonSerializer Serializer = JsonSerializer.Create(new JsonSerializerSettings()
        {
            Formatting = Formatting.Indented // not required, using anyway so it's easier to read in debug
        });
        public static string Path => GlobalConfig.SaveDataPath + "/Entity March Dream.json";

        public static bool Saved => File.Exists(Path);

        public string levelName;

        public SaveData() => levelName = SceneManager.GetActiveScene().name;

        public static void DeleteSaveFile() { if (Saved) File.Delete(Path); }
#nullable enable
        public static SaveData? LoadFromFile()
        {
            if (!File.Exists(Path)) return null;

            JsonSerializer serializer = Serializer;
            StreamReader reader = new StreamReader(Path);

            SaveData? data = serializer.Deserialize<SaveData>(new JsonTextReader(reader));
            reader.Close();

            return data;
        }
#nullable disable
        public void Save()
        {
            Directory.CreateDirectory(GlobalConfig.SaveDataPath);
            UnityEngine.Debug.Log("a");

            JsonSerializer serializer = Serializer;
            UnityEngine.Debug.Log("b");
            StreamWriter writer = File.CreateText(Path);
            UnityEngine.Debug.Log("c");

            serializer.Serialize(writer, this);
            UnityEngine.Debug.Log("d");
            writer.Close();
            UnityEngine.Debug.Log("e");
        }
    }
}
