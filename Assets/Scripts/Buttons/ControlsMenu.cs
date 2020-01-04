using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsMenu : MonoBehaviour
{
    public GameObject controlsMenu;

    public void OnControls()
    {
        GameObject audioObject = GameObject.Find("BtnAudioSource");
        audioObject.GetComponent<AudioSource>().Play();
        controlsMenu.SetActive(true);
    }

    public void Back()
    {
        controlsMenu.SetActive(false);
        GameObject audioObject = GameObject.Find("BtnAudioSource");
        audioObject.GetComponent<AudioSource>().Play();
    }
}
