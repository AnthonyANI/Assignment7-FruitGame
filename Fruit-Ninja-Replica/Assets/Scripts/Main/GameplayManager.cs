using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameplayManager : MonoBehaviour
{
    public static bool isGameover = false;

    public TextMeshProUGUI slicedText;
    public TextMeshProUGUI timerText;

    public GameObject dropped1;
    public GameObject dropped2;
    public GameObject dropped3;

    public float timer = 30f;

    // Start is called before the first frame update
    void Start()
    {
        isGameover = false;
        if (!GameDataManager.gameTimer)
        {
            timerText.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        UpdateGamePlayingStatus();
        UpdateSlicedText();
        UpdateDroppedIcons();
    }

    public void UpdateSlicedText()
    {
        if (slicedText)
        {
            slicedText.text = "Sliced: " + ScoreManager.fruitSliced;
        }
    }

    public void UpdateDroppedIcons()
    {
        switch (ScoreManager.fruitDropped)
        {
            case 0:
                dropped1.SetActive(false);
                dropped2.SetActive(false);
                dropped3.SetActive(false);
                break;
            case 1:
                dropped1.SetActive(true);
                dropped2.SetActive(false);
                dropped3.SetActive(false);
                break;
            case 2:
                dropped1.SetActive(true);
                dropped2.SetActive(true);
                dropped3.SetActive(false);
                break;
            case 3:
                dropped1.SetActive(true);
                dropped2.SetActive(true);
                dropped3.SetActive(true);
                if (!isGameover)
                    isGameover = true;
                break;
        }
    }

    private void UpdateGamePlayingStatus()
    {
        if (timer > 0 && !isGameover)
        {
            if (GameDataManager.gameTimer)
            {
                timer -= Time.deltaTime;
                if (timerText)
                    timerText.text = ((int)timer).ToString();
            }
        }
        else
        {
            if (!isGameover)
                isGameover = true;
            else if (GameObject.FindGameObjectsWithTag("Fruit").Length == 0)
                SceneManager.LoadScene("Outro");
        }
    }
}
