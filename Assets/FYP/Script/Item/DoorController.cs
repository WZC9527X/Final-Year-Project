using UnityEngine;

public class DoorController : MonoBehaviour
{
    private bool isDoorOpened = false;
    private bool firstTimeOpening = true;
    public Animator doorAnimator;

    public void Interact(PlayerInventory playerInventory)
    {
        bool isHoldingKey = playerInventory.inventoryList.Count > 0 && playerInventory.inventoryList[playerInventory.selectedItem] == itemType.Key;

        if (!isDoorOpened)
        {
            if (firstTimeOpening)
            {
                if (isHoldingKey)
                {
                    doorAnimator.SetBool("open-close", true);
                    isDoorOpened = true;
                    firstTimeOpening = false;
                }
            }
            else
            {
                doorAnimator.SetBool("open-close", true);
                isDoorOpened = true;
            }
        }
        else
        {
            doorAnimator.SetBool("open-close", false);
            isDoorOpened = false;
        }
    }
}