using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class StreamVideo : MonoBehaviour
{

    public RawImage rawImage;
    public VideoPlayer videoPlayer;
    public int videoLength = 46;
    
    void Start()
    {
        StartCoroutine(PlayVideo());
        StartCoroutine(StartCountdown());
    }

    IEnumerator PlayVideo()
    {
        videoPlayer.url = System.IO.Path.Combine(Application.streamingAssetsPath, "Uvod.mp4");
        videoPlayer.Prepare();
        WaitForSeconds waitForSeconds = new WaitForSeconds(1);
        while (!videoPlayer.isPrepared)
        {
            yield return waitForSeconds;
            break;
        }
        rawImage.texture = videoPlayer.texture;
        rawImage.color = Color.white;
        videoPlayer.Play();
    }
    
    IEnumerator StartCountdown()
    {
        yield return new WaitForSeconds(videoLength);
        UnityEngine.Cursor.visible = true;
        SceneManager.LoadScene("Start");
    }
}
