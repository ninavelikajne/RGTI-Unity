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
        if (pause)
        {
            AudioListener.pause = false;
            Time.timeScale = 1f;
        }
        else
        {
            AudioListener.pause = true;
            Time.timeScale = 0f;
        }
        pause = !pause;
    }
}