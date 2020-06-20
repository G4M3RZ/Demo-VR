using UnityEngine;

public class SelectParticles : MonoBehaviour
{
    public GameObject _selectIcon;
    public Material _carParticles;
    public Sprite[] _sprites;

    private PlayerModifier _pm;

    private void Start()
    {
        _pm = GetComponentInParent<PlayerModifier>();
    }
    public void ParticleButton(int particle)
    {
        _carParticles.SetTexture("_MainTex", _sprites[particle].texture);
        PlayerPrefs.SetInt("CarFX", particle);

        _pm.SetIconSelection(particle, _selectIcon, this.gameObject.transform);
    }
}