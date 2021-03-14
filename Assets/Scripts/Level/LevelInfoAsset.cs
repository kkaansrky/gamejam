using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelInfoAsset", menuName = "Level/Level Info Asset")]
public class LevelInfoAsset : ScriptableObject
{
    [Space]
    public List<LevelInfo> levelInfos = new List<LevelInfo>();
}

[System.Serializable]
public struct LevelInfo
{
    [Header("Platform Size At That Level")]
    public int platformSize;
    [Header("Created Platform Prefabs"), Space(20)]
    public List<GameObject> platformList;

    [Space(10)]
    public bool spawnEndPlatform;
    public GameObject endPlatform;

    [Header("Offset Values Of Platforms"), Space(20)]
    public float basicPlatformLength;
    public float endPlatformLength;
}
