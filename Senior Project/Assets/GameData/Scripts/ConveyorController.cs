using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorController : MonoBehaviour
{
    float elapsed = 0f;
    int count = 0;
    public int chanceOfBad = 5;
    public float timeBetween = 1f;
    public WaveController waveController;
    public GameObject spawnPoint;
    public GameObject badPhrase;
    public GameObject goodPhrase;
    public GameObject[] phrases;
    public GameObject[] phrasePos;

    //public Transform goal;

    private void Start()
    {
        phrases = new GameObject[11];
        //phrasePos = new GameObject[10];
        //phrasePos = GameObject.FindGameObjectsWithTag("PhrasePos");
        //Vector3 spawn = new Vector3();
        //spawn = spawnPoint.transform.position;
        //CreatePhrase();
    }

    void Update()
    {
        elapsed += Time.deltaTime;
        if (elapsed >= timeBetween)
        {
            elapsed = elapsed % 1f;
            //Debug.Log(Time.time);
            if (phrases[0] != null)
            {
                //Debug.Log("called MovePhrases");
                MovePhrases();
            }
            CreatePhrase();
        }
    }

    void CreatePhrase()
    {
        //int num = Random.Range(1, 10);
        //Debug.Log(num);
        if(phrases[9] != null)
        {
            Destroy(phrases[10]);
        }
        
        int i = 9;
        while (i >= 0){

            if(phrases[i] != null)
            {
                //Debug.Log("attempting to move phrase through array at index " + i.ToString());
                phrases[i + 1] = phrases[i];
            }
            i--;
        }
        phrases[0] = waveController.nextPhrase();
        
        //phrases[0] = ReturnRandomPhrase();
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
        //Debug.Log(Time.time);
        for (int i = 9; i >= 0; i--)
        {
            //GameObject obj = new GameObject();
            //obj = phrases[i];
            
            if(phrases[i] != null)
            {
                //Debug.Log("tried to move " + i.ToString());
                //Debug.Log(obj.ToString());
                Phrase phraseControl = phrases[i].GetComponentInChildren<Phrase>();
                phraseControl.moveNext(phrasePos[i].transform);
            }
        }
    }
}
