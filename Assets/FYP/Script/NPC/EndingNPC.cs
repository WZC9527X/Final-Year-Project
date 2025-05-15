using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndingNPC : MonoBehaviour
{
    
    public AudioSource toBeContinuedAudio;

    public GameObject ThePlayer;
    public GameObject Cam;
    public Image blackImage;
    public GameObject toBeContinuedImage;
    private bool hasShowed = false;
    private Animation toBeContinuedAnimation;

    void Start()
    {
        if (blackImage != null)
        {
            blackImage.color = new Color(0, 0, 0, 0);
        }

        toBeContinuedAnimation = toBeContinuedImage.GetComponent<Animation>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (!hasShowed)
        {
            hasShowed = true;
            
            toBeContinuedAudio.Play();
            ThePlayer.SetActive(false);
            Cam.SetActive(true);
            StartCoroutine(EndShow());
        }
    }

    IEnumerator EndShow()
    {
        yield return new WaitForSeconds(2.5f);
        yield return StartCoroutine(FadeToBlack());

        toBeContinuedImage.SetActive(true);
        toBeContinuedAnimation.Play();
        yield return new WaitForSeconds(7f);

        SceneManager.LoadScene("Demo-Start");
    }

    IEnumerator FadeToBlack()
    {
        float duration = 1f;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            blackImage.color = new Color(0, 0, 0, Mathf.Clamp01(elapsed / duration));
            yield return null;
        }
    }
}