using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConveyorController : MonoBehaviour
{
    float elapsed = 0f;
    //public int currentWave = 0;
    public int waveSize;
    public int countDownWave;
    public bool WaveOver = false;
    public int chanceOfBad = 5;
    public float timeBetween = 1f;
    public GameObject spawnPoint;
    public GameObject badPhrase;
    public GameObject goodPhrase;
    public GameObject[] phrases;
    public GameObject[] phrasePos;
    public GameObject[] wave;
    public Phrase lastPhrase;
    public WaveController wController;
    public WaveCreator creator;

    //waveSize, chanceOfBad(out of ten. higher number means more likely), timeBetween(in seconds)
    //int[,] waveArray = new int[11, 3] { { 5, 5, 4 }, { 10, 1, 3 }, { 10, 2, 3 }, { 12, 3, 3 }, { 13, 5, 3 }, { 14, 5, 3 }, { 15, 3, 3 }, { 16, 2, 3 }, { 17, 2, 3 }, { 18, 1, 3 }, { 20, 0, 3 } };

    private void Start()
    {
        GameObject obj = GameObject.FindGameObjectWithTag("GameController");
        wController = obj.GetComponent<WaveController>();
        phrases = new GameObject[11];
        //createWave(waveSize, 2);
    }

    void Update()
    {
        if (!WaveOver)
        {
            //this is our core update loop. we are counting over time and then performing the actions nesiccary in sequence
            elapsed += Time.deltaTime;
            if (elapsed >= timeBetween)
            {
                elapsed = elapsed % 1f;

                PullPhraseFromWave();

                MovePhrases();

                if (wave[1] != null)
                {
                    UpdateWave();
                }
            }
        }
        
    }

    public void createWave(int waveNum)
    {
        Debug.Log("Creating wave " + waveNum);
        WaveOver = false;
        //pull the wave we need to create from the creator
        int sizeOfWave = creator.finalWaves[waveNum].quotes.Count;
        wave = new GameObject[sizeOfWave];
        //set the wave size in the countdown so we can iterate through it
        countDownWave = wave.Length;
        Debug.Log("this wave size is " + wave.Length.ToString());
        for (int i = 0; i < wave.Length; i++)
        {
            //here we set the attributes of each card in the wave
            GameObject p;
            if(creator.finalWaves[waveNum].quotes[i].badOnWave[waveNum] == true)
            {
                p = badPhrase;
                p.GetComponent<Phrase>().status = "bad";
                p.GetComponentInChildren<Text>().text = creator.finalWaves[waveNum].quotes[i].text;
            }
            else
            {
                p = goodPhrase;
                p.GetComponent<Phrase>().status = "good";
                p.GetComponentInChildren<Text>().text = creator.finalWaves[waveNum].quotes[i].text;
            }
            //here we create it once it's set up
            wave[i] = Instantiate(p, spawnPoint.transform.position, Quaternion.identity) as GameObject;
        }
        //currentWave++;
    }

    GameObject ReturnPhrase()
    {
        //this is an old method for generating a phrase
        GameObject p = goodPhrase;
        p.GetComponent<Phrase>().status = "good";
        return Instantiate(p, spawnPoint.transform.position, Quaternion.identity) as GameObject;
    }

    void UpdateWave()
    {
        for (int i = 0; i < (wave.Length - 1); i++)
        {
            //go through and pull each card in the wave to the next position
            //this is the wave! so these are not on the conveyor yet!
            if (wave[i] == null && wave[i + 1] != null)
            {
                wave[i] = wave[i + 1];
                wave[i + 1] = null;
            }
        }
    }

    void PullPhraseFromWave()
    {
        if(phrases[10] != null)
        {
            if(phrases[9] != null)
            {
                GameObject obj = phrases[9];
                lastPhrase = obj.GetComponent<Phrase>();
                if (lastPhrase.chosen == false && lastPhrase.status == "bad")
                {
                    //this is where we track their score. we are abot to destory the last one in line so we see if they properly sorted it
                    wController.badMissed++;
                }
                lastPhrase = null;
            }
            //actually destory the last one in the line
            Destroy(phrases[10]);
            phrases[10] = null;
            countDownWave--;
        }
        if(countDownWave == 0 && WaveOver == false)
        {
            //what we want to call when there is nothing left to sort
            WaveEnded();
        }
        for(int i = 9; i >= 0; i--)
        {
            if(phrases[i] != null)
            {
                //here you can see we are pulling the cards that are on the conveyor through the conveyor
                phrases[i + 1] = phrases[i];
                phrases[i] = null;
            }
        }
        if(wave[0] != null)
        {
            //get the next-in-line card from wave and put it into phrases
            phrases[0] = wave[0];
            wave[0] = null;
        }
    }

    void MovePhrases()
    {
        for (int i = 9; i >= 0; i--)
        {
            if(phrases[i] != null)
            {
                //this physically calls the move method in the phrase class, it passes the location that it should move to
                Phrase phraseControl = phrases[i].GetComponentInChildren<Phrase>();
                phraseControl.moveNext(phrasePos[i].transform);
            }
        }
    }
    void WaveEnded()
    {
        //this is called when a wave is over
        WaveOver = true;
        Debug.Log("end of wave");
        wController.currentWave++;
        wController.nextWave();
    }
}
