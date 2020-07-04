using UnityEngine;

public class Fade : MonoBehaviour
{
    private Material _fade;
    private float _alpha;
    public CountDown _count;

    private void Start()
    {
        _fade = GetComponent<MeshRenderer>().material;
        _alpha = 1;
        _fade.color = new Color(0, 0, 0, _alpha);
    }
    private void Update()
    {
        _fade.color = new Color(0, 0, 0, _alpha);

        _alpha = (_alpha > 0) ? _alpha -= Time.deltaTime / 2 : _alpha = 0;

        if(_alpha == 0)
        {
            _count._startCount = true;
            DestroyImmediate(this.gameObject);
        }
    }
}