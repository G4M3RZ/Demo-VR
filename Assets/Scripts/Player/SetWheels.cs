using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetWheels : MonoBehaviour
{
    List<Material> _wheelsMat;
    public Texture[] _sprites, _normals;

    private void Start()
    {
        _wheelsMat = new List<Material>();
        int num = PlayerPrefs.GetInt("Wheels");

        for (int i = 0; i < transform.childCount; i++)
        {
            _wheelsMat.Add(transform.GetChild(i).GetChild(0).GetChild(0).GetComponent<MeshRenderer>().material);

            _wheelsMat[i].SetTexture("_MainTex", _sprites[num]);
            _wheelsMat[i].SetTexture("_BumpMap", _normals[num]);
            _wheelsMat[i].SetTexture("_ParallaxMap", _sprites[num]);
            _wheelsMat[i].SetTexture("_OcclusionMap", _sprites[num]);
        }
        Destroy(this);
    }
}