using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCFootsteps : MonoBehaviour
{
    public AudioSource Steps;
    public GameObject ThePlayer;
    public GameObject Cam;
    public PlayerInventory playerInventory;
    private bool hasShowed = false;

    void Update()
    {
        if (!hasShowed)
        {
            if (playerInventory.inventoryList.Contains(itemType.Key))
            {
                StartCoroutine(StartShow());
            }
        }
    }

    IEnumerator StartShow()
    {
        yield return new WaitForSeconds(1f);
        hasShowed = true;
        Steps.Play();
        yield return new WaitForSeconds(1f);
        ThePlayer.SetActive(false);
        Cam.SetActive(true);
        StartCoroutine(EndShow());
    }
    IEnumerator EndShow()
    {
        yield return new WaitForSeconds(2.5f);
        hasShowed = true;
        Steps.Stop();
        ThePlayer.SetActive(true);
        Cam.SetActive(false);
    }
}