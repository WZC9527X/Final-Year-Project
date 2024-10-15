using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CanvasGroup))]
public  class Panel : MonoBehaviour
{
    GameManager mouseControl = new GameManager();

    public GameObject panel;
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

            if (!panel.activeSelf) 
            {
                panel.SetActive(true);
                canvasGroup.alpha = 0f;
                LeanTween.alphaCanvas(canvasGroup, 1f, 0.5f).setEaseInCubic();
             //   mouseControl.MouseControl(false);
            }
            else
            {
                LeanTween.alphaCanvas(canvasGroup, 0f, 0.5f).setEaseOutCubic().setOnComplete(
                    () =>
                    {
                        panel.SetActive(false);
                    }

                );
              //  mouseControl.MouseControl(true);

            }





        }

    }



}
