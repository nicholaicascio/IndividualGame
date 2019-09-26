using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class WaveController : MonoBehaviour
{
    public int currentWave;
    public int incorrectResponses;
    public int badMissed;

    public Text ErrorsDisplay;
    public Text WaveDisplay;

    public VideoSystem videoSystem;
    public VideoClip millionaireClip;

    private void Start()
    {
        videoSystem.setNewVideo(millionaireClip);
    }

    void Update()
    {
        ErrorsDisplay.text = (incorrectResponses + badMissed).ToString();
        WaveDisplay.text = currentWave.ToString();
    }
}
