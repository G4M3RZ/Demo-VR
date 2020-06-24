using UnityEngine;

public class SelectGender : MonoBehaviour
{
    public GameObject _selectIcon;
    public Material _playerMaterial;
    public Color[] _gender;

    private PlayerModifier _pm;

    private void Start()
    {
        _pm = GetComponentInParent<PlayerModifier>();
    }
    public void GenderButton(int buttonNum)
    {
        _playerMaterial.color = _gender[buttonNum];
        _pm.SetIconSelection(buttonNum, _selectIcon, this.gameObject.transform);
    }
}