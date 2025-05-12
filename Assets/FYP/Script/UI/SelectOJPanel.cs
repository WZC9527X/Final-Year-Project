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
    public GameObject _FlashLight;
    public GameObject _FlashLightText;

    void Update()
    {
        // itemPickup();
        DisplayOJ();
        SelectOBJ();
    }

    void SelectOBJ()
    {
        //Debug.Log(selectOBJ);
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
            else if (selectOBJ.GetComponent<DoorController>() != null )
            {
                eKey.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    selectOBJ.GetComponent<DoorController>().Interact(playerInventory);
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
       if (playerInventory.inventoryList.Count > 0 && playerInventory.inventoryList[playerInventory.selectedItem] == itemType.flashlights)
       {
            if (_FlashLight.activeSelf)
            {
                _FlashLightText.SetActive(false);
                if (Input.GetKeyDown(KeyCode.F))
                {
                    _FlashLight.SetActive(false);
                }

            }
            else
            {
                _FlashLightText.SetActive(true);

                if (Input.GetKeyDown(KeyCode.F))
                {
                    _FlashLight.SetActive(true);
                }  
            }
       }else
       {
            _FlashLight.SetActive(false);
            _FlashLightText.SetActive(false);
        }

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
