using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BerkmandlcManager : MonoBehaviour
{

    private int speed; 

    void Start()
    {
        speed = 5;
    }

   
    void Update()
    {
        move();
    }

    void move()
    {
        Vector3 Movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        gameObject.transform.position += Movement * speed * UnityEngine.Time.deltaTime;

        Camera mycam = GetComponent<Camera>();
        float mouseX = (Input.mousePosition.x / Screen.width) - 0.5f;
        float mouseY = (Input.mousePosition.y / Screen.height) - 0.5f;
        transform.localRotation = Quaternion.Euler(new Vector4(-1f * (mouseY * 180f), mouseX * 360f, transform.localRotation.z));
    }
}
