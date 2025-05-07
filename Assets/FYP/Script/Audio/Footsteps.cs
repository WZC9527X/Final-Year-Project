using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    public AudioSource walking, running;
    public Transform rayStart;
    public float range;
    public LayerMask layerMask;

    RaycastHit hit;

    void Update()
    {
        bool isMoving = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D);

        if (isMoving)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                walking.enabled = false;
                running.enabled = true;
                PlayFootstepSound(running);
            }
            else
            {
                running.enabled = false;
                walking.enabled = true;
                PlayFootstepSound(walking);
            }
        }
        else
        {
            walking.enabled = false;
            running.enabled = false;
        }
    }

    void PlayFootstepSound(AudioSource source)
    {
        if (Physics.Raycast(rayStart.position, Vector3.down, out hit, range, layerMask))
        {
            if (hit.collider.CompareTag("concrete"))
            {
                source.Play();
            }
        }
    }

    private void Check()
    {
        Debug.DrawRay(rayStart.position, Vector3.down * range, Color.green);
    }
}