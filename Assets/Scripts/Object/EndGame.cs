using UnityEngine;

public class EndGame : MonoBehaviour
{
    public GameObject _fade;
    private GameObject _cam;
    private WinCondition _win;

    private void Start()
    {
        _cam = GameObject.FindGameObjectWithTag("MainCamera").gameObject;
        _win = GameObject.FindGameObjectWithTag("WinCondition").GetComponent<WinCondition>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && _win._answers.Count >= 8)
            Instantiate(_fade, _cam.transform);
    }
}