﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneMove : MonoBehaviour
{
    public string SceneName;

    public void Load()
    {
        SceneManager.LoadScene(SceneName);
    }
}
