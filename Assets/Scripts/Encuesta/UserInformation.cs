using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UserInformation : MonoBehaviour
{
    List<TMP_InputField> _fields;
    private bool _done, _InfoComplete;
    private GameObject _text;
    private Swipe _swipe;

    private void Start()
    {
        _fields = new List<TMP_InputField>();
        for (int i = 1; i < transform.childCount - 1; i++)
        {
            _fields.Add(transform.GetChild(i).GetComponent<TMP_InputField>());
        }
        _text = transform.GetChild(transform.childCount - 1).GetChild(1).gameObject;
        _swipe = transform.GetComponentInParent<Swipe>();
    }
    private void Update()
    {
        for (int i = 0; i < _fields.Count; i++)
        {
            if(_fields[i].text == "")
            {
                _InfoComplete = _done = false; break;
            }
            else
                _done = true;

            if (i == _fields.Count - 1 && _done)
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
            _swipe._next = true;
        else
            _text.SetActive(true);
    }
}