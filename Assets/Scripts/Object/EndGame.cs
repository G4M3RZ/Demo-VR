using UnityEngine;

public class EndGame : MonoBehaviour
{
    public GameObject _fade;
    private GameObject _cam;
    public WinCondition _win;
    private bool _endGame;

    private void Start()
    {
        _cam = GameObject.FindGameObjectWithTag("MainCamera").gameObject;
    }
    private void Update()
    {
        if (_endGame)
            Instantiate(_fade, _cam.transform);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && _win._answers.Count >= 8)
            _endGame = true;
    }
}