using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
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
