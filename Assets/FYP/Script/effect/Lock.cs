using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lock : MonoBehaviour
{
    private bool PlayerLock = false;
    private PlayerMovement PlayerMovement;
    public Image blackImage;
    public AudioSource audioSource;

    void Start()
    {
        if (blackImage != null)
        {
            blackImage.color = new Color(0, 0, 0, 0);
        }
    }

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
        yield return StartCoroutine(FadeToBlack(1f));
        audioSource.Play();
        //PlayerMovement.LockCamera();

        yield return new WaitForSeconds(7.5f);

        yield return StartCoroutine(FadeToBlack(0f));

        PlayerMovement.EnableMovement();
        //PlayerMovement.UnlockCamera();
        //PlayerLock = false;
    }

    private IEnumerator FadeToBlack(float targetAlpha)
    {
        float duration = 1f;
        float startAlpha = blackImage.color.a;
        float time = 0;

        while (time < duration)
        {
            time += Time.deltaTime;
            float alpha = Mathf.Lerp(startAlpha, targetAlpha, time / duration);
            blackImage.color = new Color(0, 0, 0, alpha);
            yield return null;
        }

        blackImage.color = new Color(0, 0, 0, targetAlpha);
    }
}
