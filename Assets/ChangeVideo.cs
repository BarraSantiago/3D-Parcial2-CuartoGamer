
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using Random = UnityEngine.Random;

public class ChangeVideo : MonoBehaviour
{
    [SerializeField] private VideoPlayer player;
    [SerializeField] private List<VideoClip> clips;

    private void Awake()
    {
        player = GetComponent<VideoPlayer>();
        player.loopPointReached += ChangeCurrentVideo;
    }
     private void OnDisable()
    {
        player.loopPointReached -= ChangeCurrentVideo;
    }

    private void ChangeCurrentVideo(VideoPlayer source)
    {
        source.clip = clips[Random.Range(0, clips.Count)];
        source.Play();
    }

    private void Start()
    {
        player.clip = clips[Random.Range(0, clips.Count)];
        player.Play();
    }

    void Update()
    {
 
    }
}
