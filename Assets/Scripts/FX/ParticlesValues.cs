using System.Collections.Generic;
using UnityEngine;

public class ParticlesValues : MonoBehaviour
{
    [Range(0, 20)]
    public float _maxRateValue;

    List<ParticleSystem> _ps;
    private Player _player;

    private void Start()
    {
        _ps = new List<ParticleSystem>();

        for (int i = 0; i < transform.childCount; i++)
        {
            _ps.Add(transform.GetChild(i).GetComponent<ParticleSystem>());
            var emission = _ps[i].emission;
            emission.rateOverTime = 0;
        }

        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
    private void Update()
    {
        for (int i = 0; i < _ps.Count; i++)
        {
            var emission = _ps[i].emission;
            emission.rateOverTime = Mathf.Clamp(_player._currentSpeed * 10, 0, _maxRateValue * 10);
        }
    }
}