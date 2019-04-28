using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class OutroManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = ScoreManager.fruitSliced + " fruit sliced!";
        if (ScoreManager.fruitSliced > 0)
        {
            GameDataManager.highScores.Add(new KeyValuePair<string, int>(GameDataManager.currentPlayerName, ScoreManager.fruitSliced));
            GameDataManager.SaveHighScores();
        }
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("Intro");
    }

    public void QuitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
