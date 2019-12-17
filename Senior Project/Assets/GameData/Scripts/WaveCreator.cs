using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveCreator : MonoBehaviour
{
    PhraseData phrases;
    //public Quote[] quotes;
    int currentWave = 0;
    int[] currentWaveChanceofBad;
    int[] currentWaveSize;
    public Wave[] finalWaves;
    public List<Quote> goodThisWave;
    public List<Quote> badThisWave;
    void Start()
    {
        phrases = this.GetComponent<PhraseData>();
        //we go through each wave as we generate it, below we see the chance of spawning a bad phrase in given wave
        currentWaveChanceofBad = new int[11] { 5, 1, 2, 3, 5, 5 , 5, 3, 2, 1, 0 };
        //this is the list of wave sizes
        currentWaveSize = new int[11] { 5, 10, 10, 12, 13, 14, 15, 16, 17, 18, 20 };
        //this holds the waves after we populate them
        finalWaves = new Wave[11];
        for (int i = 0; i < finalWaves.Length; i++)
        {
            Wave thisWave = new Wave();
            foreach (Quote quote in phrases.quotes)
            {
                //so for a given wave we categorize the quotes. are they good or bad on this wave?
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
                //now we populate the quotes into the waves, based upon the pre-determined chances
                int num = Random.Range(0, 10);
                if (num <= currentWaveChanceofBad[i])
                {
                    int number = Random.Range(0, badThisWave.Count);
                    thisWave.quotes.Add(badThisWave[number]);
                    //pick a random phrase from the bad
                }
                else
                {
                    int number = Random.Range(0, goodThisWave.Count);
                    thisWave.quotes.Add(goodThisWave[number]);
                    //pick a random phrase from the good
                }
            }
            //set our newly generated wave into the array, and clear out our list of quotes
            finalWaves[i] = thisWave;
            goodThisWave.Clear();
            badThisWave.Clear();
        }
    }

}
