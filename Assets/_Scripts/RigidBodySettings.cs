using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidBodySettings : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void turnOffGravity()
    {
        this.GetComponent<Rigidbody>().useGravity = false; 
    }
    public void turnOnGravity()
    {
        this.GetComponent<Rigidbody>().useGravity = true;

    }
}
