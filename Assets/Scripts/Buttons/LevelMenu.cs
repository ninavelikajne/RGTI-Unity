using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMenu : MonoBehaviour
{
    public GameObject levelMenu;

    public void onLevel() 
    {
        levelMenu.SetActive(true);
        GameObject audioObject = GameObject.Find("BtnAudioSource");
        audioObject.GetComponent<AudioSource>().Play();
    }

    public void onEasy()
    {
        GameManager.difficulty = 0;
        levelMenu.SetActive(false);
        GameObject audioObject = GameObject.Find("BtnAudioSource");
        audioObject.GetComponent<AudioSource>().Play();
    }

    public void onMedium()
    {
        GameManager.difficulty = 1;
        levelMenu.SetActive(false);
        GameObject audioObject = GameObject.Find("BtnAudioSource");
        audioObject.GetComponent<AudioSource>().Play();
    }

    public void onHard()
    {
        GameManager.difficulty = 2;
        levelMenu.SetActive(false);
        GameObject audioObject = GameObject.Find("BtnAudioSource");
        audioObject.GetComponent<AudioSource>().Play();
    }
}
