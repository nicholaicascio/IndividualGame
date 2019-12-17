using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextWriter : MonoBehaviour
{
    //this is the box where we will display the text to the user
    public Text textBox;
    //this float is how many seconds between printing a character
    [SerializeField] private float secondsBetween = 0.03f;
    //Store all your text in this string array
    private string[] textToPrint = new string[] { "1. Laik's super awesome custom typewriter script", "2. You can click to skip to the next text", "3.All text is stored in a single string array", "4. Ok, now we can continue", "5. End Kappa" };
    private int currentlyDisplayingText = 0;
    void Awake()
    {
        StartCoroutine(AnimateText());
    }
    //This is a function for a button you press to skip to the next text
    public void SkipToNextText()
    {
        StopAllCoroutines();
        currentlyDisplayingText++;
        //If we've reached the end of the array, do anything you want. I just restart the example text
        if (currentlyDisplayingText > textToPrint.Length)
        {
            currentlyDisplayingText = 0;
        }
        StartCoroutine(AnimateText());
    }
    IEnumerator AnimateText()
    {

        for (int i = 0; i < (textToPrint[currentlyDisplayingText].Length + 1); i++)
        {
            textBox.text = textToPrint[currentlyDisplayingText].Substring(0, i);
            yield return new WaitForSeconds(secondsBetween);
        }
    }
}
