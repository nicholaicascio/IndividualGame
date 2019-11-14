using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConveyorController : MonoBehaviour
{
    float elapsed = 0f;
    public int currentWave = 0;
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
    int[,] waveArray = new int[11, 3] { { 5, 5, 4 }, { 10, 1, 3 }, { 10, 2, 3 }, { 12, 3, 3 }, { 13, 5, 3 }, { 14, 5, 3 }, { 15, 3, 3 }, { 16, 2, 3 }, { 17, 2, 3 }, { 18, 1, 3 }, { 20, 0, 3 } };

    private void Start()
    {
        GameObject obj = GameObject.FindGameObjectWithTag("GameController");
        wController = obj.GetComponent<WaveController>();
        phrases = new GameObject[11];
        //createWave(waveSize, 2);
    }

    void Update()
    {
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

    public void createWave(int waveNum)
    {
        WaveOver = false;
        //chanceOfBad = waveArray[waveNum, 1];
        //int size = waveArray[waveNum, 0];
        //wave = new GameObject[size];
        //countDownWave = wave.Length;
        //Debug.Log("this wave size is " + wave.Length.ToString());
        //for (int i = 0; i < wave.Length; i++)
        //{
            //wave[i] = ReturnRandomPhrase();
        //}
        //Debug.Log(creator.finalWaves[currentWave].quotes.Count);
        int sizeOfWave = creator.finalWaves[currentWave].quotes.Count;
        Debug.Log(sizeOfWave);
        wave = new GameObject[sizeOfWave];
        countDownWave = wave.Length;
        Debug.Log("this wave size is " + wave.Length.ToString());
        for (int i = 0; i < wave.Length; i++)
        {
            GameObject p;
            if(creator.finalWaves[currentWave].quotes[i].badOnWave[currentWave] == true)
            {
                p = badPhrase;
                p.GetComponent<Phrase>().status = "bad";
                p.GetComponentInChildren<Text>().text = creator.finalWaves[currentWave].quotes[i].text;
            }
            else
            {
                p = goodPhrase;
                p.GetComponent<Phrase>().status = "good";
                p.GetComponentInChildren<Text>().text = creator.finalWaves[currentWave].quotes[i].text;
            }
            
            wave[i] = Instantiate(p, spawnPoint.transform.position, Quaternion.identity) as GameObject;
        }
        currentWave++;
    }

    GameObject ReturnPhrase()
    {
        GameObject p = goodPhrase;
        p.GetComponent<Phrase>().status = "good";
        return Instantiate(p, spawnPoint.transform.position, Quaternion.identity) as GameObject;
    }

    void UpdateWave()
    {
        for (int i = 0; i < (wave.Length - 1); i++)
        {
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
                    wController.badMissed++;
                }
                lastPhrase = null;
            }
            Destroy(phrases[10]);
            phrases[10] = null;
            countDownWave--;
        }
        if(countDownWave == 0 && WaveOver == false)
        {
            WaveEnded();
        }
        for(int i = 9; i >= 0; i--)
        {
            if(phrases[i] != null)
            {
                phrases[i + 1] = phrases[i];
                phrases[i] = null;
            }
        }
        if(wave[0] != null)
        {
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
                Phrase phraseControl = phrases[i].GetComponentInChildren<Phrase>();
                phraseControl.moveNext(phrasePos[i].transform);
            }
        }
    }
    void WaveEnded()
    {
        WaveOver = true;
        Debug.Log("end of wave");
        wController.nextWave();
    }
}
