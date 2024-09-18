using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Autohand;
using System.Diagnostics;

public class TrolleyController : MonoBehaviour
{
    public string cerealType = "";
    public string drinkType = "";
    public Grabbable grabbable;
    public ChoiceStorage choices;
    public FadeScreen fader;

    public AudioSource cerealAudio;
    public AudioSource milkAudio;
    public AudioSource trolleyAudio;

    private bool hasChosenCereal = false;
    private bool hasChosenMilk = false;
    private bool hasChosenBoth = false;

    void Update()
    {
        if (!hasChosenCereal && cerealType != "")
        {
            hasChosenCereal = true;
            if (drinkType == "")
            {
                cerealAudio.Play();
            }
        }

        if (!hasChosenMilk && drinkType != "")
        {
            hasChosenMilk = true;
            if (cerealType == "")
            {
                milkAudio.Play();
            }
        }

        if (!hasChosenBoth && cerealType != "" && drinkType != "")
        {
            hasChosenBoth = true;
            trolleyAudio.Play();
        }
    }

    public void GrabTrolley()
    {
        if (this.cerealType != "" && this.drinkType != "")
        {
            choices.cereal = this.cerealType;
            choices.drink = this.drinkType;
            fader.FadeOut();
            UnityEngine.Debug.Log("Changing to kitchen scene");
        }
        else
        {
            UnityEngine.Debug.Log("Missing items in trolley");
        }
    }
}
