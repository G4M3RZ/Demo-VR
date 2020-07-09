using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour
{
    [Range(0,5)]
    public float _timeToWait;
    public List<GameObject> _fades;
    public string _sceneName;

    private void Awake()
    {
        StartCoroutine("FadeController");
    }
    IEnumerator FadeController()
    {
        Instantiate(_fades[0], transform);
        
        yield return new WaitForSeconds(_timeToWait);
        
        GameObject fadeOut = Instantiate(_fades[1], transform) as GameObject;
        fadeOut.GetComponent<FadeOut>()._sceneName = _sceneName;

        Destroy(this);
    }
}