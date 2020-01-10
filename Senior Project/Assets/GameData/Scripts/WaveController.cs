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

    public void waveOver(int num)
    {

    }

    public void nextWave()
    {
        if(currentWave < 10)
        {
            currentWave += 1;
            conveyor.createWave(currentWave);
        }

    }
}
