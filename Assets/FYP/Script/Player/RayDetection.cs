using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RayDetection : MonoBehaviour
{
    

    public void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        Debug.DrawRay(ray.origin, Vector3.forward * 10f, Color.red);

        // check ray collision
        if (Physics.Raycast(ray, out hit, 10))
        {
            GameObject hitOJ = hit.transform.gameObject;
            //print(hit.transform.gameObject.name);
            Debug.DrawRay(ray.origin, hit.transform.position, Color.red);

            //Debug.Log(hit.transform.gameObject);
            //Debug.Log(hit.transform.gameObject.name);
            
            
            SelectOJPanel.selectOBJ = hit.transform.gameObject;

            

        }
        else
        {
            //hit no collisions
        /*    if(hit.collider == null)
            {
               
            }
        */
            SelectOJPanel.selectOBJ = null;
        }
    }   
}
