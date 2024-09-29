using Meta.WitAi;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalChoiceScript : MonoBehaviour
{
    public GameObject dataManager;
    public int answerIndex=0;
    public string firstAnswer;
    public string secondAnswer;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Cereal")
        {
            if (answerIndex == 0)
            {
                firstAnswer = "1+" + collision.gameObject.name;
                dataManager.GetComponent<DataSaving>().ToggleFirstAnswer(true);
                answerIndex++;

                Destroy(collision.gameObject);

            }
            else if (answerIndex == 1)
            {
                {
                    secondAnswer = "2+" + collision.gameObject.name;
                    dataManager.GetComponent<DataSaving>().ToggleLastAnswer(true);
                    answerIndex++;

                    Destroy(collision.gameObject);


                }

            }


        }



    }
}
