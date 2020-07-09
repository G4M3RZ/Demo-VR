﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour
{
    public string _sceneName;
    private Material _fade;
    private float _alpha;

    private void Awake()
    {
        _fade = GetComponent<Image>().material;
        _alpha = 0;
        _fade.color = new Color(0, 0, 0, _alpha);
    }
    private void Update()
    {
        _fade.color = new Color(0, 0, 0, _alpha);

        _alpha = (_alpha < 1) ? _alpha += Time.deltaTime / 2 : _alpha = 1;

        if (_alpha == 1)
            SceneManager.LoadScene(_sceneName);
    }
}