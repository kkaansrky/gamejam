using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGamePanel : Panel
{
    void OnEnable()
    {
        EventManager.OnLevelFail.AddListener(HidePanel);
        EventManager.OnLevelStart.AddListener(ShowPanel);
        EventManager.OnLevelFinish.AddListener(HidePanel);
    }

    void OnDisable()
    {
        EventManager.OnLevelFail.RemoveListener(HidePanel);
        EventManager.OnLevelStart.RemoveListener(ShowPanel);
        EventManager.OnLevelFinish.RemoveListener(HidePanel);
    }
}