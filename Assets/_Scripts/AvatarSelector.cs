using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AvatarSelector : MonoBehaviour
{
    public GameObject BoyAvatar;
    public GameObject GirlAvatar;
    public TMP_Text GenderText;


    // Start is called before the first frame update
    void Start()
    {
        //This defaulted in BoyAvatar and when right triggered is pressed it will change
        GirlAvatar.SetActive(false);
        BoyAvatar.SetActive(true);
        GenderText.text = "Boy";
    }

    // Update is called once per frame
    void Update()
    {
        bool RightTriggerButton = OVRInput.GetDown(OVRInput.Button.SecondaryHandTrigger);

        if (RightTriggerButton)
        {
            Debug.Log("Trigger is presed");
            if (BoyAvatar.activeSelf == true)
            {
                BoyAvatar.SetActive(false );
                GirlAvatar.SetActive(true );
                GenderText.text = "Girl";
            }
            else
            {
                BoyAvatar.SetActive(true);
                GirlAvatar.SetActive(false);
                GenderText.text = "Boy";
            }

        }
    }
}
