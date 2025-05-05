using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCFootsteps : MonoBehaviour
{
    public AudioSource Steps;
    public GameObject ThePlayer;
    public GameObject CCTV;
    public PlayerInventory playerInventory; // 引用玩家的物品清單
    private bool hasShowed = false;

    void OnTriggerEnter(Collider other)
    {
        if (!hasShowed && other.gameObject == ThePlayer)
        {
            // 檢查玩家是否有鎖匙
            if (playerInventory.inventoryList.Count > 0 &&
                playerInventory.inventoryList[playerInventory.selectedItem] == itemType.Key)
            {
                hasShowed = true;
                CCTV.SetActive(true);
                ThePlayer.SetActive(false);
                StartCoroutine(EndShow());
            }
        }
    }

    IEnumerator EndShow()
    {
        yield return new WaitForSeconds(0.5f);
        ThePlayer.SetActive(true);
        CCTV.SetActive(false);
    }
}