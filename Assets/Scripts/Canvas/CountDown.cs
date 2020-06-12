using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountDown : MonoBehaviour
{
    public bool _startCount;
    private TextMeshProUGUI _text;
    public string[] _message;
    private Player _player;

    private void Start()
    {
        _text = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        _text.text = "";
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        _player.enabled = false;
    }
    void Update()
    {
        if (_startCount)
            StartCoroutine("CountDownTiem");
    }
    IEnumerator CountDownTiem()
    {
        _startCount = false;

        for (int i = 0; i < 3; i++)
        {
            yield return new WaitForSeconds(1f);
            _text.text = _message[i];
            //poner musica

        }
        _player.enabled = true;
        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject);
    }
}