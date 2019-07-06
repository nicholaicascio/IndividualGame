using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorController : MonoBehaviour
{
    float elapsed = 0f;
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

    private void Start()
    {
        GameObject obj = GameObject.FindGameObjectWithTag("GameController");
        wController = obj.GetComponent<WaveController>();
        phrases = new GameObject[11];
        createWave(waveSize, 2);
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

    void createWave(int size, int badChance)
    {
        WaveOver = false;
        chanceOfBad = badChance;
        wave = new GameObject[size];
        countDownWave = wave.Length;
        Debug.Log("this wave size is " + wave.Length.ToString());
        for (int i = 0; i < wave.Length; i++)
        {
            wave[i] = ReturnRandomPhrase();
        }
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

    GameObject ReturnRandomPhrase()
    {
        int num = Random.Range(1, 10);
        if (num <= chanceOfBad)
        {
            GameObject p = badPhrase;
            p.GetComponent<Phrase>().status = "bad";
            return Instantiate(p, spawnPoint.transform.position, Quaternion.identity) as GameObject;
        }
        else if (num > chanceOfBad)
        {
            GameObject p = goodPhrase;
            p.GetComponent<Phrase>().status = "good";
            return Instantiate(p, spawnPoint.transform.position, Quaternion.identity) as GameObject;
        }
        else
        {
            return null;
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
    }
}
