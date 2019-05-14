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

    private void Start()
    {
        phrases = new GameObject[10];
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
                MovePhrases();
            }
            CreatePhrase();
        }
    }

    void CreatePhrase()
    {
        int num = Random.Range(1, 10);
        Debug.Log(num);
        if (num <= chanceOfBad)
        {
            if (count < 10)
            {
                phrases[count] = Instantiate(badPhrase, spawnPoint.transform.position, Quaternion.identity) as GameObject;
                count++;
            }
            else
            {
                count = 0;
                Destroy(phrases[10]);
                phrases[count] = Instantiate(badPhrase, spawnPoint.transform.position, Quaternion.identity) as GameObject;
                count++;
            }
        }
        if(num > chanceOfBad)
        {
            if(count < 10)
            {
                phrases[count] = Instantiate(goodPhrase, spawnPoint.transform.position, Quaternion.identity) as GameObject;
                count++;
            }
            else
            {
                count = 0;
                Destroy(phrases[10]);
                phrases[count] = Instantiate(goodPhrase, spawnPoint.transform.position, Quaternion.identity) as GameObject;
                count++;
            }
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
                obj.transform.Translate(right * Time.deltaTime);
            }
            
        }
    }
}
