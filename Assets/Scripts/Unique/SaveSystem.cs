using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    private static string saveExt = $".save";

    public class GameState
    {
        public int sceneIndex;
        public int currentLives;
        public int maxLives;

        public GameState(int _sceneIndex, int _currentLives)
        {
            sceneIndex = _sceneIndex;
            currentLives = _currentLives;
        }
        
    }

    public static void SaveGame(GameState gameSave)
    {
        int saveIndex = GameMaster.instance.saveIndex;
        if (saveIndex > 0)
        {
            string path = GetPath(saveIndex);

            var serializedSave = JsonConvert.SerializeObject(gameSave);
            File.WriteAllText(path, serializedSave);
        }
        
    }

    public static bool CheckHasSave(int saveIndex)
    {
        string path = GetPath(saveIndex);

        if (File.Exists(path))
        {
            return true;

        }
        else return false;
    }

    public static GameState LoadSaveDataFromSave(int saveIndex)
    {
        string path = GetPath(saveIndex);

        var serializedSave = File.ReadAllText(path);
        return JsonConvert.DeserializeObject<GameState>(serializedSave);
    }

    private static string GetPath(int saveIndex)
    {
        string fileName = saveIndex + saveExt;
        return Path.Combine(Application.persistentDataPath, fileName);
    }
}
