using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewLevelConfiguration",
    menuName = "ScriptableObjects/LevelConfiguration")]
public class LevelConfigurationSO : ScriptableObject
{
    public LevelData[] levelData;


}
