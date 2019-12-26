using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsManager : MonoBehaviour
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
