using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TOLight : MonoBehaviour
{
    public GameObject[] _SelectLight;
    public static bool _TOLight;

    private void Update()
    {
        for (int i = 0; i < _SelectLight.Length; i++)
        {
            _SelectLight[i].SetActive(_TOLight);
        }
        
        

    }
}
