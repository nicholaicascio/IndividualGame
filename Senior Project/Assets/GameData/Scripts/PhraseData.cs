using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhraseData : MonoBehaviour
{
    public List<Quote> quotes;
    Quote quote0;
    Quote quote1;
    Quote quote2;
    Quote quote3;
    void Awake()
    {

        Quote quote0 = new Quote();
        quote0.text = "I love the government";
        quote0.badOnWave[0] = false;
        quote0.badOnWave[1] = false;
        quote0.badOnWave[2] = false;
        quote0.badOnWave[3] = false;
        quote0.badOnWave[4] = false;
        quote0.badOnWave[5] = false;
        quote0.badOnWave[6] = false;
        quote0.badOnWave[7] = false;
        quote0.badOnWave[8] = false;
        quote0.badOnWave[9] = false;
        quote0.badOnWave[10] = false;
        quotes.Add(quote0);

        Quote quote1 = new Quote();
        quote1.text = "I hate the government";
        quote1.badOnWave[0] = true;
        quote1.badOnWave[1] = true;
        quote1.badOnWave[2] = true;
        quote1.badOnWave[3] = true;
        quote1.badOnWave[4] = true;
        quote1.badOnWave[5] = true;
        quote1.badOnWave[6] = true;
        quote1.badOnWave[7] = true;
        quote1.badOnWave[8] = true;
        quote1.badOnWave[9] = true;
        quote1.badOnWave[10] = true;
        quotes.Add(quote1);

        Quote quote2 = new Quote();
        quote2.text = "I like bananas";
        quote2.badOnWave[0] = false;
        quote2.badOnWave[1] = true;
        quote2.badOnWave[2] = true;
        quote2.badOnWave[3] = true;
        quote2.badOnWave[4] = true;
        quote2.badOnWave[5] = true;
        quote2.badOnWave[6] = true;
        quote2.badOnWave[7] = true;
        quote2.badOnWave[8] = true;
        quote2.badOnWave[9] = true;
        quote2.badOnWave[10] = true;
        quotes.Add(quote2);

        Quote quote3 = new Quote();
        quote3.text = "I like turtles";
        quote3.badOnWave[0] = false;
        quote3.badOnWave[1] = false;
        quote3.badOnWave[2] = false;
        quote3.badOnWave[3] = false;
        quote3.badOnWave[4] = true;
        quote3.badOnWave[5] = true;
        quote3.badOnWave[6] = true;
        quote3.badOnWave[7] = true;
        quote3.badOnWave[8] = true;
        quote3.badOnWave[9] = true;
        quote3.badOnWave[10] = true;
        quotes.Add(quote3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
