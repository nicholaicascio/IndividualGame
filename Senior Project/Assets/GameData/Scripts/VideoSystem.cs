using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoSystem : MonoBehaviour
{
    public VideoPlayer player;
    // Start is called before the first frame update
    void Awake()
    {
        player = GetComponent<VideoPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setNewVideo(VideoClip vid)
    {
        player.clip = vid;
        player.Play();
        //player.
    }
}
