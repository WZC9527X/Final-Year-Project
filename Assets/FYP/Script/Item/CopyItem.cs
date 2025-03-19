using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyItem : MonoBehaviour
{
    public GameObject[] Toilet;
    public Vector3 spawnPosition;
    private bool hasTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!hasTriggered && other.CompareTag("Player"))
        {
            SpawnObject();
            hasTriggered = true;
            GetComponent<Collider>().enabled = false;
        }
    }

    private void SpawnObject()
    {
        int randomIndex = Random.Range(0, Toilet.Length);

        GameObject selectedToilet = Toilet[randomIndex];

        Vector3 position = spawnPosition;
        Quaternion rotation = selectedToilet.transform.rotation;
        
        Instantiate(selectedToilet, position, rotation);
    }
}
