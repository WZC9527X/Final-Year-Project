using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using TMPro;
using UnityEngine;

public class SelectOJPanel : MonoBehaviour
{
    public PlayerInventory playerInventory;
    public GameObject eKey;
    //public GameObject AirwallText;
    public TextMeshProUGUI selectOBJText;
    public static GameObject selectOBJ;

    public static int cleanBlood;

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
                bool isHoldingMop = playerInventory.inventoryList.Count > 0 && playerInventory.inventoryList[playerInventory.selectedItem] == itemType.Mop;

                if (isHoldingMop)
                {
                    eKey.SetActive(true);

                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        cleanBlood += 1;
                        print(selectOBJ);
                        Destroy(selectOBJ);
                    }
                }
                else
                {
                    eKey.SetActive(false);
                }
            }
            else if (selectOBJ.tag == "door")
            {
                if (selectOBJ.GetComponent<isLock>() != null)
                {
                    if(playerInventory.inventoryList.Count > 0 && playerInventory.inventoryList[playerInventory.selectedItem] == itemType.Key)
                    {
                        openDoor();
                    }
                    else
                    {
                        eKey.SetActive(false);
                    }
                    //Detecting the presence of a key?
                    //if (key)
                    //{
                    //    openDoor();
                    //}
                    
                }
                else
                {
                    openDoor();
                }

            }
            else
            {
                eKey.SetActive(false);

            }
            //if (selectOBJ.tag == "Airwall")
            //{
            //    AirwallText.SetActive(true);
            //}
            //else
            //{
            //    AirwallText.SetActive(false);

            //}
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

    void openDoor()
    {
        Animator door = selectOBJ.GetComponent<Animator>();
        bool openClose = door.GetBool("open-close");

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
}
