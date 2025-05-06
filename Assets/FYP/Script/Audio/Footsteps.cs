using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
public AudioSource Walking , Running;

void Update()
{

    if(Input.GetKey(KeyCode.W)||Input.GetKey(KeyCode.A)||Input.GetKey(KeyCode.S)||Input.GetKey(KeyCode.D))
    {
        Walking.enabled = true;

        if(Input.GetKey(KeyCode.LeftShift))
        {
            Walking.enabled = false;
            Running.enabled = true;
        }
        else
        {
            Running.enabled = false;
        }
    }
    else
    {
        Walking.enabled = false;
        Running.enabled = false;
    }

}
}