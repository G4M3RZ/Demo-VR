using System.Collections.Generic;
using UnityEngine;

public class SetCarParticles : MonoBehaviour
{
    List<GameObject> _particles;
    
    private void Start()
    {
        _particles = new List<GameObject>();
        for (int i = 0; i < transform.childCount; i++)
        {
            _particles.Add(transform.GetChild(i).gameObject);
            _particles[i].SetActive(false);
        }
        _particles[PlayerPrefs.GetInt("CarFX")].SetActive(true);
    }
}