using UnityEngine;
using UnityEngine.UI;
public class PauseButton : MonoBehaviour
{
    public static bool pause;

    void Start() 
    {
        pause = false;
    }

    public void TogglePause()
    {
        if (pause) //resume
        {
            Time.timeScale = 1f;
        }
        else //pause
        {
            Time.timeScale = 0f;
        }
        pause = !pause;
    }
}