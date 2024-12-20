using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] LevelConfigurationSO levelDataSO;

    private void Start()
    {
        var currentLevelData = GetLevelData();
        LevelEvents.OnLevelDataSet?.Invoke(currentLevelData);
    }

    public LevelData GetLevelData()
    {
        return levelDataSO.levelData[DataHandler.LevelIndex % levelDataSO.levelData.Length];
    }
}
