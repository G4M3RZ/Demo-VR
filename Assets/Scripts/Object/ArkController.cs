using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ArkController : MonoBehaviour
{
    public string _question;
    public List<string> _anwsers;
    public List<Material> _colors;

    public TextMeshProUGUI _txt;
    private TextMeshPro _anws;

    List<BoxCollider> _dColl;

    private void Start()
    {
        GameObject texto = GameObject.FindGameObjectWithTag("Canvas").transform.GetChild(1).GetChild(0).gameObject;
        _txt = texto.GetComponent<TextMeshProUGUI>();

        _dColl = new List<BoxCollider>();

        for (int i = 0; i < _anwsers.Count; i++)
        {
            Transform door = transform.GetChild(i).GetChild(0);
            _dColl.Add(door.GetComponent<BoxCollider>());
            door.GetComponent<MeshRenderer>().material = _colors[i];

            _anws = door.GetChild(0).GetComponent<TextMeshPro>();
            _anws.text = _anwsers[i];
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
            _txt.text = _question;
    }
    public void DestroyThisObject()
    {
        for (int i = 0; i < _dColl.Count; i++)
            _dColl[i].enabled = false;

        _txt.text = "";

        Destroy(this.gameObject, 2f);
    }
}