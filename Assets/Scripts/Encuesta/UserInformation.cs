using System.Collections.Generic;
using UnityEngine;

public class UserInformation : MonoBehaviour
{
    [HideInInspector]
    public List<bool> _doneInfo;
    public List<string> _info;

    private bool _InfoComplete;
    private GameObject _text;
    private Swipe _swipe;

    private void Start()
    {
        _doneInfo = new List<bool>();
        _info = new List<string>();
        for (int i = 1; i < transform.childCount - 1; i++)
        {
            _doneInfo.Add(false);
            _info.Add("");
        }
        _text = transform.GetChild(transform.childCount - 1).GetChild(1).gameObject;
        _swipe = transform.GetComponentInParent<Swipe>();
    }
    private void Update()
    {
        for (int i = 0; i < _doneInfo.Count; i++)
        {
            if(!_doneInfo[i])
            {
                _InfoComplete = false; break;
            }

            if (_doneInfo[_doneInfo.Count - 1])
                _InfoComplete = true;
        }
    }
    public void Text()
    {
        _text.SetActive(false);
    }
    public void NextButton()
    {
        if (_InfoComplete)
        {
            //Enviar Informacion

            //Si la Informacion se manda:
            _swipe._next = true;
        }
        else
            _text.SetActive(true);
    }
}