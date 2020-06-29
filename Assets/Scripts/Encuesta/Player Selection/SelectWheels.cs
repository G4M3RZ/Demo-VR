using UnityEngine;

public class SelectWheels : MonoBehaviour
{
    public GameObject _selectIcon;
    private PlayerModifier _pm;
    private void Start()
    {
        _pm = GetComponentInParent<PlayerModifier>();
    }

    public void Wheel(int Num)
    {
        _pm.SetIconSelection(Num + 1, _selectIcon, this.gameObject.transform);

        PlayerPrefs.SetInt("Wheels", Num);
        PlayerPrefs.Save();
    }
}