using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectCarColor : MonoBehaviour
{
    public Material _carMaterial;
    private Image _showColor;
    List<Scrollbar> _slider;

    private void Start()
    {
        _showColor = transform.GetChild(0).GetComponent<Image>();
        _slider = new List<Scrollbar>();
        for (int i = 1; i < transform.childCount; i++)
        {
            _slider.Add(transform.GetChild(i).GetComponent<Scrollbar>());
        }
    }
    private void Update()
    {
        _showColor.color = new Color(_slider[0].value, _slider[1].value, _slider[2].value);
        _carMaterial.color = _showColor.color;
    }
}
