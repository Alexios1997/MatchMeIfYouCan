using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public int highScore;
}

public static class SaveManager 
{
    private static string savePath => Path.Combine(Application.persistentDataPath, "save.json");
    
    public static void Save(SaveData data)
    {
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(savePath, json);
    }
    public static SaveData Load()
    {
        if (!File.Exists(savePath))
        {
            return new SaveData();
        }
        string json = File.ReadAllText(savePath);
        return JsonUtility.FromJson<SaveData>(json);
    }

    public static void DeleteSave()
    {
        if (File.Exists(savePath))
        {
            File.Delete(savePath);
        }
    }
}
