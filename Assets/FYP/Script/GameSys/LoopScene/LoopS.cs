using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LoopS : LoopScene
{  
    public GameObject nextScenePrefab;
    public int nextSpawnPoint = 20;
    public Vector3 spawnPoint;
    GameObject[] _allScene;


    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("==========test==========");
        if (other.tag == "Player")
        {
            spawnPoint = gameObject.transform.parent.parent.position;
            //Debug.Log(gameObject.transform.parent.parent);

            _allScene = GameObject.FindGameObjectsWithTag("Scene");
            spawnPoint.y += nextSpawnPoint;

            if (VSPosition())
            {
                
                GameObject sceneOBJ = Instantiate(nextScenePrefab, spawnPoint, Quaternion.identity);
                //sceneCount.Enqueue(sceneOBJ_UP);
                //gameObject.SetActive(false);
                //Debug.Log("spawnPoint: " + sceneOBJ.transform.position + " Scene name: " + sceneOBJ.name);

            }

            spawnPoint.y -= nextSpawnPoint + nextSpawnPoint;
            
            if (VSPosition())
            {
                GameObject sceneOBJ = Instantiate(nextScenePrefab, spawnPoint, Quaternion.identity);
                //sceneCount.Enqueue(sceneOBJ_UP);
                //gameObject.SetActive(false);
                //Debug.Log("spawnPoint: " + sceneOBJ.transform.position + " Scene name: " + sceneOBJ.name);

            }





            //if (sceneCount.Count >= 4)
            //{
            //    Destroy(sceneCount.Dequeue());
            //    Destroy(sceneCount.Dequeue());
            //}


            //Debug.Log(sceneCount.Dequeue());


            //Debug.Log(sceneCount.Peek());
            //_sceneCount++;

            //Debug.Log(_sceneCount);


        }
    }

    public bool VSPosition()
    {
        bool cheakSceneUP = true;
        //Debug.Log("_allScene.Length: " + _allScene.Length);

        for (int i = 0; i < _allScene.Length; i++)
        {
            //Debug.Log(i + ": " +  _allScene[i].name + " position: " + _allScene[i].transform.position + " spawnPoint: " + spawnPoint.y);
            if (_allScene[i].transform.position.y == spawnPoint.y)
            {
                //Debug.Log("y");
                cheakSceneUP = false;
            }
        }
        return cheakSceneUP;
    }
}
