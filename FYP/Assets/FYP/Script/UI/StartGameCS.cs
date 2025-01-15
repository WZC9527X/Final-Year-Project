using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StartGameCS : MonoBehaviour
{

    public CanvasGroup _canvasG;
    public Material _material;
    float faceDilate = -1.0f;
    void Start()
    {
        
        _material.SetFloat(ShaderUtilities.ID_FaceDilate, faceDilate);
        _canvasG.alpha = 0f;
        LeanTween.alphaCanvas(_canvasG, 1f, 2f).setEaseOutCubic();

    }


    private void Update()
    {
        if (faceDilate <= -0.1f)
        {
            faceDilate = Mathf.Lerp(faceDilate, 0f, 0.5f * Time.deltaTime);
            _material.SetFloat(ShaderUtilities.ID_FaceDilate, faceDilate);
        }

//        Debug.Log(faceDilate);
        
    }
}
