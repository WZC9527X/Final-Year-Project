using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCFootsteps : MonoBehaviour
{
    public AudioSource Steps;
    public GameObject ThePlayer;
    public GameObject Cam;
    private bool hasShowed = false;

    void OnTriggerEnter(Collider other)
    {
        if (!hasShowed)
        {
            StartCoroutine(StartShow());
        }
    }

    IEnumerator StartShow()
    {
        yield return new WaitForSeconds(2f);
        hasShowed = true;
        Steps.Play();
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