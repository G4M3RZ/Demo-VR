using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour
{
    List<GameObject> _panels;
    List<Vector2> _newPos;
    [HideInInspector]
    public bool _next;
    [Range(0,10)]
    public float _swipeSpeed;

    private void Start()
    {
        _panels = new List<GameObject>();
        _newPos = new List<Vector2>();
        for (int i = 0; i < transform.childCount - 1; i++)
        {
            _panels.Add(transform.GetChild(i).gameObject);
            _newPos.Add(_panels[i].transform.localPosition);
            _newPos[i] = new Vector2(_newPos[i].x - 1080, _newPos[i].y);
        }
    }
    private void Update()
    {
        if (_next)
        {
            for (int i = 0; i < _panels.Count; i++)
            {
                Vector2 pos = _panels[i].transform.localPosition;
                pos = Vector2.Lerp(pos, _newPos[i], Time.deltaTime * _swipeSpeed);
                _panels[i].transform.localPosition = pos;
            }
        }
    }
}