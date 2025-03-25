using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoaderEffect : MonoBehaviour
{
    public Animator transition;
    public static Animator _transition;

    private void Awake()
    {
        _transition = transition;
    }


    public static IEnumerator LoadLevel(int levelIndex)
    {
        _transition.SetTrigger("LevelLoader_Start");
        yield return new WaitForSeconds(1.5f);

        // <------add loading log


        //transition.SetTrigger("LevelLoader_End");
        SceneManager.LoadScene(levelIndex);

        //yield return new WaitForSeconds(1);

    }
}
