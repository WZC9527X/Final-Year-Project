using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayDetection : MonoBehaviour
{

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            Debug.DrawRay(ray.origin, Vector3.forward * 100f, Color.red);

            // check ray collision
            if (Physics.Raycast(ray, out hit, 100))
            {
                //print(hit.transform.gameObject.name);
                Debug.DrawRay(ray.origin, hit.transform.position, Color.red);

                //准星選取物體
                Debug.Log("當前准星選取物體:" + hit.transform.gameObject.name);


                // Destroy(hit.transform.gameObject);
            }
        }





    }
}
