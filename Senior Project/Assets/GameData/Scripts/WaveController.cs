using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour
{
    //public int waveSize;
    public int chanceOfBad;
    public int currentPhrase;
    public int currentWaveLength;
    public GameObject spawnPoint;
    public GameObject conveyorStart;
    public GameObject badPhrase;
    public GameObject goodPhrase;
    public GameObject[] wave;

    // Start is called before the first frame update
    void Start()
    {
        createWave(3, 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void createWave(int size, int badChance)
    {
        currentWaveLength = size;
        chanceOfBad = badChance;
        wave = new GameObject[size];
        Debug.Log("this wave size is " + wave.Length.ToString());
        for (int i = 0; i < wave.Length; i++)
        {
            wave[i] = CreatePhrase();
        }
    }

    GameObject CreatePhrase()
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

    public GameObject nextPhrase()
    {
        if(currentPhrase < currentWaveLength && wave[currentPhrase] != null)
        {
            
            Phrase phraseControl = wave[currentPhrase].GetComponentInChildren<Phrase>();
            phraseControl.moveNext(conveyorStart.transform);
            GameObject send = wave[currentPhrase];
            wave[currentPhrase] = null;
            currentPhrase++;
            return send;
        }
        else
        {
            currentPhrase = 0;
            return null;
        }
    }
}
