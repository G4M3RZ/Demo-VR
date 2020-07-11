using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    [Range(0,3)]
    public float _speed;
    private Material _mat;
    private float _fade;

    private void Awake()
    {
        _mat = GetComponent<Image>().material;
        _mat.color = new Color(0, 0, 0, 1);
        _fade = 1;
    }
    private void Update()
    {
        _mat.color = new Color(0, 0, 0, _fade);

        _fade = (_fade > 0) ? _fade -= Time.deltaTime * _speed : _fade = 0;

        if (_fade == 0)
            Destroy(this.gameObject);
    }
}