using UnityEngine;

public static class DataHandler
{
    static string LevelIndexKey = "LevelIndexKey";

    public static int LevelIndex
    {
        get => PlayerPrefs.GetInt(LevelIndexKey, 0);
        set => PlayerPrefs.SetInt(LevelIndexKey, value);
    }
}
