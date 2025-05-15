using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpTrigger : MonoBehaviour
{
    public AudioSource Scream;
    public GameObject JumpCam;
    private bool hasJumped = false;

    void OnTriggerEnter(Collider other)
    {
        // 檢查進入觸發的物件是否是玩家
        if (!hasJumped && other.CompareTag("Player") && LoopScene.cleanBlood >= 3)
        {
            hasJumped = true;
            Scream.Play();
            JumpCam.SetActive(true);
            other.gameObject.SetActive(false); // 將玩家物件禁用
            StartCoroutine(EndJump(other.gameObject)); // 傳遞玩家物件
        }
    }

    IEnumerator EndJump(GameObject Player)
    {
        yield return new WaitForSeconds(2.03f);
        Player.SetActive(true); // 恢復玩家物件
        JumpCam.SetActive(false);
    }
}