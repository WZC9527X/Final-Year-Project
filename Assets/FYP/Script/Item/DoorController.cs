using UnityEngine;
using System.Collections;

public class DoorController : MonoBehaviour
{
    private bool isDoorOpened = false;
    private bool firstTimeOpening = true;
    public Animator doorAnimator;
    public bool requiresKey = false;
    public string doorID;
    public GameObject keyPrompt;

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
                    HidePrompt();
                }
                else
                {
                    StartCoroutine(ShowPromptForDuration(2f));
                }
            }
            else
            {
                OpenDoor(playerInventory);
                HidePrompt();
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
            SelectOJPanel.selectOBJ.GetComponent<TOLight>().ControlLight(true);
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
            SelectOJPanel.selectOBJ.GetComponent<TOLight>().ControlLight(false);
            AudioSystem.Instance.PlaySound("LightSwitch");
        }

        doorAnimator.SetBool("open-close", false);
        isDoorOpened = false;
    }

    private void ShowPrompt()
    {
        if (keyPrompt != null)
        {
            keyPrompt.SetActive(true);
        }
    }

    private void HidePrompt()
    {
        if (keyPrompt != null)
        {
            keyPrompt.SetActive(false);
        }
    }

    private IEnumerator ShowPromptForDuration(float duration)
    {
        ShowPrompt();
        yield return new WaitForSeconds(duration);
        HidePrompt();
    }
}