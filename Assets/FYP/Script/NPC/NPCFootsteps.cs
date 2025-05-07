using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCFootsteps : MonoBehaviour
{
    public AudioSource Steps;
    public GameObject ThePlayer;
    //public GameObject Girl;
    public GameObject Cam;
    public PlayerInventory playerInventory; // 引用玩家的物品清單
    private bool hasShowed = false;

    void Update()
    {
        if (!hasShowed)
        {
            // 檢查玩家的物品清單中是否包含鎖匙
            if (playerInventory.inventoryList.Contains(itemType.Key))
            {
                StartCoroutine(StartShow());
            }
        }
    }

    IEnumerator StartShow()
    {
        yield return new WaitForSeconds(1f);
        hasShowed = true;
        Steps.Play();
        yield return new WaitForSeconds(1f); // 添加小延迟
        ThePlayer.SetActive(false);
        Cam.SetActive(true);
        StartCoroutine(EndShow());
    }
    IEnumerator EndShow()
    {
        yield return new WaitForSeconds(2.5f);
        Steps.Stop();
        ThePlayer.SetActive(true);
        Cam.SetActive(false);
        //Girl.SetActive(false);
    }
}