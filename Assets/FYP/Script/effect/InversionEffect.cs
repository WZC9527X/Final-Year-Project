using System.Collections;
using UnityEngine;

public class InversionEffect : MonoBehaviour
{
    //public Volume _ppv;
    public GameObject playerCameraParent;
    //Vignette v_vignette;
    public Animator winking;
    private Vector3 currentEuler;

    private void Start()
    {
        //_ppv.profile.TryGet(out v_vignette);

        //v_vignette.intensity.value = 0f;
        //v_vignette.smoothness.value = 0.1f;
        //v_vignette.roundness.value = 1f;
    
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            StartCoroutine(WinkingEffect());

        }
    }

    IEnumerator WinkingEffect()
    {
        
        winking.SetTrigger("winkingTrigger");
        yield return new WaitForSeconds(0.10f);

        //Rotation player Camera
        currentEuler = playerCameraParent.transform.eulerAngles;
        currentEuler.z = 180f;
        playerCameraParent.transform.eulerAngles = currentEuler;

        yield return new WaitForSeconds(2f);

        //winking reinstate
        //winking.SetTrigger("winkingTrigger");
        //yield return new WaitForSeconds(0.10f);

        playerCameraParent.transform.localRotation = Quaternion.identity;

        //Debug.Log(winking.transform.gameObject);
        winking.transform.gameObject.SetActive(false);
        gameObject.SetActive(false);
    }



}
