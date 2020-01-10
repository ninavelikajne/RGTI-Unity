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
    public Text text;
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
        /** WEBGL EXCEPTION **/
        /*if (!videoPlayer.isPlaying) {
            text.text = "\n\nV nastavitvah brskalnika omogoči samodejno predvajanje zvoka in videa. \n Ali pa klikni gumb preskoči in preskoči uvodno zgodbo.";
        }*/
    }
    
    IEnumerator StartCountdown()
    {
        yield return new WaitForSeconds(videoLength);
        UnityEngine.Cursor.visible = true;
        SceneManager.LoadScene("Start");
    }
}
