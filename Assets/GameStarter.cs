﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameStarter : MonoBehaviour
{
    public void StartScene(){
        SceneManager.LoadScene("Scene");
    }
}
