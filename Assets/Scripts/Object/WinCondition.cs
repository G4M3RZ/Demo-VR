using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    public List<string> _answers;

    private void Awake()
    {
        _answers = new List<string>();
    }
    private void Update()
    {
        if (transform.childCount == 0)
        {
            PlayerPrefs.SetInt("Descount", 1);
            PlayerPrefs.Save();
            //Enviar Informacion

            //Si la informacion se manda:
            Destroy(this.gameObject);
        }
    }
}