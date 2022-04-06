using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;

#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public TMP_InputField nameInput;
    public TextMeshProUGUI bestScoreText;
    
    // Start is called before the first frame update
    void Start()
    {
        HighScore highScore = DataManager.Instance.highScores.First();

        bestScoreText.text = $"Best Score : {highScore.name} : {highScore.score}";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetName()
    {
        DataManager.Instance.playerName = nameInput.text;
    }

    public void StartNewGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ViewHighScores()
    {
        SceneManager.LoadScene(2);
    }

    public void Exit()
    {
        // Save High Score
        DataManager.Instance.SaveHighScores();
        
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else 
        Application.Quit();
#endif
    }
    
    
}
