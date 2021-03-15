  
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class RestartButton : Button
{
    protected override void OnEnable()
    {
        base.OnEnable();
        
        onClick.AddListener(RestartLevel);
    }
    protected override void OnDisable()
    {
        base.OnDisable();

        onClick.RemoveListener(RestartLevel);
    }

    void RestartLevel()
    {
        LevelManager.Instance.RestartLevel();
        EventManager.OnLevelStart.Invoke();
    }
}