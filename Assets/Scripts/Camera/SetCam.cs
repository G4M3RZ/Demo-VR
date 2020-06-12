using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[ExecuteInEditMode]
public class SetCam : MonoBehaviour
{
    private GameObject _player, _head;
    [Range(0,10)]
    public float _distance;
    private Vector3 headPos;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _head = transform.GetChild(0).gameObject;
        headPos = _head.transform.localPosition;
        _head.transform.localPosition = new Vector3(headPos.x, headPos.y, -_distance);
    }
    private void Update()
    {
        _head.transform.localPosition = new Vector3(headPos.x, headPos.y, -_distance);

        Vector3 _getRot = _player.transform.eulerAngles;
        transform.rotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(_getRot), Time.deltaTime * 5);

        Vector3 _getPos = _player.transform.position;
        transform.position = new Vector3(_getPos.x, _getPos.y, _getPos.z);
    }
}