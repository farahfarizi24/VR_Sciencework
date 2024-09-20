using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketDestroy : MonoBehaviour
{
    public GameObject dataSaveFile;

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Cereal")
        {
           
            dataSaveFile.GetComponent<DataSaving>().DeletedObject(collision.gameObject.name);

            Destroy(collision.gameObject);

            


        }
    }

    }
