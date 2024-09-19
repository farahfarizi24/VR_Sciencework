using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractRaycast : MonoBehaviour
{
    void FixedUpdate()
    {
        RayFunction();
    }
    void RayFunction()
    {
        Ray ray = new Ray(transform.position,transform.forward);
        RaycastHit hitData;
        Debug.DrawRay(ray.origin,ray.direction*10);
        if(Physics.Raycast(transform.position,transform.TransformDirection(Vector3.forward),
            out hitData, Mathf.Infinity))
        {
            if(hitData.collider.tag == "UI")
                {
                hitData.transform.SendMessage("HitMessage");
            }
        }
    }
}
