using UnityEngine;
using UnityEngine.UI;

public class Descount : MonoBehaviour
{
    public Button _descButton;

    private Material _fade;
    private float _alpha;
    private bool _active;

    private void Awake()
    {
        _descButton = GameObject.FindGameObjectWithTag("Canvas").transform.GetChild(2).GetComponent<Button>();
        _fade = GetComponent<Image>().material;
        _active = true;
        _alpha = 0;
        _fade.color = new Color(1, 1, 1, _alpha);
    }
    private void Update()
    {
        _fade.color = new Color(1, 1, 1, _alpha);

        if (_active)
            _alpha = (_alpha < 1) ? _alpha += Time.deltaTime : _alpha = 1;
        else
        {
            _alpha = (_alpha > 0) ? _alpha -= Time.deltaTime : _alpha = 0;

            if (_alpha == 0)
                Destroy(this.gameObject);
        }
    }
    public void QuitDescount()
    {
        _active = false;
    }
    public void RaceDescount()
    {
        PlayerPrefs.SetInt("Descount", 0);
        PlayerPrefs.Save();
        _descButton.interactable = false;

        QuitDescount();
    }
}