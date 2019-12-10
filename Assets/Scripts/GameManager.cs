using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool keyIsCollected;
    public static int score;
    public Camera cameraOne;
    public Camera cameraTwo;

    public static bool pause;

    void Start() 
    {
        pause = false;
        cameraOne.enabled = true;
        cameraTwo.enabled = false;
        Cursor.visible = false;
        keyIsCollected = false;
        score = 0;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pause = !pause;
            PauseButton.TogglePause();
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            cameraOne.enabled = !cameraOne.enabled;
            cameraTwo.enabled = !cameraTwo.enabled;
        }
    }
}
