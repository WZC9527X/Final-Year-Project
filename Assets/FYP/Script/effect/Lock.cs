using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour
{
    private bool PlayerLock = false;
    private PlayerMovement PlayerMovement;

    void OnTriggerEnter(Collider other)
    {
        if (!PlayerLock && other.CompareTag("Player"))
        {
            PlayerMovement = other.GetComponent<PlayerMovement>();
            if (PlayerMovement != null)
            {
                StartCoroutine(DisablePlayerControls());
            }
        }
    }

    private IEnumerator DisablePlayerControls()
    {
        PlayerLock = true;
        PlayerMovement.DisableMovement();
        PlayerMovement.LockCamera();

        yield return new WaitForSeconds(3);

        PlayerMovement.EnableMovement();
        PlayerMovement.UnlockCamera();
        //PlayerLock = false;
    }
}
