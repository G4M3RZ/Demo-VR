using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Transition : MonoBehaviour
{
    public bool _isFirst;
    [Range(0, 1)]
    public float _velocity;
    private float _alpha;
    private Image _panel;

    public string _sceneName;

    private void Start()
    {
        _panel = GetComponent<Image>();
        _alpha = (_isFirst) ? _alpha = 1 : _alpha = 0;
        _panel.color = new Color(0, 0, 0, _alpha);
    }

    private void Update()
    {
        _panel.color = new Color(0, 0, 0, _alpha);

        if (_isFirst)
        {
            _alpha = (_alpha > 0) ? _alpha -= Time.deltaTime * _velocity : _alpha = 0;

            if (_alpha == 0)
                _isFirst = false;
        }
        else
        {
            _alpha = (_alpha < 1) ? _alpha += Time.deltaTime * _velocity : _alpha = 1;

            if (_alpha == 1)
                SceneManager.LoadScene(_sceneName);
        }
    }
}