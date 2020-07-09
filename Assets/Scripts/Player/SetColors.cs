using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetColors : MonoBehaviour
{
    public List<string> _colorNames;
    public List<Material> _materials;
    public List<Color> _character, _car;

    private void Awake()
    {
        _materials[0].SetColor("_Color", _character[PlayerPrefs.GetInt(_colorNames[0])]);
        _materials[1].SetColor("_Color", _car[PlayerPrefs.GetInt(_colorNames[1])]);
        Destroy(this);
    }
}