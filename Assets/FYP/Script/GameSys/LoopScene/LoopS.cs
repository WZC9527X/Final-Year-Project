using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LoopS : LoopScene
{  
    public GameObject nextScenePrefab;
    public int nextSpawnPoint = 20;
    public Vector3 spawnPoint;
    public float[] _vPosition;

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            spawnPoint = gameObject.transform.parent.parent.position;
            //Debug.Log(gameObject.transform.parent.parent);

            GameObject[] _allScene = GameObject.FindGameObjectsWithTag("Scene");

            _vPosition = new float[_allScene.Length];

            for (int i = 0; i < _allScene.Length; i++)
            {
                //Debug.Log(_allScene[i]);
                //Debug.Log(_allScene.Length);
                //Debug.Log(i);
                _vPosition[i] = _allScene[i].transform.position.y;
            }

            spawnPoint.y += nextSpawnPoint;

            if (VSPosition())
            {
                
                GameObject sceneOBJ_UP = Instantiate(nextScenePrefab, spawnPoint, Quaternion.identity);
                //sceneCount.Enqueue(sceneOBJ_UP);
                //gameObject.SetActive(false);

            }

            spawnPoint.y -= nextSpawnPoint + nextSpawnPoint;
            
            if (VSPosition())
            {

                GameObject sceneOBJ_UP = Instantiate(nextScenePrefab, spawnPoint, Quaternion.identity);
                //sceneCount.Enqueue(sceneOBJ_UP);
                //gameObject.SetActive(false);
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
        for (int i = 0; i < _vPosition.Length - 1; i++)
        {
            if (_vPosition[i] == spawnPoint.y)
            {
                cheakSceneUP = false;
            }
        }
        return cheakSceneUP;
    }
}
