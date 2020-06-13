using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Range(0, 10)]
    public float _carSpeed, _wheelLimit;

    private GetCamRot _cam;
    List<GameObject> _wheels;

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
        SetRot(-_cam._camRotZ * Time.deltaTime * 5, _wheelLimit * 3);
        SetCarSpeed();
        StopDetection();
    }
    void SetRot(float _camRot, float limit) 
    {
        transform.Rotate(0, _camRot, 0);

        for (int i = 0; i < _wheels.Count; i++)
        {
            Vector3 wheelRot = _wheels[i].transform.localEulerAngles;
            float wheelLimit = Mathf.Clamp(_cam._camRotZ, -limit, limit);

            if (i < 2)
                _wheels[i].transform.localEulerAngles = new Vector3(0, 0 - wheelLimit, wheelRot.z);
            else
                _wheels[i].transform.localEulerAngles = new Vector3(0, 0, wheelRot.z);

            _wheels[i].transform.Rotate(0, 0, -_carSpeed);
        }
    }

    void SetCarSpeed()
    {

    }
    void StopDetection()
    {

    }
}