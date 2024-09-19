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
        bool Abutton = OVRInput.GetDown(OVRInput.Button.One);
        bool Bbutton = OVRInput.GetDown(OVRInput.Button.Two);
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
        if (TriggerButton)
        {
            User_ID.text = "UID:" + userIDCount.ToString() + "selected";
            DataManager.GetComponent<DataSaving>().UpdateStartingData(userIDCount);
            USERIDGameObj.SetActive(false);
        }



    }
}
