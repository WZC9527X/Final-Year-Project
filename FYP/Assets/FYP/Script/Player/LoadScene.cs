using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    int randomScene;
    int sceneCount;
    GameManager mouseControl = new GameManager();

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

    public void setting()
    {
        
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Level_1()
    {
        SceneManager.LoadScene(1);
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
        SceneManager.LoadScene("Lose");
    }

    public void Win_Scene()
    {
        SceneManager.LoadScene("Win");
    }

    public void RandomScene()
    {
        SceneManager.LoadScene(RandomNunber());
    }
}
