using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public bool muted;

    void Start()
    {
        muted = false;
    }

    public void ToggleMute() 
    {
        if (muted)
        {
            AudioListener.volume = 1f;
        }
        else 
        {
            AudioListener.volume = 0f;
        }
        muted = !muted;
    }

    public void ToGame()
    {
        GameManager.pause = !GameManager.pause;
        PauseButton.TogglePause();
    }

    public void ToStart() 
    {
        ScenesManager.StartFromStart();
    }
}
