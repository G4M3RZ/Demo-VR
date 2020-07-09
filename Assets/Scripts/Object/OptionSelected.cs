using UnityEngine;
using TMPro;

public class OptionSelected : MonoBehaviour
{
    private TextMeshPro _anwser;
    private WinCondition _wc;
    private ArkController _ark;

    private void Start()
    {
        _anwser = transform.GetChild(0).GetComponent<TextMeshPro>();
        _wc = GetComponentInParent<WinCondition>();
        _ark = GetComponentInParent<ArkController>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _wc._answers.Add(_anwser.text);
            _ark.DestroyThisObject();
        }
    }
}