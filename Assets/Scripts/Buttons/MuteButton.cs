using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MuteButton : MonoBehaviour
{
    public bool muted;
    public Sprite unmutedSprite;
    public Sprite mutedSprite;

    void Start()
    {
        muted = false;
    }

    public void ToggleMute()
    {
        muted = !muted;
        if (muted)
        {
            gameObject.GetComponent<Image>().sprite = mutedSprite;
            AudioListener.volume = 1f;
        }
        else
        {
            gameObject.GetComponent<Image>().sprite = unmutedSprite;
            AudioListener.volume = 0f;
        }
        EventSystem.current.SetSelectedGameObject(null);
    }
}
