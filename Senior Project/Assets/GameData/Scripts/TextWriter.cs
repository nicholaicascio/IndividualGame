﻿using System.Collections;
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
    public GameObject textUI;
    //a reference to the wave controller so that we can start the first(practice) wave after reading the instructions
    public WaveController wcontroller;
    //reference to the video player and the clips
    public VideoSystem videoSystem;
    public VideoClip millionaireClip;
    public VideoClip faceClip;
    public VideoClip planetClip;
    public VideoClip fogClip;
    //Store all your text in this string array
    public List<string> textToPrint = new List<string> { "Welcome to your first day at the Ministry of Communication.", 
        "It is a great honor to serve your people.", "Here we proofread the communications of our brethren so as to look for errors or other misspeaks that could cause any sort of embarrassment.", 
        "Look at the conveyor below you. Here you will see letters from your brethren.", "Click on a letter to mark it for removal.", 
        "Let us practice once to make sure you understood my directions." };
    public List<string> wave1Text = new List<string> { "Yes you are beginning to get the hang of it comrade.", 
        "Now it is time for you to proofread works from your brothers.", 
        "Remember to mark any letters which would speak ill of The Party for destruction, lest they embarrass your comrades."};
    public List<string> wave2Text = new List<string> { "Comrade you are becoming extremely efficient at sorting the letters of our people.",
        "I have just received word from the people’s capital that we are no longer doing business with our comrades in the pacific.",
        "As a result, bananas are no longer being rationed by The Party.",
        "Please make sure that none of our brothers are making a mistake by addressing these fruits.",
        "And remember, comrade... Do not allow your errors to rise too high, we cannot have mistakes at the Ministry of Communication!"};
    public List<string> wave3Text = new List<string> { "Comrade, do not falter. I have just recieved another word from the capital.",
        "War has finally broken out with our greatest enemies in the east; China.",
        "We all must make sacrifices to defeat our foes. Surely you will help sort out letters from any who will not stand up to our enemy."};
    private  int currentlyDisplayingText = 0;
    void Awake()
    {
        StartCoroutine(AnimateText(textToPrint));
    }
    //This is a function for a button you press to skip to the next text
    public void SkipToNextText()
    {
        StopAllCoroutines();
        currentlyDisplayingText++;        
        if (currentlyDisplayingText < textToPrint.Count)
        {
            //as the button is pressed, go through the array of strings
            StartCoroutine(AnimateText(textToPrint));
        }
        if (currentlyDisplayingText >= textToPrint.Count)
        {
            //if we are at the end of the array do this.
            currentlyDisplayingText = 0;
            //if wcontroller.currentwave > 0 we want to call wcontroller.GenerateNextWave() instead
            if(wcontroller.currentWave > 0)
            {
                wcontroller.GenerateNextWave();
            }
            else
            {
                wcontroller.nextWave();
            }
            videoSystem.setNewVideo(millionaireClip);
            textUI.SetActive(false);
        }

    }
    IEnumerator AnimateText(List<string> printThis)
    {
        //this is displaying the current text from textToPrint in textBox
        for (int i = 0; i < (textToPrint[currentlyDisplayingText].Length + 1); i++)
        {
            textBox.text = textToPrint[currentlyDisplayingText].Substring(0, i);
            yield return new WaitForSeconds(secondsBetween);
        }
    }

    public void WriteNextText(int currentWave)
    {
        //Debug.Log(currentWave);
        //currentWave--;
        if (currentWave == 1)
        {
            textToPrint.Clear();
            textToPrint = wave1Text;
            textUI.SetActive(true);
            StartCoroutine(AnimateText(textToPrint));

        }
        else if(currentWave == 2)
        {
            textToPrint.Clear();
            textToPrint = wave2Text;
            textUI.SetActive(true);
            currentlyDisplayingText = 0;
            StartCoroutine(AnimateText(textToPrint));
        }
        else if (currentWave == 3)
        {
            textToPrint.Clear();
            textToPrint = wave3Text;
            textUI.SetActive(true);
            currentlyDisplayingText = 0;
            StartCoroutine(AnimateText(textToPrint));
        }
        else
        {
            wcontroller.GenerateNextWave();
        }
    }
}
