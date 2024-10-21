using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class SettingPanel : MonoBehaviour
{
    public GameObject settingpPanel;
    private CanvasGroup canvasGroup;
    GameManager mouseControl = new GameManager();

    void Start()
    {
        canvasGroup = this.GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0f;
    }


    void Update()
    {
        settingPanel();
    }


    void settingPanel()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            
            if (!settingpPanel.activeSelf)
            {
                settingpPanel.SetActive(true);
                canvasGroup.alpha = 0f;
                LeanTween.alphaCanvas(canvasGroup, 1f, 0.5f).setEaseInCubic();
                mouseControl.MouseControl(true);
            }
            else
            {
                LeanTween.alphaCanvas(canvasGroup, 0f, 0.5f).setEaseOutCubic().setOnComplete(
                    () =>
                    {
                        settingpPanel.SetActive(false);
                    }

                );
                mouseControl.MouseControl(false);

            }

        }
    }
}
