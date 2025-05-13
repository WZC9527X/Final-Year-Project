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
    public float focusSpeed = 1f;
    DepthOfField doff;

    void Start()
    {
        _volume.profile.TryGet(out doff);
    }

    void Update()
    {
        raycast = new Ray(transform.position, transform.forward * 100);

        ishit = false;

        if (Physics.Raycast(raycast, out hit, 100f))
        {
            ishit = true;
            hitDistance = Vector3.Distance(transform.position, hit.point);
            //Debug.Log("Hit");
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
        if (hitDistance >= 5f)
        {
            hitDistance = hitDistance - 2f;
        }
        doff.focusDistance.value = Mathf.Lerp(doff.focusDistance.value, hitDistance, Time.deltaTime * focusSpeed);
        //Debug.Log("hitDistance: " + hitDistance);
        //Debug.Log(doff.focusDistance.value);

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
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
