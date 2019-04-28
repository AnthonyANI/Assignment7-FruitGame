using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameDataManager : MonoBehaviour
{
    public static int fruitSize = 2;
    public static int fruitSpawnSpeed = 2;
    public static int fruitSpeed = 2;
    public static int bladeSize = 2;
    public static int gravity = 2;
    public static bool gameTimer = true;

    public static List<KeyValuePair<string, int>> highScores;

    public static string currentPlayerName;

    public static string highScoresFilePath = "fruitGameHighScores.txt";
    public static string optionsFilePath = "fruitGameOptions.txt";

    public static void LoadGameOptions()
    {
        string[] gameOptionsData;
        if (File.Exists(optionsFilePath))
        {
            gameOptionsData = File.ReadAllLines(optionsFilePath);

            foreach (string line in gameOptionsData)
            {
                string[] optionsDataEntry;
                if (line.Contains(","))
                {
                    optionsDataEntry = line.Trim().Split(',');

                    switch (optionsDataEntry[0])
                    {
                        case "fruitSize":
                            fruitSize = int.Parse(optionsDataEntry[1]);
                            break;
                        case "fruitSpawnSpeed":
                            fruitSpawnSpeed = int.Parse(optionsDataEntry[1]);
                            break;
                        case "fruitSpeed":
                            fruitSpeed = int.Parse(optionsDataEntry[1]);
                            break;
                        case "bladeSize":
                            bladeSize = int.Parse(optionsDataEntry[1]);
                            break;
                        case "gravity":
                            gravity = int.Parse(optionsDataEntry[1]);
                            break;
                        case "gameTimer":
                            gameTimer = bool.Parse(optionsDataEntry[1]);
                            break;
                    }
                }
            }
        }
    }

    public static void LoadHighScores()
    {
        highScores = new List<KeyValuePair<string, int>>();
        string[] highScoresData;
        if (File.Exists(highScoresFilePath))
        {
            highScoresData = File.ReadAllLines(highScoresFilePath);
            highScores.Clear();

            foreach (string line in highScoresData)
            {
                string[] highScoresDataEntry;
                if (line.Contains(","))
                {
                    highScoresDataEntry = line.Trim().Split(',');

                    highScores.Add(new KeyValuePair<string, int>(highScoresDataEntry[0], int.Parse(highScoresDataEntry[1])));
                }
            }

            SortHighScores();
        }
    }

    public static void SaveGameOptions()
    {
        string[] gameOptionsData = {
            "fruitSize," + fruitSize,
            "fruitSpawnSpeed," + fruitSpawnSpeed,
            "fruitSpeed," + fruitSpeed,
            "bladeSize," + bladeSize,
            "gravity," + gravity,
            "gameTimer," + gameTimer,
        };

        File.WriteAllLines(optionsFilePath, gameOptionsData);
    }

    public static void SaveHighScores()
    {
        List<string> highScoresDataList = new List<string>();

        SortHighScores();

        foreach (KeyValuePair<string, int> highScore in highScores)
        {
            highScoresDataList.Add(highScore.Key + ',' + highScore.Value);
        }

        File.WriteAllLines(highScoresFilePath, highScoresDataList.ToArray());
    }

    public static void SortHighScores()
    {
        // Sort high scores by comparing their values - highest first
        highScores.Sort((x, y) => y.Value.CompareTo(x.Value));
    }
}
