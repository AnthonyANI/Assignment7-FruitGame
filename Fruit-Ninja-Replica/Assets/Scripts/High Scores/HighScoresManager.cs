using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HighScoresManager : MonoBehaviour
{
    public Text name1;
    public Text score1;

    public Text name2;
    public Text score2;

    public Text name3;
    public Text score3;

    public Text name4;
    public Text score4;

    public Text name5;
    public Text score5;

    public Text name6;
    public Text score6;

    public Text name7;
    public Text score7;

    public Text name8;
    public Text score8;

    public Text name9;
    public Text score9;

    public Text name10;
    public Text score10;


    public InputField playerName;

    // Start is called before the first frame update
    void Start()
    {
        GameDataManager.LoadHighScores();
        ShowHighScores();
    }

    private void ShowHighScores()
    {
        if (GameDataManager.highScores != null)
        {
            for (int entry = 1; entry <= GameDataManager.highScores.Count; entry++)
            {
                switch (entry)
                {
                    case 1:
                        name1.text = GameDataManager.highScores[entry - 1].Key;
                        score1.text = GameDataManager.highScores[entry - 1].Value.ToString();
                        break;
                    case 2:
                        name2.text = GameDataManager.highScores[entry - 1].Key;
                        score2.text = GameDataManager.highScores[entry - 1].Value.ToString();
                        break;
                    case 3:
                        name3.text = GameDataManager.highScores[entry - 1].Key;
                        score3.text = GameDataManager.highScores[entry - 1].Value.ToString();
                        break;
                    case 4:
                        name4.text = GameDataManager.highScores[entry - 1].Key;
                        score4.text = GameDataManager.highScores[entry - 1].Value.ToString();
                        break;
                    case 5:
                        name5.text = GameDataManager.highScores[entry - 1].Key;
                        score5.text = GameDataManager.highScores[entry - 1].Value.ToString();
                        break;
                    case 6:
                        name6.text = GameDataManager.highScores[entry - 1].Key;
                        score6.text = GameDataManager.highScores[entry - 1].Value.ToString();
                        break;
                    case 7:
                        name7.text = GameDataManager.highScores[entry - 1].Key;
                        score7.text = GameDataManager.highScores[entry - 1].Value.ToString();
                        break;
                    case 8:
                        name8.text = GameDataManager.highScores[entry - 1].Key;
                        score8.text = GameDataManager.highScores[entry - 1].Value.ToString();
                        break;
                    case 9:
                        name9.text = GameDataManager.highScores[entry - 1].Key;
                        score9.text = GameDataManager.highScores[entry - 1].Value.ToString();
                        break;
                    case 10:
                        name10.text = GameDataManager.highScores[entry - 1].Key;
                        score10.text = GameDataManager.highScores[entry - 1].Value.ToString();
                        break;
                }
            }
        }
    }

    public void PlayGame()
    {
        if (!string.IsNullOrWhiteSpace(playerName.text))
        {
            GameDataManager.currentPlayerName = playerName.text;
            SceneManager.LoadScene("Main");
        }
    }

    public void GoBack()
    {
        SceneManager.LoadScene("Intro");
    }
}
