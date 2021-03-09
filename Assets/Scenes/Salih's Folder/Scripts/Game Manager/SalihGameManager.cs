using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalihGameManager : MonoBehaviour
{
    static SalihGameManager instance;

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
        if (SalihLevelManager.Instance.HandleCreateNextLevel())
        {
            Debug.Log("Created New Level!");
        }
        else
        {
            Debug.Log("No More Level!");
        }

        SalihLevelManager.Instance.LevelCompleted += OnLevelCompleted;
    }

    void OnLevelCompleted()
    {
        Debug.Log("Current Level Completed!");
        SalihLevelManager.Instance.HandleCreateNextLevel();
    }
}
