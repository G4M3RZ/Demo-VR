using UnityEngine;
using UnityEngine.SceneManagement;

public class DescountScene : MonoBehaviour
{
    public string _sceneName;
    private int _descActive;
    private bool _play;
    private void Awake()
    {
        _descActive = PlayerPrefs.GetInt("Descount");

        if (_descActive == 0)
            SceneManager.LoadScene(_sceneName);
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