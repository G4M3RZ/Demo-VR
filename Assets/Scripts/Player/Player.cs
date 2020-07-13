using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Range(0,20)]
    public float _carSpeed, _limitCarRot, _wheelLimit;
    [Range(0,4)]
    public float _rayForward, _rayDown;
    public LayerMask _detect;

    private GetCamRot _cam;
    List<GameObject> _wheels;

    private Rigidbody _rgb;
    [HideInInspector]
    public float _currentSpeed;
    private bool _stopCar;
    [HideInInspector]
    public bool _endRace;

    private void Start()
    {
        _cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GetCamRot>();
        _wheels = new List<GameObject>();
        
        for (int i = 0; i < transform.GetChild(0).GetChild(1).childCount; i++)
            _wheels.Add(transform.GetChild(0).GetChild(1).GetChild(i).gameObject);

        _rgb = GetComponent<Rigidbody>();
        _currentSpeed = 0;
    }
    private void Update()
    {
        float carRot = Mathf.Clamp(-_cam._camRotZ, -_limitCarRot, _limitCarRot);
        SetRot(carRot * Time.deltaTime * 5, _wheelLimit * 3);
        SetCarSpeed(_currentSpeed, 20);
        StopDetection(transform.position);
    }
    private void FixedUpdate()
    {
        if (!_stopCar)
            _rgb.velocity = transform.forward * _currentSpeed;
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

            _wheels[i].transform.Rotate(0, 0, -_currentSpeed);
        }
    }
    void SetCarSpeed(float speed, float velocity)
    {
        if (!_endRace)
        {
            if (_stopCar)
                _currentSpeed = (speed > 0) ? speed -= Time.deltaTime * velocity : speed = 0;
            else
                _currentSpeed = (speed < _carSpeed) ? speed += Time.deltaTime * (velocity / 3) : speed = _carSpeed;
        }
        else
            _currentSpeed = (speed > 0) ? speed -= Time.deltaTime * velocity : speed = 0;
    }
    void StopDetection(Vector3 playerPos)
    {
        RaycastHit hitInfo;
        Ray front = new Ray(playerPos, transform.forward * _rayForward);
        Ray down = new Ray(playerPos, transform.up * -_rayDown);

        /*Debug.DrawLine(front.origin, front.origin + front.direction * _rayForward, Color.red);
        Debug.DrawLine(down.origin, down.origin + down.direction * _rayDown, Color.red);*/

        if (Physics.Raycast(front, out hitInfo, _rayForward, _detect) || !Physics.Raycast(down, out hitInfo, _rayDown, _detect))
            _stopCar = true;
        else
            _stopCar = false;
    }
}