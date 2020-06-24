using TMPro;
using UnityEngine;

public class ArkController : MonoBehaviour
{
    public string _question;
    private TextMeshPro _txt;

    private void Start()
    {
        _txt = transform.GetChild(0).GetChild(2).GetComponent<TextMeshPro>();
        _txt.text = _question;
    }
    public void DestroyThisObject()
    {
        Destroy(this.gameObject, 2f);
    }
}