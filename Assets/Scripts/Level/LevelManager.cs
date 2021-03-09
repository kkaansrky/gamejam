using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance => instance;

    public System.Action LevelCompleted;

    [Space]
    [SerializeField] LevelInfoAsset levelInfoAsset;


    private static LevelManager instance;

    int currentLevelIndex = 0;

    
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

    }
}
