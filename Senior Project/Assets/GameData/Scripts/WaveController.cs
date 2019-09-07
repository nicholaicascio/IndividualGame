using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveController : MonoBehaviour
{
    public int currentWave;
    public int incorrectResponses;
    public int badMissed;

    public Text ErrorsDisplay;
    public Text WaveDisplay;

    void Update()
    {
        ErrorsDisplay.text = (incorrectResponses + badMissed).ToString();
        WaveDisplay.text = currentWave.ToString();
    }
}
