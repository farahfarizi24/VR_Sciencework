using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeKinematic : MonoBehaviour
{
    public BoxCollider safeZone = null;
    public TrolleyController trolleyController;
    public bool isCereal;
    public string itemName;
    private bool inTrolley = false;
    public GameObject SaveDataObject;
    private Rigidbody rb;

    private Vector3 startPos;
    private Quaternion startRot;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeAll;
        startPos = this.transform.position;
        startRot = this.transform.rotation;
    }

    public void SetLocation()
    {
        startPos = this.transform.position;
        startRot = this.transform.rotation;
    }

    private void OnEnable()
    {
        rb = this.GetComponent<Rigidbody>();
        rb.isKinematic = true;
        //rb.constraints = RigidbodyConstraints.FreezeAll;
    }



    // Update is called once per frame
    void Update()
    {

    }

    public void Grabbed()
    {
        if (this.inTrolley)
        {
            if (this.isCereal)
            {
                trolleyController.cerealType = "";
            }
            else
            {
                trolleyController.drinkType = "";
            }
            this.inTrolley = false;
        }
        SaveDataObject.GetComponent<DataSaving>().OnCerealGrabbed(itemName);

        rb.isKinematic = false;
        rb.constraints = RigidbodyConstraints.None;

    }

    public void LetGo()
    {
        if (safeZone != null)
        {
            if (safeZone.bounds.Contains(this.transform.position))
            {
                if (this.isCereal)
                {
                    if (trolleyController.cerealType == "")
                    {
                        this.inTrolley = true;
                        trolleyController.cerealType = this.itemName;
                        return;
                    }
                }
                else
                {
                    if (trolleyController.drinkType == "")
                    {
                        this.inTrolley = true;
                        trolleyController.drinkType = this.itemName;
                        return;
                    }
                }
            }
        }
        // transform.position = startPos;
        // transform.rotation = startRot;
        // rb.constraints = RigidbodyConstraints.FreezeAll;
        SaveDataObject.GetComponent<DataSaving>().OnCerealLetGo(itemName);

       
        rb.useGravity = true;
       // rb.isKinematic = true;
    }
}
