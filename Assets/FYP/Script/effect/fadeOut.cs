using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

public class fadeOut : MonoBehaviour
{
    
    public Volume _ppv;
    public float fadeInOut_Speed = 1f;

    Vignette v_vignette;
    float s_value = 0f;

    private void Start()
    {
        _ppv.profile.TryGet(out v_vignette);

        v_vignette.smoothness.value = 0.1f;

       
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (v_vignette.smoothness.value >= 0.59f)
            {
                s_value = 0.2f;
            }
            if (v_vignette.smoothness.value <= 0.21f)
            {
                s_value = 0.6f;
            }
            v_vignette.smoothness.value = Mathf.Lerp(v_vignette.smoothness.value, s_value, fadeInOut_Speed * Time.deltaTime);
        }
     
    }

    private void OnTriggerExit(Collider other)
    {
        v_vignette.smoothness.value = 0.01f;
    }
   
}
