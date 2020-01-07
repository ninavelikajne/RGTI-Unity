using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipButton : MonoBehaviour
{
    void Update() {
        if (Input.mousePosition.x > 5 * (Screen.width / 6) && Input.mousePosition.y < Screen.height / 8)
        {
            Cursor.visible = true;
        }
        else {
            Cursor.visible = false;
        }
    }

    public void Skip()
    {
        ScenesManager.StartFromStart();
    }
}
