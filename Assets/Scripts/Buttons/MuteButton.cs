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
        if (AudioListener.volume == 0f) {
            gameObject.GetComponent<Image>().sprite = mutedSprite;
            muted = true;
        }
    }

    public void ToggleMute()
    {
        muted = !muted;
        if (muted)
        {
            gameObject.GetComponent<Image>().sprite = mutedSprite;
            AudioListener.volume = 0f;
        }
        else
        {
            gameObject.GetComponent<Image>().sprite = unmutedSprite;
            AudioListener.volume = 1f;
        }
        EventSystem.current.SetSelectedGameObject(null);
    }
}
