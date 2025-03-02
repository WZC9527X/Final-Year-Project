using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopScene : MonoBehaviour
{
    public GameObject nextScenePrefab;
    public int nextSpawnPoint = 20;
    
    private Vector3 spawnPoint;

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            //Debug.Log(gameObject.transform.parent.parent);

            spawnPoint = gameObject.transform.parent.parent.position;
            spawnPoint.y += nextSpawnPoint;
            Instantiate(nextScenePrefab, spawnPoint, Quaternion.identity);
            

        }

        
    }

}