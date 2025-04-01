using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckScene : MonoBehaviour
{
    private static GameObject[] _allScene;
    

    public bool VSPosition(float spawnPoint)
    {

        bool _cheakScene = true;
        //Debug.Log("_allScene.Length: " + _allScene.Length);
        _allScene = GameObject.FindGameObjectsWithTag("Scene");

        for (int i = 0; i < _allScene.Length; i++)
        {
            //Debug.Log(i + ": " +  _allScene[i].name + " position: " + _allScene[i].transform.position + " spawnPoint: " + spawnPoint.y);
            if (_allScene[i].transform.position.y == spawnPoint)
            {
                //if ((LoopS.sceneOBJ1[i] != null) && (LoopS.sceneOBJ2[i] != null))
                //{

                //    Destroy(LoopS.sceneOBJ1[i]);
                //    Destroy(LoopS.sceneOBJ2[i]);

                //}

                Destroy(_allScene[i]);
                //Debug.Log("y");
                //_cheakScene = false;
            }

        }

        return _cheakScene;
    }
}
