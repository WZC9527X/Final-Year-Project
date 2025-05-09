using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoaderEffect : MonoBehaviour
{
    public GameObject _LevelLoaderCanvas;

    Animator transition;
    CanvasGroup _CanvasGroup;
    public static Animator _transition;

    public bool _EnableLevelLoaderEffect = false;


    private void Start()
    {
        transition = _LevelLoaderCanvas.GetComponent<Animator>();
        _CanvasGroup = _LevelLoaderCanvas.GetComponent<CanvasGroup>();

        _transition = transition;

        if (_EnableLevelLoaderEffect)
        {
            _CanvasGroup.alpha = 1f;
        }
        else
        {
            _CanvasGroup.alpha = 0f;
        }
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
