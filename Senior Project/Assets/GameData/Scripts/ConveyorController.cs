using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorController : MonoBehaviour
{
    float elapsed = 0f;
    public float chanceOfBad = 5;
    public float timeBetween = 1f;
    public GameObject spawnPoint;
    public GameObject badPhrase;
    public GameObject goodPhrase;

    private void Start()
    {
        //Vector3 spawn = new Vector3();
        //spawn = spawnPoint.transform.position;
        CreatePhrase();
    }

    void Update()
    {
        elapsed += Time.deltaTime;
        if (elapsed >= timeBetween)
        {
            elapsed = elapsed % 1f;
            //CreatePhrase();
            MovePhrases();
        }
    }

    void CreatePhrase()
    {
        int num = Random.Range(1, 10);
        Debug.Log(num);
        if (num <= 5)
        {
            Instantiate(badPhrase, spawnPoint.transform.position, Quaternion.identity);
        }
        if(num > 5)
        {
            Instantiate(goodPhrase, spawnPoint.transform.position, Quaternion.identity);
        }
    }

    void MovePhrases()
    {
        Debug.Log(Time.time);

    }
}
