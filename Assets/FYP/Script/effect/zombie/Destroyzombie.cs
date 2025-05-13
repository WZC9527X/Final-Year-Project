using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Girlscout T Masuyama")
        {

            Destroy(other.gameObject);
        }
    }
}