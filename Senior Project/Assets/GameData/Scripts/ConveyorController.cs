using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorController : MonoBehaviour
{
    float elapsed = 0f;
    int count = 0;
    public int chanceOfBad = 5;
    public float timeBetween = 1f;
    public GameObject spawnPoint;
    public GameObject badPhrase;
    public GameObject goodPhrase;
    public GameObject[] phrases;
    public GameObject[] phrasePos;

    //public Transform goal;

    private void Start()
    {
        phrases = new GameObject[10];
        //phrasePos = new GameObject[10];
        phrasePos = GameObject.FindGameObjectsWithTag("PhrasePos");
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
            if(phrases[0] != null)
            {
                //MovePhrases();
            }
            //CreatePhrase();
        }
    }

    void CreatePhrase()
    {
        //int num = Random.Range(1, 10);
        //Debug.Log(num);
        if(phrases[9] != null)
        {
            Destroy(phrases[9]);
        }
        
        int i = 8;
        while (i > 0){
            if(phrases[i] != null)
            {
                phrases[i + 1] = phrases[i];
            }
            
            i--;
        }
        phrases[0] = ReturnRandomPhrase();
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
        Debug.Log(Time.time);
        foreach(GameObject obj in phrases)
        {
            Vector3 right = new Vector3(25f, 0, 0);
            //Debug.Log(obj);
            if(obj != null)
            {
                //obj.transform.Translate(right * Time.deltaTime);
                Phrase phraseControl = obj.GetComponentInChildren<Phrase>();
                //phraseControl.moveNext(goal);
            }
            
        }
    }
}
