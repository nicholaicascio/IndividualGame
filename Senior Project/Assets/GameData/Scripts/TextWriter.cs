using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class TextWriter : MonoBehaviour
{
    //this float is how many seconds between printing a character
    [SerializeField] private float secondsBetween = 0.03f;
    //this is the box where we will display the text to the user
    public Text textBox;
    //a reference to the wave controller so that we can start the first(practice) wave after reading the instructions
    public WaveController wcontroller;
    //reference to the video player and the clips
    public VideoSystem videoSystem;
    public VideoClip millionaireClip;
    public VideoClip faceClip;
    public VideoClip planetClip;
    public VideoClip fogClip;
    //Store all your text in this string array
    private string[] textToPrint = new string[] { "Welcome to your first day at the Ministry of Communication.", 
        "It is a great honor to serve your people.", "Here we proofread the communications of our brethren so as to look for errors or other misspeaks that could cause any sort of embarrassment.", 
        "Look at the conveyor below you. Here you will see letters from your brethren.", "Click on a letter to mark it for removal.", 
        "Let us practice once to make sure you understood my directions." };
    private  int currentlyDisplayingText = 0;
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
        
        if (currentlyDisplayingText < textToPrint.Length)
        {
            //as the button is pressed, go through the array of strings
            StartCoroutine(AnimateText());
        }
        if (currentlyDisplayingText >= textToPrint.Length)
        {
            //if we are at the end of the array do this.
            currentlyDisplayingText = 0;
            //conveyor.WaveOver = false;
            wcontroller.nextWave();
            videoSystem.setNewVideo(millionaireClip);
            //StartCoroutine(AnimateText());
        }

    }
    IEnumerator AnimateText()
    {
        //this is displaying the current text from textToPrint in textBox
        for (int i = 0; i < (textToPrint[currentlyDisplayingText].Length + 1); i++)
        {
            textBox.text = textToPrint[currentlyDisplayingText].Substring(0, i);
            yield return new WaitForSeconds(secondsBetween);
        }
    }
}
