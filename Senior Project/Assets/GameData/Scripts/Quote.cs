using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Quote
{
    public string text;
    public bool[] badOnWave =  new bool[11];

    private void Awake()
    {
        //badOnWave = new bool[11];
    }
}
