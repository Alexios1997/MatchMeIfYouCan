using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine;


// What we consider to 
// save Data
[System.Serializable]
public class SaveData
{
    public int highScore;
    public int level;
}

// Save Manager Handling save and load
public static class SaveManager 
{
    // Save path -> where the save.json will be saved (Persisten Data Path)
    private static string savePath => Path.Combine(Application.persistentDataPath, "save.json");
    
    // Save FUncction , Writing all SaveData there
    public static void Save(SaveData data)
    {
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(savePath, json);
    }
    
    // Load FUncction , Reading all SaveData from there
    public static SaveData Load()
    {
        if (!File.Exists(savePath))
        {
            return new SaveData();
        }
        string json = File.ReadAllText(savePath);
        return JsonUtility.FromJson<SaveData>(json);
    }

    // Delete Saves function
    public static void DeleteSave()
    {
        if (File.Exists(savePath))
        {
            File.Delete(savePath);
        }
    }
}
