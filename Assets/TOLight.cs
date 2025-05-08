using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TOLight : MonoBehaviour
{
    public GameObject[] _SelectLight;
    private void Start()
    {
        for (int i = 0; i < _SelectLight.Length; i++)
        {
            _SelectLight[i].SetActive(false);
        }
    }
    public void ControlLight(bool _TOLight)
    {
        for (int i = 0; i < _SelectLight.Length; i++)
        {
            _SelectLight[i].SetActive(_TOLight);
        }
    }
}
