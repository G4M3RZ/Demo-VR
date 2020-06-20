using UnityEngine;

public class SlowMotion : MonoBehaviour
{
    private bool _slowMotion;
    [Range(0,1)]
    public float _Speed;
    private AudioSource _music;

    private void Update()
    {
        if (_music != null)
            _music.pitch = Time.timeScale;

        if(_slowMotion)
            Realentizar(0.05f);
        else
            VolverNormalidad(_Speed); //4f
    }
    void Realentizar(float slowLimit)
    {
        Time.timeScale = slowLimit;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
        _slowMotion = false;
    }
    void VolverNormalidad(float slowVelocity)
    {
        if (Time.timeScale != 1)
        {
            Time.timeScale += (1f * slowVelocity) * Time.unscaledDeltaTime;
            Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("GameController"))
            _slowMotion = true;
    }
}