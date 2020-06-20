using UnityEngine;

public class Reset : MonoBehaviour
{
    [Range(0,3)]
    public float _rayUp, _upSpawn;
    public LayerMask _detect;

    private bool _resetPlayer;

    private void Update()
    {
        RayCast(transform.position);
        ResetCar(transform.position);
    }
    void RayCast(Vector3 playerPos)
    {
        Ray front = new Ray(playerPos, transform.up * _rayUp);
        RaycastHit hitInfo;

        Debug.DrawLine(front.origin, front.origin + front.direction * _rayUp, Color.blue);

        if (Physics.Raycast(front, out hitInfo, _rayUp, _detect))
            _resetPlayer = true;
    }
    void ResetCar(Vector3 playerPos)
    {
        if(_resetPlayer)
        {
            transform.position = new Vector3(playerPos.x, playerPos.y + _upSpawn, playerPos.z);
            transform.eulerAngles = Vector3.zero;
            _resetPlayer = false;
        }
    }
}