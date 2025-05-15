using UnityEngine;
using System.Collections;

public class DoorController : MonoBehaviour
{
    public Animator doorAnimator;

    private bool isDoorOpened = false;
    private bool firstTimeOpening = true;
    public bool requiresKey = true;

    public void Interact(PlayerInventory playerInventory)
    {

        bool isHoldingKey = playerInventory.inventoryList.Count > 0 && playerInventory.inventoryList[playerInventory.selectedItem] == itemType.Key;

        if (!isDoorOpened)
        {
            if (firstTimeOpening && requiresKey)
            {
                if (isHoldingKey)
                {
                    OpenDoor(playerInventory);
                }
                else
                {
                    AudioSystem.Instance.PlaySound("Locked");
                }
            }
            else
            {
                OpenDoor(playerInventory);
            }
        }
        else
        {

            CloseDoor();
        }

    }

    private void OpenDoor(PlayerInventory playerInventory)
    {
        if (SelectOJPanel.selectOBJ.tag == "door")
        {      
            AudioSystem.Instance.PlaySound("OpenDoor");
        }
        else if (SelectOJPanel.selectOBJ.tag == "LightSwitch")
        {
            SelectOJPanel.selectOBJ.GetComponent<TOLight>().ControlLight();
            AudioSystem.Instance.PlaySound("LightSwitch");
        }

        doorAnimator.SetBool("open-close", true);
        isDoorOpened = true;
        firstTimeOpening = false;

        if (requiresKey && playerInventory.inventoryList[playerInventory.selectedItem] == itemType.Key)
        {
            playerInventory.inventoryList.RemoveAt(playerInventory.selectedItem);
            playerInventory.selectedItem = 0;
        }
    }

    private void CloseDoor()
    {
        if (SelectOJPanel.selectOBJ.tag == "door")
        {
            AudioSystem.Instance.PlaySound("CloseDoor");
        }
        else if (SelectOJPanel.selectOBJ.tag == "LightSwitch")
        {
            SelectOJPanel.selectOBJ.GetComponent<TOLight>().ControlLight();
            AudioSystem.Instance.PlaySound("LightSwitch");
        }

        doorAnimator.SetBool("open-close", false);
        isDoorOpened = false;
    }
}