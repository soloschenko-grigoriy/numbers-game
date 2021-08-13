using System.Collections;
using System.IO;
using System.Text;
using UnityEngine;

public static class SaveLoadLocalFile
{
    private static readonly string path = Application.persistentDataPath + Path.DirectorySeparatorChar +  "stats.json";
    
    public static void Save(Stats stats)
    {
        using (var fs = File.Open(path, FileMode.OpenOrCreate))
        {
            AddText(fs, JsonUtility.ToJson(stats));
        }
    }

    public static Stats Load()
    {
        var stats = new Stats(0);
        if (!File.Exists(path))
        {
            Save(stats);
        }
        else
        {
            using (FileStream fs = File.OpenRead(path))  
            {  
                var b = new byte[1024];  
                var temp = new UTF8Encoding(true);
                var str = "";
                while (fs.Read(b,0,b.Length) > 0)  
                {  
                    str += temp.GetString(b);  
                }
                
                stats = JsonUtility.FromJson<Stats>(str);
            } 
        }

        return stats;
    }

    public static void Erase()
    {
        if(File.Exists(path))
        {
            File.Delete(path);
        }
    }

    public static bool HasSavings()
    {
        return File.Exists(path);
    }
    
    private static void AddText(FileStream fs, string value)  
    {  
        byte[] info = new UTF8Encoding(true).GetBytes(value);  
        fs.Write(info, 0, info.Length);  
    }
}