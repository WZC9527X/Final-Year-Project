using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    int randomScene;
    int sceneCount;
    GameManager mouseControl = new GameManager();
    public float transitionTime = 1f;
    public Animator transition;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "SphereWin")
        {
            Win_Scene();

        }
        if (other.gameObject.name == "SphereLose")
        {
            Lose_Scene();

        }
        if (other.gameObject.name == "RandomScene")
        {
            RandomScene();
            
        }

       // mouseControl.MouseControl(true);

    }

 
    private int RandomNunber()
    {
        sceneCount = SceneManager.sceneCount;
        //display sceneNumber
        //Debug.Log("sceneCount=" + sceneCount);
        do
        {
            randomScene = Random.Range(0, 4);
            //Debug.Log("randomScene =" + randomScene);

        } while (randomScene == sceneCount);

        return (randomScene);
    }

    public void StartGameScenes()
    {
        StartCoroutine(LoadLevel(0));
    }

    public void RestartGame()
    {
        int scene = SceneManager.GetActiveScene().buildIndex;
        StartCoroutine(LoadLevel(scene));
    }

    public void setting()
    {
        
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Level_1()
    {
        StartCoroutine(LoadLevel(1));


    }


    /*
    public void Level_2()
    {
        SceneManager.LoadScene(2);
    }

    public void Level_3()
    {
        SceneManager.LoadScene(2);
    }
    */

    public void Lose_Scene()
    {
        
        StartCoroutine(LoadLevel(2));
    }

    public void Win_Scene()
    {
        StartCoroutine(LoadLevel(3));
        
    }

    public void RandomScene()
    {
        StartCoroutine(LoadLevel(RandomNunber())); 
        
    }



    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("LevelLoader_Start");
        yield return new WaitForSeconds(1.5f);
        
        // <------add loading log
        

        //transition.SetTrigger("LevelLoader_End");
        SceneManager.LoadScene(levelIndex);

        //yield return new WaitForSeconds(1);

    }
    


}
