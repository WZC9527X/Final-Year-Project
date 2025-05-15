using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class JumpTrigger : MonoBehaviour
{
    public AudioSource Scream;
    public GameObject JumpCam;
    public Image blackScreen;
    private bool hasJumped = false;

    void Start()
    {
        if (blackScreen != null)
        {
            blackScreen.color = new Color(0, 0, 0, 0);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (!hasJumped && other.CompareTag("Player"))
        {
            hasJumped = true;
            Scream.Play();
            JumpCam.SetActive(true);
            other.gameObject.SetActive(false);
            StartCoroutine(EndJump(other.gameObject));
        }
    }

    IEnumerator EndJump(GameObject Player)
    {
        yield return new WaitForSeconds(2.03f);
        JumpCam.SetActive(false);
        Player.SetActive(true);

        yield return StartCoroutine(FadeToBlack());

        SceneManager.LoadScene("End");

        yield return new WaitForSeconds(0.5f);
    }

    IEnumerator FadeToBlack()
    {
        float duration = 1f;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            blackScreen.color = new Color(0, 0, 0, Mathf.Clamp01(elapsed / duration));
            yield return null;
        }
    }
}