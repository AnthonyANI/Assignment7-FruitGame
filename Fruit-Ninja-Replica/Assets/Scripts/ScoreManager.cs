using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static int fruitSliced = 0;
    public static int fruitDropped = 0;
    // Start is called before the first frame update

    public static void UpdateFruitSliced(int valueToAdd = 1, bool resetToZero = false)
    {
        fruitSliced = valueToAdd + (resetToZero ? 0 : fruitSliced);
    }

    public static void UpdateFruitDropped(int valueToAdd = 1, bool resetToZero = false)
    {
        fruitDropped = valueToAdd + (resetToZero ? 0 : fruitDropped);
    }

    public static void ResetCurrentScores()
    {
        UpdateFruitSliced(0, true);
        UpdateFruitDropped(0, true);
    }
}
