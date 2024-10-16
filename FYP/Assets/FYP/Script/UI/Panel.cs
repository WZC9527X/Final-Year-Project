using TMPro;
using Unity.VisualScripting;
using UnityEngine;


[RequireComponent(typeof(CanvasGroup))]
public  class Panel : MonoBehaviour
{
    GameManager mouseControl = new GameManager();
   
    
    public static string displayOJ;
    public GameObject panel;
    private CanvasGroup canvasGroup;
    public TextMeshProUGUI selectObject;

    void Start()
    {
        canvasGroup = this.GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0f;
        selectObject.color = Color.yellow;

        
    }

    void Update()
    {
        selectObject.text = displayOJ;
       


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
