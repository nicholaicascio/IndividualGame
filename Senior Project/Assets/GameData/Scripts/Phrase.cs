using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phrase : MonoBehaviour
{
    public WaveController wave;
    public Transform target;
    public string status;
    public bool chosen = false;
    public float smoothTime = 0.5f;
    private Vector3 velocity = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        GameObject obj = GameObject.FindGameObjectWithTag("GameController");
        wave = obj.GetComponent<WaveController>();
        target = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        // Define a target position above and behind the target transform
        Vector3 targetPosition = target.TransformPoint(new Vector3(0, 0, 0));

        // Smoothly move the camera towards that target position
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }

    public void moveNext(Transform pos)
    {
        target = pos;
    }

    public void clicked()
    {
        chosen = true;
        if (status == "good")
        {
            wave.incorrectResponses++;
        }
        
    }
}
