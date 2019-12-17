using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static bool keyIsCollected;
    public static int score;
    public Camera cameraOne;
    public Camera cameraTwo;
    public Text scoreText;
    public Text timerText;
    public static bool pause;

    private float timer;
    void Start() 
    {
        timer = 0f;
        timerText.text = "";
        scoreText.text = "Točke: 0";
        pause = false;
        cameraOne.enabled = true;
        cameraTwo.enabled = false;
        Cursor.visible = false;
        keyIsCollected = false;
        score = 0;
    }

    void Update()
    {
        timer += Time.deltaTime;
        float minutes = Mathf.Floor(timer / 60);
        float seconds = Mathf.RoundToInt(timer % 60);
        string m="";
        string s="";
        if (minutes < 10)
        {
            m = "0" + minutes.ToString();
        }
        if (seconds < 10)
        {
            s = "0" + Mathf.RoundToInt(seconds).ToString();
        }
        timerText.text = m+":"+s + "  ";
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

        scoreText.text="Točke: " + score.ToString();

    }
}
