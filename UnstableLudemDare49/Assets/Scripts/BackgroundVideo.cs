using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class BackgroundVideo : MonoBehaviour
{
    [SerializeField] string videoName;
    [SerializeField] VideoPlayer videoPlayer;
    // Start is called before the first frame update
    void Start()
    {
        videoPlayer.url = System.IO.Path.Combine (Application.streamingAssetsPath,videoName); 
    }
}
