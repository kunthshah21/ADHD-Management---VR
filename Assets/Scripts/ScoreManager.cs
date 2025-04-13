using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    // This static variable tracks the total number of boxes spawned.
    public static int TotalBoxesSpawned = 0;

    // A public static method to increment the box count.
    public static void IncrementBoxCount()
    {
        TotalBoxesSpawned++;
    }
}
