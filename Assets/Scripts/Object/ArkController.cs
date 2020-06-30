using TMPro;
using UnityEngine;

public class ArkController : MonoBehaviour
{
    public string _question;
    private TextMeshPro _txt;

    private void Start()
    {
        Transform child = transform.GetChild(0);
        _txt = child.GetChild(child.childCount - 1).GetComponent<TextMeshPro>();
        _txt.text = _question;
    }
    public void DestroyThisObject()
    {
        Destroy(this.gameObject, 2f);
    }
}