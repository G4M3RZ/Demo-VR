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

    public AudioClip[] _sounds;
    private AudioSource _music;

    private void Start()
    {
        _text = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        _text.text = "";
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        _player.enabled = false;

        _music = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (_startCount)
            StartCoroutine("CountDownTiem");
    }
    IEnumerator CountDownTiem()
    {
        _startCount = false;

        for (int i = 0; i < _message.Length; i++)
        {
            yield return new WaitForSeconds(1.5f);
            _text.text = _message[i];

            if (i < _message.Length - 1)
                _music.clip = _sounds[0];
            else
                _music.clip = _sounds[1];

            _music.Play();
        }
        _player.enabled = true;
        yield return new WaitForSeconds(2f);
        Destroy(this.gameObject);
    }
}