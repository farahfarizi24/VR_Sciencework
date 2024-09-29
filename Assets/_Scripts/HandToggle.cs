using Autohand.Demo;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandToggle : MonoBehaviour
{
    public GameObject Boy;
    public OVRHandControllerLink boy_leftHand;
    public OVRHandControllerLink boy_rightHand;
    public GameObject Girl;
    public OVRHandControllerLink girl_leftHand;
    public OVRHandControllerLink girl_rightHand;
    // Start is called before the first frame update
    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("Col exited");
        if (collision.gameObject.tag == "Player")
        {
            if (Boy.activeSelf == true)
            {
                boy_leftHand.enabled = false;
                boy_rightHand.enabled = false;
            }
            if (Girl.activeSelf == true)
            {
                Debug.Log("Code activated");
                girl_leftHand.enabled = false;
                girl_rightHand.enabled = false;
            }
        }
       
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (Boy.activeSelf == true)
            {
                boy_leftHand.enabled = true;
                boy_rightHand.enabled = true;
            }
            if (Girl.activeSelf == true)

            {
                girl_leftHand.enabled = true;
                girl_rightHand.enabled = true;
            }

        }
            
    }
}
