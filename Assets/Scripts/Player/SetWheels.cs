using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetWheels : MonoBehaviour
{
    public GameObject[] _wheels;
    List<GameObject> _place;

    private void Start()
    {
        _place = new List<GameObject>();
        
        for (int i = 0; i < transform.childCount; i++)
        {
            _place.Add(transform.GetChild(i).GetChild(0).gameObject);
            GameObject newWheel = Instantiate(_wheels[PlayerPrefs.GetInt("Wheels")], _place[i].transform);
        }
        Destroy(this);
    }
}