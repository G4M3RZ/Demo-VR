using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectColors : MonoBehaviour
{
    public string _color;
    public GameObject _selectIcon;
    public Material _material;
    List<Color> _colorList;
    private PlayerModifier _pm;

    private void Start()
    {
        _pm = GetComponentInParent<PlayerModifier>();
        
        _colorList = new List<Color>();
        
        for (int i = 0; i < transform.childCount; i++)
        {
            if(transform.GetChild(i).GetComponent<Image>())
                _colorList.Add(transform.GetChild(i).GetComponent<Image>().color);
        }
    }

    public void SelectButton(int buttonNum)
    {
        _material.SetColor("_Color", _colorList[buttonNum]);
        _pm.SetIconSelection(buttonNum + 1, _selectIcon, this.gameObject.transform);
        
        PlayerPrefs.SetInt(_color, buttonNum);
        PlayerPrefs.Save();
    }
}