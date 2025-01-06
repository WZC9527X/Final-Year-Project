using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using TMPro;
using UnityEngine;

public class SelectOJPanel : MonoBehaviour
{
    public GameObject eKey;
    public TextMeshProUGUI selectOBJText;
    public static GameObject selectOBJ;

    public Animator door;
    public bool openClose;
    private void Start()
    {
    }

    void Update()
    {

        


        // itemPickup();
        DisplayOJ();
        SelectOBJ();
    }

    void SelectOBJ()
    {
       
        if (selectOBJ != null)
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
            else if (selectOBJ.tag == "blood")
            {
                /*
                var spriteRenderer = selectOBJ.GetComponent<SpriteRenderer>();

                Color color = spriteRenderer.color;
                color.a = color.a - 0.25f;
                spriteRenderer.color = color;
                */
                eKey.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    print(selectOBJ);
                    Destroy(selectOBJ);
                }
            }
            else if (selectOBJ.tag == "door")
            {
                door = selectOBJ.GetComponent<Animator>();

                openClose = door.GetBool("open-close");

                eKey.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (openClose)
                    {
                        door.SetBool("open-close", false);
                        

                    }
                    else
                    {
                        door.SetBool("open-close", true);
                    }

                }
            }
            else
            {
                eKey.SetActive(false);

            }
        }
        else
        {
            eKey.SetActive(false);
        }


            
        
       // print(selectOBJ.name);


    }

    void DisplayOJ()
    {
        if(selectOBJ != null)
        {
            selectOBJText.text = selectOBJ.name;
            
        }
        else
        {
            selectOBJText.text = "";
        }
        
    }

}
