using UnityEngine;

public class SetCam : MonoBehaviour
{
    private GameObject _player, _head;
    [Range(0,10)]
    public float _distance;
    private Vector3 headPos;

    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _head = transform.GetChild(0).gameObject;
        
        headPos = _head.transform.localPosition;
        _head.transform.localPosition = new Vector3(headPos.x, headPos.y, -_distance);
    }
    private void Update()
    {
        Vector3 _getRot = _player.transform.eulerAngles;
        transform.rotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(_getRot), Time.deltaTime * 5);

        transform.position = _player.transform.position;
    }
}