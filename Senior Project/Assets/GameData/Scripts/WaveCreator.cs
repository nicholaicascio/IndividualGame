using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveCreator : MonoBehaviour
{
    PhraseData phrases;
    int currentWave = 0;
    int[] currentWaveChanceofBad;
    int[] currentWaveSize;
    public Wave[] finalWaves = new Wave[11];
    public List<Quote> goodThisWave;
    public List<Quote> badThisWave;
    // Start is called before the first frame update
    void Start()
    {
        //finalWaves =  new Wave[11];

        //PhraseData phrases = new PhraseData();
        phrases = this.GetComponent<PhraseData>();
        //we go through each wave as we generate it, below we see the chance of spawning a bad phrase in given wave
        currentWaveChanceofBad = new int[] { 5, 1, 2, 3, 5, 5 , 5, 3, 2, 1, 0 };
        currentWaveSize = new int[] { 5, 10, 10, 12, 13, 14, 15, 16, 17, 18, 20 };
        for (int i = 0; i < finalWaves.Length; i++)
        {
            Wave thisWave = new Wave();
            foreach (Quote quote in phrases.quotes)
            {
                if (quote.badOnWave[currentWave] == true)
                {
                    badThisWave.Add(quote);
                }
                else
                {
                    goodThisWave.Add(quote);
                    

                }
                //if it is bad in the given wave add it to the bad list, else add to good list
            }
            for (int x = 0; x < currentWaveSize[i]; x++)
            {
                //FOR SOME REASON WE ARENT GETTING HERE WTF!!!
                int num = Random.Range(0, 10);
                if (num <= currentWaveChanceofBad[i])
                {
                    int number = Random.Range(0, badThisWave.Count);
                    thisWave.quotes.Add(badThisWave[number]);
                    Debug.Log("Add a bad quote");
                    //pick a random phrase from the bad
                }
                else
                {
                    int number = Random.Range(0, goodThisWave.Count);
                    thisWave.quotes.Add(goodThisWave[number]);
                    Debug.Log("Add a good quote");
                    //pick a random phrase from the good
                }
            }
            

            finalWaves[i] = thisWave;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
