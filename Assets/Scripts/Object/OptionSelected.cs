using UnityEngine;

public class OptionSelected : MonoBehaviour
{
    private WinCondition _wc;
    private ArkController _ark;
    public string _anwser;
    private void Start()
    {
        _wc = GetComponentInParent<WinCondition>();
        _ark = GetComponentInParent<ArkController>();
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