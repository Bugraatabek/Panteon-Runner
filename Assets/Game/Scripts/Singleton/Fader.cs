using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Fader : MonoBehaviour
{
    Coroutine currentlyActiveFade = null;   // Stores the reference to the currently active fade coroutine
    CanvasGroup canvasGroup;                 // Reference to the CanvasGroup component

    private void Awake()
    {
        canvasGroup = FindObjectOfType<CanvasGroup>();    // Find the CanvasGroup component in the scene
    }

    // Set the alpha of the canvas group to 1, instantly fading it out
    public void FadeOutImmediate()
    {
        canvasGroup.alpha = 1;
    }

    // Start a fade-out coroutine with the specified time duration
    public Coroutine FadeOut(float time)
    {
        return Fade(time, 1);   // Call the Fade method with target alpha = 1 (fade-out)
    }

    // Start a fade-in coroutine with the specified time duration
    public Coroutine FadeIn(float time)
    {
        return Fade(time, 0);   // Call the Fade method with target alpha = 0 (fade-in)
    }

    // Start a fade coroutine with the specified time duration and target alpha
    private Coroutine Fade(float time, float target)
    {
        if (currentlyActiveFade != null)
        {
            StopCoroutine(currentlyActiveFade);   // Stop the currently active fade coroutine if there is one
        }

        currentlyActiveFade = StartCoroutine(FadeRoutine(time, target));   // Start the new fade coroutine
        return currentlyActiveFade;
    }

    // Coroutine that gradually adjusts the alpha of the canvas group towards the target value
    private IEnumerator FadeRoutine(float time, float target)
    {
        float deltaAlpha = Time.deltaTime / time;   // Calculate the increment per frame based on the desired time

        while (!Mathf.Approximately(canvasGroup.alpha, target))
        {
            canvasGroup.alpha = Mathf.MoveTowards(canvasGroup.alpha, target, deltaAlpha);   // Adjust the alpha value towards the target
            yield return null;   // Wait for the next frame
        }
    }
}
