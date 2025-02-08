using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

public class LevelLoader_effect : MonoBehaviour
{
    public float transitionTime = 1f;
    public Animator transition;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            LoadNextlevel();
        }
    }

    public void LoadNextlevel()
    {
        StartCoroutine(LoadLevel(1));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);



    }
}
