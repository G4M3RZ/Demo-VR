using TMPro;
using UnityEngine;

public class OptionSelected : MonoBehaviour
{
    public string _anwser;
    private WinCondition _wc;
    private ArkController _ark;
    private TextMeshPro _text;
    private void Start()
    {
        _wc = GetComponentInParent<WinCondition>();
        _ark = GetComponentInParent<ArkController>();
        _text = transform.GetChild(0).GetComponent<TextMeshPro>();
        _text.text = _anwser;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _wc._answers.Add(_anwser);
            _ark.DestroyThisObject();
        }
    }
}