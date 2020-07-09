using UnityEngine;

public class RotatePlayer : MonoBehaviour
{
    [Range(0,20)]
    public float _speed;
    private float _rot;
    private void Update()
    {
        _rot += Time.deltaTime * _speed;
        transform.localRotation = Quaternion.Euler(0, _rot, 0);
    }
}