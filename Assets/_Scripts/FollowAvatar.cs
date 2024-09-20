using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowAvatar : MonoBehaviour
{
    public GameObject AvatarObject;
    Vector3 TrolleyOBJ;
    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = new Vector3(0.981999993f, -0.296000004f, 14.5509996f); 
    }

    // Update is called once per frame
    void Update()
    {
      TrolleyOBJ = new Vector3(0.0f,0.0f,AvatarObject.transform.position.z);
        this.transform.position = new Vector3(this.transform.position.x,this.transform.position.y,TrolleyOBJ.z);

    }
}
