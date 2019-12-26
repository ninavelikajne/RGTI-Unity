using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsMenu : MonoBehaviour
{
    public GameObject controlsMenu;


    public void OnControls()
    {
        controlsMenu.SetActive(true);
    }

    public void Back()
    {
        controlsMenu.SetActive(false);
    }
}
