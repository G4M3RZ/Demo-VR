using UnityEngine;
using TMPro;
public class CompareInfo : MonoBehaviour
{
    public int _infoNum;

    private TMP_InputField _field;
    private UserInformation _info;

    private void Start()
    {
        _field = GetComponent<TMP_InputField>();
        _info = GetComponentInParent<UserInformation>();
    }
    public void InfoField(int infoLengh)
    {
        if (_field.text.Length > infoLengh)
            _info._doneInfo[_infoNum] = true;
        else
            _info._doneInfo[_infoNum] = false;
    }
    public void AgeField()
    {
        if (_field.text.Length == 2 || _field.text.Length == 5)
        {
            _field.text = _field.text + "/";
            _field.MoveTextEnd(false);
        }
    }
    public void ResetAge()
    {
        _field.text = "";
    }
}