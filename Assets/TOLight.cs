using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TOLight : MonoBehaviour
{
    public bool AwakeLight = false;
    public GameObject[] _SelectLight;
    
    private void Start()
    {
        for (int i = 0; i < _SelectLight.Length; i++)
        {
            _SelectLight[i].SetActive(AwakeLight);
        }
    }
    public void ControlLight()
    {
        for (int i = 0; i < _SelectLight.Length; i++)
        {
            if (_SelectLight[i].activeSelf)
            {
                _SelectLight[i].SetActive(false);
            }
            else
            {
                _SelectLight[i].SetActive(true);
            }
        }
    }
}
