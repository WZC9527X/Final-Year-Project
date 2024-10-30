using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SelectOJPanel : MonoBehaviour
{
    public GameObject eKey;
    public TextMeshProUGUI selectOBJText;
    public static GameObject selectOBJ;

    void Update()
    {
   
           // itemPickup();
        DisplayOJ();
        
    }

    void itemPickup()
    {
        if (selectOBJ.tag == "item")
        {
            eKey.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                //    print(item.tag);
                Destroy(selectOBJ);
            }

        }
        else
        {
            eKey.SetActive(false);

        }
    }

    void DisplayOJ()
    {
        if(selectOBJ != null)
        {
            selectOBJText.text = selectOBJ.name;
            itemPickup();
        }
        else
        {
            selectOBJText.text = "";
        }
        
    }

}
