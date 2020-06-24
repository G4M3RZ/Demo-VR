using UnityEngine;
using UnityEngine.UI;

public class Descount : MonoBehaviour
{
    private Material _image;
    private float alpha;
    private bool _active;
    private GameObject button;
    private void Start()
    {
        _image = transform.GetChild(0).GetComponent<Image>().material;
        _image.color = new Color(1, 1, 1, alpha);
        button = transform.GetChild(1).gameObject;
        
        if (PlayerPrefs.GetInt("Descount") == 1)
            button.SetActive(true);
        else
            button.SetActive(false);
    }
    private void Update()
    {
        _image.color = new Color(1, 1, 1, alpha);

        if (_active)
            alpha = (alpha < 1) ? alpha += Time.deltaTime : alpha = 1;
        else
            alpha = (alpha > 0) ? alpha -= Time.deltaTime : alpha = 0;
    }

    public void ActiveButton()
    {
        if(PlayerPrefs.GetInt("Descount") == 1)
            _active = !_active;
    }
}