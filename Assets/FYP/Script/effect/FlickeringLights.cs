using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class FlickeringLights : MonoBehaviour
{
    public float max;
    public float min;
    float timer;

    private void Start()
    {
        timer = Random.Range(min, max);
    }
    void Update()
    {
        flickeringLights();
        //Debug.Log(transform.GetChild(0).gameObject);
    }

    void flickeringLights()
    {
        
        if (timer > 0)
        {
            
            timer -= Time.deltaTime;
        }

        if(timer <= 0)
        {
            timer = Random.Range(min, max);
            //Debug.Log(transform.GetChild(0));

            if (transform.GetChild(0).gameObject.activeSelf)
            {
                for (int i = 0; i < transform.childCount; i++)
                {
                    var child = transform.GetChild(i);
                    child.gameObject.SetActive(false);
                }
            }
            else
            {
                for (int i = 0; i < transform.childCount; i++)
                {
                    var child = transform.GetChild(i);
                    child.gameObject.SetActive(true);
                }
            }
        }


    }
}
