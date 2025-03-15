using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class SettingPanel : GameManager
{
    public GameObject settingpPanel;
    private CanvasGroup canvasGroup;
    

    void Start()
    {
        canvasGroup = this.GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0f;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            settingPanel();
        }
    }


    public void settingPanel()
    {

        if (!settingpPanel.activeSelf)
        {
            settingpPanel.SetActive(true);
            canvasGroup.alpha = 0f;
            LeanTween.alphaCanvas(canvasGroup, 1f, 0.5f).setEaseInCubic();
            MouseControl(true);
        }
        else
        {
            LeanTween.alphaCanvas(canvasGroup, 0f, 0.5f).setEaseOutCubic().setOnComplete(
                () =>
                {
                    settingpPanel.SetActive(false);
                }

            );
            MouseControl(false);
            

        }
        
    }
}
