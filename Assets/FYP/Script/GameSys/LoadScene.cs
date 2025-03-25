using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    int randomScene;
    int sceneCount;

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

        StartCoroutine(LevelLoaderEffect.LoadLevel(0));

    }

    public void RestartGame()
    {
        int scene = SceneManager.GetActiveScene().buildIndex;
        StartCoroutine(LevelLoaderEffect.LoadLevel(scene));

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
        StartCoroutine(LevelLoaderEffect.LoadLevel(1));
     

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
        
        StartCoroutine(LevelLoaderEffect.LoadLevel(2));
    }

    public void Win_Scene()
    {
        StartCoroutine(LevelLoaderEffect.LoadLevel(3));
    }

    public void RandomScene()
    {
        StartCoroutine(LevelLoaderEffect.LoadLevel(RandomNunber()));
    }
    
}
