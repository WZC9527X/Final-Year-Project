using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class fadeOut : MonoBehaviour
{

    public PostProcessVolume _ppv;

    Vignette v_vignette;
    public float s_value = 0f;

    private void Start()
    {
        _ppv.profile.TryGetSettings(out v_vignette);

        v_vignette.smoothness.value = 0.2f;

        
    }

    
    void Update()
    {
        if(v_vignette.smoothness.value >= 0.59f)
        {
            s_value = 0.2f;
        }
        if (v_vignette.smoothness.value <= 0.21f)
        {
            s_value = 0.6f;
        }
            
        v_vignette.smoothness.value = Mathf.Lerp(v_vignette.smoothness.value, s_value, 2f * Time.deltaTime);

    }
}
