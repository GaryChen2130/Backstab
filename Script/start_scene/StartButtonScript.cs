﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartButtonScript : MonoBehaviour
{
    public Button start;

    void Start()
    {
        start.onClick.AddListener(btnClick);
    }

    private void btnClick()
    {
        SceneManager.LoadScene("main_scene", 0);
    }
}
