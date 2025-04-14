using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

public class DynamicDepthofField : MonoBehaviour
{
    Ray raycast;
    RaycastHit hit;
    bool ishit;
    float hitDistance;

    public Volume _volume;
    DepthOfField doff;

    // Start is called before the first frame update
    void Start()
    {
        _volume.profile.TryGet(out doff);
    }

    // Update is called once per frame
    void Update()
    {
        raycast = new Ray(transform.position, transform.forward * 100);

        ishit = false;

        if (Physics.Raycast(raycast, out hit, 100f))
        {
            ishit = true;
            hitDistance = Vector3.Distance(transform.position, hit.point)/5;
            Debug.Log("Hit");
        }
        else
        {
            if (hitDistance < 100f)
            {
                hitDistance++;
            }
        }
        SetFocus();
    }

    void SetFocus()
    {
        if (hitDistance <= 1.2f)
        {
            hitDistance = 1.3f;
        }
        doff.focusDistance.value = Mathf.Lerp(doff.focusDistance.value, hitDistance, Time.deltaTime * 4f);
        //Debug.Log("hitDistance: " + hitDistance);
        //Debug.Log(doff.focusDistance.value);

    }

    private void OnDrawGizmos()
    {
        
        if (ishit)
        {
            //Debug.Log(hit.point);
            Gizmos.DrawSphere(hit.point, 1f);
            Debug.DrawRay(transform.position, transform.forward * Vector3.Distance(transform.position, hit.point));

        }
        else
        {
            Debug.DrawRay(transform.position, transform.forward * 100f);
        }
    }
}
