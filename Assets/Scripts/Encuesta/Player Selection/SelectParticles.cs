using UnityEngine;

public class SelectParticles : MonoBehaviour
{
    public GameObject _selectIcon;
    private PlayerModifier _pm;

    private void Start()
    {
        _pm = GetComponentInParent<PlayerModifier>();
    }
    public void ParticleButton(int particle)
    {
        PlayerPrefs.SetInt("CarFX", particle);
        _pm.SetIconSelection(particle + 1, _selectIcon, this.gameObject.transform);
    }
}