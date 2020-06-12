using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private GetCamRot _cam;
    List<GameObject> _wheels;
    [Range(0,10)]
    public float _carSpeed;

    private void Start()
    {
        _cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GetCamRot>();
        _wheels = new List<GameObject>();
        for (int i = 0; i < transform.GetChild(0).GetChild(1).childCount; i++)
        {
            _wheels.Add(transform.GetChild(0).GetChild(1).GetChild(i).gameObject);
        }
    }

    private void Update()
    {
        SetRot(-_cam._camRotZ * Time.deltaTime * 5);
    }
    void SetRot(float _camRot) 
    {
        //Car
        transform.Rotate(0, _camRot, 0);

        //Wheels
        for (int i = 0; i < _wheels.Count; i++)
        {
            _wheels[i].transform.Rotate(0, -_carSpeed, 0);
        }
    }
}