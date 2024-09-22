using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
public class UIDEnter : MonoBehaviour
{
    public GameObject USERIDGameObj;
    public TMP_Text User_ID;
    public int userIDCount;
    public GameObject DataManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Upper button to scroll up
        //Lower button to scroll down
        //Trigger button to enter
        bool Abutton = OVRInput.GetDown(OVRInput.RawButton.A);
        bool Bbutton = OVRInput.GetDown(OVRInput.RawButton.B);
        bool Ybutton = OVRInput.GetDown(OVRInput.RawButton.Y);
        bool Xbutton = OVRInput.GetDown(OVRInput.RawButton.X);
        bool TriggerButton = OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger);
        if (Bbutton)
        {
            //update TMPRo
            userIDCount++;
         User_ID.text = "UID:" + userIDCount.ToString();

        }
        if (Abutton) 
        {
            //update TMPRo
            userIDCount--;
            User_ID.text = "UID:" + userIDCount.ToString();
        }

        if (Ybutton)
        {
            userIDCount += 10;
            User_ID.text = "UID:" + userIDCount.ToString();

        }
        if (Xbutton)
        { 
            userIDCount -= 10;
            User_ID.text = "UID:" + userIDCount.ToString();

        }
        if (TriggerButton)
        {
            User_ID.text = "UID:" + userIDCount.ToString() + "selected";
            DataManager.GetComponent<DataSaving>().UpdateStartingData(userIDCount);
            USERIDGameObj.SetActive(false);
        }



    }
}
