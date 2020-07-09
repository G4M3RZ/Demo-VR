using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBorder : MonoBehaviour
{
    public List<GameObject> _borderType;
    public List<GameObject> _curveType;

    [Range(0,10)]
    public List<int> _limits;
    private Transform _nextPos;

    private void Awake()
    {
        _nextPos = transform.GetChild(0);
        StartCoroutine("Border");
    }
    void StreetInstance(GameObject instance, Transform parent)
    {
        GameObject nextBush = Instantiate(instance, _nextPos.position, Quaternion.identity) as GameObject;
        nextBush.transform.parent = parent;

        _nextPos = nextBush.transform.GetChild(0).transform;
    }
    void ChangeBushes(GameObject bushType, Transform parent, int limit)
    {
        for (int i = 0; i < limit; i++)
            StreetInstance(bushType, parent);
    }
    IEnumerator Border()
    {
        bool change = false;

        for (int i = 0; i < 3; i++)
        {
            if (!change)
                ChangeBushes(_borderType[0], transform.GetChild(0), _limits[i]);
            else
                ChangeBushes(_borderType[1], transform.GetChild(0), _limits[i]);
            
            if(i < 2)
                ChangeBushes(_curveType[i], transform.GetChild(0), 1);

            change = !change;
        }

        yield return null;
        Destroy(this);
    }
}