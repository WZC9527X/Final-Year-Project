using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            gameObject.GetComponent<AudioSource>().Play();
        }
    }
}
