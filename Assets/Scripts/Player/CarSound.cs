using System.Collections.Generic;
using UnityEngine;

public class CarSound : MonoBehaviour
{
    public List<AudioClip> _carSounds;
    private AudioSource _sound;
    private Player _player;
    private bool _change;

    private void Start()
    {
        _sound = GetComponent<AudioSource>();
        _player = GetComponent<Player>();
        _change = true;
    }
    private void Update()
    {
        if (_player.enabled && _change)
        {
            ChangeSoundTruck(0, false);
        }
        if (!_sound.isPlaying && !_change)
        {
            ChangeSoundTruck(1, true);
            Destroy(this);
        }
    }
    void ChangeSoundTruck(int soundNum, bool value)
    {
        _sound.clip = _carSounds[soundNum];
        _sound.loop = _change = value;
        _sound.Play();
    }
}