using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public GameObject _fade, _uiWin;
    public List<GameObject> _particles;
    private GameObject _cam;
    private Player _player;
    private WinCondition _win;

    private void Awake()
    {
        for (int i = 0; i < _particles.Count; i++)
            _particles[i].SetActive(false);

        _cam = GameObject.FindGameObjectWithTag("MainCamera");
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        _win = GameObject.FindGameObjectWithTag("WinCondition").GetComponent<WinCondition>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && _win._answers.Count >= 8)
            StartCoroutine("EndRace");
    }
    IEnumerator EndRace() 
    {
        _player._endRace = true;
        
        for (int i = 0; i < _particles.Count; i++)
            _particles[i].SetActive(true);
        
        yield return new WaitForSeconds(2f);

        _player.enabled = false;
        Instantiate(_uiWin, GameObject.FindGameObjectWithTag("Canvas").transform);

        yield return new WaitForSeconds(2f);
        
        Instantiate(_fade, _cam.transform);
        Destroy(this);
    }
}