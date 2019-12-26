using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour
{
    private static GameObject menu;

    void Start()
    {
        menu = this.transform.parent.gameObject;
        menu.SetActive(false);

    }

    public static void TogglePause()
    {
        if (GameManager.pause)
        {
            Cursor.visible = true;
            AudioListener.pause = true;
            menu.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            Cursor.visible = false;
            AudioListener.pause = false;
            Time.timeScale = 1f;
            menu.SetActive(false);
        }
    }

}
