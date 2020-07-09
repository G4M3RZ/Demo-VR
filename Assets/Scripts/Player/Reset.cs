using UnityEngine;

[ExecuteInEditMode]
public class Reset : MonoBehaviour
{
    [Range(0,3)]
    public float _rayUp, _upSpawn;
    public LayerMask _detect;

    private void Update()
    {
        RayCast(transform.position);
    }
    void RayCast(Vector3 playerPos)
    {
        Ray front = new Ray(playerPos, transform.up * _rayUp);
        RaycastHit hitInfo;

        //Debug.DrawLine(front.origin, front.origin + front.direction * _rayUp, Color.red);

        if (Physics.Raycast(front, out hitInfo, _rayUp, _detect))
            if(hitInfo.collider.CompareTag("Respawn"))
                ResetCar(playerPos);
    }
    void ResetCar(Vector3 playerPos)
    {
        transform.position = new Vector3(playerPos.x, playerPos.y + _upSpawn, playerPos.z);
        transform.eulerAngles = Vector3.zero;
    }
}