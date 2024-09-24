using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerBodyCollisionSolver : MonoBehaviour
{
    public Transform camera;
    //public Transform feet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        camera.transform.position = new Vector3(camera.position.x, 0.0f, camera.position.z);
    }
}
