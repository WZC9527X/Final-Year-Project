using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCFootsteps : MonoBehaviour
{
    //public AudioSource Steps;
    //public GameObject ThePlayer;
    public GameObject Girl;
    public PlayerInventory playerInventory; // 引用玩家的物品清單
    private bool hasShowed = false;

    void OnTriggerEnter(Collider other)
    {
        if (!hasShowed)
        {
            // 檢查玩家的物品清單中是否包含鎖匙
            if (playerInventory.inventoryList.Contains(itemType.Key))
            {
                hasShowed = true;
                Girl.SetActive(true);
                StartCoroutine(EndShow());
            }
        }
    }

    IEnumerator EndShow()
    {
        yield return new WaitForSeconds(0.5f);
        Girl.SetActive(false);
    }
}