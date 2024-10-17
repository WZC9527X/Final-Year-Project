using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RayDetection : MonoBehaviour
{
    Panel Panel = new Panel();
    public GameObject eKey;

    void Start()
    {
        
    }

    public void Update()
    {
        

        
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        Debug.DrawRay(ray.origin, Vector3.forward * 100f, Color.red);

        // check ray collision
        if (Physics.Raycast(ray, out hit, 100))
        {
            GameObject hitOJ = hit.transform.gameObject;
            //print(hit.transform.gameObject.name);
            Debug.DrawRay(ray.origin, hit.transform.position, Color.red);

            //准星選取物體
            //Debug.Log("當前准星選取物體:" + hit.transform.gameObject.name);

            Panel.displayOJ = (hitOJ.name);

            
            itemPickup(hitOJ);

        }
    }


    public void itemPickup(GameObject item)
    {
        if (item.tag == "item")
        {
            eKey.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
            //    print(item.tag);
                Destroy(item);
            }

        }
        else
        {
            eKey.SetActive(false);

        }
    }

    
}
