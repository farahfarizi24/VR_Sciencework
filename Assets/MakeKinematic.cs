using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeKinematic : MonoBehaviour
{
    public BoxCollider safeZone = null;
    public TrolleyController trolleyController;
    public FinalChoiceScript ChoiceScript;

    public bool isCereal;
    public string itemName;
    private bool inTrolley = false;
    public GameObject SaveDataObject;
    private Rigidbody rb;
    public bool HasBeenDropped=false;
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
        
        SaveDataObject.GetComponent<DataSaving>().OnCerealGrabbed(itemName);

        rb.isKinematic = false;
        rb.constraints = RigidbodyConstraints.None;

    }

    public void LetGo()
    {
        
        // transform.position = startPos;
        // transform.rotation = startRot;
        // rb.constraints = RigidbodyConstraints.FreezeAll;
       // SaveDataObject.GetComponent<DataSaving>().OnCerealLetGo(itemName);

       HasBeenDropped = true;
        rb.useGravity = true;
       // rb.isKinematic = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        if (HasBeenDropped) 
        {

            if (collision.gameObject.tag == "Checkout")
            {
                ChoiceScript.HandleAnswerToggle();

                SaveDataObject.GetComponent<DataSaving>().OnCerealLetGo(itemName);
                Destroy(this.gameObject);
            }
            else
            {
                SaveDataObject.GetComponent<DataSaving>().OnCerealLetGo(itemName);
              
            }
            HasBeenDropped=false;
        }
    }
}
