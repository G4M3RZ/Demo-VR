using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRoad : MonoBehaviour
{
    public List<GameObject> _normalStreet;
    public List<GameObject> _openStreet;
    public List<GameObject> _arks;
    public List<GameObject> _endRoad;

    [Range(0,20)]
    public int _arkDistances, _normalArksCount;
    private int _streetCount;

    private Transform _nextPos;

    private void Awake()
    {
        _streetCount = 0;
        _nextPos = transform;

        StartCoroutine("World");
    }
    void StreetInstance(GameObject instance, Transform parent)
    {
        GameObject nextStreet = Instantiate(instance, _nextPos.position, Quaternion.identity) as GameObject;
        nextStreet.transform.parent = parent;

        _nextPos = nextStreet.transform.GetChild(0).transform;
    }
    void ChangeStreets(GameObject arkType, Transform parent, int limit)
    {
        for (int i = 0; i < _arkDistances; i++)
        {
            StreetInstance(arkType, parent);
            _streetCount = (_streetCount < limit) ? _streetCount++ : _streetCount = 0;
        }
    }
    IEnumerator World()
    {
        for (int a = 0; a < _arks.Count; a++)
        {
            if (a < _normalArksCount)
                ChangeStreets(_normalStreet[_streetCount], transform.GetChild(1), _normalStreet.Count);
            else
                ChangeStreets(_openStreet[_streetCount], transform.GetChild(2), _openStreet.Count);

            StreetInstance(_arks[a], transform.GetChild(3));
        }

        for (int e = 0; e < _arkDistances * 2; e++)
        {
            if(e <= 1)
                StreetInstance(_endRoad[e], transform.GetChild(4));
            else
                StreetInstance(_normalStreet[0], transform.GetChild(1));
        }

        yield return null;
        Destroy(this);
    }
}