using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManager : MonoBehaviour
{
    float y;

    void Start() {
        y = 0;
    }

    void Update()
    {
        y = y + 2;
        if (y > 360) {
            y = 0;
        }
        transform.eulerAngles = new Vector3(0, y, 0);
    }
}
