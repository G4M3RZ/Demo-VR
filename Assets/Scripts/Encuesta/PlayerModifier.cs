using UnityEngine;

public class PlayerModifier : MonoBehaviour
{
    public string _sceneName;
    private AudioSource _selectEfect;

    private void Awake()
    {
        _selectEfect = GetComponent<AudioSource>();
    }
    public void StartGame(GameObject fadeOut)
    {
        GameObject fade = Instantiate(fadeOut, transform) as GameObject;
        fade.GetComponent<FadeOut>()._sceneName = _sceneName;
        Destroy(this);
    }
    public void SetIconSelection(int buttonNum, GameObject icon, Transform section)
    {
        _selectEfect.Play();

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