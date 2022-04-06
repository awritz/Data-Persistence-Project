using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]
public class HighScoresUIHandler : MonoBehaviour
{

    public TextMeshProUGUI highScoreList;

    // Start is called before the first frame update
    void Start()
    {
        PopulateHighScores();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }
    
    private void PopulateHighScores()
    {
        List<HighScore> highScores = DataManager.Instance.highScores;

        string scores = "";

        int index = 0;
        foreach (var highScore in highScores)
        {
            index++;
            scores += $"#{index:D2}: {highScore}\n";
        }

        highScoreList.text = scores;
    }
}
