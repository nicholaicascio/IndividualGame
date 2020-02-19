using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class WaveController : MonoBehaviour
{

    public int currentWave = 0;
    public int incorrectResponses;
    public int badMissed;

    public Text ErrorsDisplay;
    public Text WaveDisplay;

    public VideoSystem videoSystem;
    public VideoClip planetClip;
    public VideoClip faceClip;
    public ConveyorController conveyor;
    public TextWriter tWriter;

    //NOTE: this script is assigned to the GameController in the GameScene!
    private void Start()
    {
        videoSystem.setNewVideo(faceClip);
        //videoSystem.setNewVideo(faceClip);
        //conveyor.createWave(currentWave);
    }

    void Update()
    {
        ErrorsDisplay.text = (incorrectResponses + badMissed).ToString();
        WaveDisplay.text = (currentWave).ToString();
    }

    public void nextWave()
    {
        //Debug.Log(currentWave);
        if (currentWave == 0)
        {
            //Debug.Log("beep");
            //this happens first wave after intro text
            //the reason we have a special case for this first wave is because we don't need to play any text after calling this wave
            conveyor.createWave(currentWave);
            currentWave++;
            
        }
        else if(currentWave < 10)
        {
            //Debug.Log("boop");
            //conveyor.createWave(currentWave);
            tWriter.WriteNextText(currentWave);

            currentWave++;
            //tell textwriter to write some text and play creepyface
            //when textwriter is done it should call generate next wave
            
        }

    }

    public void GenerateNextWave()
    {
        conveyor.createWave(currentWave);
        //this should be called after the text is done.
        //play a video clip as well
    }
}
