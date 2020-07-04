using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeEnd : MonoBehaviour
{
    private Material _mat;
    private float _fade;

    private void Start()
    {
        _mat = GetComponent<MeshRenderer>().material;
        _mat.color = new Color(0, 0, 0, 0);
    }
    private void Update()
    {
        _mat.color = new Color(0, 0, 0, _fade);

        _fade = (_fade < 1) ? _fade += Time.deltaTime / 3 : _fade = 1;

        if (_fade == 1)
            SceneManager.LoadScene(0);
    }
}