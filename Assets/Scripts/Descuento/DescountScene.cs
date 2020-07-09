using UnityEngine;
using UnityEngine.UI;

public class DescountScene : MonoBehaviour
{
    public string _sceneName;
    private Button _descButton;
    private bool _descActive, _play;
    private void Awake()
    {
        _descButton = transform.GetChild(2).GetComponent<Button>();
        _descActive = (PlayerPrefs.GetInt("Descount") == 1) ? _descActive = true : _descActive = false;
        _descButton.interactable = _descActive;
    }

    public void NewGame(GameObject prefabFade)
    {
        if (!_play)
        {
            GameObject fade = Instantiate(prefabFade, transform) as GameObject;
            fade.GetComponent<FadeOut>()._sceneName = _sceneName;
            _play = true;
        }
    }
    public void ShowDescount(GameObject descount)
    {
        if (!_play)
            Instantiate(descount, transform);
    }
}