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
    public VideoClip millionaireClip;
    public ConveyorController conveyor;

    private void Start()
    {
        videoSystem.setNewVideo(millionaireClip);
        conveyor.createWave(currentWave);
    }

    void Update()
    {
        ErrorsDisplay.text = (incorrectResponses + badMissed).ToString();
        WaveDisplay.text = (currentWave +1 ).ToString();
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
