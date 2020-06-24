using UnityEngine;

public class ParticlesValues : MonoBehaviour
{
    private ParticleSystem _particles;
    private Player _player;
    [Range(0,20)]
    public float _maxRateValue;

    private void Start()
    {
        _particles = GetComponent<ParticleSystem>();
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        var emission = _particles.emission;
        emission.rateOverTime = 0;
    }
    private void Update()
    {
        var emission = _particles.emission;
        emission.rateOverTime = Mathf.Clamp(_player._currentSpeed * 10, 0, _maxRateValue * 10);
    }
}