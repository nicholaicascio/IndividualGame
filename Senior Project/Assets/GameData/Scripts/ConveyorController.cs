using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorController : MonoBehaviour
{
    float elapsed = 0f;
    public int waveSize;
    public int chanceOfBad = 5;
    public float timeBetween = 1f;
    public GameObject spawnPoint;
    public GameObject badPhrase;
    public GameObject goodPhrase;
    public GameObject[] phrases;
    public GameObject[] phrasePos;
    public GameObject[] wave;

    private void Start()
    {
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
        chanceOfBad = badChance;
        wave = new GameObject[size];
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
            Destroy(phrases[10]);
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
            return Instantiate(badPhrase, spawnPoint.transform.position, Quaternion.identity) as GameObject;
        }
        else if (num > chanceOfBad)
        {
            return Instantiate(goodPhrase, spawnPoint.transform.position, Quaternion.identity) as GameObject;
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
}
