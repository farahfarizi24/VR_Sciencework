using Meta.WitAi;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalChoiceScript : MonoBehaviour
{
    public GameObject dataManager;  
    public int answerIndex;
    public string firstAnswer;
    public string secondAnswer;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Cereal")
        {
            if (answerIndex == 0)
            {
                firstAnswer = "1+" + collision.gameObject.name;
                answerIndex++;
                Destroy(collision.gameObject);
            }
            else
            {
                secondAnswer = "2+" + collision.gameObject.name;
                answerIndex++;
                Destroy(collision.gameObject);
                dataManager.GetComponent<DataSaving>().UpdateFinalData(firstAnswer,secondAnswer);
            }
        }
       
     
    }



}
