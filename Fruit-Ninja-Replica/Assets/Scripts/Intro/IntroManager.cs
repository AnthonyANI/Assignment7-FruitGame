using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour
{
    public Canvas MenuUI;
    public Canvas OptionsUI;

    // Options Components
    public Slider fruitSizeSlider;
    public Slider fruitSpawnSpeedSlider;
    public Slider fruitSpeedSlider;
    public TMP_Dropdown fruitSelectionDropdown;
    public TMP_Dropdown bladeSizeDropdown;
    public TMP_Dropdown gravityDropdown;
    public Toggle gameTimerToggle;

    public void StartGame()
    {
        ScoreManager.ResetCurrentScores();
        SceneManager.LoadScene("HighScores");
    }

    public void ShowMenu()
    {
        SaveOptions();
        OptionsUI.gameObject.SetActive(false);
        MenuUI.gameObject.SetActive(true);
    }

    public void ShowOptions()
    {
        LoadOptions();
        MenuUI.gameObject.SetActive(false);
        OptionsUI.gameObject.SetActive(true);
    }

    public void QuitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

    private void LoadOptions()
    {
        GameDataManager.LoadGameOptions();

        fruitSizeSlider.value = GameDataManager.fruitSize;
        fruitSpawnSpeedSlider.value = GameDataManager.fruitSpawnSpeed;
        fruitSpeedSlider.value = GameDataManager.fruitSpeed;
        bladeSizeDropdown.value = GameDataManager.bladeSize - 1;
        gravityDropdown.value = GameDataManager.gravity - 1;
        gameTimerToggle.isOn = GameDataManager.gameTimer;
    }

    private void SaveOptions()
    {
        GameDataManager.fruitSize = (int)fruitSizeSlider.value;
        GameDataManager.fruitSpawnSpeed = (int)fruitSpawnSpeedSlider.value;
        GameDataManager.fruitSpeed = (int)fruitSpeedSlider.value;
        GameDataManager.bladeSize = bladeSizeDropdown.value + 1;
        GameDataManager.gravity = gravityDropdown.value + 1;
        GameDataManager.gameTimer = gameTimerToggle.isOn;

        GameDataManager.SaveGameOptions();
    }
}
