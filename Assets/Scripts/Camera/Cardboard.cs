using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Cardboard : MonoBehaviour
{
    public bool _isVR;

    private void Start()
    {
        StartCoroutine(ChangeGameMode(_isVR));
    }
    IEnumerator ChangeGameMode(bool value)
    {
        if(value)
            XRSettings.LoadDeviceByName("cardboard");
        else
            XRSettings.LoadDeviceByName("none");

        yield return null;

        XRSettings.enabled = value;
    }
}