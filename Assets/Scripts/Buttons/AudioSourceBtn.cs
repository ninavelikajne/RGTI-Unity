using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSourceBtn : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

}
