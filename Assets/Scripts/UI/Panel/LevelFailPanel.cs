using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFailPanel : Panel
{
    void OnEnable()
    {
        HidePanel();
        EventManager.OnLevelFail.AddListener(ShowPanel);
        EventManager.OnLevelStart.AddListener(HidePanel);
    }

    void OnDisable()
    {
        EventManager.OnLevelFail.RemoveListener(ShowPanel);
        EventManager.OnLevelStart.RemoveListener(HidePanel);
        HidePanel();
    }
}