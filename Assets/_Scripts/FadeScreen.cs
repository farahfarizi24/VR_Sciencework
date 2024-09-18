using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.Diagnostics;

public class FadeScreen : MonoBehaviour
{
    public bool fadeOnStart = true;
    public float fadeDuration = 2;
    public Color fadeColor;
    private Renderer rend;
    public string nextLevel = "";
    public bool exitGame = false;

    void Start()
    {
        rend = GetComponent<Renderer>();
        if (fadeOnStart)
            FadeIn();
    }

    public void FadeIn()
    {
        Fade(1, 0, false);
    }

    public void FadeOut()
    {
        Fade(0, 1, true);
    }

    public void Fade(float alphaIn, float alphaOut, bool changeLevel)
    {
        StartCoroutine(FadeRoutine(alphaIn, alphaOut, changeLevel));
    }

    public IEnumerator FadeRoutine(float alphaIn, float alphaOut, bool changeLevel)
    {
        float timer = 0;
        while (timer <= fadeDuration)
        {
            Color newColor = fadeColor;
            newColor.a = Mathf.Lerp(alphaIn, alphaOut, timer / fadeDuration);
            rend.material.SetColor("_Color", newColor);

            timer += Time.deltaTime;
            yield return null;
        }

        Color outColor = fadeColor;
        outColor.a = alphaOut;
        rend.material.SetColor("_Color", outColor);

        if (changeLevel && nextLevel != "")
            SceneManager.LoadScene(nextLevel);

        if (changeLevel && exitGame)
            Application.Quit();
    }
}
