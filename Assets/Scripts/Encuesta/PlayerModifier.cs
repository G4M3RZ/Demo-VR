using UnityEngine;

public class PlayerModifier : MonoBehaviour
{
    public GameObject _transition;
    private Transition _script;

    public void StartGame(string sceneName)
    {
        GameObject fade = Instantiate(_transition, transform) as GameObject;
        _script = fade.GetComponent<Transition>();
        _script._isFirst = false;
        _script._sceneName = sceneName;
    }

    public void SetIconSelection(int buttonNum, GameObject icon, Transform section)
    {
        for (int i = 1; i < section.childCount; i++)
        {
            if (i != buttonNum)
            {
                if (section.GetChild(i).childCount != 0)
                    Destroy(section.GetChild(i).GetChild(0).gameObject);
            }
            else
            {
                if (section.GetChild(i).childCount == 0)
                    Instantiate(icon, section.GetChild(i).transform);
            }
        }
    }
}