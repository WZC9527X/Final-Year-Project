using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    int randomScene;
    int sceneCount;
    GameManager mouseControl = new GameManager();

    private void Start()
    {
/*
        sceneCount = SceneManager.sceneCount;
        //display sceneNumber
        Debug.Log("sceneCount=" + sceneCount);
*/

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "SphereWin")
        {
            SceneManager.LoadScene("Win");

        }else if (other.gameObject.name == "SphereLose")
        {
            SceneManager.LoadScene("Lose");

        }else if (other.gameObject.name == "RandomScene")
        {
     
            SceneManager.LoadScene(RandomNunber());
        }

       // mouseControl.MouseControl(true);

    }

 
    private int RandomNunber()
    {
        do
        {
            randomScene = Random.Range(0, 4);
            Debug.Log("randomScene =" + randomScene);

        } while (randomScene == sceneCount);

        return (randomScene);
    }
      
     
   
          
     
        
    


}
