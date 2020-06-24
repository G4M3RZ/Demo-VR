using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CompareInfo : MonoBehaviour
{
    public int _infoNum;
    public bool _useNormalField;
    private TMP_InputField _field;
    private InputField _normalField;
    private UserInformation _info;

    private void Start()
    {
        if (!_useNormalField)
            _field = GetComponent<TMP_InputField>();
        else
            _normalField = GetComponent<InputField>();

        _info = GetComponentInParent<UserInformation>();
    }
    public void InfoField(int infoLengh)
    {
        if (!_useNormalField)
            Field(_field.text.Length, infoLengh, _field.text);
        else
            Field(_normalField.text.Length, infoLengh, _normalField.text);
    }
    void Field(int size, int line, string newText)
    {
        if (size > line)
            _info._doneInfo[_infoNum] = true;
        else
            _info._doneInfo[_infoNum] = false;

        _info._info[_infoNum] = newText;
    }

    public void AgeField(TextMeshProUGUI newText)
    {
        if (_normalField.text.Length == 2 || _normalField.text.Length == 5)
        {
            _normalField.text = _normalField.text + "/";
            _normalField.MoveTextEnd(false);
        }
        newText.text = _normalField.text;
    }
    public void ResetAge()
    {
        _normalField.text = "";
    }
}