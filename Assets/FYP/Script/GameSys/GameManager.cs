using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool hideMouse;

    public static GameManager Instance = null;
    public Volume _Volume;

    void Start()
    {
        if (hideMouse)
        {
            MouseControl(false);
        }
        else
        {
            MouseControl(true);
        }

        StartCoroutine(_setVolume(0.1f));
        Debug.Log("next Level: " + LoopScene._LevelCount);
    }

    void Update()
    {
       

        
    }

    public void MouseControl(bool YN)
    {
        if (YN)
        {
            
            //Display Mouse
            //MouseControl(true);
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;

        }
        else
        {
            //Hide Mouse
            //MouseControl(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }


    }


    public IEnumerator _setVolume(float time)
    {
        _Volume.weight = 0f;
        yield return new WaitForSeconds(time);
        _Volume.weight = 1f;
    }



}
