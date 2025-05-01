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
        doorAnimator.SetBool("open-close", true);
        isDoorOpened = true;
        firstTimeOpening = false;

        if (playerInventory.inventoryList.Count > 0 && requiresKey)
        {
            playerInventory.inventoryList.RemoveAt(playerInventory.selectedItem);
            playerInventory.selectedItem = 0;
        }
    }

    private void CloseDoor()
    {
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