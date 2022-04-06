using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    public List<HighScore> highScores;

    public string playerName; 
    
    // Start is called before the first frame update
    void Start()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        
        // Load high scores and users
        LoadHighScores();
    }
    
    [Serializable]
    class SaveData
    {
        public List<HighScore> highScores;
    }

    public void SaveHighScores()
    {
        SaveData data = new SaveData();
        data.highScores = highScores;

        string json = JsonUtility.ToJson(data);
        
        File.WriteAllText(Application.persistentDataPath + "/highscores.json", json);
    }

    public void LoadHighScores()
    {
        string path = Application.persistentDataPath + "/highscores.json";
        
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);

            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScores = data.highScores;            
            
            SortHighScores();
        }
        else
        {
            highScores = new List<HighScore> {new HighScore("TBD", 0)};
        }
    }

    public void SortHighScores()
    {
        highScores = highScores.OrderByDescending(o=>o.score).ToList();
    }

    public void FilterHighScores()
    {
        highScores = highScores.GetRange(0, Math.Min(highScores.Count, 10));
    }
}
