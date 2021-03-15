using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static GameManager instance;

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
            return;
        }
    }

    private void Start()
    {
        if (LevelManager.Instance.HandleCreateNextLevel())
        {
            EventManager.OnLevelStart.Invoke();
        }
        else
        {
            Debug.Log("No More Level!");
        }

        LevelManager.Instance.LevelCompleted += OnLevelCompleted;
        LevelManager.Instance.LevelFailed += OnLevelFailed;
    }

    void OnLevelCompleted()
    {
        Debug.Log("Current Level Completed!");
        LevelManager.Instance.HandleCreateNextLevel();
    }
    void OnLevelFailed()
    {
        Debug.Log("Current Level Completed!");
        LevelManager.Instance.HandleLevelFailed();
    }
}
