﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void changemenuscene(string scenename)
    {

        SceneManager.LoadScene(scenename);

    }
}