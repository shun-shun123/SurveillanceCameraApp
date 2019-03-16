using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class ImageToVideoConverter : MonoBehaviour
{
    private RawImage image;
    private VideoPlayer video;

    void Start()
    {
        image = GetComponent<RawImage>();
        video = GetComponent<VideoPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (video.isPrepared)
        {
            image.texture = video.texture;
        }
    }
}
