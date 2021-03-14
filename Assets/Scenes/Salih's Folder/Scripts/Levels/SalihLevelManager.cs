using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalihLevelManager : MonoBehaviour
{
    public static SalihLevelManager Instance => instance;

    public System.Action LevelCompleted;

    [Space]
    [SerializeField] LevelInfoAsset levelInfoAsset;


    private static SalihLevelManager instance;

    int currentLevelIndex = 0;

    List<GameObject> groundsList = new List<GameObject>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public bool HandleCreateNextLevel()
    {
        if (groundsList.Count > 0)
        {
            for (int i = 0; i < groundsList.Count; i++)
            {
                Destroy(groundsList[i]);
            }
        }

        ++currentLevelIndex;

        if (levelInfoAsset.levelInfos.Count >= currentLevelIndex)
        {
            CreateNextLevel();
            return true;
        }
        return false;
    }

    void CreateNextLevel()
    {
        groundsList = SalihGroundManager.Instance.SpawnPlatforms();
    }
}
